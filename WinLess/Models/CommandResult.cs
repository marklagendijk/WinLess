using System;
using System.Collections.Generic;
using System.Text;

namespace WinLess.Models
{
    public class CommandResult {
        public CommandResult()
        {
            IsSuccess = false;
            ResultText = "";
        }

        public string TimeString
        {
            get
            {
                return Time.ToLongTimeString();
            }
        }

        public DateTime Time
        {
            get;
            set;
        }

        public bool IsSuccess
        {
            get;
            set;
        }

        public string ResultText
        {
            get;
            set;
        }
    }
}
