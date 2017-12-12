using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    abstract class BaseClient : IAccount, IComparable
    {
		public double percent;
		public string name;
		public string surname;
		public string address;
		public string password;

        public double balance { get; set; }
        public Currency currency { get; set; }

        private bool bankrot = false;

		public BaseClient(double percent, string name, string surname, string address, double balance, Currency currency, string password) 
        {
            this.percent = percent;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.balance = balance;
            this.currency = currency;
			this.password = password;
        }
        //--------------------------------------------------------------
        public CashInTransaction CashIn()
		{
            try
            {
                if (!bankrot)
                {
                    Console.Write($"Input sum(in {Functions.getInstance().CurrencyName(currency)}): ");
                    balance += Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Balance: {balance}{Functions.getInstance().CurrencyName(currency)}");
                    CashInTransaction ct = new CashInTransaction(balance, DateTime.Now, this);
                    return ct;
                }
                else
                {
                    Console.WriteLine("Bank is Bankrot!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
                return null;
            }
		}
        //--------------------------------------------------------------
        public WithDrawTransaction WithDraw()
		{
            try
            {
                if (!bankrot)
                {
                    if (balance == 0)
                    {
                        Console.WriteLine("Your balance is 0!");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine($"Balance: {balance}{Functions.getInstance().CurrencyName(currency)}");
                        Console.Write("Sum for out: ");
                        int sum = Convert.ToInt32(Console.ReadLine());
                        if (balance - sum > 0)
                        {
                            Console.WriteLine($"Balance: {balance - sum}{Functions.getInstance().CurrencyName(currency)}");
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
                else
                {
                    Console.WriteLine("Bank is Bankrot!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
                return null;
            }
		}
        //--------------------------------------------------------------
        public TransferTransaction Transfer(BaseClient obj)
		{
            try
            {
                if (!bankrot)
                {
                    Console.WriteLine($"From {surname} {name} to {obj.surname} {obj.name}");
                    Console.WriteLine($"Your balance: {balance}");
                    Console.Write($"Input sum for transfer: ");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    if (balance - sum > 0)
                    {
                        Console.WriteLine($"Balance: {balance - sum}{Functions.getInstance().CurrencyName(currency)}");
                        TransferTransaction tt = new TransferTransaction(balance, DateTime.Now, obj, this);
                        return tt;
                    }
                    else
                    {
                        Console.WriteLine($"You have not enough money for this transaction!");
                        return null;
                    } 
                }
                else
                {
                    Console.WriteLine("Bank is Bankrot!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
                return null;
            }
		}
		//--------------------------------------------------------------
		public int CompareTo(object obj)
		{
			if (name == ((obj as BaseClient).name))
			{
				return 1;
			}
			return -1;
		}
		//--------------------------------------------------------------
		public void MonthPlus()
		{
			balance += (balance * percent) / 100.0;
		}
        //--------------------------------------------------------------
        public void BankrotGo()
        {
            bankrot = !bankrot;
        }
    }
}
//--------------------------------------------------------------