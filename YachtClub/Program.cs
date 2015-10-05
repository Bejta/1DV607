using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "YachtClub";
            controller.Registry cr = new controller.Registry();
            cr.Run();
        }
    }
}
