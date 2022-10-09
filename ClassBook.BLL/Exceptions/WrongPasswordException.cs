﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.BLL.Exceptions
{
    public class WrongPasswordException : CustomException
    {
        public WrongPasswordException() : base("Given password was wrong")
        {
        }
    }
}