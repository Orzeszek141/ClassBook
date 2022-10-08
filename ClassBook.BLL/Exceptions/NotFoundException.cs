using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.BLL.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException() : base("Resource was not found for given id")
    {
    }

    public NotFoundException(string email) : base($"User for given {email} does not exist")
    {
    }
}