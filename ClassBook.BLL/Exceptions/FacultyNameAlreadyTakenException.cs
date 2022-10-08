using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.BLL.Exceptions
{
    public class FacultyNameAlreadyTakenException : CustomException
    {
        public FacultyNameAlreadyTakenException(string facultyName) : base($"Given faculty name: {facultyName} is already taken")
        {
        }
    }
}
