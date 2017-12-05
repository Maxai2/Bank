using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    abstract class BaseClient : IAccount//, IComparable
    {
        double percent;
        string name;
        string surname;
        string address;

        public double balance { get; set; }
        public Currency currency { get; set; }

		public BaseClient(double percent, string name, string surname, string address, double balance, Currency currency) 
        {
            this.percent = percent;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.balance = balance;
            this.currency = currency;
        }

		public CashInTransaction CashIn()
		{
			Console.Write($"Input sum(in {CurrencyName(currency)}): ");
			balance += Convert.ToDouble(Console.ReadLine());
			Console.WriteLine($"Balance: {balance}{CurrencyName(currency)}");
			CashInTransaction ct = new CashInTransaction(balance, DateTime.Now, this);
			return ct;
		}

		public WithDrawTransaction WithDraw()
		{
			if (balance == 0)
			{ 
				Console.WriteLine("Your balance is 0!");
				return null;
			}
			else
			{ 
				Console.WriteLine($"Balance: {balance}{CurrencyName(currency)}");
				Console.Write("Sum for out: ");
				int sum = Convert.ToInt32(Console.ReadLine());
				if (balance - sum > 0)
				{
					Console.WriteLine($"Balance: {balance - sum}{CurrencyName(currency)}");
					WithDrawTransaction wt = new WithDrawTransaction(balance, DateTime.Now, this);
					return wt;
				}
				else
				{ 
					Console.WriteLine($"You have not enough money for this transaction!");
					return null;
				}
			}
		}

		public TransferTransaction Transfer(BaseClient obj)
		{
			Console.WriteLine($"From {surname} {name} to {obj.surname} {obj.name}");
			Console.WriteLine($"Your balance: {balance}");
			Console.Write($"Input sum for transfer: ");
			int sum = Convert.ToInt32(Console.ReadLine());
			if (balance - sum > 0)
			{
				Console.WriteLine($"Balance: {balance - sum}{CurrencyName(currency)}");
				TransferTransaction tt = new TransferTransaction(balance, DateTime.Now, obj, this);
				return tt;
			}
			else
			{ 
				Console.WriteLine($"You have not enough money for this transaction!");
				return null;
			}
		}

		private string CurrencyName(Currency cur)
		{
			switch (cur)
			{
				case Currency.USD:
					return "USD";
				case Currency.RUB:
					return "RUB";
				case Currency.AZN:
					return "AZN";
				case Currency.EUR:
					return "EUR";
			}

			return "Error Currency!";
		}

		//public int CompareTo(object obj)
		//{
		//	if (this is Client)
		//	{

		//	}
		//}
	}
}
//--------------------------------------------------------------