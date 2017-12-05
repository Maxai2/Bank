using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    public enum Curency { USD, RUB, AZN, EUR }

    interface IAccount
    {
        double balance { get; set; }
        Curency currency { get; set; }
    }
}
//--------------------------------------------------------------