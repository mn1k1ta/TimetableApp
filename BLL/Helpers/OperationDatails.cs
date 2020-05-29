using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class OperationDatails
    {
        public string Message { get; private set; }
        public bool Succedeed { get; private set; }
        public OperationDatails(string Message, bool Succedeed)
        {
            this.Message = Message;
            this.Succedeed = Succedeed;
        }
    }
}
