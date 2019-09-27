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
        protected string _description;

        public Item(string name, int cost, string description)
        {
            _name = name;
            _cost = cost;
            _description = description;
        }
        public Item()
        {

        }
        public void Printitem()
        {
            string name = _name;
            string description = _description;
            int cost = _cost;

            Console.Write(name + "\n" + description + "\nThis Item cost " + cost + " Gold.");
        }

        
        
    }
}
