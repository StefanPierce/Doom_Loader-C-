using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doomLoader
{
    class Loader
    {
        byte[] file;

        public void load(string filePath)
        {
            file = System.IO.File.ReadAllBytes(filePath);

            String s = getStringFromFile(0, 3);
            Console.WriteLine("IWAD or PWAD?:  " + s);

            int numb = getIntFromFile(4,7);
            Console.WriteLine("Number of directory Entries:  " + numb);

            int locDir = getIntFromFile(8, 11);
            Console.WriteLine("Directory Location:  " + locDir);

            for(int i = locDir; i < locDir+(numb*16); i += 16)
            {
                int loc = getIntFromFile(i, i + 3);
                int size = getIntFromFile(i + 4, i + 7);
                String name = getStringFromFile(i + 8, i + 15);


                if (size == 0) { Console.WriteLine(""); }
                Console.Write("Lump Location:  " + loc);
                Console.Write("   Lump Size:  " + size);
                Console.WriteLine("   Lump Name:  " + name);

                
            }

        }

        private string getStringFromFile(int s, int e)
        {
            int size = e - (s-1);
            char[] a = new char[size];
            for(int i = 0; i < size; i++)
            {
                a[i] = (char)file[s + i];
            }
            
            return new string(a);
        }

        private int getIntFromFile(int s, int e)
        {
            int size = e - (s - 1);
            byte[] a = new byte[size];
            int results = 0;

            for(int i = size-1; i>=0; i--)
            {
                results |= file[s + i] << i * 8;
            }

            //Array.Reverse(a);

            return results;
        }
    }
}
