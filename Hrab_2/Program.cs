using System;
using Hrab_2.Classes;

namespace Hrab_2
{
    class Program
    {
        static void BinaryTree()
        {
            Student st1 = new Student(5, "Lal", "lala");
            Student st2 = new Student(4, "Lal", "lala");
            Student st3 = new Student(9, "Lal", "lala");
            Student st4 = new Student(3, "Lal", "lala");
            Student st5 = new Student(8, "Lal", "lala");
            Student st6 = new Student(15, "Lal", "lala");
            Student st7 = new Student(1, "Lal", "lala");
            Student st8 = new Student(6, "Lal", "lala");
            Student st9 = new Student(10, "Lal", "lala");
            Student st10 = new Student(7, "Lal", "lala");
            Student st11 = new Student(37, "Lal", "lala");
            
            var Tree = new BinaryTree<Student>("PostOrder")
            {
                st1, st2, st3, st4, st5, st6, st7, st8, st9, st10
            };

            Tree.Added += (object sender, BinaryTreeEventArgs e) => Console.WriteLine((e.message + "\n"));

            Tree.Add(st11);

            Console.WriteLine("Traversal: ");
            foreach (var value in Tree)
                Console.Write($" {value}");
        }

        static void Array()
        {
            One_DimensionalArray<object> arr = new One_DimensionalArray<object>(4, 10);

            arr[4] = 'a';
            arr[5] = 1;
            arr[6] = 8.5f;
            arr[7] = "lol";
            arr[8] = 1.1d;
            arr[9] = 5;

            foreach (var el in arr)
                Console.WriteLine(el);
        }

        static void Main(string[] args)
        {
            BinaryTree();
            //Array();

            Console.ReadKey();
        }
    }
}
