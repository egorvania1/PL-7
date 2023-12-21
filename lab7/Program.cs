//Вариант 3
using System;
using System.Collections.Generic;
using System.Globalization;

namespace lab7
{
    class Program
    {
        private static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Hello World!");
            int choice = -1;
            while (choice != 0)
            {
                try
                {
                    Console.Write("Выберите задание (1-5) (0 - выход): ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 1:
                        Tasks.Task1();
                        break;
                    case 2:
                        Tasks.Task2();
                        break;
                    case 3:
                        Tasks.Task3();
                        break;
                    case 4:
                        Tasks.Task4();
                        break;
                    case 5:
                        Tasks.Task5();
                        break;
                    case 0:
                        Console.WriteLine("Bye bye!");
                        break;
                    default:
                        Console.WriteLine("Введите число от 1 до 6. Чтобы выйти, введите 0.");
                        break;
                }
            }
        }
    }
}
