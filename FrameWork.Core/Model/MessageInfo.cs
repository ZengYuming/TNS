using System;
namespace Framework.Core.Model
{
    [Serializable]
    public class MessageInfo
    {
        public bool success
        {
            get;
            set;
        }
        public string msg
        {
            get;
            set;
        }
        public MessageInfo(bool success, string msg)
        {
            this.msg = msg;
            this.success = success;
        }
    }
}
