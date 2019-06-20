using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.CustomExceptions
{
    class DoctorIsBusyAtThisTimeException : Exception
    {
        public DoctorIsBusyAtThisTimeException() : base() { }
        public DoctorIsBusyAtThisTimeException(string message) : base(message) { }
        public DoctorIsBusyAtThisTimeException(string message, Exception inner) : base(message, inner) { }

    }
}
