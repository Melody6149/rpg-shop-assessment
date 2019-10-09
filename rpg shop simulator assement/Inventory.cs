using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{
    class Inventory
    {
        private Item[] _list;


        public Inventory()
        {
            _list = new Item[0];
        }



        public virtual void remove(int index)
        {
            Item[] newlist = new Item[_list.Length - 1];
            int j = 0;
            for (int i = 0; i < _list.Length; i++)
            {
                if (i != index)
                {
                    newlist[j] = _list[i];
                    j++;
                }

            }
            _list = newlist;
        }


        public virtual void Add(Item value)
        {
            Item[] newlist = new Item[_list.Length + 1];

            for (int i = 0; i < _list.Length; i++)
            {
                newlist[i] = _list[i];
            }
            newlist[newlist.Length - 1] = value;
            _list = newlist;

        }

        public void Openinventory()
        {
            for (int i = 0; i < _list.Length; i++ )
            {

                Console.Write("\n" + (i + 1) + ": ");
                _list[i].Printitem();
            }
        }
        public Item GetItem(int choice)
        {
            return _list[(choice)];
        }

        public int GetLenth()
        {
            return _list.Length;
        }

        public int Getcost(int i)
        {
            return _list[i].GetCost();
        }

        public void Clear()
        {
            _list = new Item[0];
        }

        public void Saving(string path, Shop shop)
        {
            StreamWriter writer = File.CreateText(path);

            if (path == "PlayerInventory.txt")
            {
                writer.WriteLine(shop.PlayerGold);
            }
            if (path == "ShopInventory.txt")
            {
                writer.WriteLine(shop.ShopGold);
            }
            // the above code is used to know if to save player gold or shop gold
            

            for (int i = 0; i < _list.Length; i++)
            {
                writer.WriteLine(_list[i].Getitemtype()); //used for loading to know which constructor to use
                writer.WriteLine(_list[i].GetName());
                writer.WriteLine(_list[i].GetCost());
                writer.WriteLine(_list[i].Getstats());
                writer.WriteLine(_list[i].getdescription());
                
            }
            writer.Close();
        }
        public void Loading(string path, Shop shop)
        {

            string temp; // used to know if item is armor or weapon
            string name; 
            int cost;
            int stats;
            string description;
            bool Loading = true;
            if (File.Exists(path))
            {
                
                Clear();
                StreamReader reader = File.OpenText(path);

                if (path == "PlayerInventory.txt")
                {
                    shop.PlayerGold = Convert.ToInt32(reader.ReadLine());
                }
                if (path == "ShopInventory.txt")
                {
                    shop.ShopGold = Convert.ToInt32(reader.ReadLine());
                }
                while (Loading)
                {
                    
                    temp = reader.ReadLine();
                    name = reader.ReadLine();
                    cost = Convert.ToInt32(reader.ReadLine());
                    stats = Convert.ToInt32(reader.ReadLine());
                    description = reader.ReadLine();
                    

                    if (temp == "weapon")
                    {
                        Weapons weapon = new Weapons(name, cost, stats, description);
                        Add(weapon);
                    }
                    if (temp == "Armor")
                    {
                        Armor armor = new Armor(name, cost, stats, description);
                        Add(armor);
                    }
                    else if (temp == null)
                    {
                        Loading = false;
                        reader.Close();
                    }
                }
                
            }

        }
    }
}
