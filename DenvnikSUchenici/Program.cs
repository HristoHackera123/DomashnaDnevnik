using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace DenvnikSUchenici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList registry = new ArrayList() { "Иван", 14, 5.50, "Петър", 15, 4.00, "Георги", 14, 3.85 };
            List<int> namesIdx = new List<int> { 0, 3, 6 };
            AddStudent(registry, namesIdx);
            PrintRegistry(registry, namesIdx);
            DeleteStudent(registry, namesIdx);
            PrintRegistry(registry, namesIdx);
            FindYoungestStudent(registry, namesIdx);
        }
        static void AddStudent(ArrayList registry, List<int> namesIdx)
        {
            string name = null;
            int age = 0;
            double grade = 0;
            while (true)
            {
                name = null;
                age = 0;
                grade = 0;
                try
                {
                    Console.Write("Student name: ");
                    name = Console.ReadLine();
                    Console.Write("Student age: ");
                    age = int.Parse(Console.ReadLine());
                    Console.Write("Student grade: ");
                    grade = double.Parse(Console.ReadLine());
                    Console.WriteLine("===================");
                }
                catch
                {
                    Console.WriteLine("Invalid data, please do input again");
                    continue;
                }
                break;
            }
            registry.Add(name);
            registry.Add(age);
            registry.Add(grade);
            namesIdx.Add(registry.IndexOf(name));
        }
        static void DeleteStudent(ArrayList registry, List<int> namesIdx)
        {
            Console.Write("Give name for deletion: ");
            string input = Console.ReadLine();
            Console.WriteLine("==============================");
            int idx = registry.IndexOf(input);
            if (idx != -1)
            {
                registry.RemoveAt(idx);
                registry.RemoveAt(idx);
                registry.RemoveAt(idx);
                namesIdx.RemoveAt(namesIdx.Count-1);
            }
        }
        static void FindYoungestStudent(ArrayList registry, List<int> namesIdx)
        {
            int minAge = int.MaxValue;
            string minName = null;
            for (int i = 0; i < namesIdx.Count; i++)
            {
                if ((int)registry[namesIdx[i]+1] < minAge)
                {
                    minAge = (int)registry[namesIdx[i] + 1];
                    minName = (string)registry[namesIdx[i]];
                }
            }
            Console.WriteLine($"The youngest student is {minName}, aged {minAge}");
        }
        static void PrintRegistry(ArrayList registry, List<int> namesIdx)
        {
            for (int i = 0; i < namesIdx.Count; i++)
            {
                Console.WriteLine($"Student {i+1}: {registry[namesIdx[i]]}, {registry[namesIdx[i]+1]} years old, grade {registry[namesIdx[i]+2]:F2}");
            }
            Console.WriteLine("============================");
        }
    }
}