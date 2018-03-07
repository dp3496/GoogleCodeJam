using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam17
{
    class OversizedPancakeFlipper
    {
        static void Main(string[] args)
        {
            var content = File.ReadAllText(args[0]);
            OversizedPancakeFlipper opf = new OversizedPancakeFlipper();
            //int t = int.Parse(Console.ReadLine());
            string[] contents = content.Split('\n');
            int t = int.Parse(contents[0].ToString());
            int i = 1;
            while (t > 0)
            {
                string[] val = contents[i].Split(' ');
                int res = opf.PFlipper(val[0], int.Parse(val[1]));
                if (res != -1)
                    Console.WriteLine("Case #{0}: " + res, i);
                else
                    Console.WriteLine("Case #{0}: IMPOSSIBLE", i);
                t--;
                i++;
            }
        }
        public int PFlipper(string value, int k)
        {
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '-')
                {
                    if (i + k <= value.Length)
                    {
                        value = Flipper(value.Substring(i, k), value, i);
                        count++;
                    }
                    else
                        count = -1;
                }
            }
            return count;
        }

        private string Flipper(string substring, string value, int j)
        {
            char[] val = value.ToCharArray();
            for (int i = 0; i < substring.Length; i++)
            {
                if (substring[i] == '-')
                {
                    val[i + j] = '+';
                }
                else
                {
                    val[i + j] = '-';
                }
            }
            return new string(val);
        }
    }
}
