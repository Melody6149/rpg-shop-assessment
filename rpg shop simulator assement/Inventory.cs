using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{
    class Inventory
    {
        private object[] _list;
        

        public  Inventory()
        {
            _list = new object[0];
        }



        public virtual void remove(int index)
        {
            object[] newlist = new object[_list.Length - 1];
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
            object[] newlist = new object[_list.Length + 1];

            for (int i = 0; i < _list.Length; i++)
            {
                newlist[i] = _list[i];
            }
            newlist[newlist.Length - 1] = value;
            _list = newlist;

        }

        
        
    }
}
