using System;
using System.Runtime.Serialization;

namespace CrystalSoftware.ERP.Shared.Exceptions
{
    [Serializable]
    public class ErrorConfigurationException : Exception
    {
        protected ErrorConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public ErrorConfigurationException()
        {
        }

        public ErrorConfigurationException(string message) : base(message)
        {
        }
    }
}
