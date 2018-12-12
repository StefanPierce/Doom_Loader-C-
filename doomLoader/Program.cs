using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doomLoader
{
    class Program
    {


        static void Main(string[] args)
        {
            Loader l = new Loader();
            l.load("Doom1.WAD");
        }

        
    }
}
