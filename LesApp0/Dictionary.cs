using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Словник
    /// </summary>
    class Dictionary
    {
        public enum Language
        {
            /// <summary>
            /// English
            /// </summary>
            en,
            /// <summary>
            /// Українська
            /// </summary>
            ua,
            /// <summary>
            /// Русский
            /// </summary>
            ru
        }

        public int Length
        {
            get { return eur.GetLength(0); }
        }

        /// <summary>
        /// Англійські слова
        /// </summary>
        private string[] en = new string[5];
        /// <summary>
        /// Українські слова
        /// </summary>
        private string[] ua = new string[5];
        /// <summary>
        /// Російські слова
        /// </summary>
        private string[] ru = new string[5];
        /// <summary>
        /// Спільна база даних слів
        /// </summary>
        private string[,] eur = new string[5, 3];

        /// <summary>
        /// Ініціалізація словника
        /// </summary>
        public Dictionary()
        {
            // занесення слів
            en[0] = "book"; ua[0] = "книжна"; ru[0] = "книга";
            en[1] = "pen"; ua[1] = "ручка"; ru[1] = "ручка";
            en[2] = "sun"; ua[2] = "сонце"; ru[2] = "солнце";
            en[3] = "apple"; ua[3] = "яблуко"; ru[3] = "яблоко";
            en[4] = "table"; ua[4] = "стіл"; ru[4] = "стол";

            // групування для швидкого пошуку по всім словам
            for (int i = 0; i < eur.GetLength(0); i++)
            {
                eur[i, 0] = en[i];
                eur[i, 1] = ua[i];
                eur[i, 2] = ru[i];
            }
        }

        /// <summary>
        /// Переклад слів з однієї мови на іншу
        /// </summary>
        /// <param name="index">Слово що перекладається</param>
        /// <param name="inLang">Мова на якій написане слово</param>
        /// <param name="outLang">Мова на яку перекласти слово</param>
        /// <returns></returns>
        public string this[string index, Language inLang, Language outLang]
        {
            get { return Translate(index, inLang, outLang); }
        }

        // Примітка. Звичайно, в мовах є подібні слова наприклад ручка, і можна було б зробити
        // пошук по всьому словнику, але тоді він буде не ефективний відносно швидкості пошуку інших слів

        /// <summary>
        /// Пошук слова по всьому словнику і переклад на вибрану мову
        /// </summary>
        /// <param name="index">Слово що перкладається</param>
        /// <param name="outLang">Мова на яку перекласти слово</param>
        /// <returns></returns>
        public string this[string index, Language outLang]
        {
            get
            {
                for (int i = 0; i < eur.GetLength(0); i++)
                {
                    for (int j = 0; j < eur.GetLength(1); j++)
                    {
                        if (index.ToLower() == eur[i, j])
                        {
                            return Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[j].ToString() + ": " + index +
                                $" - {Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[(int)outLang]}: {eur[i, (int)outLang]}";
                        }
                    }
                }

                return index + " - немає перекладу цього слова в жодному із словників.";
            }
        }

        /// <summary>
        /// Отримання слів по нумерації
        /// </summary>
        /// <param name="index">Індекс слова</param>
        /// <returns></returns>
        public string this[int index, Language outLang]
        {
            get
            {
                if (index >= 0 && index < eur.GetLength(0))
                {
                    return $"{Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[(int)outLang]}: {eur[index, (int)outLang]}";
                }
                else
                {
                    return "Спроба звернутися за межі масиву.";
                }
            }
        }

        /// <summary>
        /// Вивід всіх слів по відповідному індексу
        /// </summary>
        /// <param name="index">Індекс слів</param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < eur.GetLength(0))
                {
                    string res = string.Empty;
                    for (int i = 0; i < eur.GetLength(1); i++)
                    {
                        res += $"{Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[i]}: {eur[index, i]} ";
                    }
                    return res;
                }
                else
                {
                    return "Спроба звернутися за межі масиву.";
                }
            }
        }

        /// <summary>
        /// Перекладач
        /// </summary>
        /// <param name="inWord">Слово для пошуку</param>
        /// <param name="inLang">На якій мові шукати</param>
        /// <param name="outLang">На яку мову перекласти</param>
        private string Translate(string inWord, Language inLang, Language outLang)
        {
            // переклад слова
            string outWord = string.Empty;

            // пошук слова
            for (int i = 0; i < eur.GetLength(0); i++)
            {
                if (inWord.ToLower() == eur[i, (int)inLang])
                {
                    outWord = eur[i, (int)outLang];
                    break;
                }
            }

            // за умови якщо його немає в словнику
            // http://qaru.site/questions/52601/getting-the-max-value-of-an-enum
            if (outWord == string.Empty)
            {
                outWord = Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[(int)inLang].ToString() + ": " + inWord +
                    $" - {Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[(int)outLang]}: немає перекладу цього слова.";
            }
            else
            {
                outWord = $"{Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[(int)inLang]}: {inWord} - " +
                $"{Enum.GetValues(typeof(Language)).Cast<Language>().ToArray()[(int)outLang]}: {outWord}";
            }

            return outWord;
        }

    }
}
