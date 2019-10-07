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

        public int GetCost()
        {
            return _cost; //
        }
        public virtual void Printitem()
        {
           
        }

        public string GetName()
        {
            return _name;
        }
        public virtual string Getitemtype()
        {
            return "";
        }

        public virtual int Getstats()
        {
            return 1;
        }
        public string getdescription()
        {
            return _description;
        }
    }
}
