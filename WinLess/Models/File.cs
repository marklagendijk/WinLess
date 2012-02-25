using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using WinLess.Helpers;
using WinLess.Less;

namespace WinLess.Models
{
    public class File
    {
        #region Constructor

        private File()
        {
            this.ParentFiles = new List<File>();
        }
        
        public File(Models.Directory directory, string fullPath)
        {
            this.FullPath = fullPath;
            this.ProjectDirectoryPath = directory.FullPath;
            this.Minify = Program.Settings.DefaultMinify;
            this.Enabled = true;
            InitOutputPath();
            this.ParentFiles = new List<File>();
            CheckForImports();
        }

        #endregion

        #region Properties

        public string FullPath
        {
            get;
            set;
        }

        public string DirectoryPath
        {
            get
            {
                return Path.GetDirectoryName(this.FullPath);
            }
        }

        public string ProjectDirectoryPath
        {
            get;
            set;
        }

        public string RelativePath
        {
            get
            {
                return FullPath.Replace(ProjectDirectoryPath, "").Substring(1); ;
            }
        }


        public string OutputPath
        {
            get;
            set;
        }

        public string RelativeOutputPath
        {
            get
            {
                return OutputPath.Replace(ProjectDirectoryPath, "").Substring(1);
            }
        }

        public bool Minify
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        [XmlIgnore]
        public List<File> ParentFiles
        {
            get; set;
        }

        #endregion

        #region Public Methods

        public void CheckForImports()
        {
            List<string> importPaths = this.GetLessImportPaths();
            foreach (string importPath in importPaths)
            {
                File importFile = Program.Settings.DirectoryList.GetFile(importPath);
                if(importFile != null && importFile.ParentFiles.Find(f => string.Compare(f.FullPath, this.FullPath, StringComparison.InvariantCultureIgnoreCase) == 0) == null)
                {
                    importFile.ParentFiles.Add(this);
                }  
            }
        }

        public void Compile(bool compileParentFiles = true)
        {
            if (this.Enabled)
            {
                Compiler.CompileLessFile(this.FullPath, this.OutputPath, this.Minify);
            }
            if (compileParentFiles)
            {
                foreach (File parentFile in this.ParentFiles)
                {
                    parentFile.Compile();
                }
            }

            //Recheck the imports of the current file
            CheckForImports();
        }

        #endregion

        #region Private Methods

        private void InitOutputPath()
        {
            FileInfo fileInfo = new FileInfo(this.FullPath);
            string directoryName = fileInfo.DirectoryName;
            //if contains *\less\* -> replace *\less\* with *\css\*
            if (directoryName.Contains("\\less\\") && System.IO.Directory.Exists(directoryName.Replace("\\less\\", "\\css\\")))
            {
                this.OutputPath = directoryName.Replace("\\less\\", "\\css\\");
            }
            //else if endWith less -> replace \less at end with \css
            else if (directoryName.EndsWith("\\less") && System.IO.Directory.Exists(string.Format("{0}css", directoryName.Substring(0, directoryName.Length - 4))))
            {
                this.OutputPath = string.Format("{0}css", directoryName.Substring(0, directoryName.Length - 4));
            }
            //else same dir less file
            else
            {
                this.OutputPath = directoryName;
            }

            //add filename
            string fileName = fileInfo.Name.Replace(fileInfo.Extension, ".css");
            if (fileName.Contains(".less"))
            {
                fileName = fileName.Replace(".less", "");
            }
            this.OutputPath = string.Format("{0}\\{1}", OutputPath, fileName);
        }

        private List<string> GetLessImportPaths()
        {
            List<string> lessImportPaths = new List<string>();
            string fileText = this.GetFileText();
            if (!string.IsNullOrEmpty(fileText))
            {
                // find the @imports using regex
                MatchCollection matches = Regex.Matches(fileText, "@import [\"\\']?([^\"\\';]+)[\"\\']?;");

                foreach (Match match in matches)
                {
                    if (match.Groups.Count > 1)
                    {
                        string cssImportValue = match.Groups[1].Value;

                        // if the import is a .less import
                        if (!cssImportValue.EndsWith(".css", StringComparison.InvariantCultureIgnoreCase) ||
                            cssImportValue.EndsWith(".less.css", StringComparison.InvariantCultureIgnoreCase))
                        {
                            string relativeImportPath = cssImportValue.Replace("/", "\\");

                            // if the import doesn't include the .less extension
                            if (!cssImportValue.EndsWith(".less.css", StringComparison.InvariantCultureIgnoreCase) &&
                                !cssImportValue.EndsWith(".less", StringComparison.InvariantCultureIgnoreCase))
                            {
                                relativeImportPath = string.Format("{0}.less", relativeImportPath);
                            }

                            try
                            {
                                string fullImportPath = Path.GetFullPath(string.Format("{0}\\{1}", this.DirectoryPath, relativeImportPath));
                                lessImportPaths.Add(fullImportPath);
                            }
                            catch { 
                                //invalid path, ignore this here
                            }
                        }
                    }
                }
            }

            return lessImportPaths;
        }

        private string GetFileText()
        {
            string fileText = null;
            try
            {
                StreamReader streamReader = new StreamReader(this.FullPath);
                fileText = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
            
            return fileText;
        }

        #endregion
    }
}
