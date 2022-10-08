using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.BLL.Exceptions
{
    public class EmailAlreadyTakenException : CustomException
    {
        public EmailAlreadyTakenException(string email) : base($"Given email: {email} is already taken")
        {
        }
    }
}
