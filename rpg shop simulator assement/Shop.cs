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
        private int _Playergold = 50; // stores player gold
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
            Console.WriteLine("The shop has " + _shopgold + " Gold.");
            Console.WriteLine("You have has " + _Playergold + " Gold.");
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

                else if (shopchoice <= PlayerInventory.GetLenth() && shopchoice >= 0)
                {

                    if (_shopgold > PlayerInventory.Getcost(shopchoice))
                    {
                        _Playergold = _Playergold + PlayerInventory.Getcost(shopchoice);
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
                else if (shopchoice <= ShopInventory.GetLenth() && shopchoice >= 0)
                {

                    if (_Playergold >= ShopInventory.Getcost(shopchoice))
                    {
                        _Playergold = _Playergold - ShopInventory.Getcost((shopchoice));
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
            Console.WriteLine("Cheat Menu");
            Console.WriteLine("1: Create your own weapon");
            Console.WriteLine("2: Create Your own armor");
            Console.WriteLine("3: Give or remove gold from player");
            Console.WriteLine("4: Give or remove gold from shopkeeper");
            string cheatchoice = "";
            choice = Console.ReadLine();
            if (choice == "1")
            {
               
                Console.WriteLine("do you want to add it to player or store inventory");
                Console.WriteLine("1: PLayer");
                Console.WriteLine("2: Shop");
                cheatchoice = Console.ReadLine();
                Console.WriteLine("Please make sure to use numbers for cost and damage or it will crash");
                if (cheatchoice == "1")
                    {
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
                    Weapons addedWeapon = new Weapons(newname, cost, damage, description); 
                    PlayerInventory.Add(addedWeapon);
                }
                choice = Console.ReadLine();
                if (cheatchoice == "2")
                {
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
                    Weapons addedWeapon = new Weapons(newname, cost, damage, description);
                    ShopInventory.Add(addedWeapon);
                }

            }

            if (choice == "2")
            {
                Console.WriteLine("do you want to add it to player or store inventory");
                Console.WriteLine("1: PLayer");
                Console.WriteLine("2: Shop");
                choice = Console.ReadLine();
                Console.WriteLine("Please make sure to use numbers for cost and defense or it will crash");
                if (cheatchoice == "1")
                {
                    string newname = "";
                    int cost = 0;
                    int damage = 0;
                    string description;
                    Console.WriteLine("Pick a name for the Armor");
                    newname = Console.ReadLine();
                    Console.WriteLine("Type in the cost");
                    cost = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type in a defense");
                    damage = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type in a description");
                    description = Console.ReadLine();
                    Armor addedWeapon = new Armor(newname, cost, damage, description);
                    PlayerInventory.Add(addedWeapon);
                }
                choice = Console.ReadLine();
                if (cheatchoice == "2")
                {
                    string newname = "";
                    int cost = 0;
                    int damage = 0;
                    string description;
                    Console.WriteLine("Pick a name for the Armor");
                    newname = Console.ReadLine();
                    Console.WriteLine("Type in the cost");
                    cost = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type in a defense");
                    damage = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type in a description");
                    description = Console.ReadLine();
                    Armor addedWeapon = new Armor(newname, cost, damage, description);
                    ShopInventory.Add(addedWeapon);
                }
            }
            if (choice == "3")
            {
                int cheatgold;
                Console.WriteLine("type in a number for amount of gold\n Type in a negative number to remove gold");
                cheatgold = Convert.ToInt32(Console.ReadLine());
                _Playergold = _Playergold + cheatgold;
            }
            if (choice == "4")
            {
                int cheatgold;
                Console.WriteLine("type in a number for amount of gold\n Type in a negative number to remove gold");
                cheatgold = Convert.ToInt32(Console.ReadLine());
                _shopgold = _shopgold + cheatgold;
            }
        }

      

        public int PlayerGold
        {
            get
            {
                return _Playergold;
            }
            set
            {
                _Playergold = value;
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
