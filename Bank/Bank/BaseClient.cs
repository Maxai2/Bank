using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    class BaseClient : IAccount
    {
        double percent;
        string name;
        string surname;
        string address;

        public double balance { get; set; }
        public Curency curency { get; set; }

        public BaseClient(double percent, string name, string surname, string address, double balance, Curency curency) 
        {
            this.percent = percent;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.balance = balance;
            this.curency = curency;
        }

        public ITransaction CashIn()
        {
            throw new NotImplementedException();
        }

        public ITransaction Transfer()
        {
            throw new NotImplementedException();
        }

        public ITransaction Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
//--------------------------------------------------------------