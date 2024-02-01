using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ИБ_МоноЗаменаФулл
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


        char[] BaseAlf = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '.', ',', '/', '\\', '\'', '"', '+', '=', '-', '_', '!', '?',';',':',')','(', '0', '1', '2','3','4','5','6','7','8','9' };
        string[] NumberAlf = new string[] {"874", "987", "600", "642", "915", "658", "526", "202", "244", "565", "100", "845", "256", "110", "971", "962", "601", "640", "827", "509", "578", "564", "730", "170", "740", "279", "246", "985", "280", "184", "995", "606", "660", "328", "896", "634", "358", "959", "269", "284", "267", "362", "579", "377", "355", "692", "502", "418", "330", "335", "138", "655", "637", "103", "585", "620", "901", "826", "757", "785", "540", "213", "225", "659", "956", "419", "534", "696", "554", "994", "476", "883", "556", "759", "648", "376", "261", "332", "307", "180", "299", "320", "868", "102", "675", "384", "338", "389", "469", "724", "628", "946", "424", "814", "670", "717", "949", "720", "651", "710", "894", "733", "121", "850", "570", "643", "560", "250", "492", "762", "128", "505", "305", "818", "471", "367", "109", "725", "680", "106", "444", "190", "770", "154", "897", "254", "792", "612", "130", "511", "216", "334", "379", "363", "436", "237", "849", "917", "165", "291", "746", "731", "899"};
        char[] ChangeAlf = new char[] {'Ш', 'н', 'I', 'w', 'о', '_', 'C', 'y', '/', 'R', 'v', 'x', ')', 'U', 'Э', 'Y', 'a', 'J', 'э', 'f', 'Л', 'ы', '\\', 'z', 'Ь', 'b', 'O', '7', 'E', '!', 'h', 'ъ', '-', 'ш', 'M', 'T', ';', 'ж', 'q', 'М', 'Й', 'F', 'm', 'Q', '(', 'Ж', 'Н', '4', '.', 'S', 'W', '2', 'G', 'К', 'Я', '=', 's', ':', 'З', 'Ы', 'P', 'Ч', 'V', 'е', 'И', 'О', 'l', 'j', 'и', '1', 'Ф', 'я', 'п', 'e', 'Ъ', '6', 'r', 'м', 'i', 'Е', 'В', 'L', 'o', 'u', 'Т', 'X', '\'', '?', 'х', '"', 'k', 'з', '5', 'Ц', 'л', 'к', 'K', '0', 'n', 'щ', 'в', 'Б', 'Д', 'ь', 'Z', 'c', 'ф', 't', 'П', 'N', 'г', '3', 'р', 'ц', 'б', 'т', ' ', ',', 'У', 'с', '8', 'ч', 'B', 'Р', 'g', '+', 'Щ', 'ю', 'd', 'Х', 'A', 'Г', 'D', 'p', 'й', 'а', 'Ю', 'А', '9', 'у', 'С', 'д', 'H'};


        private void Coding_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool change=true;
                if (T1.IsChecked == true)
                {
                    string OpenText = StartText.Text;
                    ShifrText.Text = string.Empty;
                    for (int i = 0; i < OpenText.Length; i++)
                    {
                        change = true;
                        for (int ik = 0; ik < BaseAlf.Length; ik++)
                        {
                            if (OpenText[i] == BaseAlf[ik])
                            {
                                ShifrText.Text += ChangeAlf[ik];
                                change = false;
                                break;
                            }
                        }
                        if (change)
                            ShifrText.Text += OpenText[i];
                    }
                }
                else if (T2.IsChecked == true)
                {
                    string OpenText = StartText.Text;
                    ShifrText.Text = string.Empty;
                    for (int i = 0; i < OpenText.Length; i++)
                    {
                        change = true;
                        for (int ik = 0; ik < BaseAlf.Length; ik++)
                        {
                            if (OpenText[i] == BaseAlf[ik])
                            {
                                ShifrText.Text += NumberAlf[ik];
                                change = false;
                                break;
                            }
                        }
                        if (change)
                            ShifrText.Text += OpenText[i];
                    }
                }
                else if (T3.IsChecked == true)
                {
                    string OpenText = StartText.Text;
                    ShifrText.Text = string.Empty;
                    for (int i = 0; i < OpenText.Length; i++)
                    {
                        change = true;
                        for (int ik = 0; ik < BaseAlf.Length; ik++)
                        {
                            if (OpenText[i] == BaseAlf[ik])
                            {
                                ShifrText.Text += BaseAlf[BaseAlf.Length - ik - 1];
                                change = false;
                                break;
                            }
                        }
                        if (change)
                            ShifrText.Text += OpenText[i];
                    }
                }
                else if (T4.IsChecked == true)
                {
                    if (!(string.IsNullOrWhiteSpace(KeyText.Text)))
                    {
                        string[] strin = StartText.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        ShifrText.Text = string.Empty;
                        StringBuilder sb = new StringBuilder();
                        foreach (byte b in Encoding.Unicode.GetBytes(KeyText.Text))
                            sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                        string key = sb.ToString();
                        int ik=0;
                        for (int l = 0; l < strin.Length; l++)
                        {
                            sb.Clear();
                            foreach (byte b in Encoding.Unicode.GetBytes(strin[l]))
                                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                            string binaryStr = sb.ToString();
                            string binaryShifr = "";
                            for (int i = 0; i < binaryStr.Length; i++, ik++)
                            {
                                if (ik == key.Length)
                                    ik = 0;
                                if ((binaryStr[i] == '1' && key[ik] == '1') || (binaryStr[i] == '0' && key[ik] == '0'))
                                    binaryShifr += '1';
                                else
                                    binaryShifr += '0';
                            }
                            byte[] stringArray = Enumerable.Range(0, binaryShifr.Length / 8).Select(i => Convert.ToByte(binaryShifr.Substring(i * 8, 8), 2)).ToArray();
                            string str = Encoding.Unicode.GetString(stringArray);
                            ShifrText.Text += str + " ";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не ввели ключ.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали шифр.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Decoding_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool change=true;
                if (T1.IsChecked == true)
                {
                    string CloseText = ShifrText.Text;
                    DeShifrText.Text = string.Empty;
                    for (int i = 0; i < CloseText.Length; i++)
                    {
                        change = true;
                        for (int ik = 0; ik < ChangeAlf.Length; ik++)
                        {
                            if (CloseText[i] == ChangeAlf[ik])
                            {
                                DeShifrText.Text += BaseAlf[ik];
                                change = false;
                                break;
                            }
                        }
                        if (change)
                            DeShifrText.Text += CloseText[i];
                    }
                }
                else if (T2.IsChecked == true)
                {
                    string CloseText = ShifrText.Text;
                    string time = string.Empty;
                    DeShifrText.Text = string.Empty;
                    for (int i = 0; i < CloseText.Length; i++)
                    {
                        if (char.IsDigit(CloseText[i]))
                        {
                            time += CloseText[i];
                            if (time.Length == 3)
                            {
                                for (int ik = 0; ik < NumberAlf.Length; ik++)
                                    if (time == NumberAlf[ik])
                                    {
                                        DeShifrText.Text += BaseAlf[ik];
                                        break;
                                    }
                                time = string.Empty;
                            }
                        }
                        else
                        {
                            DeShifrText.Text += CloseText[i];
                        }
                    }
                }
                else if (T3.IsChecked == true)
                {
                    string CloseText = ShifrText.Text;
                    DeShifrText.Text = string.Empty;
                    for (int i = 0; i < CloseText.Length; i++)
                    {
                        change = true;
                        for (int ik = 0; ik < BaseAlf.Length; ik++)
                        {
                            if (CloseText[i] == BaseAlf[ik])
                            {
                                DeShifrText.Text += BaseAlf[BaseAlf.Length - ik - 1];
                                change = false;
                                break;
                            }
                        }
                        if (change)
                            DeShifrText.Text += CloseText[i];
                    }
                }
                else if (T4.IsChecked == true)
                {
                    if (!(string.IsNullOrWhiteSpace(KeyText.Text)))
                    {
                        string[] strin = ShifrText.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        DeShifrText.Text = string.Empty;
                        StringBuilder sb = new StringBuilder();
                        foreach (byte b in Encoding.Unicode.GetBytes(KeyText.Text))
                            sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                        string key = sb.ToString();
                        int ik=0;
                        for (int l = 0; l < strin.Length; l++)
                        {
                            sb.Clear();
                            foreach (byte b in Encoding.Unicode.GetBytes(strin[l]))
                                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                            string binaryStr = sb.ToString();
                            string binaryShifr = "";
                            for (int i = 0; i < binaryStr.Length; i++, ik++)
                            {
                                if (ik == key.Length)
                                    ik = 0;
                                if ((binaryStr[i] == '1' && key[ik] == '1') || (binaryStr[i] == '0' && key[ik] == '0'))
                                    binaryShifr += '1';
                                else
                                    binaryShifr += '0';
                            }
                            byte[] stringArray = Enumerable.Range(0, binaryShifr.Length / 8).Select(i => Convert.ToByte(binaryShifr.Substring(i * 8, 8), 2)).ToArray();
                            string str = Encoding.Unicode.GetString(stringArray);
                            DeShifrText.Text += str + " ";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не ввели ключ.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали шифр.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Текстовый файл (*.txt)|*.txt| Все файлы (*.*)|*.*";
                if (Open.IsChecked == true)
                {
                    openFile.ShowDialog();
                    StreamReader reader = new StreamReader(File.Open(openFile.FileName, FileMode.Open), Encoding.GetEncoding("Unicode"));
                    StartText.Text = reader.ReadToEnd();
                    reader.Close();
                }
                else if (Close.IsChecked == true)
                {
                    openFile.ShowDialog();
                    StreamReader reader = new StreamReader(File.Open(openFile.FileName, FileMode.Open), Encoding.GetEncoding("Unicode"));
                    ShifrText.Text = reader.ReadToEnd();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Вы не выбрали какой текст нужно загружать.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Текстовый файл (*.txt)|*.txt| Все файлы (*.*)|*.*";
                if (Open.IsChecked == true)
                {
                    saveFile.ShowDialog();
                    StreamWriter sw = new StreamWriter(File.Open(saveFile.FileName, FileMode.Create), Encoding.GetEncoding("Unicode"));
                    sw.Write(ShifrText.Text);
                    sw.Close();
                }
                else if (Close.IsChecked == true)
                {
                    saveFile.ShowDialog();
                    StreamWriter sw = new StreamWriter(File.Open(saveFile.FileName, FileMode.Create), Encoding.GetEncoding("Unicode"));
                    sw.Write(DeShifrText.Text);
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("Вы не выбрали какой текст нужно сохранять.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (T1.IsChecked == true || T2.IsChecked == true)
                {
                    MessageBox.Show("Шифр простой замены, простой подстановочный шифр, моноалфавитный шифр — класс методов шифрования, которые сводятся к созданию по определённому алгоритму таблицы шифрования, в которой для каждой буквы открытого текста существует единственная сопоставленная ей буква шифр-текста. Само шифрование заключается в замене букв согласно таблице. Для расшифровки достаточно иметь ту же таблицу, либо знать алгоритм, по которому она генерируется.", "Замена", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (T3.IsChecked == true)
                {
                    MessageBox.Show("Атбаш — простой шифр подстановки для алфавитного письма. Правило шифрования состоит в замене i-й буквы алфавита буквой с номером n-i+1, где n — число букв в алфавите.", "Атбаш", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (T4.IsChecked == true)
                {
                    MessageBox.Show("Гаммирование, или Шифр XOR, — метод симметричного шифрования, заключающийся в «наложении» последовательности, состоящей из случайных чисел, на открытый текст.", "Гаммирование", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Вы не выбрали шифр.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        private void StartText_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(StartText.Text.Length < 200) && !(e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
                MessageBox.Show("Максимальное количество символов 200!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShifrText_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(ShifrText.Text.Length < 200) && !(e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
                MessageBox.Show("Максимальное количество символов 200!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void DeShifrText_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(ShifrText.Text.Length < 200) && !(e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
                MessageBox.Show("Максимальное количество символов 200!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void T4_Checked(object sender, RoutedEventArgs e)
        {
            if (T4.IsChecked == true)
                KeyText.IsReadOnly = false;
            else
                KeyText.IsReadOnly = true;
        }
    }
}
