using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR7_2
{
    public partial class MainWindow : Window
    {
        private Encryptor _encryptor;
        private Decryptor _decryptor;

        public MainWindow()
        {
            InitializeComponent();
            _encryptor = new Encryptor();
            _decryptor = new Decryptor();
        }

        /// <summary>
        /// Обработчик кнопки "Зашифровать"
        /// </summary>
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;

                // Валидация пустой строки
                if (string.IsNullOrWhiteSpace(input))
                {
                    StatusTextBlock.Text = "Ошибка: Введите текст для шифрования";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    OutputTextBox.Clear();
                    return;
                }

                // Валидация содержимого
                if (!_encryptor.IsValidForEncrypt(input))
                {
                    StatusTextBlock.Text = "Ошибка: ROT13 поддерживает только латинский алфавит (A-Z, a-z)";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    OutputTextBox.Clear();
                    return;
                }

                // Шифрование
                string result = _encryptor.Encrypt(input);
                OutputTextBox.Text = result;
                StatusTextBlock.Text = $"Шифрование выполнено. Длина текста: {result.Length} символов";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Green;
            }
            catch (ArgumentNullException ex)
            {
                StatusTextBlock.Text = $"Ошибка: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            catch (ArgumentException ex)
            {
                StatusTextBlock.Text = $"Ошибка: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Неизвестная ошибка: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        /// <summary>
        /// Обработчик кнопки "Расшифровать"
        /// </summary>
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;

                // Валидация пустой строки
                if (string.IsNullOrWhiteSpace(input))
                {
                    StatusTextBlock.Text = "Ошибка: Введите текст для дешифрования";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    OutputTextBox.Clear();
                    return;
                }

                // Валидация содержимого
                if (!_decryptor.IsValidForDecrypt(input))
                {
                    StatusTextBlock.Text = "Ошибка: ROT13 поддерживает только латинский алфавит (A-Z, a-z)";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    OutputTextBox.Clear();
                    return;
                }

                // Дешифрование
                string result = _decryptor.Decrypt(input);
                OutputTextBox.Text = result;
                StatusTextBlock.Text = $"Дешифрование выполнено. Длина текста: {result.Length} символов";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Green;
            }
            catch (ArgumentNullException ex)
            {
                StatusTextBlock.Text = $"Ошибка: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            catch (ArgumentException ex)
            {
                StatusTextBlock.Text = $"Ошибка: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Неизвестная ошибка: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        /// <summary>
        /// Обработчик кнопки "Очистить"
        /// </summary>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
            OutputTextBox.Clear();
            StatusTextBlock.Text = "Готов";
            StatusTextBlock.Foreground = System.Windows.Media.Brushes.Gray;
            InputTextBox.Focus();
        }
    }
}
