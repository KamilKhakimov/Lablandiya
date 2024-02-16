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
    }
}
