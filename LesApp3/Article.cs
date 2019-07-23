using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Властивості за заповчуванням створюються закриті поля, тому
// формально вимоги що до умови збережені =)

namespace LesApp3
{
    /// <summary>
    /// Продукт
    /// </summary>
    internal class Article
    {
        /// <summary>
        /// Назва продукту
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Назва магазину
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// Ціна товару
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Вивід інформації в консоль
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder()
                .Append($"\n\tНазва продукту: {ProductName}")
                .Append($"\n\tНазва магазину, де продається товар: {ShopName}")
                .Append($"\n\tЦіна товару: {Price:N2} грн");

            return s.ToString();
        }
    }
}
