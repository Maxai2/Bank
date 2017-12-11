using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    public enum Currency { USD, RUB, AZN, EUR }
 
    interface IAccount
    { 
        double balance { get; set; }
        Currency currency { get; set; }

		CashInTransaction CashIn();
		WithDrawTransaction WithDraw();
		TransferTransaction Transfer(BaseClient obj);
	}
}
//--------------------------------------------------------------