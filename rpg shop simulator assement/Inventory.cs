using System;
using System.Collections.Generic;
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
    }
}
