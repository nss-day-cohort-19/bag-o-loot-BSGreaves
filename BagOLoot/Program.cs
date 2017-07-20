using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            var MainMenu = new MenuInterface();
            //db.CheckDB();
            db.DropAndSeedDB();
			int choice = MainMenu.DisplayMainMenu();
			// Read in the user's choice
            //Alt:
            //ConsoleKeyInfo enteredKey = Console.ReadKey();
            //choice = int.Parse(enteredKey.KeyChar.ToString());

            switch (choice)
            {
                case 1:
                    Console.WriteLine ("What's the Child's name?");
                    Console.Write ("> ");
                    string childName = Console.ReadLine();
                    ChildRegister registry = new ChildRegister();
                    bool childId = registry.AddChild(childName);
                    Console.WriteLine(childId);
                    break;
                case 2:

                    break;
            }
        }
    }
}
