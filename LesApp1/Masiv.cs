using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    /// <summary>
    /// Масив цілих чисел
    /// </summary>
    class Masiv
    {
        /// <summary>
        /// Парність/непарність числа
        /// </summary>
        public enum Parnist
        {
            /// <summary>
            /// парне
            /// </summary>
            even,
            /// <summary>
            /// непарне
            /// </summary>
            odd
        }

        /// <summary>
        /// Кількість елемнтів в масиві
        /// </summary>
        private int count = 0;
        /// <summary>
        /// Ємність масиву
        /// </summary>
        private int capacity = 4;

        /// <summary>
        /// Внутнутрішній масив цілих значень
        /// </summary>
        private int[] array = new int[4];

        /// <summary>
        /// Кількість елемнтів в масиві
        /// </summary>
        public int Count
        {
            get { return count; }
        }
        /// <summary>
        /// Ємність масиву
        /// </summary>
        public int Capacity
        {
            get
            {
                capacity = array.Length;
                return capacity;
            }
        }
        /// <summary>
        /// Мінімальне значення масиву
        /// </summary>
        public int Min
        {
            get
            {
                int minValue = array[0];
                for (int i = 1; i < Count; i++)
                {
                    minValue = Math.Min(minValue, array[i]);
                }

                // звичайно можна було зразу вказати array.Min(), але необхідно реалізувати свою колекцію
                return minValue;
            }
        }
        /// <summary>
        /// Максимальне значення масиву
        /// </summary>
        public int Max
        {
            get
            {
                int maxValue = array[0];
                for (int i = 1; i < Count; i++)
                {
                    maxValue = Math.Max(maxValue, array[i]);
                }

                return maxValue;
            }
        }
        /// <summary>
        /// Сума елементів масиву
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                
                return sum;
            }
        }
        /// <summary>
        /// Середнє значення масиву
        /// </summary>
        public double Average
        {
            get
            {
                return (double)Sum / Count;
            }
        }

        /// <summary>
        /// Парні значення
        /// </summary>
        public Masiv EvenNumbers
        {
            get
            {
                // створюємо внутрішній масив, який базується на уже створеному
                Masiv mas = new Masiv();

                // робимо цикл який знаходить парні значення
                for (int i = 0; i < Count; i++)
                {
                    if (Math.Abs(array[i] % 2) == 0)
                    {
                        mas.AddRange(array[i]);
                    }
                }

                return mas;
            }
        }

        /// <summary>
        /// Непарні значення
        /// </summary>
        public Masiv OddNumbers
        {
            get
            {
                // створюємо внутрішній масив, який базується на уже створеному
                Masiv mas = new Masiv();

                // робимо цикл який знаходить парні значення
                for (int i = 0; i < Count; i++)
                {
                    if (Math.Abs(array[i] % 2) == 1)
                    {
                        mas.AddRange(array[i]);
                    }
                }

                return mas;
            }
        }

        /// <summary>
        /// Індексатор масиву
        /// </summary>
        /// <param name="index">Індекс в масиві значень</param>
        /// <returns></returns>
        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        /// <summary>
        /// Повернення цілого масиву
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int[] mas = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                mas[i] = array[i];
            }

            return mas;
        }

        /// <summary>
        /// Додавання елемнтів масиву
        /// </summary>
        /// <param name="value">Масив вхідних значень</param>
        public void AddRange(params int[] value)
        {
            #region вибір розміру масиву
            // в даному випадку для керування об'ємом масиву необхідно
            // розв'язати рівняння: capacity = 2^n > count
            // 2^n > count
            // log_2(2^n) > log_2(count)
            // n > log_2(count)
            // n = ln(count) / ln(2) 
            #endregion

            // щоб даремно не виконувати лишні операції,
            // то краще перевірити чи щось було передано
            if (value.Length < 1)
            {
                return;
            }

            // зміна розмірів, якщо необхідно
            if (Count + value.Length == Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2)) + 1));
            }
            else if (Count + value.Length >= Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2))));
            }

            // присвоєння значень
            for (int i = 0; i < value.Length; i++)
            {
                array[count] = value[i];
                count++;
            }
        }

        /// <summary>
        /// Зміна розміру масиву
        /// </summary>
        /// <param name="num">Необхідна кількість елементів масиву</param>
        private void Resize(int num)
        {
            // новий тимчасовий масив
            int[] mas = new int[num];
            // min, якщо прийдеться обрізати масив
            for (int i = 0; i < Math.Min(array.Length, num); i++)
            {
                mas[i] = array[i];
            }

            array = mas;
        }

        /// <summary>
        /// Виведення значень масиву в ряд
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Empty;

            for (int i = 0; i < Count; i++)
            {
                s += array[i] + " ";
            }

            return s;
        }

        public string ToString(Parnist parnist)
        {
            string s = string.Empty;

            Masiv temp;

            switch (parnist)
            {
                case Parnist.even:
                    temp = EvenNumbers;
                    break;
                case Parnist.odd:
                    temp = OddNumbers;
                    break;
                default:
                    temp = new Masiv();
                    break;
            }

            for (int i = 0; i < temp.Count; i++)
            {
                s += temp[i] + " ";
            }

            return s;
        }

    }
}
