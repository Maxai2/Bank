﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    interface ITransaction
    {
        double Amount { get; set; } 
        DateTime DT { get; set; }
    }
}
//--------------------------------------------------------------