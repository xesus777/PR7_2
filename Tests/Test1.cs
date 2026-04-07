using PR7_2;

namespace Tests
{
    [TestClass]
    public class Test1
    {
        private Encryptor _encryptor;
        private Decryptor _decryptor;

        [TestInitialize]
        public void Setup()
        {
            _encryptor = new Encryptor();
            _decryptor = new Decryptor();
        }

        /// <summary>
        /// TC1: Проверка самодвойственности (шифрование = дешифрование)
        /// </summary>
        [TestMethod]
        public void Test_SelfDuality_EncryptAndDecryptAreSame()
        {
            // Arrange
            string original = "HelloWorld";

            // Act
            string encrypted = _encryptor.Encrypt(original);
            string decrypted = _decryptor.Decrypt(encrypted);

            // Assert
            Assert.AreEqual(original, decrypted);
        }

        /// <summary>
        /// TC2: Проверка, что дважды зашифрованный текст равен исходному
        /// </summary>
        [TestMethod]
        public void Test_DoubleEncrypt_ReturnsOriginal()
        {
            // Arrange
            string original = "Test";

            // Act
            string once = _encryptor.Encrypt(original);
            string twice = _encryptor.Encrypt(once);

            // Assert
            Assert.AreEqual(original, twice);
        }

        /// <summary>
        /// TC3: Шифрование строчных букв
        /// </summary>
        [TestMethod]
        public void Test_Encrypt_LowercaseLetters()
        {
            // Arrange
            string input = "hello";
            string expected = "uryyb";

            // Act
            string result = _encryptor.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// TC4: Шифрование заглавных букв
        /// </summary>
        [TestMethod]
        public void Test_Encrypt_UppercaseLetters()
        {
            // Arrange
            string input = "HELLO";
            string expected = "URYYB";

            // Act
            string result = _encryptor.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// TC5: Шифрование смешанного регистра
        /// </summary>
        [TestMethod]
        public void Test_Encrypt_MixedCase()
        {
            // Arrange
            string input = "Hello";
            string expected = "Uryyb";

            // Act
            string result = _encryptor.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// TC6: Игнорирование неалфавитных символов (цифры, знаки, пробелы)
        /// </summary>
        [TestMethod]
        public void Test_NonAlphabeticCharacters_RemainUnchanged()
        {
            // Arrange
            string input = "Hello123! ";
            string expected = "Uryyb123! ";

            // Act
            string result = _encryptor.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// TC7: Только неалфавитные символы - без изменений
        /// </summary>
        [TestMethod]
        public void Test_OnlyNonAlphabetic_NoChange()
        {
            // Arrange
            string input = "123!@# $%^&*() ";

            // Act
            string result = _encryptor.Encrypt(input);

            // Assert
            Assert.AreEqual(input, result);
        }

        /// <summary>
        /// TC8: Проверка граничных значений A->N, Z->M
        /// </summary>
        [TestMethod]
        public void Test_WrapAround_ABecomesN_ZBecomesM()
        {
            // Assert
            Assert.AreEqual("N", _encryptor.Encrypt("A"));
            Assert.AreEqual("M", _encryptor.Encrypt("Z"));
            Assert.AreEqual("n", _encryptor.Encrypt("a"));
            Assert.AreEqual("m", _encryptor.Encrypt("z"));
        }

        /// <summary>
        /// TC9: Null входное значение - исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_NullInput_ThrowsArgumentNullException()
        {
            // Act
            _encryptor.Encrypt(null);
        }

        /// <summary>
        /// TC10: Пустая строка - исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_EmptyInput_ThrowsArgumentException()
        {
            // Act
            _encryptor.Encrypt("");
        }

        /// <summary>
        /// TC11: Валидация - латинские буквы проходят проверку
        /// </summary>
        [TestMethod]
        public void Test_IsValidForEncrypt_LatinLetters_ReturnsTrue()
        {
            // Arrange
            string input = "Hello World";

            // Act
            bool result = _encryptor.IsValidForEncrypt(input);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// TC12: Валидация - кириллица не проходит проверку
        /// </summary>
        [TestMethod]
        public void Test_IsValidForEncrypt_Cyrillic_ReturnsFalse()
        {
            // Arrange
            string input = "Привет";

            // Act
            bool result = _encryptor.IsValidForEncrypt(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// TC13: Известный пример ROT13
        /// </summary>
        [TestMethod]
        public void Test_KnownExample_HelloWorld()
        {
            // Assert
            Assert.AreEqual("Uryyb Jbeyq", _encryptor.Encrypt("Hello World"));
            Assert.AreEqual("Hello World", _encryptor.Encrypt("Uryyb Jbeyq"));
        }

        /// <summary>
        /// TC14: Шифрование и дешифрование длинной строки
        /// </summary>
        [TestMethod]
        public void Test_LongString_EncryptDecrypt()
        {
            // Arrange
            string original = "The quick brown fox jumps over the lazy dog";

            // Act
            string encrypted = _encryptor.Encrypt(original);
            string decrypted = _decryptor.Decrypt(encrypted);

            // Assert
            Assert.AreEqual(original, decrypted);
        }

        /// <summary>
        /// TC15: Проверка что зашифрованный текст отличается от исходного
        /// </summary>
        [TestMethod]
        public void Test_EncryptedText_DifferentFromOriginal()
        {
            // Arrange
            string original = "Hello";

            // Act
            string encrypted = _encryptor.Encrypt(original);

            // Assert
            Assert.AreNotEqual(original, encrypted);
        }

        /// <summary>
        /// TC16: Проверка дешифрования через Decryptor
        /// </summary>
        [TestMethod]
        public void Test_Decryptor_WorksCorrectly()
        {
            // Arrange
            string encrypted = "Uryyb";
            string expected = "Hello";

            // Act
            string result = _decryptor.Decrypt(encrypted);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
