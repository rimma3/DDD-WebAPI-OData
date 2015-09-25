using System;

namespace BandR.Core.Exceptions
{
    public class DomainException : BandRException
    {
        public DomainException(string message)
            : base(message, null)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}