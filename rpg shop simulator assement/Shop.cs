using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{


    class Shop
    {
        int shopchoice = 0; // used for shop to know which item in the array to pick
        private int shopgold = 50; // stores shop gold
        private int Playergold = 50; // stores player gold
        bool shop = true; //used to know when to close program
        string choice = "0"; // used to store the players choice
        
        Inventory PlayerInventory = new Inventory(); // this makes a inventory for the player 
        Inventory ShopInventory = new Inventory(); // This makes a inventory for the shopkeeper

        bool validchoice = false;

                                 //Name  cost damage or defense.  Description
        Weapons test = new Weapons("test", 1, 1, "you should not be seeing this after i am done making this program"); // test weapon will name it later
        Weapons sword = new Weapons("Sword", 20, 30, "Just a normal Sword.");
        Armor Armor = new Armor("Armor", 20, 30, "starter armor");





        public void start()
        {
            PlayerInventory.Add(test);
            PlayerInventory.Add(Armor);
            ShopInventory.Add(sword);
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
                    PlayerInventory.Openinventory();
                    Console.WriteLine("\n");

                }



                else if (choice == "5")
                {
                    shop = false;
                }
                else if (choice == "6")
                {
                    Cheats();
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
                Buy();
            }
            if (choice == "2")
            {
                PlayerInventory.Openinventory();
                Sell();
            }
            Console.WriteLine("\n");
        }

        void Sell() // add a way to stop crashing 
        {
            validchoice = false;
            while (!validchoice)
            {
                
                shopchoice = Convert.ToInt32(Console.ReadLine());
                shopchoice = shopchoice - 1;

                if (shopchoice <= PlayerInventory.GetLenth() && shopchoice >= 0)
                {

                    Playergold = Playergold + PlayerInventory.Getcost((shopchoice));
                    shopgold = shopgold - PlayerInventory.Getcost((shopchoice));
                    Item temp = PlayerInventory.GetItem(shopchoice);
                    ShopInventory.Add(temp);
                    PlayerInventory.remove((shopchoice));
                    validchoice = true;
                }
                else
                {
                    Console.WriteLine("Please pick a valid choice");
                }


            }
            
        }

        void Buy()
        {
            validchoice = false;
            while (!validchoice)
            {
                Console.WriteLine("Type in the number for the item you want");

                shopchoice = Convert.ToInt32(Console.ReadLine());
                shopchoice = shopchoice - 1;
                if (shopchoice <= ShopInventory.GetLenth() || shopchoice < 0)
                {
                    Playergold = Playergold - ShopInventory.Getcost((shopchoice));
                    shopgold = shopgold + ShopInventory.Getcost((shopchoice));
                    Item temp = ShopInventory.GetItem(shopchoice);
                    PlayerInventory.Add(temp);
                    ShopInventory.remove((shopchoice));
                    validchoice = true;
                }
                else
                {
                    Console.WriteLine("Please pick a valid choice");
                }
            }
        }
        void Cheats()
        {
            Console.WriteLine("Cheat Menu");
            Console.WriteLine("1: Create your own weapon");
            Console.WriteLine("2: Create Your own armor");
            Console.WriteLine("3: Give or remove gold from player");
            Console.WriteLine("4: Give or remove gold from shopkeeper");
            choice = Console.ReadLine();
            if (choice == "1")
            {

                Console.WriteLine("do you want to add it to player or store inventory");
                string newname = "";
                int cost = 0;
                int damage = 0;
                string description;
                Console.WriteLine("Pick a name for the weapon");
                newname = Console.ReadLine();
                Console.WriteLine("Type in the cost");
                cost = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type in a damage");
                damage = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type in a description");
                description = Console.ReadLine();

                
                    Weapons addedWeapon = new Weapons(newname, cost, damage, description); //
                PlayerInventory.Add(addedWeapon);
            }

            if (choice == "2")
            {

            }
        }
    }
}
