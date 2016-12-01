using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using WinLess.Models;
using WinLess.Helpers;

namespace WinLess
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            this.IsSingleInstance = true;
            this.StartupNextInstance += this_StartupNextInstance;
        }

        private void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs eventArgs)
        {
            string[] args = new string[eventArgs.CommandLine.Count];
            eventArgs.CommandLine.CopyTo(args, 0);

            CommandArguments commandLineArguments = new CommandArguments(args);
            if (!commandLineArguments.ConsoleExit)
            {
                mainForm form = (mainForm)this.MainForm;

                if (commandLineArguments.HasArguments)
                {
                    form.LoadDirectories(commandLineArguments);
                }
                else
                {
                    form.RestoreFromTray();
                }
            }
        }

        protected override void OnCreateMainForm()
        {
            this.MainForm = new mainForm();
        }

    }


}
