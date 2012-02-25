using System;
using System.Collections.Generic;
using System.Text;

namespace WinLess.Models
{
    public class CompileResult
    {
        #region Properties

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

        public string FullPath
        {
            get;
            set;
        }

        public string ResultText
        {
            get;
            set;
        }

        #endregion
    }
}
