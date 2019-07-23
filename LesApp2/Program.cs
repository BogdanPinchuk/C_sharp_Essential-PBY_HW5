using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Примітка. Дуже коротке завдання і багато деталей упущено.
// 1. "Матриця довільного розміру" - її має задати користувач, має рандомно
// створюватись, чи має за замовчуванням якийсь розмір створювати
// 2. "можливість зміни розмірів" - не указані моменти/випадки при яких вона
// повинна змінюватися, чи по аналогії з MatLab або MathCAD матрииця змінює
// свої розміри в залежності від того в "яке місце" задасть користувач присвоєння,
// тобто, приклад: маємо матриицю M розміром 4х4 і користувач вирішив присвоїти
// M[6, 8] = 5; в такому випадку матриця автоматично змынюэ своъ розміри
// на 7х9; можливо користувач хоче змінювати матрицю обрізанням якимось внутрішнім
// методом класу, при цьому не змінюючи намрицю, яка наявна в середині,
// і просто в результаті зовні переприсвоїть те що вирізано, або він не хоче
// так і хоче зразу змінити розміри в середині...
// 3. "виводить на екран похідні від базової матриці" - які похідні? за умов коли
// матрицю саму "порізали", чи ті що задані копіюванням внутрішньої, чи просто набір
// набір матриць з перебором від 1х1 до nхm по рядках і колонках, хоча на даному
// етапі немає смислу, при цьому необхідно було враховувати зміщення вікна різних
// розмірів по самій матриці...

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // для створення чогось умовно рандомного
            Random rnd = new Random();

            // створюємо масив відповідного типу
            MyMatrix<double> matrix = new MyMatrix<double>
                (rnd.Next(1, 10), rnd.Next(1, 10));

            // Заповнюємо матрицю значеннями
            for (int i = 0; i < matrix.Count.H; i++)
            {
                for (int j = 0; j < matrix.Count.W; j++)
                {
                    matrix[i, j] = rnd.Next(-9, 10);
                }
            }

            // виведення даних
            Console.WriteLine("\n\tЗгенерована матриця:\n");
            Console.WriteLine(matrix.ToString());

            // вирізати підматрицю
            var temp = matrix.CutOut(0, 0, matrix.Count.H / 2, matrix.Count.W / 2);

            // результат
            Console.WriteLine("\n\tВирізана підматриця:\n");

            // виведення даних
            Console.WriteLine(temp.ToString());

            // зміна розмірів внутрішнього масиву
            matrix.Change(matrix.Count.H / 2, matrix.Count.W / 2);

            // виведення даних
            Console.WriteLine("\n\tОбрізана матриця матриця:\n");
            Console.WriteLine(matrix.ToString());

            // збільшення розмірів
            matrix.Change(matrix.Count.H * 2, matrix.Count.W * 2);

            // виведення даних
            Console.WriteLine("\n\tЗбільшена матриця матриця:\n");
            Console.WriteLine(matrix.ToString());

            // repeat
            DoExitOrRepeat();
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
