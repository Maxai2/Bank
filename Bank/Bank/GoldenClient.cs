using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
	class GoldenClient : BaseClient
	{
		public GoldenClient(string name, string surname, string address, double balance, Currency currency, string password, double percent = 0.7) : base(percent, name, surname, address, balance, currency, password)
		{
		}
	}
}
//--------------------------------------------------------------