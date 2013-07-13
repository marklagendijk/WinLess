﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using WinLess.Helpers;

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
            this.Debug = Program.Settings.DefaultDebugInfo;
            this.Enabled = true;
            this.OutputPath = GetInitialOutputPath();
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
                Uri outputPathUri = new Uri(OutputPath);
                Uri projectDirPathUri = new Uri(string.Format("{0}\\", ProjectDirectoryPath));
                return Uri.UnescapeDataString(projectDirPathUri.MakeRelativeUri(outputPathUri).ToString()).Replace("/", "\\");
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
        public bool Debug
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
                LessCompiler.Compile(this.FullPath, this.OutputPath, this.Minify, this.Debug);
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

        private string GetInitialOutputPath()
        {           
            return string.Format("{0}{1}", GetInitialOuputDir(), GetInitialOuputFileName());
        }

        private string GetInitialOuputDir()
        {
            FileInfo fileInfo = new FileInfo(this.FullPath);
            string directoryName = string.Format("{0}\\", fileInfo.DirectoryName);
                       
            if (directoryName.Contains("\\less\\")){
                if (System.IO.Directory.Exists(directoryName.Replace("\\less\\", "\\css\\"))){
                    return directoryName.Replace("\\less\\", "\\css\\");
                }
                else if (System.IO.Directory.Exists(directoryName.Replace("\\less\\", "\\..\\css\\"))){
                    return directoryName.Replace("\\less\\", "\\..\\css\\");
                }
                else if (System.IO.Directory.Exists(directoryName.Replace("\\less\\", "\\less\\css\\"))){
                    return directoryName.Replace("\\less\\", "\\less\\css\\");
                }
            }       
            
            //no matches, use same dir as the less file is in
            return directoryName;
        }

        private string GetInitialOuputFileName()
        {
            FileInfo fileInfo = new FileInfo(this.FullPath);
            string fileName = fileInfo.Name.Replace(fileInfo.Extension, ".css");
            if (fileName.Contains(".less"))
            {
                fileName = fileName.Replace(".less", "");
            }
            return fileName;
        }

        private List<string> GetLessImportPaths()
        {
            List<string> lessImportPaths = new List<string>();
            string fileText = this.GetFileText();
            if (!string.IsNullOrEmpty(fileText))
            {
                // find the @imports using regex
                MatchCollection matches = Regex.Matches(fileText, "@import\\s*(?:url\\()?\\s*[\"\\']?([^\"\\'\\);]+)[\"\\']?\\s*\\)?\\s*;");

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
