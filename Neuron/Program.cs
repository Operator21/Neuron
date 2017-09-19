using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuron
{
    class Program
    { 

        static void Main(string[] args)
        {
            string x;
            bool fired = false;

            Console.WriteLine("Dendritů:");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hodnota pro výstřel:");
            int input2 = Convert.ToInt32(Console.ReadLine());
            Neuron n = new Neuron(input, input2);
            do
            {
                foreach (Dendrit d in n.dendrits)
                {
                    if (!fired)
                    {
                        if (n.dendrits.Sum(pkg => pkg._v) >= n.maxV)
                        {
                            SpaceWrite("Vystřeleno");
                            fired = true;
                        }
                        else
                        {
                            Console.WriteLine("Vstup:");
                            int value = Convert.ToInt32(Console.ReadLine());
                            if (value > 1)
                            {
                                value = 1;
                            }
                            d._v = value * d.w;
                            if (value > 0)
                            {
                                d.w++;
                                d.Increase = true;
                            }

                        }
                    }
                }
                int sum = n.dendrits.Sum(pkg => pkg._v);
                SpaceWrite("Suma = " + sum + " Hodnota výstřelu = " + n.maxV);
                foreach (Dendrit d in n.dendrits)
                {
                    if (d.Increase)
                    {
                        Console.WriteLine("Hodnota dendritu: " + d._v + " váha: " + (d.w - 1) + "+1");
                        d.Increase = false;
                    }
                    else
                    {
                        Console.WriteLine("Hodnota dendritu: " + d._v + " váha: " + (d.w - 1));
                    }
                    d._v = 0;
                }
                if (sum >= n.maxV)
                {
                    SpaceWrite("Vystřeleno");
                    Debug.WriteLine(sum + " / " + n.maxV);
                    fired = true;
                }
                else if(!fired)
                {
                    Debug.WriteLine(sum + " / " + n.maxV);
                    SpaceWrite("Opakovat ? (a/n)");
                }
                x = Console.ReadLine();
            } while (x != "n");

        }
        static void ClearWrite(string x)
        {
            Console.Clear();
            Console.WriteLine(x);
            Console.WriteLine();
        }
        static void SpaceWrite(string x)
        {
            if(x == "Vystřeleno")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int z = 0; z <= x.Length; z++)
                {
                    Console.Write("-");  
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(x);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
