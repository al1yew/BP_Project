using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg)
        {

        }
    }
}
