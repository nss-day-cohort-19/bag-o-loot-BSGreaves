using System;

namespace BagOLoot
{
    public class MenuInterface
    {
        public MenuInterface(){}
        public int DisplayMainMenu ()
        {
            int choice;
            Console.Clear();
            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
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
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a child");
            Console.WriteLine ("2. Assign toy to a child");
            Console.WriteLine ("3. Revoke toy from child");
            Console.WriteLine ("4. Review child's toy list");
            Console.WriteLine ("5. Child toy delivery complete");
            Console.WriteLine ("6. Yuletime Delivery Report");
            Console.WriteLine ("7. Exit");
			Console.Write ("> ");
        }
    }
}



