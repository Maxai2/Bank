using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
	class PlatinumClient : BaseClient
	{
		public PlatinumClient(double percent, string name, string surname, string address, double balance, Currency currency) : base(percent, name, surname, address, balance, currency)
		{
		}
	}
}
//--------------------------------------------------------------