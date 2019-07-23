using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Матриця
    /// </summary>
    class MyMatrix<T>
    {
        /// <summary>
        /// Матриця
        /// </summary>
        private T[,] arrays;

        /// <summary>
        /// Отримати розміри внутрішньої матриці
        /// </summary>
        public Coordinate Count
        {
            get
            {
                return new Coordinate(arrays.GetLength(0), arrays.GetLength(1));
            }
        }

        /// <summary>
        /// Створення базової (4 х 4) чистої матриці
        /// </summary>
        public MyMatrix()
        {
            arrays = new T[4, 4];
        }

        /// <summary>
        /// Створення чистої матриці (довільної, тобто заданої користувачем)
        /// </summary>
        /// <param name="height">рядки</param>
        /// <param name="weight">колонки</param>
        public MyMatrix(int height, int weight)
        {
            if (height < 1 || weight < 1)
            {
                Console.WriteLine("\n\tПомилка задання розмірів матриці.");
                return;
            }

            arrays = new T[height, weight];
        }

        /// <summary>
        /// Створення чистої квадратної матриці
        /// </summary>
        /// <param name="number">розмір сторони</param>
        public MyMatrix(int number)
            : this(number, number) { }

        /// <summary>
        /// Індексатор для прямого доступу до матриці
        /// </summary>
        /// <param name="i">рядок</param>
        /// <param name="j">колонка</param>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get { return arrays[i, j]; }
            set { arrays[i, j] = value; }
        }

        /// <summary>
        /// Вирізає підматрицю з матриці
        /// </summary>
        /// <param name="up">границя зверху</param>
        /// <param name="left">границя зліва</param>
        /// <param name="down">границя знизу</param>
        /// <param name="right">границя справа</param>
        public MyMatrix<T> CutOut(int up, int left, int down, int right)
        {
            // може бути момент коли задано дані вказані поза межами і буде помилка
            // зробимо автоматичне регулювання
            up = Corect(up, Count.H);
            down = Corect(down, Count.H);
            left = Corect(left, Count.W);
            right = Corect(right, Count.W);

            int h = Math.Abs(down - up),        // рядки
                w = Math.Abs(right - left);     // колонки

            // щоб не було помилки, якщо буде ділення 1 на 2 і націло лишиться 0
            h = (h < 1) ? 1 : h;
            w = (w < 1) ? 1 : w;

            // створюємо тимчасову матрицю
            MyMatrix<T> temp = new MyMatrix<T>(h, w);

            // вирізаємо підматрицю (похідні) матриці з базової
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    // необхідно зробити захист від переплутування сторін, як приклад Math.Min(up, down)
                    temp[i, j] = arrays[Math.Min(up, down) + i, Math.Min(left, right) + j];
                }
            }

            return temp;

            // внутрішня функція
            // value - задане користувачем значення межі обрізання матриці
            // limit - границя наявної матриці
            int Corect(int value, int limit)
            {
                return (value < 0) ? 0 : ((value > limit) ? limit : value);
            }
        }

        /// <summary>
        /// Перетворення в масив
        /// </summary>
        /// <returns></returns>
        public T[,] ToArray()
        {
            // пустий масив для виведення даних
            T[,] temp = new T[Count.H, Count.W];

            for (int i = 0; i < Count.H; i++)
            {
                for (int j = 0; j < Count.W; j++)
                {
                    temp[i, j] = arrays[i, j];
                }
            }

            return temp;
        }

        /// <summary>
        /// Виведення даних
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Empty; 

            for (int i = 0; i < Count.H; i++)
            {
                s += "\t";
                for (int j = 0; j < Count.W; j++)
                {
                    s += arrays[i, j] + " ";
                }
                s += "\n";
            }

            return s;
        }

        /// <summary>
        /// Зміна розмірів матриці
        /// </summary>
        /// <param name="up">границя зверху</param>
        /// <param name="left">границя зліва</param>
        /// <param name="height">кількість рядків</param>
        /// <param name="weight">кількістсь колонок</param>
        public void Change(int height, int weight)
        {
            // щоб не було помилки, якщо буде ділення 1 на 2 і націло лишиться 0
            height = (height < 1) ? 1 : height;
            weight = (weight < 1) ? 1 : weight;

            // тимчасовий масив
            T[,] temp = new T[height, weight];

            // копіювання даних
            for (int i = 0; i < Math.Min(height, Count.H); i++)
            {
                for (int j = 0; j < Math.Min(weight, Count.W); j++)
                {
                    temp[i, j] = arrays[i, j];
                }
            }

            arrays = temp;
        }

    }

    /// <summary>
    /// Клас який враховуэ координати, або ж розміри матриці
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Coordinate
    {
        /// <summary>
        /// колонки
        /// </summary>
        public int W { get; set; }
        /// <summary>
        /// рядки
        /// </summary>
        public int H { get; set; }

        /// <summary>
        /// Занесення даних зразу
        /// </summary>
        /// <param name="w">колонки</param>
        /// <param name="h">рядки</param>
        public Coordinate(int h, int w)
        {
            W = w;
            H = h;
        }

        public Coordinate() { }
    }

}
