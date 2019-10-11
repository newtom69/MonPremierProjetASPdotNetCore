using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MonPremierProjetASPdotNetCore.DAL
{
    [Serializable]
    internal class ConcurrencyException : Exception
    {
        public ConcurrencyException()
        {
        }

        public ConcurrencyException(string message) : base(message)
        {
        }

        public ConcurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}