using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{
    class Item
    {
        protected int _cost;
        protected string _name;

        public Item(string name, int cost)
        {
            _name = name;
            _cost = cost;

        }
        public Item()
        {

        }
        public void Printinventory()
        {
            Console.WriteLine();
        }

        
    }
}
