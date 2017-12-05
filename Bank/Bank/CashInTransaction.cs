using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
	class CashInTransaction : ITransaction
	{
		BaseClient to;

		public double Amount { get; set; }
		public DateTime DT { get; set; }

		public CashInTransaction(double Amount, DateTime DT, BaseClient to)
		{
			this.Amount = Amount;
			this.DT = DT;
			this.to = to;
		}
	}
}
//--------------------------------------------------------------