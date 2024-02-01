﻿using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
//Подключения библиотек(опять же правильно говорить пространства имён, но для тебя библиотеки)

//Имя пространства имён данного проекта
namespace Шифрование
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //Базовый алфавит
        char[] BaseAlf = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '.', ',', '/', '\\', '\'', '"', '+', '=', '-', '_', '!', '?',';',':',')','(', '0', '1', '2','3','4','5','6','7','8','9' };
        //Алфавит из цифр(1 символ=3 циврам)
        string[] NumberAlf = new string[] {"874", "987", "600", "642", "915", "658", "526", "202", "244", "565", "100", "845", "256", "110", "971", "962", "601", "640", "827", "509", "578", "564", "730", "170", "740", "279", "246", "985", "280", "184", "995", "606", "660", "328", "896", "634", "358", "959", "269", "284", "267", "362", "579", "377", "355", "692", "502", "418", "330", "335", "138", "655", "637", "103", "585", "620", "901", "826", "757", "785", "540", "213", "225", "659", "956", "419", "534", "696", "554", "994", "476", "883", "556", "759", "648", "376", "261", "332", "307", "180", "299", "320", "868", "102", "675", "384", "338", "389", "469", "724", "628", "946", "424", "814", "670", "717", "949", "720", "651", "710", "894", "733", "121", "850", "570", "643", "560", "250", "492", "762", "128", "505", "305", "818", "471", "367", "109", "725", "680", "106", "444", "190", "770", "154", "897", "254", "792", "612", "130", "511", "216", "334", "379", "363", "436", "237", "849", "917", "165", "291", "746", "731", "899"};
        //Перемешаный(закодироавный) алфавит
        char[] ChangeAlf = new char[] {'Ш', 'н', 'I', 'w', 'о', '_', 'C', 'y', '/', 'R', 'v', 'x', ')', 'U', 'Э', 'Y', 'a', 'J', 'э', 'f', 'Л', 'ы', '\\', 'z', 'Ь', 'b', 'O', '7', 'E', '!', 'h', 'ъ', '-', 'ш', 'M', 'T', ';', 'ж', 'q', 'М', 'Й', 'F', 'm', 'Q', '(', 'Ж', 'Н', '4', '.', 'S', 'W', '2', 'G', 'К', 'Я', '=', 's', ':', 'З', 'Ы', 'P', 'Ч', 'V', 'е', 'И', 'О', 'l', 'j', 'и', '1', 'Ф', 'я', 'п', 'e', 'Ъ', '6', 'r', 'м', 'i', 'Е', 'В', 'L', 'o', 'u', 'Т', 'X', '\'', '?', 'х', '"', 'k', 'з', '5', 'Ц', 'л', 'к', 'K', '0', 'n', 'щ', 'в', 'Б', 'Д', 'ь', 'Z', 'c', 'ф', 't', 'П', 'N', 'г', '3', 'р', 'ц', 'б', 'т', ' ', ',', 'У', 'с', '8', 'ч', 'B', 'Р', 'g', '+', 'Щ', 'ю', 'd', 'Х', 'A', 'Г', 'D', 'p', 'й', 'а', 'Ю', 'А', '9', 'у', 'С', 'д', 'H'};



        private void ShifrText_KeyDown(object sender, KeyEventArgs e)              //Метод для проверки количества символов в поле для ввода(закрытого текста)
        {
            if (ShifrText.Text.Length == 1500 && !(e.Key == Key.Back || e.Key == Key.Delete))//Проверяеться, что если длинна текста уже максимальная и нажат не Delet или Backspac
            {
                //Игнорируеться последнее нажатие кнопки и выводит предупреждение о максимальной длине
                e.Handled = true;
                MessageBox.Show("Максимальное количество символов 1500!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void StartText_KeyDown(object sender, KeyEventArgs e)              //Аналогичный метод, но для открытого текста
        {
            if (StartText.Text.Length == 500 && !(e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
                MessageBox.Show("Максимальное количество символов 500!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Coding_Click(object sender, RoutedEventArgs e)                                                         //Метод шифрования
        {
            try
            {
                bool change = true;                                                                                         //Переменая для проверки заменена ли буква или нет
                if (T1.IsChecked == true)                                                                                   //Проверка с помощью RadioButton(имя T1) выбран ли шифр под номером 1
                {
                    string OpenText = StartText.Text;                                                                       //Создаём переменую с исходным текстом
                    ShifrText.Text = string.Empty;                                                                          //Очищения поля с зашифрованым текстом
                    for (int i = 0; i < OpenText.Length; i++)                                                               //Запуск цикла для перебора искходного текста
                    {
                        change = true;                                                                                      //Сброс вспомогательной переменной
                        for (int ik = 0; ik < BaseAlf.Length; ik++)                                                         //Запуск цикла для перебора массива алфавита
                        {
                            if (OpenText[i] == BaseAlf[ik])                                                                 //Проверка буквы в тексте с исходным алфавитом
                            {
                                ShifrText.Text += ChangeAlf[ik];                                                            //Добавляет к зашифрованому тексту символ из изменёного алфавита, аналогично команде ShifrText.Text = ShifrText.Text + ChangeAlf[ik]
                                change = false;                                                                             //Подсказка, что не надо добавлять букву, ведь она заменена
                                break;                                                                                      //Принудительный выход из цикла
                            }
                        }
                        if (change)                                                                                         //Проверка заменили ли букву
                            ShifrText.Text += OpenText[i];                                                                  //Добавляет к зашифрованому тексту символ из исходного текста, аналогично команде ShifrText.Text = ShifrText.Text + OpenText[i]
                    }
                }
                else if (T2.IsChecked == true)                                                                              //Проверка с помощью RadioButton(имя T2) выбран ли шифр под номером 2
                {
                    string OpenText = StartText.Text;                                                                       //Создаём переменую с исходным текстом
                    ShifrText.Text = string.Empty;                                                                          //Очищения поля с зашифрованым текстом
                    for (int i = 0; i < OpenText.Length; i++)                                                               //Запуск цикла для перебора искходного текста
                    {
                        change = true;                                                                                      //Сброс вспомогательной переменной
                        for (int ik = 0; ik < BaseAlf.Length; ik++)                                                         //Запуск цикла для перебора массива алфавита
                        {
                            if (OpenText[i] == BaseAlf[ik])                                                                 //Проверка буквы в тексте с исходным алфавитом
                            {
                                ShifrText.Text += NumberAlf[ik];                                                            //Добавляет к зашифрованому тексту символ из номерного алфавита, аналогично команде ShifrText.Text = ShifrText.Text + NumberAlf[ik]
                                change = false;                                                                             //Подсказка, что не надо добавлять букву, ведь она заменена
                                break;                                                                                      //Принудительный выход из цикла
                            }
                        }
                        if (change)                                                                                         //Проверка заменили ли букву
                            ShifrText.Text += OpenText[i];                                                                  //Добавляет к зашифрованому тексту символ из исходного текста, аналогично команде ShifrText.Text = ShifrText.Text + OpenText[i]
                    }
                }
                else if (T3.IsChecked == true)                                                                              //Проверка с помощью RadioButton(имя T3) выбран ли шифр под номером 3
                {
                    string OpenText = StartText.Text;                                                                       //Создаём переменую с исходным текстом
                    ShifrText.Text = string.Empty;                                                                          //Очищения поля с зашифрованым текстом
                    for (int i = 0; i < OpenText.Length; i++)                                                               //Запуск цикла для перебора искходного текста
                    {
                        change = true;                                                                                      //Сброс вспомогательной переменной
                        for (int ik = 0; ik < BaseAlf.Length; ik++)                                                         //Запуск цикла для перебора массива алфавита
                        {
                            if (OpenText[i] == BaseAlf[ik])                                                                 //Проверка буквы в тексте с исходным алфавитом
                            {
                                ShifrText.Text += BaseAlf[BaseAlf.Length - ik - 1];                                         //Добавляет к зашифрованому тексту символ из номерного алфавита, аналогично команде ShifrText.Text = ShifrText.Text + BaseAlf[BaseAlf.Length - ik - 1]
                                change = false;                                                                             //Подсказка, что не надо добавлять букву, ведь она заменена
                                break;                                                                                      //Принудительный выход из цикла
                            }
                        }
                        if (change)                                                                                         //Проверка заменили ли букву
                            ShifrText.Text += OpenText[i];                                                                  //Добавляет к зашифрованому тексту символ из исходного текста, аналогично команде ShifrText.Text = ShifrText.Text + OpenText[i]
                    }
                }

                //Далее идут сложные шифры и скорее всего тебе их не надо знать, но комментарии я сделал, хочешь почитай
                else if (T4.IsChecked == true)                                     //Проверка с помощью RadioButton(имя T4) выбран ли шифр под номером 4                                        
                {
                    string Key = Interaction.InputBox("Введите ключ для гаммирования.", "Ввод ключа", "", -1, -1);             //Созданю переменую ключ с помощью inputBox даю ей значение
                    if (!string.IsNullOrWhiteSpace(Key))                                                                       //Проверяю ввёл ли что-то пользователь или нет
                    {
                        string binaryStr=string.Empty, binaryShifr=string.Empty;                                               //Создаю 2 перменные где потом будут битовые значения
                        string strin = StartText.Text;                                                                         //Беру исходный текст
                        ShifrText.Text = string.Empty;                                                                         //Очищения поля с зашифрованым текстом
                        StringBuilder sb = new StringBuilder();                                                                //Создаю переменую типы StringBuilder для работы со строками
                        foreach (byte b in Encoding.Unicode.GetBytes(Key))                                                     //Беру значение байт каждой буквы из ключа
                            sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));                                                 //Перевожу взятые байты в string формат, чтобы мог их посчитать по битам и делаю, чтобы размер каждого байта был равным
                        string key = sb.ToString();                                                                            //Получившиюся битовую последовательность(находящиюся в формате string) присваиюваю ключу(ведь его и перебирал)
                        int ik=0;                                                                                              //Переменая индекса для ключа, чтобы перебирать его значения
                        sb.Clear();                                                                                            //Очищаю StringBuelder для корректноый работы
                        foreach (byte b in Encoding.Unicode.GetBytes(strin))                                                   //Беру значение байт каждой буквы из перебираемого текста
                            sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));                                                 //Перевожу взятые байты в string формат, чтобы мог их посчитать по битам и делаю, чтобы размер каждого байта был равным
                        binaryStr = sb.ToString();                                                                             //Получившиюся битовую последовательность(находящиюся в формате string) присваиюваю временой переменной
                        for (int i = 0; i < binaryStr.Length; i++, ik++)                                                       //Цикл перебора исходной последовательности бит текста. С каждым шагом увеличиваю индекс бита как в шифруемом слове, так и в ключе. Заканичается только при достижении конца шифруемого текста
                        {
                            if (ik == key.Length)                                                                              //Проверяю был ли это последний бит ключа
                            {
                                ik = 0;                                                                                        //Если да, то сбрасиваю счётчик на ноль
                            }
                            if ((binaryStr[i] == '1' && key[ik] == '1') || (binaryStr[i] == '0' && key[ik] == '0'))            //Проверяю значения битов в выбраных позициях
                            {
                                binaryShifr += '0';                                                                            //Если они одинаковы, то тогда ставлю ноль
                            }
                            else
                            {
                                binaryShifr += '1';                                                                            //Иначе присваю единицу
                            }
                        }
                        byte[] stringArray = Enumerable.Range(0, binaryShifr.Length / 8).Select(i => Convert.ToByte(binaryShifr.Substring(i * 8, 8), 2)).ToArray();//Преобразую зашифрованую string переменую в массив байтов(каждый символ 1 байт, поэтому забираю из начальной строки по 8 символов)
                        ShifrText.Text = Encoding.Unicode.GetString(stringArray);                                              //Преобразую массив байтов в string переменую и выходит зашифрованый текст, который вывожу
                    }
                    else//Если пользователь не ввёл ключ
                    {
                        MessageBox.Show("Вы не ввели ключ.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (T5.IsChecked == true)                                     //Проверка с помощью RadioButton(имя T5) выбран ли шифр под номером 5
                {
                    string Key = Interaction.InputBox("Введите ключ для гаммирования.", "Ввод ключа", "", -1, -1);//Созданю переменую ключ с помощью inputBox даю ей значение
                    if (!string.IsNullOrWhiteSpace(Key))                                                          //Проверяю ввёл ли что-то пользователь или нет
                    {
                        string strin = StartText.Text;                                                            //Беру исходный текст
                        ShifrText.Text = string.Empty;                                                            //Очищения поля с зашифрованым текстом
                        byte[] ByteK = Encoding.Unicode.GetBytes(Key);                                            //Перевожу ключ в байтовый массив
                        int ik=0;                                                                                 //Переменая индекса для ключа, чтобы перебирать его значения
                        byte[] ByteS = Encoding.Unicode.GetBytes(strin);                                          //Перевожу исходный текст в байтовый массив
                        byte[] ByteE = new byte[ByteS.Length];                                                    //Создаю массив в которому буду закодированые байты символов для вывода, длинна массива равна длине массива исходного текста
                        for (int i = 0; i < ByteS.Length; i++, ik++)                                              //Цикл перебора исходного массива байт. С каждым шагом увеличиваю индекс массива как в шифруемом слове, так и в ключе. Заканичается только при достижении конца шифруемого текста
                        {
                            if (ik == ByteK.Length)                                                               //Проверяю был ли это последний элемент массива ключа
                            {
                                ik = 0;                                                                           //Если да, то сбрасиваю счётчик на ноль
                            }
                            if (ByteS[i] + ByteK[ik] > byte.MaxValue)                                             //Проверка, что при сложение байтовых значений выбраных символов они не превысят максимальный байтовы размер
                            {
                                ByteE[i] = Convert.ToByte(ByteS[i] + ByteK[ik] - byte.MaxValue);                  //Если превышают, то я вычитаю максимальный размер байта, чтобы отчёт начался как бы с нуля
                            }
                            else
                            {
                                ByteE[i] = Convert.ToByte(ByteS[i] + ByteK[ik]);                                  //Иначе, просто складываю байтовые значения символов
                            }
                        }
                        ShifrText.Text = Encoding.Unicode.GetString(ByteE);                                       //Преобразую массив байтов в string переменую и выходит зашифрованый текст, который вывожу
                    }
                    else//Если пользователь не ввёл ключ
                    {
                        MessageBox.Show("Вы не ввели ключ.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else//данная else на всяки случай, если пользователь, как-то сними с RadioButton галочку, хотя вроде это нельзя сделать
                {
                    MessageBox.Show("Вы не выбрали шифр.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ms)//Обработчик исключения в котором ловиться переменная типа Exception, чтобы выбрать из неё сообщение об ошибки
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)//Метод выводящий MessageBox с информацие о шифрах
        {
            MessageBox.Show("Моноалфавитная замена\n" +
                "Шифр простой замены, простой подстановочный шифр, моноалфавитный шифр — класс методов шифрования, " +
                "которые сводятся к созданию по определённому алгоритму таблицы шифрования, в которой для каждой " +
                "буквы открытого текста существует единственная сопоставленная ей буква шифр-текста. Само шифрование " +
                "заключается в замене букв согласно таблице. Для расшифровки достаточно иметь ту же таблицу, либо " +
                "знать алгоритм, по которому она генерируется.\n\n" +
                "Атбашь\n" +
                "Атбаш — простой шифр подстановки для алфавитного письма. Правило шифрования состоит в замене " +
                "i-й буквы алфавита буквой с номером n-i+1, где n — число букв в алфавите.\n\n" +
                "Гаммирование\n" +
                "Гаммирование, или Шифр XOR, — метод симметричного шифрования, заключающийся в «наложении» " +
                "последовательности, состоящей из случайных чисел, на открытый текст.\n" +
                "В данной программе представлен вариант гаммирования по ключу, то есть \"накладываеться\"" +
                " не в случайно последовательности, а определенный по желанию пользователя.", "Шифры", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();                       //Создаю окно для выбора, какой файл загружать
                openFile.Filter = "Текстовый файл (*.txt)|*.txt| Все файлы (*.*)|*.*";//Устанавливаю какие типы файлов он поддерживает
                if (openFile.ShowDialog() == true)                                    //Проверяю, что пользователь нажал ОК, а не просто закрыл окно
                {
                    StreamReader reader = new StreamReader(File.Open(openFile.FileName, FileMode.Open), Encoding.GetEncoding("Unicode"));//Создаю поток чтения, куда передаю имя файла, а с помощью переменной Encoding задаю в какой кодировки файл считывать
                    StartText.Text = reader.ReadToEnd();                              //Просто считываю всё из файла и вывожу в открытый текст
                    reader.Close();                                                   //Закрываю поток чтения
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();                       //Создаю окно для выбора, в какой файл сохранить
                saveFile.Filter = "Текстовый файл (*.txt)|*.txt| Все файлы (*.*)|*.*";//Устанавливаю какие типы файлов он поддерживает
                if (saveFile.ShowDialog() == true)                                    //Проверяю, что пользователь нажал ОК, а не просто закрыл окно
                {
                    StreamWriter sw = new StreamWriter(File.Open(saveFile.FileName, FileMode.Create), Encoding.GetEncoding("Unicode"));//Создаю поток записи, куда передаю имя файла, а с помощью переменной Encoding задаю в какой кодировки файл создавать
                    sw.Write(ShifrText.Text);                                         //Записываю весь текст, что есть в зашифрованом поле
                    sw.Close();                                                       //Закрываю поток записи
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
