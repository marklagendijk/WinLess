using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WinLess.Models
{
    public class Directory
    {
        #region Constructor

        private Directory()
        {
        }
        
        public Directory(string path)
        {
            FullPath = path;
            LoadFiles();
        }

        #endregion

        #region Properties

        private string fullPath;
        public string FullPath
        {
            get 
            {
                return fullPath;
            }
            set {
                DirectoryInfo directoryInfo = new DirectoryInfo(value);
                if(directoryInfo.Exists){
                    fullPath = directoryInfo.FullName;
                }
            }
        }

        public List<Models.File> Files
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        public void LoadFiles()
        {
            Files = new List<Models.File>();
            this.Refresh();
        }

        public void Refresh()
        {
            List<File> removedFiles = new List<File>();
            foreach (File file in Files)
            {
                if (!System.IO.File.Exists(file.FullPath))
                {
                    removedFiles.Add(file);
                }
            }
            foreach (File file in removedFiles)
            {
                Files.Remove(file);
            }

            AddFiles(new DirectoryInfo(this.FullPath));
        }

        public bool ContainsFile(string fullPath)
        {
            bool result = false;
            foreach (File file in Files)
            {
                if (string.Compare(file.FullPath, fullPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public override string ToString()
        {
            return FullPath;
        }

        #endregion

        #region Private Methods

        private void AddFiles(DirectoryInfo directoryInfo)
        {
            try
            {
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    if ((string.Compare(file.Extension, ".less", StringComparison.InvariantCultureIgnoreCase) == 0 ||
                        (string.Compare(file.Extension, ".css", StringComparison.InvariantCultureIgnoreCase) == 0) && file.Name.Contains(".less")
                       ) && !this.ContainsFile(file.FullName))
                    {
                        Files.Add(new Models.File(this, file.FullName));
                    }
                }

                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo subDirectoryInfo in subDirectories)
                {
                    AddFiles(subDirectoryInfo);
                }
            }
            catch{}
        }

        #endregion
    }
}
