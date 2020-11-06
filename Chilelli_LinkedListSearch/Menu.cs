using System;
using System.Diagnostics;
using System.Threading;

namespace Chilelli_LinkedListSearch
{
    class Menu
    {
        public static void menuStrings()
        {
            Console.WriteLine("Kindly pick an item from the list sir / madam'\n");
            Console.WriteLine("1: Search by name");
            Console.WriteLine("2: Show count of all list items");
            Console.WriteLine("3: Show count of all female names");
            Console.WriteLine("4: Show count of all male names");
            Console.WriteLine("5: Add a name to the list");
            Console.WriteLine("6: See data for most popular female name");
            Console.WriteLine("7: See data for most popular male name");
            Console.WriteLine("8: Exit");
        }
        public static void theeList(string userChoice, LinkedList L)
        {
            switch (userChoice)
            {
                case "1":
                    //Search by name
                    Console.Write("Please type the name you wish to search for:");
                    string userInput = Console.ReadLine();
                    Stopwatch searchTime = new Stopwatch();
                    searchTime.Start();
                    Node temp = L.SearchBoth(userInput.ToLower());
                    searchTime.Stop();
                    TimeSpan elapsed = searchTime.Elapsed;
                    if (temp != null)
                    {
                        Console.Clear();
                        Console.WriteLine(userInput + " is indeed here \n");
                        Console.Write("It took " + string.Format("{0:00}:{1:00}:{2:00}:{3:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds / 10));
                        Console.WriteLine(" to find " + userInput + "\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(userInput + " is not here at all! \n");
                    }
                    break;
                case "2":
                    //Show count of all list items
                    Console.Clear();
                    Console.WriteLine("There are " + L.theHead.Data.countNodes + " total names in the list\n");
                    break;
                case "3":
                    //Show count of all female names
                    Console.Clear();
                    Console.WriteLine("There are " + L.theHead.Data.countF + " female names in the list\n");
                    break;
                case "4":
                    //Show count of all male names
                    Console.Clear();
                    Console.WriteLine("There are " + L.theHead.Data.countM + " male names in the list\n");
                    break;
                case "5":
                    //Add a name to the list
                    Console.Clear();
                    Console.Write("Please type name to add: ");
                    string name = Console.ReadLine();
                    Console.Write("Please type gender to add: ");
                    char gender = Console.ReadKey().KeyChar;
                    gender = char.ToUpper(gender);
                    Console.WriteLine();
                    Console.Write("Please type rank of name: ");
                    int rank = Convert.ToInt32(Console.ReadLine());
                    if (L.SearchBoth(name.ToLower()) == null) { L.Add(new MetaData(gender, name, rank)); break; }
                    else if (L.SearchBoth(name.ToLower()).Data.Name.ToLower() == name.ToLower() && L.SearchBoth(name.ToLower()).Data.Gender != gender)
                    { L.Add(new MetaData(gender, name, rank)); break; }

                    if (L.SearchBoth(name.ToLower()).Data.Name.ToLower() == name.ToLower() && L.SearchBoth(name.ToLower()).Data.Gender == gender)
                    {
                        Console.WriteLine(name + " already exists! Would you like to add " + name + "_1 (Y/N)");
                        char yN = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (yN == 'y' || yN == 'Y')
                        {
                            name = name + "_1";
                            L.Add(new MetaData(gender, name, rank));
                            break;
                        }
                        else { Console.WriteLine("Name not added"); }
                    }
                    else if (L.SearchBoth(name.ToLower()).Next != null)
                    {
                        if (L.SearchBoth(name.ToLower()).Next.Data.Name.ToLower() == name.ToLower() && L.SearchBoth(name.ToLower()).Next.Data.Gender == gender)
                        {
                            Console.WriteLine(name + " already exists! Would you like to add " + name + "_1");
                            char yN = Console.ReadKey().KeyChar;
                            if (yN == 'y')
                            {
                                name = name + "_1";
                                L.Add(new MetaData(gender, name, rank));
                                break;
                            }
                        }
                    }
                    else if (L.SearchBoth(name.ToLower()).Previous != null)
                    {
                        if (L.SearchBoth(name.ToLower()).Previous.Data.Name.ToLower() == name.ToLower() && L.SearchBoth(name.ToLower()).Previous.Data.Gender == gender)
                        {
                            Console.WriteLine(name + " already exists! Would you like to add " + name + "_1");
                            char yN = Console.ReadKey().KeyChar;
                            if (yN == 'y')
                            {
                                name = name + "_1";
                                L.Add(new MetaData(gender, name, rank));
                                break;
                            }
                        }
                    }
                    break;
                case "6":
                    //See data for most popular female name
                    Console.Clear();
                    Console.WriteLine("Popular Name / Rank: " + L.topName()[1].Data.Name + " " + L.topName()[1].Data.Rank + "\n");
                    break;
                case "7":
                    //See data for most popular male name
                    Console.Clear();
                    Console.WriteLine("Popular Name / Rank: " + L.topName()[0].Data.Name + " " + L.topName()[0].Data.Rank + "\n");
                    break;
                case "8":
                    //Exit program
                    Console.Clear();
                    Console.WriteLine("Goodbye and have a nice day");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                case "debug":
                    Console.Clear();
                    Console.WriteLine(L.Print());
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That selection was invalid");
                    break;
            }
        }
    }
}