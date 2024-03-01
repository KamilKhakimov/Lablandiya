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
        //public List<string> buf_last = new List<string> {};
        //public List<string> buf_next = new List<string> {};
        //public int last = 0;
        //public int next = 0;
        public Form1()
        {
            InitializeComponent();
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            fileItem.DropDownItems.Add("Создать");
            //menuStrip4_ItemClicked.Items.Add(fileItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            string[] keywords = { "if", "else", "while", "for", "switch", "case", "break", "default", "return" };
            int start = richTextBox1.SelectionStart;
            foreach (string keyword in keywords)
            {
                int index = 0;
                while (index < richTextBox1.Text.Length)
                {
                    int startIndex = richTextBox1.Find(keyword, index, RichTextBoxFinds.WholeWord);
                    if (startIndex == -1)
                    {
                        break;
                    }
                    richTextBox1.SelectionStart = startIndex;
                    richTextBox1.SelectionLength = keyword.Length;
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                    index = startIndex + keyword.Length;
                }
            }
            richTextBox1.SelectionStart = start;

            richTextBox1.SelectionColor = Color.Black;
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
        // Увеличение и уменьшение текста
        public void IncreaseFontIOText()
        {
            ChangeFont(this.richTextBox1, 1.2f);
            ChangeFont(this.richTextBox1, 1.2f);
        }
        public void DecreaseFontIOText()
        {
            ChangeFont(this.richTextBox1, 10f / 12f);
            ChangeFont(this.richTextBox1, 10f / 12f);
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
            if(a.ShowDialog() == DialogResult.OK)
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
                fs.Read(buffer,0,buffer.Length);
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
            {

            }
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
                //Извлекаем (точнее копируем) его и сохраняем в переменную
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

        }

        private void button7_Click(object sender, EventArgs e)
        {

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
            if(substr != "") { 
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
                    default:
                        {
                            int num = 7;
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
            else
            {
                return 11;
            }
        }
         
        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary <string, int> a  = new Dictionary<string, int>();
            string str = Regex.Replace(richTextBox1.Text, @"[\r]", " ");
            string[] t = str.Split(' ');
            bool test = true;
            int start = 0;
            int numbers = 1;
            foreach (string st in t)
            {
                int end = start + st.Length;
                string type = "";
                int key = check(st);
                if (key == 0)
                {
                    richTextBox2.Text = richTextBox2.Text + "Error: " + st+ "\n";
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
                } else if (key == 2)
                {
                    if(a.ContainsKey("("))
                    {
                        a["("] = a["("] + 1;
                    } else
                    {
                        a["("] = 1;
                    }
                    type = "(";
                }
                else  if (key == 3) {
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
                //out
                richTextBox2.Text = richTextBox2.Text + $"Code: {key} - {type} - {st} - c {start} до {end} символы\n";
                start = end;
                numbers++;
            }
        }
    }
}
