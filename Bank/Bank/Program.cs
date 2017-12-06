using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------------------
namespace BankName
{
    class Program
    {
        static string[] menuName = { "Add Client", "Operation", "Month +", "Bankrot", "Return Card" };

        static void menu(int sel)
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
        static void AddClient(Bank b)
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

            //Console.Clear();
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

			Console.Write("Password: ");
			string password = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Check");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Balance: {balance}");
            Console.WriteLine($"Currency: {curtemp}");
			Console.WriteLine($"Password: {password}\n");
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
                    b.Client.Add(ctemp);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    GoldenClient gctemp = new GoldenClient(name, surname, address, balance, curtemp);
                    b.Client.Add(gctemp);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    PlatinumClient pctemp = new PlatinumClient(name, surname, address, balance, curtemp);
                    b.Client.Add(pctemp);
                    break;
            }
        }
        //--------------------------------------------------------------
        static void ClientByCard(Bank b)
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < b.Client.Count; i++, count++) {}

            Console.SetCursorPosition(25, 0);
            Console.WriteLine($"Client Count: {count}");
        }
		//--------------------------------------------------------------
		static void Operation(Bank b)
		{
			Console.WriteLine("Select, how u want sort clients");
			Console.WriteLine("1 - Name");
			Console.WriteLine("2 - Surname");
			Console.WriteLine("3 - Balane");
			Console.WriteLine("4 - Curreny");
			Console.WriteLine("5 - Percent");

			var key = Console.ReadKey(true).Key;
			switch (key)
			{
				case ConsoleKey.D1:
				case ConsoleKey.NumPad1:
					b.Client.Sort();
				break;
			}

			Console.WriteLine();
			foreach (var item in b.Client)
			{
				Console.WriteLine($"{item.name} {item.surname}");				
			}
		}
		//--------------------------------------------------------------        
		static void Main(string[] args)
        {
			Bank B = new Bank();
			int select = 0;
			Console.CursorVisible = false;

			while (true)
			{
				menu(select);
                ClientByCard(B);

				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.DownArrow:
						if (select < menuName.Length - 1)
							select++;
						break;
					case ConsoleKey.UpArrow:
						if (select > 0)
							select--;
						break;
					case ConsoleKey.LeftArrow:
						select = 0;
						break;
					case ConsoleKey.RightArrow:
						select = 5;
						break;
					case ConsoleKey.Enter:
						if (select == 0)
						{
							Console.Clear();
							Console.CursorVisible = true;
							AddClient(B);
							Console.Clear();
							Console.CursorVisible = false;
						}
						else
						if (select == 1)
						{
							Console.Clear();
							Console.CursorVisible = true;
							if (B.Client.Count == 0)
							{
								Console.Write("Bank have no client, create?(y/n): ");
								char ans = Console.ReadKey(true).KeyChar;
								if (ans == 'y')
								{ 
									Console.Clear();
									AddClient(B);
								}
							}
							else
								Operation(B);

							Console.Clear();
							Console.CursorVisible = false;
						}
						else
						if (select == 5)
						{ 
							Console.Clear();
							Environment.Exit(0);
						}
						break;     
                }
			}					
        }
    }
}
//--------------------------------------------------------------