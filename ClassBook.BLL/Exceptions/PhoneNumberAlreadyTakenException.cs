using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.BLL.Exceptions
{
    public class PhoneNumberAlreadyTakenException : CustomException
    {
        public PhoneNumberAlreadyTakenException(string phoneNumber) : base($"Given phone number: {phoneNumber} is already taken")
        {
        }
    }
}
