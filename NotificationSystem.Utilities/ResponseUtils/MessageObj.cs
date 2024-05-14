using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Utilities.ResponseUtils
{
    public class AppResponseInfo<T>
    {
        public AppMessage Message { get; set; }
        public bool IsSuccess { get; set; }
        public string RespCode { get; set; }
        public T ResultData { get; set; }
    }

    public class AppMessage
    {
        public string FriendlyMessage { get; set; }
        public string TechMessage { get; set; }
    }
    public class AppStatusInfo
    {
        public AppMessage Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
