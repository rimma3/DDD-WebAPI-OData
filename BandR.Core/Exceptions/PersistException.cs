using System;

namespace BandR.Core.Exceptions
{
    public class PersistException : BandRException
    {
        public PersistException(string message)
            : base(message)
        {
        }

        public PersistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}