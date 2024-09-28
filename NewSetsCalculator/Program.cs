using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsCalculator
{
    class Set
    {
        public string Name;
        public List<double> values = new List<double> ();
    }
    internal class Program
    {
        static void Main()
        {
            Interface();
        }
        static void Interface()
        {
            char NextName = 'A';
            Random rnd = new Random();
            string var;
            Set[] SetArray = new Set[0];
            Console.WriteLine("1. Make custom sets");
            Console.WriteLine("2. Make random sets");
            do
            {
                var = Console.ReadLine();
            } while (var != "1" && var != "2");
            if (var == "1")
            {
                Console.Write("Enter the amount of sets: ");
                var = Console.ReadLine();
                Array.Resize(ref SetArray, int.Parse(var));
                for (int i = 0; i < SetArray.Length; i++)
                {
                    SetArray[i] = new Set();
                }
                Console.WriteLine("Making sets");
                for (int i = 0; i < SetArray.Length; i++)
                {
                    Console.Write("Enter the size of the set: ");
                    var = Console.ReadLine();
                    Console.WriteLine("Filling the set");
                    for (int j = 0; j < int.Parse(var); j++)
                    {
                        Console.Write("Enter values of the set: ");
                        var = Console.ReadLine();
                        SetArray[i].values.Add(double.Parse(var));
                    }
                    UsefulView(ref SetArray[i].values);
                    SetArray[i].Name = char.ToString(NextName++);
                    Console.Write(SetArray[i].Name + ": ");
                    for (int k = 0; k < SetArray[i].values.Count; k++)
                    {
                        Console.Write(SetArray[i].values[k]);
                    }
                    Console.WriteLine();
                }
            }
            if (var == "2")
            {
                Array.Resize(ref SetArray, rnd.Next(2, 11));
                for (int i = 0; i < SetArray.Length; i++)
                {
                    SetArray[i] = new Set();
                }
                for (int i = 0; i < SetArray.Length; i++)
                {
                    int IntVar = rnd.Next(1, 11);
                    SetArray[i].Name = char.ToString(NextName++);
                    for (int j = 0; j < IntVar; j++)
                    {
                        SetArray[i].values.Add(rnd.Next(0, 11));
                    }
                    UsefulView(ref SetArray[i].values);
                    Console.Write("The set is: ");
                    for (int k = 0; k < SetArray[i].values.Count; k++)
                    {
                        Console.Write(SetArray[i].values[k]);
                    }
                    Console.WriteLine();
                }
            }
            for (int i = 0; i < SetArray.Length; i++)
            {
                Console.Write(SetArray[i].Name);
                Console.Write("[");
                for (int j = 0; j < SetArray[i].values.Count; j++)
                {
                    Console.Write(SetArray[i].values[j]);
                    if (j < SetArray[i].values.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("]");
            }
            Queue<string> Operations = new Queue<string>();
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Intersection");
            Console.WriteLine("4. Excluding OR");
            Console.WriteLine("Enter operations by one, in order fron left to right");
            for (int i = 0; i < SetArray.Length - 1; i++)
            {
                Console.Write("> ");
                Operations.Enqueue(Console.ReadLine());
            }
        }
        static void UsefulView(ref List<double> Set)
        {
            Set.Sort();
            for (int i = 0; i < Set.Count - 1; i++)
            {
                if (Set[i] == Set[i+1])
                {
                    Set.Remove(Set[i]);
                }
            }
        }
        static void DoOperations(string Operation, ref double[] BaseSet, ref double[] Set)
        {
            switch(Operation)
            {
                case "1":
                    //Addition(ref BaseSet, ref Set);
                    Console.WriteLine("Done Addition");
                    break;
                case "2":
                    //Subtraction(ref BaseSet, ref Set);
                    Console.WriteLine("Done Sub");
                    break;
                case "3":
                    //Intersection(ref BaseSet, ref Set);
                    Console.WriteLine("Done Inter");
                    break;
                case "4":
                    //ExcludingOr(ref BaseSet, ref Set);
                    Console.WriteLine("Done XOR");
                    break;

            }
        }
        static void Addition(ref double[] Set1, ref double[] Set2)
        {
            bool flag = false;
            for(int i = 0; i < Set2.Length;  i++)
            {
                flag = false;
                for (int j = 0; j < Set1.Length; j++)
                {
                    if (Set1[j] == Set2[i])
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Array.Resize<double>(ref Set1, Set1.Length + 1);
                    Set1[Set1.Length-1] = Set2[i];
                }
            }
            Console.Write("The set is: ");
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
        }
        static void Intersection(ref double[] Set1, ref double[] Set2)
        {
            bool flag = false;
            for (int i = 0; i < Set1.Length; i++)
            {
                flag = false;
                if (Set1[i] != Set2[i])
                {
                    flag = true;
                }
                if (flag == true)
                {
                    for (int k = i; k < (Set1.Length - 1); k++)
                    {
                        Set1[k] = Set1[k+1];
                    }
                    Array.Resize<double>(ref Set1, Set1.Length - 1);
                }
            }
            Console.Write("The set is: ");
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
        }
        static void Subtraction(ref double[] Set1, ref double[] Set2)
        {
            bool flag = false;
            for (int i = 0; i < Set2.Length; i++)
            {
                flag = false;
                for (int j = 0; j < Set1.Length; j++)
                {
                    if (Set1[j] == Set2[i])
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    for (int k = i; k < (Set1.Length - 1); k++)
                    {
                        Set1[k] = Set1[k+1];
                    }
                    Array.Resize<double>(ref Set1, Set1.Length - 1);
                }
            }
            Console.Write("The set is: ");
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
        }
        static void Not(ref double[] Set1)
        {
            Console.Write("All rational values except: ");
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
        }
    }
}
