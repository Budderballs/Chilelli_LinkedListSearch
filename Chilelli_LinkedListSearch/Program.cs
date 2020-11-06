using System;

namespace Chilelli_LinkedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading Data \n");
            LinkedList L = Load.LoadFile();
            bool running = true;
            while (running)
            {
                Menu.menuStrings();
                string userChoice = Console.ReadLine();
                Menu.theeList(userChoice, L);
            }
        }
    }
}