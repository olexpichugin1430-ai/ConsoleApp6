using System;
using DataStructures;

namespace ListUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var myList = new CustomLinkedList();

            int[] data = { 12, -3, 25, 8, -1, 14 };
            foreach (int item in data) myList.Add(item);

            Console.WriteLine("list:");
            Show(myList);

            myList.InsertAfterSecond(67);
            myList.RemoveAt(1);

            Console.WriteLine("changed list:");
            Show(myList);

            int searchFactor = 4;
            Console.WriteLine($"first divisible by  {searchFactor}: {myList.FindFirstMultipleOf(searchFactor)}");
            Console.WriteLine($"positive quantity: {myList.CountPositive()}");

            int threshold = 10;
            Console.WriteLine($"\nquantity of nums more than  {threshold}:");
            Show(myList.GetElementsAbove(threshold));

            myList.RemoveAboveAverage();
            Console.WriteLine("\nlist without removed items:");
            Show(myList);
        }

        static void Show(CustomLinkedList list)
        {
            foreach (int val in list)
            {
                Console.Write($"{val} ");
            }
            Console.WriteLine();
        }
    }
}