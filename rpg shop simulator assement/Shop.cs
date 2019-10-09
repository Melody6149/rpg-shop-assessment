using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{


    class Shop
    {
        int shopchoice = 0; // used for shop to know which item in the array to pick
        private int _shopgold = 50; // stores shop gold
        private int _playergold = 50; // stores player gold
        bool shop = true; //used to know when to close program
        string choice = "0"; // used to store the players choice

        Inventory PlayerInventory = new Inventory(); // this makes a inventory for the player 
        Inventory ShopInventory = new Inventory(); // This makes a inventory for the shopkeeper

        bool validchoice = false;

        //Name  cost damage or defense.  Description
        Weapons test = new Weapons("sword", 1, 1, "begginer sword"); // test weapon will name it later
        Weapons Sword = new Weapons("Sword", 20, 30, "Just a normal Sword");
        Armor starterarmor = new Armor("Starter armor", 30, 30, "starting armor");


        public void start()
        {
            PlayerInventory.Add(test);
            PlayerInventory.Add(starterarmor);
            ShopInventory.Add(Sword);
            PlayerInventory.Loading("PlayerInventory.txt", this);
            ShopInventory.Loading("ShopInventory.txt", this);
            //Gets the starting inventory and gold from both txt files

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
                    Console.WriteLine("\nYou have " + _playergold + " Gold.");
                    PlayerInventory.Openinventory();
                    Console.WriteLine("\n");

                }

                if (choice == "3")
                {
                    PlayerInventory.Saving("PlayerInventory.txt",this);
                    ShopInventory.Saving("ShopInventory.txt",this);
                }
                if (choice == "4")
                {
                    PlayerInventory.Loading("PlayerInventory.txt", this);
                    ShopInventory.Loading("ShopInventory.txt", this);
                }

                else if (choice == "5")
                {
                    shop = false; //sets shop to false so it can quit the shop
                }
                else if (choice == "6")
                {
                    Cheats();
                }
            }
        }

        public void OpenShop() //used for buying and selling weapons. later there will be a hidden option to add weapons and other items
        {
            validchoice = false;
            Console.WriteLine("\n");
            while (!validchoice)
            {
                Console.WriteLine("Would you like to buy or sell.");
                Console.WriteLine("The shop has " + _shopgold + " Gold.");
                Console.WriteLine("You have has " + _playergold + " Gold.");
                Console.WriteLine("1: Buy");
                Console.WriteLine("2: Sell");
                Console.WriteLine("3: Exit");
                string choice = "";
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    if (ShopInventory.GetLenth() > 0)
                    {
                        ShopInventory.Openinventory();
                        Buy();
                    }
                    else
                    {
                        Console.WriteLine("There is nothing to buy\n");
                    }
                }
                if (choice == "2")
                {
                    if (PlayerInventory.GetLenth() > 0)
                    {
                        PlayerInventory.Openinventory();
                        Sell();
                    }
                    else
                    {
                        Console.WriteLine("You have nothing to sale\n");
                    }
                }
                if (choice == "3")
                {
                    Console.WriteLine();
                    validchoice = true;
                }
            }
            Console.WriteLine("\n");
        }

        void Sell() // add a way to stop crashing 
        {
            Console.WriteLine("Type in the number for the item you want");
            Console.WriteLine("Type in 0 to exit");
            Console.WriteLine("");
            validchoice = false;
            while (!validchoice)
            {

                shopchoice = Convert.ToInt32(Console.ReadLine());




                shopchoice = shopchoice - 1;

                if (shopchoice == -1)
                {
                    validchoice = true;
                }

                else if (shopchoice < PlayerInventory.GetLenth() && shopchoice >= 0)
                {

                    if (_shopgold >= PlayerInventory.Getcost(shopchoice))
                    {
                        _playergold = _playergold + PlayerInventory.Getcost(shopchoice);
                        _shopgold = _shopgold - PlayerInventory.Getcost((shopchoice));
                        Item temp = PlayerInventory.GetItem(shopchoice);
                        ShopInventory.Add(temp);
                        PlayerInventory.remove((shopchoice));
                        validchoice = true;

                    }
                    else
                    {
                        Console.WriteLine("The shop cant buy your item\n");
                        validchoice = true;
                    }
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
                Console.WriteLine("Type in 0 to exit");


                shopchoice = Convert.ToInt32(Console.ReadLine());
                shopchoice = shopchoice - 1;
                
                
                if(shopchoice == -1)
                {
                    validchoice = true;
                }
                else if (shopchoice < ShopInventory.GetLenth() && shopchoice >= 0)
                {

                    if (_playergold >= ShopInventory.Getcost(shopchoice))
                    {
                        _playergold = _playergold - ShopInventory.Getcost((shopchoice));
                        _shopgold = _shopgold + ShopInventory.Getcost((shopchoice));
                        Item temp = ShopInventory.GetItem(shopchoice);
                        PlayerInventory.Add(temp);
                        ShopInventory.remove((shopchoice));
                        validchoice = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have the money to buy this");
                    }
                }
                else
                {
                    Console.WriteLine("Please pick a valid choice");
                }
            }
        }
        void Cheats()
        {
            string cheatchoice = "";
            validchoice = false;
            while (!validchoice)
            {
                Console.WriteLine("Cheat Menu");
                Console.WriteLine("1: Create your own weapon");
                Console.WriteLine("2: Create Your own armor");
                Console.WriteLine("3: Give or remove gold from player");
                Console.WriteLine("4: Give or remove gold from shopkeeper");
                Console.WriteLine("5: Exit cheat menu");
                
                choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    validchoice = true;
                }
                else if (choice == "5")
                {
                    validchoice = true;
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("please pick a valid choice");
                }
            }
            if (choice == "1")
            {
                validchoice = false;
                while (!validchoice)
                {
                    Console.WriteLine("do you want to add it to player or store inventory");
                    Console.WriteLine("1: Player");
                    Console.WriteLine("2: Shop");
                    Console.WriteLine("3: Exit the cheat menu");
                    cheatchoice = Console.ReadLine();
                    if(cheatchoice == "1" || cheatchoice == "2")
                    {
                        validchoice = true;
                    }
                    if(cheatchoice == "3")
                    {
                        validchoice = true;
                        
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("Please make sure to use numbers for cost and damage or it will crash");

                string newname = "";
                int cost = -1;
                int damage = 0;
                string description;
                Console.WriteLine("Pick a name for the weapon");
                newname = Console.ReadLine();
                while (cost < 0)
                {
                    Console.WriteLine("Type in the cost");
                    cost = Convert.ToInt32(Console.ReadLine());
                    if (cost < 0)
                    {
                        Console.WriteLine("Type in a positive number");
                    }
                }
                Console.WriteLine("Type in a damage");
                damage = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type in a description");
                description = Console.ReadLine();
                Weapons addedWeapon = new Weapons(newname, cost, damage, description);
                if (cheatchoice == "1")
                    {
                
                    PlayerInventory.Add(addedWeapon);
                }
                choice = Console.ReadLine();
                if (cheatchoice == "2")
                {
                    
                    ShopInventory.Add(addedWeapon);
                }

            }

            if (choice == "2")
            {
                Console.WriteLine("do you want to add it to player or store inventory");
                Console.WriteLine("1: PLayer");
                Console.WriteLine("2: Shop");
                cheatchoice = Console.ReadLine();
                Console.WriteLine("Please make sure to use numbers for cost and defense or it will crash");

                string newname = "";
                int cost = -1;
                int damage = 0;
                string description;
                Console.WriteLine("Pick a name for the Armor");
                newname = Console.ReadLine();
                while (cost < 0)
                {
                    Console.WriteLine("Type in the cost");
                    cost = Convert.ToInt32(Console.ReadLine());
                    if (cost < 0)
                    {
                        Console.WriteLine("Type in a positive number");
                    }
                }
                Console.WriteLine("Type in a defense");
                damage = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type in a description");
                description = Console.ReadLine();
                Armor addedWeapon = new Armor(newname, cost, damage, description);
                if (cheatchoice == "1")
                {
                   PlayerInventory.Add(addedWeapon);
                }
                choice = Console.ReadLine();
                if (cheatchoice == "2")
                {
                   ShopInventory.Add(addedWeapon);
                }
            }
            if (choice == "3")
            {
                int cheatgold;
                Console.WriteLine("type in a number for amount of gold\nType in a negative number to remove gold");
                cheatgold = Convert.ToInt32(Console.ReadLine());
                _playergold = _playergold + cheatgold;
                if(PlayerGold < 0)
                {
                    PlayerGold = 0;
                }

            }
            if (choice == "4")
            {
                int cheatgold;
                Console.WriteLine("type in a number for amount of gold\nType in a negative number to remove gold");
                cheatgold = Convert.ToInt32(Console.ReadLine());
                _shopgold = _shopgold + cheatgold;
                if(ShopGold < 0)
                {
                    ShopGold = 0;
                }
            }
        }

      

        public int PlayerGold
        {
            get
            {
                return _playergold;
            }
            set
            {
                _playergold = value;
            }
        }
        public int ShopGold
        {
            get
            {
                return _shopgold;
            }
            set
            {
                _shopgold = value;
            }
        }
    }
}
