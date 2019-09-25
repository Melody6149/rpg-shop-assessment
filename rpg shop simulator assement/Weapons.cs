using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{
    class Weapons : Item
    {
        private int _damage;


        public Weapons(string name, int cost, int damage) : base(name,cost)
        {
            _damage = damage;

        }
    }
}
