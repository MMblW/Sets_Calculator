using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsCalculator
{
    internal class Program
    {
        static void Main()
        {
            Interface();
        }
        static void Interface()
        {
            string var;
            Console.WriteLine("1. Make a set");
            Console.WriteLine("2. Use preset set");
            do
            {
                var = Console.ReadLine();
            } while (var != "1" && var != "2");
            if (var == "1")
            {
                Console.Write("Enter size of the first set > ");
                var = Console.ReadLine();
                int size = int.Parse(var);
                double[] Set1 = new double[size];
                MakeSet(ref Set1);
                Console.Write("Enter size of the second set > ");
                var = Console.ReadLine();
                size = int.Parse(var);
                double[] Set2 = new double[size];
                MakeSet(ref Set2);
            }
            else
            {
                double[] Set1 = new double[4] { 1, 2, 3, 4 };
                double[] Set2 = new double[4] { 1, 3, 5, 6 };
                Console.Write("The first set is: ");
                for (int i = 0; i < Set1.Length; i++)
                {
                    Console.Write(Set1[i].ToString());
                    if (i == Set1.Length - 1)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("The second set is: ");
                for (int i = 0; i < Set2.Length; i++)
                {
                    Console.Write(Set2[i].ToString());
                    if (i == Set2.Length - 1)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(", ");
                    }
                }
            }
            Console.WriteLine("Operation: ");
            Console.WriteLine("Currently WIP. Press any key to quit.");
            Console.Read();
        }
        static void MakeSet(ref double[] Set)
        {
            Console.WriteLine("Enter elements of the set: ");
            string var;
            for (int i = 0; i < Set.Length; i++)
            {
                Console.Write((i+1).ToString());
                Console.Write(" > ");
                var = Console.ReadLine();
                Set[i] = double.Parse(var);
            }
            Console.Write("The set is: ");
            for (int i = 0; i < Set.Length; i++)
            {
                Console.Write(Set[i].ToString());
                if (i == Set.Length - 1)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
