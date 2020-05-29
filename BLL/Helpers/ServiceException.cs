using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class ServiceException : Exception
    {
        public string ExceptionMessage { get; private set; }
        public bool Succedeed { get; private set; }
        public ServiceException(string ExceptionMessage, bool Succedeed)
        {
            this.ExceptionMessage = ExceptionMessage;
            this.Succedeed = Succedeed;
        }
    }
}
