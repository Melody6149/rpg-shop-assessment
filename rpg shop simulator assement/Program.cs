using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{
    class Program
    {

        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            inventory.Add(new Item());
            inventory.Add(new Item());
            inventory.Add(new Item());
            inventory.remove(1);
            bool shop = true; //used to know when to close program
            string choice = "0"; // used to store the players choice
            Inventory Playerinventory = new Inventory(); // this is just a test because i have not made the inventory for shop 
            Weapons test = new Weapons("test", 1, 1); // test weapon
            Playerinventory.Add(test);
            while (shop)
            {
                
                Console.WriteLine("1: look at shop inventory");
                Console.WriteLine("2: look at your inventory");
                Console.WriteLine("3: Save");
                Console.WriteLine("4: leave");

               
                choice = Console.ReadLine();

                if (choice == "2")
                {
                    
                }
                

                else if (choice == "4")
                {
                    shop = false;
                }
            }

            
            
            Console.ReadKey();
        }
    }
}
