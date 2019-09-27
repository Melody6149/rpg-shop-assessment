using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{


    class Shop
    {
        int shopchoice = 0;
        private int shopgold = 50;
        private int Playergold = 50;
        bool shop = true; //used to know when to close program
        string choice = "0"; // used to store the players choice
        
        Inventory Playerinventory = new Inventory(); // this makes a inventory for the player 
        Inventory ShopInventory = new Inventory(); // This makes a inventory for the shopkeeper


        Weapons test = new Weapons("test", 1, 1, "you should not be seeing this after i am done making this program"); // test weapon will name it later







        public void start()
        {
            Playerinventory.Add(test);
            while (shop)
            {

                Console.WriteLine("1: Buy/Sell");
                Console.WriteLine("2: look at your inventory");
                Console.WriteLine("3: Save");
                Console.WriteLine("4: Load");
                Console.WriteLine("5: leave");


                choice = Console.ReadLine();

                if (choice == "1")
                {
                    OpenShop();
                }

                if (choice == "2")
                {
                    Playerinventory.Openinventory();
                    Console.WriteLine("\n");

                }



                else if (choice == "5")
                {
                    shop = false;
                }
            }
        }

        public void OpenShop() //used for buying and selling weapons. later there will be a hidden option to add weapons and other items
        {
            
            Console.WriteLine("\n");

            Console.WriteLine("Would you like to buy or sell.");
            Console.WriteLine("The shop has " + shopgold + " Gold.");
            Console.WriteLine("You have has " + Playergold + " Gold.");
            Console.WriteLine("1: Buy");
            Console.WriteLine("2: Sell");
            string choice = "";
            choice = Console.ReadLine();
            if (choice == "1")
            {
                ShopInventory.Openinventory();
            }
            if (choice == "2")
            {
                Playerinventory.Openinventory();
                Sell();
            }
            Console.WriteLine("\n");
        }

        void Sell() // add a way to stop crashing 
        {
            bool validchoice = false;
            while (!validchoice)
            {
                
                shopchoice = Convert.ToInt32(Console.ReadLine()); 
               
                Playerinventory.remove((shopchoice - 1));
                validchoice = true;
            }
            
        }
    }
}
