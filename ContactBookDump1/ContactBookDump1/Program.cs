using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContactBookDump1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ContactBook = new List<Tuple<string, string, int, string>>();


            while (true)
            {
                Menu();
                Console.WriteLine("Choose an option from the menu:");
                var choice = int.Parse(Console.ReadLine());
                var number = 0;
                var numCheck = 0;
                string entry = "";
                var name = "";
                var lastName = "";
                var address = "";
                var option = 0;




                //Adding a new contact
                if (choice == 1)
                {

                    Console.WriteLine("Enter a name:");
                    name = Console.ReadLine();


                    Console.WriteLine("Enter a last name:");
                    lastName = Console.ReadLine();

                    Console.WriteLine("Enter a telephone number:");
                    entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                    number = int.Parse(entry);

                    Console.WriteLine("Enter the number again to confirm:");
                    entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                    numCheck = int.Parse(entry);

                    while (true)
                    {
                        if (number == numCheck)
                            break;
                        else
                        {
                            Console.WriteLine("Numbers don't match! Please try again!");
                            Console.WriteLine("Enter a telephone number:");
                            entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                            number = int.Parse(entry);
                            Console.WriteLine("Enter the number again to confirm:");
                            entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                            numCheck = int.Parse(entry);
                        }

                    }

                    Console.WriteLine("Enter an address:");
                    address = Console.ReadLine();
                    var t = new Tuple<string, string, int, string>(name, lastName, number, address);
                    ContactBook.Add(t);
                    Console.WriteLine("Contact saved successfully!");
                }
                //Changing an existing contact
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the number of the contact you want to change:");
                    entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                    number = int.Parse(entry);

                    Console.WriteLine("Do you want to change the number(Press 1) or the address(Press 2)?");
                    option = int.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        for (int i = 0; i < ContactBook.Count; i++)
                        {
                            if (ContactBook[i].Item3 == number)
                            {
                                Console.WriteLine("Enter a new number:");
                                entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                                number = int.Parse(entry);
                                Console.WriteLine("Enter the number again to confirm:");
                                entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                                numCheck = int.Parse(entry);
                                while (true)
                                {
                                    if (number == numCheck)
                                    {
                                        ContactBook[i] = new Tuple<string, string, int, string>(ContactBook[i].Item1, ContactBook[i].Item2, number, ContactBook[i].Item4);
                                        Console.WriteLine("Contact was modified successfully!");
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Numbers don't match! Please try again!");
                                        Console.WriteLine("Enter a new number:");
                                        entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                                        number = int.Parse(entry);
                                        Console.WriteLine("Enter the number again to confirm:");
                                        entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                                        numCheck = int.Parse(entry);
                                    }

                                }

                                break;

                            }
                            else
                            {
                                Console.WriteLine("There is no such contact.");
                            }
                        }
                    }
                    else if (option == 2)
                    {
                        for (int i = 0; i < ContactBook.Count; i++)
                        {
                            if (ContactBook[i].Item3 == number)
                            {
                                Console.WriteLine("Enter a new address:");
                                address = Console.ReadLine();
                                ContactBook[i] = new Tuple<string, string, int, string>(ContactBook[i].Item1, ContactBook[i].Item2, ContactBook[i].Item3, address);
                                Console.WriteLine("Contact was modified successfully!");
                                break;

                            }
                            else
                            {
                                Console.WriteLine("There is no such contact.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    option = 0;
                }
                //Removing a contact
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the number of a contact you want to delete:");
                    entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                    number = int.Parse(entry);

                    for (int i = 0; i < ContactBook.Count; i++)
                    {
                        if (ContactBook[i].Item3 == number)
                        {
                            Console.WriteLine("Are you sure? Enter the number again to confirm:");
                            entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                            numCheck = int.Parse(entry);
                            while (true)
                            {
                                if (number == numCheck)
                                {
                                    ContactBook.Remove(ContactBook[i]);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Numbers don't match.");
                                    Console.WriteLine("Enter the number again to confirm:");
                                    entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                                    numCheck = int.Parse(entry);
                                }
                            }
                            Console.WriteLine("Contact was deleted successfully!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There is no such contact.");
                        }
                    }

                }
                //Search by number
                else if (choice == 4)
                {
                    Console.WriteLine("Enter a number:");
                    entry = Regex.Replace(Console.ReadLine(), @"\D", "");
                    number = int.Parse(entry);

                    foreach (var item in ContactBook)
                    {
                        if (item.Item3 == number)
                        {
                            Console.WriteLine(item);
                            break;
                        }
                        else
                        {
                            Console.Write("There is no such contact.");
                        }
                    }
                }
                //Search by name/surname
                else if (choice == 5)
                {
                    Console.WriteLine("Enter a name or a last name:");
                    entry = Console.ReadLine();
                    ContactBook.Sort();
                    foreach (var item in ContactBook)
                    {
                        if (item.Item1.Contains(entry) || item.Item2.Contains(entry))
                        {
                            Console.WriteLine(item);
                        }
                        else
                        {
                            Console.WriteLine("There is no such contact.");
                        }
                    }

                }
                //Exit
                else if (choice == 6)
                    break;

            }
            foreach (var item in ContactBook)
            {
                Console.WriteLine(item);
            }

        }
        static void Menu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("|CONTACT BOOK MENU|");
            Console.WriteLine("(1) - New entry");
            Console.WriteLine("(2) - Change entry");
            Console.WriteLine("(3) - Delete entry");
            Console.WriteLine("(4) - Search by number");
            Console.WriteLine("(5) - Search by name");
            Console.WriteLine("(6) - Exit");
        }
    }
}
