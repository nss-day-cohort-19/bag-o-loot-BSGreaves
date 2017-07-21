using System;
using System.Collections.Generic;

namespace BagOLoot
{
    public class MenuInterface
    {
        public MenuInterface(){}
        public int DisplayMainMenu ()
        {
            int choice;
            DisplayMainMenuOptions();
            Int32.TryParse (Console.ReadLine(), out choice);
            while (choice == 0)
            {
                Console.WriteLine (" ");
                Console.WriteLine ("Sorry, please enter a single digit to choose a menu item");
                DisplayMainMenuOptions();
                Int32.TryParse (Console.ReadLine(), out choice);
            }
            return choice;
        }
        public void DisplayMainMenuOptions()
        {
            Console.WriteLine ("****************************");
            Console.WriteLine ("MAIN MENU - Select an Option");
            Console.WriteLine ("****************************");
            Console.WriteLine ("1. Add a child");
            Console.WriteLine ("2. Review child's toy list");
            Console.WriteLine ("3. Assign toy to a child");
            Console.WriteLine ("4. Revoke toy from child");
            Console.WriteLine ("5. Child toy delivery complete");
            Console.WriteLine ("6. Yuletime Delivery Report");
            Console.WriteLine ("7. Exit");
			Console.Write ("> ");
        }
        public int DisplayChildList (string heading, List<(string, int)> childlist)
        {
            int choice;
            Console.WriteLine (" ");
            Console.WriteLine (heading);
            Console.WriteLine ("****************************");
            int menuCount = 1;
                foreach ((string, int) child in childlist)
                {
                    Console.WriteLine($"{menuCount}. {child.Item1}");
                    menuCount++;
                }
            Int32.TryParse (Console.ReadLine(), out choice);
            if (choice == 0 || choice > childlist.Count)
            {
                Console.WriteLine (" ");
                DisplayChildList("Sorry, I didn't understand. Which child's toy list would you like to review? Select a number.", childlist);
            }
            return choice;
        }
        public bool DisplayToyList (string heading, List<string>toylist)
        {
            Console.WriteLine (" ");
            Console.WriteLine (heading);
            Console.WriteLine ("****************************");
            int menuCount = 1;
                foreach (string toy in toylist)
                {
                    Console.WriteLine($"{menuCount}. {toy}");
                    menuCount++;
                }
            Console.WriteLine (" ");
            Console.WriteLine ("****************************");
            Console.WriteLine ("Press enter when done");
            Console.WriteLine ("****************************");
            while (Console.ReadKey().Key != ConsoleKey.Enter) {}
            return true;
        }
    }
}



