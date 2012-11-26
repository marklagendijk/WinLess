using System;
using System.Collections.Generic;
using System.Text;

namespace WinLess.Models
{
    public class CompileCommandResult : CommandResult
    {
        public CompileCommandResult(CommandResult result)
        {
            this.Time = result.Time;
            this.IsSuccess = result.IsSuccess;
            this.ResultText = result.ResultText;            
        }

        #region Properties

        public string FullPath
        {
            get;
            set;
        }

        #endregion
    }
}
