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
            bool shop = true;
            string choice = "0";
            while(shop)
            {
                Console.WriteLine("1: look at shop inventory");
                Console.WriteLine("2: look at your inventory");
                Console.WriteLine("3: Save");
                Console.WriteLine("4: leave");

               
                choice = Console.ReadLine();

                if (choice == "2")
                {
                    Player.playerinventory();
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
