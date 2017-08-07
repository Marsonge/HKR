using System;
using System.Collections.Generic;
using System.Text;

namespace HKRCore.Exception
{
    public class DomainException : System.Exception
    {
        public DomainException() { }
        public DomainException( string message ) : base( message ) { }
        public DomainException( string message, System.Exception inner ) : base( message, inner ) { }
    }

}
