﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public string Exception()
        {
            return "Insufficent Balance";
        }
    }
}