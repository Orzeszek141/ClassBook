using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.BLL.Exceptions
{
    public class NoContentFoundException : CustomException
    {
        public NoContentFoundException() : base("There is no content found in table")
        {
        }
    }
}
