using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
	class TransferTransaction : ITransaction
	{
		BaseClient to;
		BaseClient from; 

		public double Amount { get; set; }
		public DateTime DT { get; set; }

		public TransferTransaction(double Amount, DateTime DT, BaseClient to, BaseClient from)
		{
			this.Amount = Amount;
			this.DT = DT;
			this.to = to;
			this.from = from;
		}
	}
}
//--------------------------------------------------------------