using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            Dictionary dictionary = new Dictionary();

            // вивід інформації

            // вивід всіх слів на всіх мовах
            #region
            Console.WriteLine("\n\tВивід всіх слів:\n");
            for (int i = 0; i <= dictionary.Length; i++)
            {
                Console.WriteLine(dictionary[i]);
            } 
            #endregion

            Console.WriteLine(new string('-', 20));

            // вивід всіх слів на якійсь із мов
            #region
            Console.WriteLine("\n\tВивід всіх слів на одній із мов:\n");
            for (int i = -1; i < dictionary.Length; i++)
            {
                Console.WriteLine(dictionary[i, Dictionary.Language.en]);
            } 
            #endregion

            Console.WriteLine(new string('-', 20));

            // переклад слів з мови на мову
            #region
            Console.WriteLine("\n\tПереклад слів з однієї мови на іншу:\n");
            Console.WriteLine(dictionary["Table", Dictionary.Language.en, Dictionary.Language.ua]);
            Console.WriteLine(dictionary["Книга", Dictionary.Language.ru, Dictionary.Language.en]);
            Console.WriteLine(dictionary["Яблуко", Dictionary.Language.ua, Dictionary.Language.en]);
            Console.WriteLine(dictionary["Sun", Dictionary.Language.en, Dictionary.Language.ru]);
            Console.WriteLine(dictionary["Pen", Dictionary.Language.en, Dictionary.Language.en]);
            Console.WriteLine(dictionary["Бла-бла-бла", Dictionary.Language.ru, Dictionary.Language.en]); 
            #endregion

            Console.WriteLine(new string('-', 20));

            // переклад слів, за умови якщо невідомо на якій мові воно написано
            #region
            Console.WriteLine("\n\tПереклад слів за умови якщо не відомо на якій мові слово написано: \n(+ є можливість визначити мову)\n");
            Console.WriteLine(dictionary["Стіл", Dictionary.Language.en]);
            Console.WriteLine(dictionary["Book", Dictionary.Language.en]);
            Console.WriteLine(dictionary["Яблоко", Dictionary.Language.en]);
            Console.WriteLine(dictionary["Словарь", Dictionary.Language.en]); 
            #endregion

            Console.WriteLine(new string('-', 20));

            // delay
            Console.ReadKey(true);
        }
    }
}
