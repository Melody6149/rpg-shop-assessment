using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{
    class Armor : Item
    {
        private int _defense;

        int Getdefense()
        {
            return _defense;
        }

        public Armor(string name, int cost, int defense, string description) : base(name, cost, description)
        {
            _defense = defense;

        }

        public override void Printitem()
        {
            string name = _name;
            string description = _description;
            int cost = _cost;
            Console.Write(name + "\n" + description + "\nThis Armor cost " + cost + " Gold." + "\nThis armor has " + _defense + " Defense.");
        }

        public override string Getitemtype()
        {
            return "Armor";
        }

        public override int Getstats()
        {
            return _defense;
        }
    }
}
