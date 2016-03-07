using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK9BankingProgram1
{
    class Menu
    {
        private string name;
        private List<string> menuItems;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<string> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; }
        }

        public Menu()
        { }
        public Menu(string name)
        {
            Name = name;
        }
        public Menu(string name,List<string> menuItems)
        {
            Name = name;
            MenuItems = menuItems;
        }

        public int RunMenu()
        {
            Console.Clear();
            Console.WriteLine(Name);
            int counter = 1;
            foreach(string item in menuItems)
            {
                Console.WriteLine($"{counter}.  {item}");
                counter++;
            }
            Console.WriteLine("Enter the number of a Menu Item:");
            string input=Console.ReadLine();
            int choice;
            bool valid = int.TryParse(input, out choice) && choice > 0 && choice <= menuItems.Count;
            if (!valid)
                choice = 0;
            return choice;
        }

    }
}
