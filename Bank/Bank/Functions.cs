using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    class Functions
    {
        private static Functions instance;

        public static Functions getInstance()
        {
            if (instance == null)
                instance = new Functions();

            return instance;
        }
        //--------------------------------------------------------------
        public string CurrencyName(Currency cur)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
                return null;
            }
        }
        //--------------------------------------------------------------
        public string[] menuName = { "Add Client", "Operation", "Return Card" };

        public void menu(int sel)
        {
            for (int i = 0; i < menuName.Length; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("              ");
                Console.SetCursorPosition(0, i);
                if (i == sel)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine($"{menuName[i]}");
            }
        }
        //--------------------------------------------------------------
        public void AddClient(Bank b)
        {
            BEGIN:
            Console.WriteLine("Choose Client Type");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("1 - Simple Client (0.5% monthly)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2 - Gold Client (0.7% monthly)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("3 - Platinum Client (1% monthly)");
            var cl = Console.ReadKey(true).Key;

            Console.ForegroundColor = ConsoleColor.Green;
            switch (cl)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("Simple Client");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("Gold Client");
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.WriteLine("Platinum Client");
                    break;
                default:
                    Console.Clear();
                    goto BEGIN;
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            CUR:
            Console.WriteLine("Select currency");
            Console.WriteLine("1 - AZN");
            Console.WriteLine("2 - RUB");
            Console.WriteLine("3 - USD");
            Console.WriteLine("4 - EUR");
            var cur = Console.ReadKey(true).Key;

            Currency curtemp;
            Console.ForegroundColor = ConsoleColor.Green;
            switch (cur)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("AZN");
                    curtemp = Currency.AZN;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("RUB");
                    curtemp = Currency.RUB;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.WriteLine("USD");
                    curtemp = Currency.USD;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.WriteLine("EUR");
                    curtemp = Currency.EUR;
                    break;
                default:
                    Console.Clear();
                    goto CUR;
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
            BAL:
            Console.Write("Want to make an initial balance?(y/n): ");
            char ans = Console.ReadKey().KeyChar;
            double balance;

            if (ans == 'y')
            {
                Console.WriteLine();
                Console.Write("Input sum: ");
                balance = Convert.ToDouble(Console.ReadLine());
            }
            else
            if (ans == 'n')
                balance = 0;
            else
                goto BAL;

            Console.WriteLine();
            Console.Write("\nPIN(only 4 digital namber): ");
            string password = null;

            for (int i = 0; i < 4; i++)
            {
                int ctemp = Console.ReadKey().KeyChar;
				//if (48 <= ctemp && ctemp <= 57)
                password += Convert.ToChar(ctemp);
            }

            Console.WriteLine();
            Console.WriteLine("\nCheck");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Balance: {balance}");
            Console.WriteLine($"Currency: {curtemp}");
            Console.WriteLine($"PIN: {password}\n");
            Console.Write("Allright or again?(y/n): ");
            ans = Console.ReadKey(true).KeyChar;

            if (ans == 'n')
            {
                Console.Clear();
                goto BEGIN;
            }

            Console.WriteLine();
            switch (cl)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Client ctemp = new Client(name, surname, address, balance, curtemp, password);
                    b.Clients.Add(ctemp);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    GoldenClient gctemp = new GoldenClient(name, surname, address, balance, curtemp, password);
                    b.Clients.Add(gctemp);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    PlatinumClient pctemp = new PlatinumClient(name, surname, address, balance, curtemp, password);
                    b.Clients.Add(pctemp);
                    break;
            }
        }
        //--------------------------------------------------------------
        public void ClientByCard(Bank b)
        {
            int SimpleClient = 0;
            int GoldenClient = 0;
            int PlatinumClient = 0;

            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < b.Clients.Count; i++)
            {
                if (b.Clients[i] is Client)
                    SimpleClient++;
                else
                if (b.Clients[i] is GoldenClient)
                    GoldenClient++;
                else
                if (b.Clients[i] is PlatinumClient)
                    PlatinumClient++;
            }

            Console.SetCursorPosition(30, 0);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Simple Client:\t{SimpleClient}");
            Console.SetCursorPosition(30, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Gold Client:\t{GoldenClient}");
            Console.SetCursorPosition(30, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Platinum Client:\t{PlatinumClient}");
            Console.SetCursorPosition(30, 3);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-------------------");
            Console.SetCursorPosition(30, 4);
            Console.WriteLine($"Client Count:\t{SimpleClient + GoldenClient + PlatinumClient}");
        }
        //--------------------------------------------------------------
        static string[] OpearationName = { "Cash In", "Cash Out", "Transfer", "Back To Menu" };
        static string[] BossMenuName = { "Month +", "Bankrot", "Clear Transaction", "Back To Menu" };

        static void OperationMenu(int select)
        {
            short pos = 5;
            for (int i = 0; i < OpearationName.Length; i++)
            {
                Console.SetCursorPosition(0, i + pos);
                Console.WriteLine("             ");
                Console.SetCursorPosition(0, i + pos);

                if (select == i)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(OpearationName[i]);
            }
        }

        static void BossOperationMenu(int select)
        {
            short pos = 5;
            for (int i = 0; i < BossMenuName.Length; i++)
            {
                Console.SetCursorPosition(0, i + pos);
                Console.WriteLine("             ");
                Console.SetCursorPosition(0, i + pos);

                if (select == i)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(BossMenuName[i]); 
            }
        }
        //--------------------------------------------------------------
        static void Clear()
        {
            Console.SetCursorPosition(0, 9);

            for (int i = 0; i < 7; i++)
                Console.WriteLine("                                                       ");
        }
		//--------------------------------------------------------------
		static void MonthPlus(Bank b)
		{
            try
            {
                foreach (var item in b.Clients)
                {
                    b.PercentUp += item.MonthPlus;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //--------------------------------------------------------------
        static void BankrotGo(Bank b)
        {
            try
            {
                foreach (var item in b.Clients)
                {
                    b.Bankrot += item.BankrotGo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //--------------------------------------------------------------
        static void ClearTransactionFile(Bank b)
        {
            File.Delete(b.path);
        }
        //--------------------------------------------------------------
        static int FindClientForTransfer(Bank b, int MySelf)
        {
            for (int i = 0; i < b.Clients.Count; i++)
            {
                if (b.Clients[i] is Client)
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                else
                if (b.Clients[i] is GoldenClient)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                if (b.Clients[i] is PlatinumClient)
                    Console.ForegroundColor = ConsoleColor.White;

                if (i != MySelf)
                    Console.WriteLine($"{i + 1}. {b.Clients[i].surname} {b.Clients[i].name}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-------------------------------");
            Console.Write("Select Client: ");
            int temp = Convert.ToInt32(Console.ReadLine()) - 1;
            return temp;
        }
        //--------------------------------------------------------------
        public void Operation(Bank b)
        {
            Console.Write("Input PIN: ");
            string password = null;
            bool found = false;
            int ClientId = 0;
            bool boss = false;

            for (int i = 0; i < 4; i++)
            {
                int ctemp = Console.ReadKey().KeyChar;
                password += Convert.ToChar(ctemp);
            }

            if (password == "0000")
            {
                boss = true;
                goto BOSS;
            }

            for (int i = 0; i < b.Clients.Count; i++)
            {
                if (b.Clients[i].password == password)
                {
                    found = true;
                    ClientId = i;
                    break;
                }
            }

			BOSS:
            if (!found && !boss)
            {
				Console.WriteLine();
                Console.WriteLine("Error PIN!");
                goto EXIT;
            }
            else
            {
				Console.WriteLine();
				Console.CursorVisible = false;
				if (boss)
					Console.WriteLine("\nWelcome BOSS");
				else
				{ 
					Console.WriteLine($"\nWelcome {b.Clients[ClientId].surname} {b.Clients[ClientId].name}");
					Console.WriteLine($"Balance: {b.Clients[ClientId].balance} {b.Clients[ClientId].currency}");
				}

                int select = 0;

                while (true)
                {
					if (boss)
						BossOperationMenu(select);
					else
						OperationMenu(select);

                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.DownArrow:
                            if (select < (boss ? BossMenuName.Length - 1 : OpearationName.Length - 1))
                                select++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (select > 0)
                                select--;
                            break;
                        case ConsoleKey.Enter:
                            if (select == 0)
                            {
                                Console.SetCursorPosition(0, 9);
                                Console.CursorVisible = true;
                                Console.WriteLine("--------------------------");
                                if (boss)
                                {
                                    if (b.Clients.Count != 0)
                                    {
                                        MonthPlus(b);
                                        b.PercentInvoke();
                                        Console.WriteLine("Month +: OK!");
                                    }
                                    else
                                        Console.WriteLine("No Clients BOSS!");
                                }
                                else
                                    b.Transaction.Add(b.Clients[ClientId].CashIn());
                                Console.Read();
                                Clear();
                                Console.CursorVisible = false;
                            }
                            else
                            if (select == 1)
                            {
                                Console.SetCursorPosition(0, 9);
                                Console.CursorVisible = true;
                                Console.WriteLine("--------------------------");
                                if (boss)
                                {
                                    BankrotGo(b);
                                    b.BankrotInvoke();
                                    Console.WriteLine("Ok!");
                                }
                                else
                                    b.Transaction.Add(b.Clients[ClientId].WithDraw());
                                Console.Read();
                                Clear();
                                Console.CursorVisible = false;
                            }
                            else
                            if (select == 2)
                            {
                                Console.SetCursorPosition(0, 9);
                                Console.CursorVisible = true;
                                Console.WriteLine("--------------------------");
                                if (boss)
                                {
                                    ClearTransactionFile(b);
                                    Console.WriteLine("Ok!");
                                }
                                else
                                if (b.Clients.Count == 1)
                                    Console.WriteLine("You are the only person in the group!");
                                else
                                    b.Transaction.Add(b.Clients[ClientId].Transfer(b.Clients[FindClientForTransfer(b, ClientId)]));
                                Console.Read();
                                Clear();
                                Console.CursorVisible = false;
                            }
                            else
                            if (select == 3)
                                goto EXIT;
                            break;
                    }
                }
            }

			EXIT:
			boss = false;
            Console.WriteLine();
        }
    }
}
//--------------------------------------------------------------