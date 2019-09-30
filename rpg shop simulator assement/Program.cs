using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shop_simulator_assement
{
    class Program
    {

        static void Main(string[] args)
        {

            Shop shop = new Shop();
            shop.start();
            
            Console.ReadKey();
        }
    }
}
