using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.CustomExceptions
{
    class DatabaseConnectionFailedException : Exception
    {
        public DatabaseConnectionFailedException() : base() { }
        public DatabaseConnectionFailedException(string message) : base(message) { }
        public DatabaseConnectionFailedException(string message, Exception inner) : base(message, inner) { }
    }
}
