using System;

namespace SMSAExpressServiceRequest
{
    [Serializable]
    public class SMSAExpressException : Exception
    {

        public SMSAExpressException(string error) : base(error)
        {

        }
    }
}
