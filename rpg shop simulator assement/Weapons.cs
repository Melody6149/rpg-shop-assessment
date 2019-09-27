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

        int GetDamage()
        {
            return _damage;
        }

        public Weapons(string name, int cost, int damage, string description) : base(name,cost,description)
        {
            _damage = damage;

        }
    }
}
