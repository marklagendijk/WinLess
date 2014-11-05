using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using WinLess.Models;
using WinLess.Helpers;

namespace WinLess
{
    public class Settings
    {
        public Settings()
        {
            DirectoryList = new DirectoryList();
            DefaultMinify = true;
            CompileOnSave = true;
            ShowSuccessMessages = false;
            StartWithWindows = true;
            StartMinified = false;
            UseGloballyInstalledLess = false;
        }

        public DirectoryList DirectoryList { get; set; }
        public bool DefaultMinify { get; set; }
        public bool CompileOnSave { get; set; }
        public bool ShowSuccessMessages { get; set; }
        public bool StartMinified { get; set; }
        public bool UseGloballyInstalledLess { get; set; }

        private bool startWithWindows;
        public bool StartWithWindows
        {
            get{
                return startWithWindows;   
            }
            set
            {
                startWithWindows = value;
                ApplyStartWithWindows();
            }
        }

        private void ApplyStartWithWindows()
        {
            string keyName = "WinLess";
            string assemblyLocation = Application.ExecutablePath;
            
            if (StartWithWindows && !AutoStartUtil.IsAutoStartEnabled(keyName, assemblyLocation))
            {
                AutoStartUtil.SetAutoStart(keyName, assemblyLocation);
            }
            else if (!StartWithWindows && AutoStartUtil.IsAutoStartEnabled(keyName, assemblyLocation))
            {
                AutoStartUtil.UnSetAutoStart(keyName);
            }
        }

        public void SaveSettings(){
            string dataDir = string.Format("{0}\\data", Application.UserAppDataPath);
            string settingsFilePath = string.Format("{0}\\settings.xml", dataDir);
            
            try {     
                if (!System.IO.Directory.Exists(dataDir)) {
                    System.IO.Directory.CreateDirectory(dataDir);
                }
            }
            catch (Exception e) {
                ExceptionHandler.ShowErrorMessage(string.Format("Error while trying to create data directory: {0}\n\nException message:\n{1}", dataDir, e.Message));
            }

            try {
                TextWriter writer = new StreamWriter(settingsFilePath);
                XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception e) {
                ExceptionHandler.ShowErrorMessage(string.Format("Error while trying to save settings: {0}\n\nException message:\n{1}", settingsFilePath, e.Message));
            }
        }

        public static Settings LoadSettings()
        {
            string path = string.Format("{0}\\data\\settings.xml", Application.UserAppDataPath);
            if (System.IO.File.Exists(path))
            {
                try
                {
                    TextReader reader = new StreamReader(path);
                    XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Settings));
                    Settings settings = (Settings)serializer.Deserialize(reader);
                    reader.Close();
                    return settings;
                }
                catch
                {
                    return new Settings();
                }
            }
            return new Settings();
        }
    }
}
