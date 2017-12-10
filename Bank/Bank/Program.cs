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
		static void Main(string[] args)
        {
			Bank B = new Bank();
			int select = 0;
			Console.CursorVisible = false;

			while (true)
			{
				Functions.getInstance().menu(select);
                Functions.getInstance().ClientByCard(B);

				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.DownArrow:
						if (select < Functions.getInstance().menuName.Length - 1)
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
                            Functions.getInstance().AddClient(B);
							Console.Clear();
							Console.CursorVisible = false;
						}
						else
						if (select == 1)
						{
							Console.Clear();
							Console.CursorVisible = true;
							if (B.Clients.Count == 0)
							{
								Console.Write("Bank have no client, create?(y/n): ");
								char ans = Console.ReadKey(true).KeyChar;
								if (ans == 'y')
								{ 
									Console.Clear();
                                    Functions.getInstance().AddClient(B);
								}
							}
							else
                                Functions.getInstance().Operation(B);

							Console.Clear();
							Console.CursorVisible = false;
						}
						else
						if (select == 2)
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