using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові числа
            Random rnd = new Random();

            // створюємо нашу колекцію
            Masiv array = new Masiv();

            // випадковий розмір масиву
            int num = rnd.Next(0, byte.MaxValue);
            // створюємо масив
            for (int i = 0; i < num; i++)
            {
                array.AddRange(rnd.Next(sbyte.MinValue, sbyte.MaxValue));
            }

            // вивід всіх значень
            Show("\n\tКількість значень масиву", ConsoleColor.Red);
            Console.WriteLine(array.Count);

            Show("\n\tЄмність масиву", ConsoleColor.Red);
            Console.WriteLine(array.Capacity);

            Show("\n\tВсі значення масиву", ConsoleColor.Red);
            Console.WriteLine(array.ToString());

            Show("\n\tМаксимальне значення", ConsoleColor.Red);
            Console.WriteLine(array.Max);
            Show("\n\tМінімальне значення", ConsoleColor.Red);
            Console.WriteLine(array.Min);

            Show("\n\tСереднє арифметичне значення", ConsoleColor.Red);
            Console.WriteLine($"{array.Average:N3}");

            Show("\n\tВсі непарні значення масиву", ConsoleColor.Red);
            Console.WriteLine(array.ToString(Masiv.Parnist.odd));

            Show("\n\tВсі парні значення масиву", ConsoleColor.Red);
            Console.WriteLine(array.ToString(Masiv.Parnist.even));

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Відображення рядка в кольорі
        /// </summary>
        /// <param name="s">рядок</param>
        /// <param name="color">колір</param>
        private static void Show(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
