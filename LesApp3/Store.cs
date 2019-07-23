using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    /// <summary>
    /// Склад
    /// </summary>
    class Store
    {
        /// <summary>
        /// Продукти на складі
        /// </summary>
        // Навний перелік товару - наприклад книги
        // "має закритий масив", отже можна спрогнозувати
        // що доступ користувачу до нього закритий і дані
        // вже наявні в базі даних
        private Article[] shelf = new Article[]
        {
                new Article()
                {
                     ProductName = "Pro C# 7: With .NET and .NET Core",
                     ShopName = "Apress.com",
                     Price = 1261.3
                },
                new Article()
                {
                     ProductName = "Design Patterns in .NET",
                     ShopName = "Amazon.com",
                     Price = 977.9
                },
                new Article()
                {
                     ProductName = "Оптимизация приложений на платформе .Net",
                     ShopName = "TopBooks",
                     Price = 1557
                },
                new Article()
                {
                     ProductName = "C# 5.0 и платформа .NET 4.5 для профессионалов",
                     ShopName = "Bizlit",
                     Price = 663
                },
                new Article()
                {
                     ProductName = "Библия C#", // 3-е издание
                     ShopName = "Prom.ua",
                     Price = 351
                }
        };

        /// <summary>
        /// Кількість товару на складі
        /// </summary>
        public int Count
        {
            get { return shelf.Length; }
        }

        /// <summary>
        /// Пошук по назві товару
        /// </summary>
        /// <param name="index">назва товару</param>
        /// <returns></returns>
        public string this[string index]
        {
            get
            {
                // пошук по назві
                for (int i = 0; i < Count; i++)
                {
                    if (index.ToLower() == shelf[i].ProductName.ToLower())
                    {
                        return shelf[i].ToString();
                    }
                }

                return $"\n\tТовар \"{index}\" - не найдено на складі.";
            }
        }
        /// <summary>
        /// Пошук по номеру товару
        /// </summary>
        /// <param name="index">номер товару</param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return shelf[index].ToString();
                }
                else
                {
                    return "\n\tСпроба звернутися за межі масиву.";
                }
            }
        }

    }
}
