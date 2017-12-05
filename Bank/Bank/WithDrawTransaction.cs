using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
	class WithDrawTransaction : ITransaction
	{
		BaseClient from;

		public double Amount { get; set; }
		public DateTime DT { get; set; }

		public WithDrawTransaction(double Amount, DateTime DT, BaseClient from)
		{
			this.Amount = Amount;
			this.DT = DT;
			this.from = from;
		}
	}
}
//--------------------------------------------------------------