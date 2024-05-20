using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; // Библиотека создания
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lablandiya
{
    public partial class Form1 : Form
    {
        public string filePath;
        public Form1()
        {
            InitializeComponent();
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            fileItem.DropDownItems.Add("Создать");
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void menuStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e){ }
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.FileStream file;
            SaveFileDialog a = new SaveFileDialog();
            a.InitialDirectory = "c:\\Users\\Lenovo\\Desktop";
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.filePath = a.FileName;
                FileStream fs = File.Create(this.filePath);
                fs.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.FileStream file;
            OpenFileDialog a = new OpenFileDialog();
            a.InitialDirectory = "c:\\Users\\Lenovo\\Desktop";
            a.Filter = "txt files (*.txt)|*txt|All files (*.*)|*.*";
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.filePath = a.FileName;
                FileStream fs = File.OpenRead(this.filePath);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                richTextBox1.Text = Encoding.Default.GetString(buffer);
                fs.Close();
            }
        }
        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            // Проверка, что перетаскивается файл
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            // Получение списка файлов, перетаскиваемых на элемент управления
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Обработка каждого файла
            foreach (string file in files)
            {
                // Добавление текста в элемент управления
                richTextBox1.Text = file;
            }
        }
        void ChangeFont(RichTextBox richTextBox, float modify)
        {
            richTextBox.Select(0, richTextBox.Text.Length);

            Font currentFont = richTextBox.SelectionFont;
            float newSize = currentFont.Size * modify;
            richTextBox.SelectionFont = new Font(currentFont.FontFamily, newSize);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.FileStream file;
            SaveFileDialog a = new SaveFileDialog();
            a.InitialDirectory = "c:\\Users\\Lenovo\\Desktop";
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.filePath = a.FileName;
                FileStream fs = File.Create(this.filePath);
                fs.Close();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.FileStream file;
            OpenFileDialog a = new OpenFileDialog();
            a.InitialDirectory = "c:\\Users\\Lenovo\\Desktop";
            a.Filter = "txt files (*.txt)|*txt|All files (*.*)|*.*";
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.filePath = a.FileName;
                FileStream fs = File.OpenRead(this.filePath);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                richTextBox1.Text = Encoding.Default.GetString(buffer);
                fs.Close();
            }
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = File.OpenWrite(this.filePath);
                byte[] buffer = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
            catch (Exception)
            {}
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.FileStream file;
            SaveFileDialog a = new SaveFileDialog();
            a.InitialDirectory = "c:\\Users\\Lenovo\\Desktop";
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.filePath = a.FileName;
                FileStream fs = File.Create(this.filePath);
                byte[] buffer = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "Фунцция: СоздатьToolStripMenuItem_Click - Создает файл по выбранному адресу \nФункция: открытьToolStripMenuItem_Click\nФункция: сохранитьToolStripMenuItem_Click \nсохранитьКакToolStripMenuItem_Click",
                    "Описание функций:",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText() == true)
            {
                string someText = Clipboard.GetText();
                richTextBox1.Text = someText;
            }
        }
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            richTextBox1.Text = "";
        }
        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = File.OpenWrite(this.filePath);
                byte[] buffer = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
            catch (Exception)
            { }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            richTextBox1.Text = "";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "Разработчик: Хакимов Камиль \nПрограмма разработана на языке программирования C# с ильпользованием Windows Forms \n",
                    "О программе:",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }
        public void CheckClose()
        {
            DialogResult result = MessageBox.Show("Сохранить изменения в файле?", "Неприменённые изменения", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                сохранитьКакToolStripMenuItem_Click(null, null);
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else
                Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckClose();
        }

        public int check(string substr)
        {
            if (substr != "")
            {
                switch (substr)
                {
                    case "function":
                        return 1;
                        break;
                    case "(":
                        return 2;
                        break;
                    case ")":
                        return 3;
                        break;
                    case "{":
                        return 4;
                        break;
                    case "}":
                        return 5;
                        break;
                    case "*":
                        return 6;
                        break;
                    case "+":
                        return 6;
                        break;
                    case "-":
                        return 6;
                        break;
                    case "/":
                        return 6;
                        break;
                    case "%":
                        return 6;
                        break;
                    case " ":
                        return 8;
                        break;
                    case "\n":
                        return 9;
                        break;
                    case "\t":
                        return 10;
                        break;
                    case "return":
                        return 1;
                        break;
                    case ";":
                        return 12;
                        break;
                    case ",":
                        return 13;
                        break;
                    default:
                        {
                            bool isDig = true;
                            for (int j = 0; j < substr.Length; j++)
                                if (!Char.IsDigit(substr[j]))
                                {
                                    isDig = false;
                                    break;
                                }
                            int num = 7;
                            if (isDig)
                                return num;
                            else
                                foreach (Char ch in substr)
                                {
                                    if ((ch < 'a') || (ch > 'z'))
                                    {
                                        num = 0;
                                    }
                                }
                            return num;
                            break;
                        }
                }
            }
            return 11;
        }
        struct lexem
        {
            public int key;
            public string type;
            public string st;
            public int start;
            public int end;
        }
        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            Dictionary<string, int> a = new Dictionary<string, int>();
            string str = Regex.Replace(richTextBox1.Text, @"[\r]", " ");
            string[] t1 = str.Split(' ', '\n', '\t');
            List<string> t2 = new List<string>();
            char[] specSimb = { '(', ')', '{', '}', '*', '/', '+', '-', ',', ';' };

            foreach (string t1string in t1)
            {
                int starti = 0;
                for (int i = 0; i < t1string.Length; i++)
                {
                    if (specSimb.Contains(t1string[i]))
                    {
                        if (i - starti != 1 || !((t1string[i] == ')' && t2.Last() == "(") || (t1string[i] == '}' && t2.Last() == "{")))
                        {
                            t2.Add(t1string.Substring(starti, i - starti));
                            starti = i++;
                        }
                        t2.Add(t1string.Substring(starti, 1));
                        starti = i++;
                    }
                }
                if (t1string.Length != starti)
                    t2.Add(t1string.Substring(starti, t1string.Length - starti));
            }
            while (t2.Remove(String.Empty)) ;
            List<lexem> lexems = new List<lexem>();
            List<string> variables = new List<string>();
            bool test = true;
            int start = 0;
            int numbers = 1;
            int index = 1;

            foreach (string st in t2.ToArray())
            {

                int end = start + st.Length;
                string type = "";
                int key = check(st);
                if (key == 0)
                {
                    test = false;
                }
                if (key == 1)
                {
                    if (a.ContainsKey("keyword"))
                    {
                        a["keyword"] = a["keyword"] + 1;
                    }
                    else
                    {
                        a["keyword"] = 1;
                    }
                    type = "Ключевое слово";
                }
                else if (key == 2)
                {
                    if (a.ContainsKey("("))
                    {
                        a["("] = a["("] + 1;
                    }
                    else
                    {
                        a["("] = 1;
                    }
                    type = "(";
                }
                else if (key == 3)
                {
                    if (a.ContainsKey(")"))
                    {
                        a[")"] = a[")"] + 1;
                    }
                    else
                    {
                        a[")"] = 1;
                    }
                    type = "(";
                }
                else if (key == 4)
                {
                    if (a.ContainsKey("{"))
                    {
                        a["{"] = a["{"] + 1;
                    }
                    else
                    {
                        a["{"] = 1;
                    }
                    type = "{";

                }
                else if (key == 5)
                {
                    if (a.ContainsKey("}"))
                    {
                        a["}"] = a["}"] + 1;
                    }
                    else
                    {
                        a["}"] = 1;
                    }
                    type = "}";

                }
                else if (key == 7)
                {
                    if (a.ContainsKey("variable"))
                    {
                        a["variable"] = a["variable"] + 1;
                    }
                    else
                    {
                        a["variable"] = 1;
                    }
                    type = "variable";
                }
                else if (key == 6)
                {
                    if (a.ContainsKey("operator"))
                    {
                        a["operator"] = a["operator"] + 1;
                    }
                    else
                    {
                        a["operator"] = 1;
                    }
                    type = "operator";
                }
                else if (key == 8)
                {
                    if (a.ContainsKey("_"))
                    {
                        a["_"] = a["_"] + 1;
                    }
                    else
                    {
                        a["_"] = 1;
                    }
                    type = "_";

                }
                else if (key == 9)
                {
                    if (a.ContainsKey("Перенос строки"))
                    {
                        a["Перенос строки"] = a["Перенос строки"] + 1;
                    }
                    else
                    {
                        a["Перенос строки"] = 1;
                    }
                    type = "Перенос строки";
                }
                else if (key == 10)
                {
                    if (a.ContainsKey("Табуляция"))
                    {
                        a["Табуляция"] = a["Табуляция"] + 1;
                    }
                    else
                    {
                        a["Табуляция"] = 1;
                    }
                }
                lexem word = new lexem { key = key, type = type, st = st, start = start, end = end };
                lexems.Add(word);
                start = end;
                numbers++;
            }

            int step = 0;
            bool result = true;
            bool ch = false;
            for (int i = 0; i < lexems.Count; i++)
            {
                if (lexems[i].key >= 8 && lexems[i].key <= 10)
                    continue;

                // проверка на Function
                if (step == 0)
                {
                    if (lexems[i].st == "function")
                    {
                        step++;
                    }
                    else if (lexems[i].st == "(")
                    {
                        richTextBox2.AppendText($"{index}. Попустили слово function перед {lexems[i].st}\n");
                        step += 2;
                        index++;
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Ожидается ключевое слово function вместо {lexems[i].st}\n");
                        step++;
                        index++;
                    }
                }
                // проверка на (
                else if (step == 1)
                {
                    if (lexems[i].key == 2)
                    {
                        step++;
                    }
                    else if (lexems[i].key == 7)
                    {
                        richTextBox2.AppendText($"{index}. Попустили символ ( перед {lexems[i].st}\n");
                        step++;
                        i--;
                        index++;
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Ожидается (  до {lexems[i].st}\n");
                        index++;
                        step++;
                    }
                }
                // проверка на Number
                else if (step == 2)
                {
                    if (lexems[i].key == 3)
                    {
                        step++;
                    }
                    else if (lexems[i].key == 7)
                    {
                        while (lexems[i].key == 7)
                        {
                            variables.Add(lexems[i].st);
                            i++;
                            if (lexems[i].st == ",")
                                i++;
                            else if (lexems[i].st == ")")
                            {
                                step++;
                                break;
                            }
                            else
                            {
                                richTextBox2.AppendText($"{index}. Ожидается ) перед: {lexems[i].st}\n");
                                i--;
                                index++;
                                step++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Ожидается Имя переменной с {lexems[i].st}\n");
                        index++;
                        step++;
                    }
                }
                // проверка на {
                else if (step == 3)
                {

                    if (lexems[i].key == 4)
                    {
                        step++;
                    }
                    // Проверить на variable
                    else if (lexems[i].st == "return")
                    {
                        richTextBox2.AppendText($"{index}. Попустили скобку на открытие функции с {lexems[i].start}\n");
                        index++;
                        step += 2;
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Ожидается символ Открывающей скобки с {lexems[i].start}\n");
                        index++;
                        step++;
                    }
                }
                // проверка на return
                else if (step == 4)
                {

                    if (lexems[i].st == "return")
                    {
                        step++;
                    }
                    // Проверить на variable
                    else if (lexems[i].key == 7)
                    {
                        richTextBox2.AppendText($"{index}. Попустили слово return с {lexems[i].st}\n");
                        index++;
                        i--;
                        step++;
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Ожидается ключевое слово return с {lexems[i].st}\n");
                        index++;
                        result = false;
                    }
                }
                else if(step == 5)
                {
                    int tmp = i;

                    int open = 0, close = 0;
                    try
                    {
                        while (i < lexems.Count && lexems[i].st != ";")
                        {
                            if (lexems[i].st == "(")
                                open++;
                            if (lexems[i].st == ")")
                                close++;
                            i++;
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        richTextBox2.AppendText($"{index++}. Пропущен символ ; \n");
                    }

                    if (open > close)
                    {
                        richTextBox2.AppendText($"{index++}. В варажении открвыающихся скобок больше закрывающихся на {open-close}\n");
                        return;
                    }
                    else if(close> open)
                    {
                        richTextBox2.AppendText($"{index++}. В варажении закрывающихся скобок больше открывающихся на {close - open}\n");
                        return;
                    }
                    i = tmp;
                    step++;
                }
                // проверка на Number
                else if (step == 6)
                {
                    ch = true;
                    bool isDig = true;
                    for (int j = 0; j < lexems[i].st.Length; j++)
                        if (!Char.IsDigit(lexems[i].st[j]))
                        {
                            isDig = false;
                            break;
                        }
                    if (lexems[i].key == 7 || isDig == true)
                    {
                        try
                        {
                            while (lexems[i].key == 7)
                            {
                                bool check = false;
                                foreach (string variabl in variables)
                                {
                                    if (variabl == lexems[i].st)
                                    {
                                        check = true;
                                    }
                                }

                                for (int j = 0; j < lexems[i].st.Length; j++)
                                    if (Char.IsDigit(lexems[i].st[j]))
                                    {
                                        check = true;
                                        break;
                                    }

                                if (!check)
                                {
                                    richTextBox2.AppendText($"{index}. Переменная не подходит: {lexems[i].st}\n");
                                    index++;
                                }

                                i++;
                                if (lexems[i].key == 6)
                                    i++;
                                else if (lexems[i].st == ";")
                                {
                                    step++;
                                    break;
                                }
                                else if (lexems[i].key == 3)
                                    continue;
                                else if (lexems[i].key == 7)
                                {
                                    richTextBox2.AppendText($"{index}. Ожидается оператор перед: {lexems[i].st}\n");
                                    index++;
                                }
                                else
                                {
                                    richTextBox2.AppendText($"{index}. Ожидается ; перед: {lexems[i].st}\n");
                                    index++;
                                    i--;
                                    step++;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (lexems[i - 1].key == 6)
                            {
                                richTextBox2.AppendText($"{index}. Ожидается переменная перед: {lexems[i - 1].st}\n");
                                index++;
                            }
                            else
                            {
                                richTextBox2.AppendText($"{index}. Ожидается ; перед: {lexems[i - 1].st}\n");
                                index++;
                            }
                        }
                    }
                    else if (lexems[i].st == ";")
                        step++;
                    else if (lexems[i].key == 6)
                    {
                        //richTextBox2.AppendText($"{index}. Попустили число или Имя переменной {lexems[i].st}\n");
                        index++;
                        i++;
                        try
                        {
                            while (lexems[i].key == 7)
                            {

                                i++;
                                if (lexems[i].key == 6)
                                    i++;
                                else if (lexems[i].st == ";")
                                {
                                    step++;
                                    break;
                                }
                                else
                                {
                                    richTextBox2.AppendText($"{index}. Ожидается ; перед: {lexems[i].st}\n");
                                    index++;
                                    i--;
                                    step++;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (lexems[i - 1].key == 6)
                            {
                                richTextBox2.AppendText($"{index}. Ожидается переменная перед: {lexems[i - 1].st}\n");
                                index++;
                            }
                            else
                            {
                                richTextBox2.AppendText($"{index}. Ожидается ; перед: {lexems[i - 1].st}\n");
                                index++;
                            }
                        }
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Ожидается имя переменной или число {lexems[i].st}\n");
                        index++;
                        result = false;
                    }
                }
                // проверка на }
                else if (step == 7)
                {
                    ch = true;
                    if (lexems[i].key == 5)
                    {
                        step++;
                    }
                    // Проверить на variable
                    else if (lexems[i].st == " ")
                    {
                        richTextBox2.AppendText($"{index}. Попустили конец функции {lexems[i].st}\n");
                        index++;
                        step += 2;
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Ожидается конец функции перед {lexems[i].st}\n");
                        index++;
                        result = false;
                    }
                }
                else if (step == 7)
                {
                    if (lexems[i].key == 12)
                    {
                        step++;
                    }
                    // Проверить на variable
                    else if (lexems[i].st == " ")
                    {
                        richTextBox2.AppendText($"{index}. Пропустили точку с запятой {lexems[i].st}\n");
                        index++;
                        step++;
                    }
                    else
                    {
                        richTextBox2.AppendText($"{index}. Пропустили точку с запятой {lexems[i].st}\n");
                        index++;
                        result = false;
                    }
                }
            }
            if (step == 5 && !ch)
            {
                richTextBox2.AppendText($"{index}. После return нет оператора " + '}' + " \n");
                index++;
                richTextBox2.AppendText($"{index}. В конце функции нет " + '}' + " \n");
                index++;
                richTextBox2.AppendText($"{index}. В конце функции нет ; \n");
                index++;
            }
            if (step == 6 && !ch)
            {
                richTextBox2.AppendText($"{index}. В конце функции нет " + '}' + " \n");
                index++;
            }
            if (step == 7)
            {
                richTextBox2.AppendText($"{index}. В конце функции нет ; \n");
                index++;
            }
            if (richTextBox2.Text == "")
            {
                richTextBox2.AppendText("Ошибок не обнаруженно");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText() == true)
            {
                //Извлекаем (точнее копируем) его и сохраняем в переменную
                string someText = Clipboard.GetText();
                richTextBox1.Text = someText;
            }
        }
        private void постановкаЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Постановка задачи";
            form.richTextBox1.Text = "Функции в языке программирования JavaScript имеют различную реализацию написания, в данном случае используется создание функции, которая работает с цифрами и переменными. Функция начинается с ключевого  слова “function”, далее передаются переменные внутри скобок: (“number” - переменная), с помощью ключевого слова “return” возвращается значение. Над возвращаемыми значениями можно произвести следующие операции: +, -, /, *, %. Так же помимо переменных могут использоваться числа типа int.";
            form.Show();
        }
        private void грамматикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Грамматика";
            form.richTextBox1.Text = "1.FUNCTION> -> ‘function’ OPEN. \n2.OPEN-> ‘(’ ARGUMENTS \n3.ARGUMENTS-> ‘)’ OPENFUNC | letter ARGUMENTSREM \n4.ARGUMENTSREM →  letter ARGUMENTSREM | ‘,’ ARGUMENTS \n5.OPENFUNC-> ‘{’ RETURN \n6.RETURN-> ‘return’ ARITHEXPR ‘;’  CLOSEFUNC \n7.ARITHEXPR -> TA \n8.A -> E | ‘+’ TA | ‘-’TA \n9.T -> OB \n10.B -> E | ‘*’OB| ‘/’ OB \n11. O -> num | id | ‘(’ ARITHEXPR ‘)’ \n12.CLOSEFUNC -> ‘}’ END \n13.END -> ‘;’ \nnum → digit{digit}" +
                "num → digit{digit} \ndigit → 0|...|9 \nid → letter{letter} \nletter → A|...|Z|a|...|z \nZ = FUNCTION – начальный нетерминальный символ \nVT = {(, ), {, }, , , ;, A,…,Z, a,…,z, 0...9, +, -, *, /} - словарь терминальных символов \nVN = {FUNCTION, OPEN, ARGUMENTS, ARGUMENTSREM, OPENFUNC, RETURN, ARITHEXPR, A, T, B, O, CLOSEFUNC, END} – словарь нетерминальных символов";
            form.Show();
        }

        private void классификацияГрамматикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Классификация грамматики";
            form.richTextBox1.Text = "Н. Хомский выделил четыре класса грамматик: грамматики нулевого типа, контекстно-зависимые, контекстно-свободные и автоматные грамматики. Вид грамматики определяется исходя из формы записи ее правил. \nСогласно приведённым выше правилам, грамматика G[FUNCTION] является  контекстно-свободной грамматикой.";
            form.Show();
        }

        private void методАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Метод анализа";
            form.richTextBox1.Text = "Так как данная грамматика относится к классу контекстно-свободных, анализ реализован методом рекурсивного спуска. Идея метода заключается в том, что каждому нетерминалу ставится в соответствии, программная функция которая распознает цепочку, порождённую этим нетерминалом. Эти функции вызываются в соответствии с правилами грамматики и иногда вызывают сами себя.Поэтому для реализации необходимо выбрать язык С#.";
            form.Show();
        }

        private void тестовыйПримерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Тестовый пример";
            form.richTextBox1.Text = "function (number) { \n return number * number; \n};";
            form.Show();
        }

        private void списокЛитературыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Список летиратуры";
            form.richTextBox1.Text = "1.Теория формальных языков и компиляторов [Электронный ресурс]/ Электрон. дан. URL: https://dispace.edu.nstu.ru/didesk/course/show/8594, свободный. Яз.рус. (дата обращения 08.04.2024). \n2.Gries D.Designing Compilers for Digital Computers. New York, Jhon Wiley, 1971. 493 p. \n3.Основы JavaScript | Создание функции[Электронный ресурс] / Электрон.дан. \nURL: https://metanit.com/php/tutorial/2.4.php, свободный. Яз.рус. (дата обращения 12.03.2024). \n4.Шорников Ю.В.Теория и практика языковых процессоров : учеб.пособие / Ю.В.Шорников. – Новосибирск: Изд - во НГТУ, 2004.";
            form.Show();
        }

        private void исходныйКодПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Исходный код программы";
            form.richTextBox1.Text = "https://github.com/KamilKhakimov/Lablandiya.git";
            form.Show();
        }
        // Регулярки:
        private void button9_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(richTextBox1.Text, "^[0-9a-zA-Z!@#$%^&:;]+$"))
                richTextBox2.Text = "строка " + richTextBox1.Text + " соответсвует регулярному выражению: [0-9a-zA-Z!@#$%^&:;]";
            else
                richTextBox2.Text = "строка " + richTextBox1.Text + " не соответсвует регулярному выражению: [0-9a-zA-Z!@#$%^&:;]";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(richTextBox1.Text, "^[1|3]+[0-9a-zA-Z]{26,35}$"))
                richTextBox2.Text = "строка " + richTextBox1.Text + " соответсвует регулярному выражению: [1|3]+[0-9a-zA-Z]{26,35}";
            else
                richTextBox2.Text = "строка " + richTextBox1.Text + " не соответсвует регулярному выражению: [1|3]+[0-9a-zA-Z]{26,35}";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(richTextBox1.Text, "^-?(180(/.0+)?|1?[0-7]?[0-9])$"))
                    richTextBox2.Text = "строка " + richTextBox1.Text + " соответсвует регулярному выражению: #[0-9A-Fa-f]{3}";
            else
                richTextBox2.Text = "строка " + richTextBox1.Text + " не соответсвует регулярному выражению: #[0-9A-Fa-f]{3}";
        }
    }
}