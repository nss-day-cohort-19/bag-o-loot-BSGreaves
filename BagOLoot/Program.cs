using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseInterface db = new DatabaseInterface();
            MenuInterface mainMenu = new MenuInterface();
            ChildRegister children = new ChildRegister();
            ToyRegister toys = new ToyRegister();
            List<(string, int)> childList = new List<(string, int)>();
            List<string> toyList = new List<string>();
            int childChoice;
            string toyChoice;
            //db.CheckDB();
            db.DropAndSeedDB();
            int choice;
            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            do
            {
                choice = mainMenu.DisplayMainMenu();
                switch (choice)
                {
                    case 1:
                        bool successChildRegister = false;
                        do 
                        {
                            Console.WriteLine ("What's the Child's name?");
                            Console.Write ("> ");
                            string childName = Console.ReadLine();
                            successChildRegister = children.AddChild(childName);
                            if (successChildRegister == true)
                            {
                                Console.WriteLine (" ");
                                Console.WriteLine ($"{childName} was successfully registered!");
                                Console.WriteLine (" ");
                            } 
                            else
                            {
                                Console.WriteLine ($"There was a problem. Please try again.");
                                Console.WriteLine (" ");
                            }
                        } while (successChildRegister == false);
                        break;
                    case 2:
                        childList = children.GetChildList();
                        childChoice = mainMenu.DisplayChildList("Which child's toy list would you like to review?", childList);
                        toyList = toys.GetToyList(childChoice);
                        mainMenu.DisplayToyList("Their current toys are:", toyList);
                        break;
                    case 3:
                        bool successToyAdded = false;
                        childList = children.GetChildList();
                        childChoice = mainMenu.DisplayChildList("Which child would you like to give a toy to?", childList);
                        Console.WriteLine ("****************************");
                        Console.WriteLine ("What toy would you like to give them?");
                        Console.WriteLine ("****************************");
                        toyChoice = Console.ReadLine();
                        successToyAdded = toys.AddToy(childChoice, toyChoice);
                        toyList = toys.GetToyList(childChoice);
                        if (successToyAdded == true)
                        {
                            mainMenu.DisplayToyList("Toy added successfuly! Their current toys are:", toyList);
                        } else
                        {
                            mainMenu.DisplayToyList("Sorry, I wasn't able to add that toy. Their current toys are:", toyList);
                        }
                        break;
                    case 4:
                        // bool successToyRevoked = false;
                        // childList = children.GetChildList();
                        // childChoice = mainMenu.DisplayChildList("Which child would you like to take from?", childList);
                        // Console.WriteLine ("****************************");
                        // Console.WriteLine ("Which toy would you like to take from them?");
                        // Console.WriteLine ("****************************");
                        // toyChoice = Console.ReadLine();
                        // successToyRevoked = toys.AddToy(childChoice, toyChoice);
                        // toyList = toys.GetToyList(childChoice);
                        // if (successToyRevoked == true)
                        // {
                        //     mainMenu.DisplayToyList("Toy added successfuly! Their current toys are:", toyList);
                        // } else
                        // {
                        //     mainMenu.DisplayToyList("Sorry, I wasn't able to add that toy. Their current toys are:", toyList);
                        // }

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
            }

            } while (choice != 7);
        }
    }
}
