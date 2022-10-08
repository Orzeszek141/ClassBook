using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.BLL.Exceptions
{
    public class ClassNumberAlreadyTakenException : CustomException
    {
        public ClassNumberAlreadyTakenException(string className) : base($"Given class name: {className} is already taken")
        {
        }
    }
}
