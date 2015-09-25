using System;

namespace BandR.Core.Exceptions
{
    public abstract class BandRException : Exception
    {
        protected BandRException(string message)
            : base(message)
        {
        }

        protected BandRException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}