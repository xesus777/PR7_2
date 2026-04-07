using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7_2
{
    /// <summary>
    /// Класс для шифрования текста методом ROT13
    /// </summary>
    public class Encryptor
    {
        /// <summary>
        /// Шифрование текста методом ROT13
        /// </summary>
        /// <param name="input">Входной текст</param>
        /// <returns>Зашифрованный текст</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается при null</exception>
        /// <exception cref="ArgumentException">Выбрасывается при пустой строке</exception>
        public string Encrypt(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Входная строка не может быть null");

            if (input == string.Empty)
                throw new ArgumentException("Входная строка не может быть пустой", nameof(input));

            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (c >= 'a' && c <= 'z')
                    chars[i] = (char)('a' + (c - 'a' + 13) % 26);
                else if (c >= 'A' && c <= 'Z')
                    chars[i] = (char)('A' + (c - 'A' + 13) % 26);
            }

            return new string(chars);
        }

        /// <summary>
        /// Проверка, можно ли шифровать текст (только латиница)
        /// </summary>
        public bool IsValidForEncrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (char c in input)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
                      char.IsWhiteSpace(c) || char.IsPunctuation(c) || char.IsDigit(c)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
