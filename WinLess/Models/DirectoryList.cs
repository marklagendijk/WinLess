using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WinLess.Helpers;

namespace WinLess.Models
{
    public class DirectoryList
    {
        private List<FileSystemWatcher> fileSystemWatchers;
        private string previousFileChangedPath = null;
        private DateTime previousFileChangedTime = DateTime.Now;
        
        public List<Directory> Directories { get; set; }

        public DirectoryList()
        {
            Directories = new List<Directory>();
        }

        public void Initialize( CompilerDispatcher dispacher)
        {
            RemoveDeletedDirectories();
            CheckAllFilesForImports();
            StartWatchers(dispacher);
        }

        public Directory AddDirectory(string path, CompilerDispatcher dispacher)
        {
            Directory directory = GetDirectory(path);
            if (directory == null)
            {
                directory = new Models.Directory(path);
                Directories.Add(directory);
                AddWatcher(directory, dispacher);
                Program.Settings.SaveSettings();
                CheckAllFilesForImports();
            }

            return directory;
        }

        public void RemoveDirectory(Models.Directory directory)
        {
            Directories.Remove(directory);
            RemoveWatcher(directory.FullPath);
            Program.Settings.SaveSettings();
            CheckAllFilesForImports();
        }

        public void RemoveDeletedDirectories()
        {
            List<Models.Directory> removedDirectories = new List<Models.Directory>();
            foreach (Models.Directory directory in Directories)
            {
                if (!System.IO.Directory.Exists(directory.FullPath))
                {
                    removedDirectories.Add(directory);
                }
            }
            foreach (Models.Directory directory in removedDirectories)
            {
                RemoveDirectory(directory);
            }
        }

        public void ClearDirectories()
        {
            List<Models.Directory> allDirectories = new List<Directory>(Directories);
            foreach (Directory directory in allDirectories)
            {
                Directories.Remove(directory);
                RemoveWatcher(directory.FullPath);
            }
            Program.Settings.SaveSettings();
            CheckAllFilesForImports();
        }


        public Models.Directory GetDirectory(string path)
        {
            foreach (Models.Directory directory in Directories)
            {
                if (path == directory.FullPath || (path.StartsWith(directory.FullPath)))
                {
                    return directory;
                }
            }

            return null;
        }

        public Models.File GetFile(string path)
        {
            foreach (Models.Directory directory in Directories)
            {
                Models.File file = directory.Files.Find(f => string.Compare(f.FullPath, path, StringComparison.InvariantCultureIgnoreCase) == 0);
                if (file != null)
                {
                    return file;
                }
            }
            return null;
        }

        private void CheckAllFilesForImports()
        {
            foreach (Models.Directory directory in this.Directories)
            {
                foreach (Models.File file in directory.Files)
                {
                    file.ParentFiles = new List<Models.File>();
                }
            }
            foreach (Models.Directory directory in this.Directories)
            {
                foreach (Models.File file in directory.Files)
                {
                    file.CheckForImports();
                }
            }
        }
        
        public void StartWatchers( CompilerDispatcher dispacher)
        {
            foreach (Models.Directory directory in Directories)
            {
                this.AddWatcher(directory, dispacher);
            }
        }

        private void AddWatcher(Models.Directory directory, CompilerDispatcher dispacher)
        {
            try
            {
                if (System.IO.Directory.Exists(directory.FullPath))
                {
                    if (fileSystemWatchers == null)
                    {
                        fileSystemWatchers = new List<FileSystemWatcher>();
                    }
                    
                    Action<object, System.IO.FileSystemEventArgs> compileOnChage = delegate(object sender, System.IO.FileSystemEventArgs e)
                    {
                        if (Program.Settings.CompileOnSave && IsNewFileChange(e) && IsLessFile(e.FullPath))
                        {
                            Models.File file = Program.Settings.DirectoryList.GetFile(e.FullPath);
                            if (file != null)
                            {
                                if (Program.Settings.CompileOnDirectoryChange)
                                {
                                    dispacher.CompileSelectedFiles();
                                }
                                else
                                {
                                    file.Compile();
                                    previousFileChangedPath = file.FullPath;
                                    previousFileChangedTime = DateTime.Now;
                                }
                            }
                        }
                    };

                    FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
                    fileSystemWatcher.Path = directory.FullPath;
                    fileSystemWatcher.IncludeSubdirectories = true;
                    fileSystemWatcher.Filter = "*.*";
                    fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.CreationTime | NotifyFilters.Attributes;
                    fileSystemWatcher.Changed += new FileSystemEventHandler(compileOnChage);
                    fileSystemWatcher.EnableRaisingEvents = true;

                    fileSystemWatchers.Add(fileSystemWatcher);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
        }

        private void RemoveWatcher(string path)
        {
            try
            {
                if (fileSystemWatchers != null)
                {
                    foreach (FileSystemWatcher fileSystemWatcher in fileSystemWatchers)
                    {
                        if (fileSystemWatcher.Path == path)
                        {
                            fileSystemWatcher.EnableRaisingEvents = false;
                            fileSystemWatchers.Remove(fileSystemWatcher);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
        }

       

        private bool IsNewFileChange(System.IO.FileSystemEventArgs e)
        {
            return (
                 previousFileChangedPath != e.FullPath ||
                 DateTime.Now - previousFileChangedTime > new TimeSpan(0, 0, 1)
            );
        }

        private bool IsLessFile(string path)
        {
            return (
                path.EndsWith(".less") ||
                path.EndsWith(".less.css")
            );
        }
    }
}
