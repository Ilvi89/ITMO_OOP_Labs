using System;

namespace BackupsExtra.Exceptions
{
    public class BackupsExtraException : Exception
    {
        public BackupsExtraException(string msg)
            : base($"BackupsExtraException: {msg}")
        {
        }
    }
}