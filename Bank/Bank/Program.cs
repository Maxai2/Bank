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
		static string[] menuName = { "Add Client", "Operation", "Compare", "Month +", "Bankrot" };

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

        static void Main(string[] args)
        {
			Bank B = new Bank();
			int select = 0;
			Console.CursorVisible = false;

			while (true)
			{
				menu(select);

				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.DownArrow:

					default:
				}
			}					
        }
    }
}
//--------------------------------------------------------------