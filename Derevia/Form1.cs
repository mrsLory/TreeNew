using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Derevia
{
    public partial class Form1 : Form
    {
        public static bool StringIsValid(string str)
        {
            return !string.IsNullOrEmpty(str) && !Regex.IsMatch(str, @"[^a-z]");
        }
        private bool proverka = false; //проверка добавлять в массив или нет
        private string[] massivstrok = new string[0]; // массив слов
        public void Vstavka(string i)
        {
            if (proverka == false) // если проверка false, то слово будет добавляться в массив
            {
                Array.Resize(ref massivstrok, massivstrok.Length + 1);
                massivstrok[massivstrok.Length - 1] = i;
                pt1.Insert1(i.ToLower());
                pt2.Insert2(i);
                pt3.Insert3(i);
                pt4.Insert4(i);

            }
            if (proverka == true) // если true, то слово не добавляется в массив
            {
                pt1.Insert1(i.ToLower());
                pt2.Insert2(i);
                pt3.Insert3(i);
                pt4.Insert4(i);

            }
        }
        public void VstavkaFaila(string a)
        {
            string text;
            using (StreamReader sr = new StreamReader(a))
            {
                text = sr.ReadToEnd();
            }
            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r', '-' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < t.Length; i++)
            {
                Vstavka(t[i].ToLower());
            }
        }
        private readonly string filename1 = "../../Tests/Python.txt";
        private readonly string filename2 = "../../Tests/C.txt";
        private readonly string filename3 = "../../Tests/CSH.txt";
        private readonly string filename4 = "../../Tests/Java.txt";
        private readonly string filename5 = "../../Tests/100000.txt";
        private readonly string filename6 = "../../Tests/10000.txt";
        private readonly string filename7 = "../../Tests/1000.txt";
        private readonly string filename8 = "../../Tests/100.txt";
        private readonly string filename9 = "..\\..\\Вывод"; //путь на папку вывода 
        private readonly string filename10 = "..\\..\\Вывод\\Вывод.txt"; //путь на вывод
        private int fals;
        public string Adres
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public Form1()
        {
            Directory.CreateDirectory(filename9); //создаёт папку где будет храниться вывод
            MessageBox.Show("Добро пожаловать в программу, предназначенную для работы с деревьями. Вы можете добавлять, удалять и искать слова, загружать готовые библиотеки и словари, и работать с ними. Если у вас появился вопрос, связанный с работой программы, или вы хотите посмотреть все добавленные слова, вы можете найти на него ответ в 'Справке', кнопка вызова которой находится в правой верхней часте программы. Внимание! Помните, программа может взаимодействовать только со словами, написанными только английскими буквами, без любых знаков и пробелов.");
            InitializeComponent();
        }
        private Trie pt1 = new Trie();
        private TST pt2 = new TST();
        private DST pt3 = new DST();
        private BST pt4 = new BST();
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label2.Visible = false;
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                MessageBox.Show("Данное слово успешно добавлено");
                Vstavka(richTextBox1.Text);
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label2.Visible = false;
            List<string> list = massivstrok.Cast<string>().ToList();//удаление слова из листа и перевод в массив
            list.Remove(richTextBox1.Text);                //удаление слова из листа и перевод в массив
            massivstrok = list.ToArray();                  //удаление слова из листа и перевод в массив
            fals = 0;
            fals += pt1.Delete1(richTextBox1.Text);
            fals += pt2.Delete2(richTextBox1.Text);
            fals += pt3.Delete3(richTextBox1.Text);
            fals += pt4.Delete4(richTextBox1.Text);
            if (fals == 0) { MessageBox.Show("Данное слово отсутствует в дереве"); }
            else { MessageBox.Show("Данное слово успешно удалено"); }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                System.Diagnostics.Stopwatch elapsedTime = System.Diagnostics.Stopwatch.StartNew();
                pt1.Search1(richTextBox1.Text);
                for (int i = 0; i < 2500; i++)
                {
                    fals = pt1.Search1(richTextBox1.Text);
                }
                elapsedTime.Stop();
                textBox1.Visible = true;
                label2.Visible = true;
                textBox1.Text = ((elapsedTime.Elapsed.TotalMilliseconds / 2500).ToString());
            }
            if (radioButton2.Checked)
            {
                System.Diagnostics.Stopwatch elapsedTime = System.Diagnostics.Stopwatch.StartNew();
                pt2.Search2(richTextBox1.Text);
                for (int i = 0; i < 2500; i++)
                {
                    fals = pt2.Search2(richTextBox1.Text);
                }
                elapsedTime.Stop();
                textBox1.Visible = true;
                label2.Visible = true;
                textBox1.Text = ((elapsedTime.Elapsed.TotalMilliseconds / 2500).ToString());
            }
            if (radioButton3.Checked)
            {
                System.Diagnostics.Stopwatch elapsedTime = System.Diagnostics.Stopwatch.StartNew();
                pt3.Search3(richTextBox1.Text);
                for (int i = 0; i < 2500; i++)
                {
                    fals = pt3.Search3(richTextBox1.Text);
                }
                elapsedTime.Stop();
                textBox1.Visible = true;
                label2.Visible = true;
                textBox1.Text = ((elapsedTime.Elapsed.TotalMilliseconds / 2500).ToString());
            }
            if (radioButton4.Checked)
            {
                System.Diagnostics.Stopwatch elapsedTime = System.Diagnostics.Stopwatch.StartNew();
                pt4.Search4(richTextBox1.Text);
                for (int i = 0; i < 2500; i++)
                {
                    fals = pt4.Search4(richTextBox1.Text);
                }
                elapsedTime.Stop();
                textBox1.Visible = true;
                label2.Visible = true;
                textBox1.Text = ((elapsedTime.Elapsed.TotalMilliseconds / 2500).ToString());
            }
            if (fals == 0) { MessageBox.Show("Данное слово отсутсвует в дереве"); }
            else { MessageBox.Show("Данное слово присутствует в дереве"); }
        }
        private void ЗагрузитьБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proverka = true; //устанавливает true, чтобы слова не добавлялись в массив
            Array.Resize<string>(ref massivstrok, 0); //отчистит массив
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename1); //занесёт все слова из файла в массив
            VstavkaFaila(filename1);
            proverka = false;//устанавливает true, чтобы слова не добавлялись в массив
        }
        private void ЗагрузитьБибиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proverka = true;
            Array.Resize<string>(ref massivstrok, 0);
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename3);
            VstavkaFaila(filename3);
            proverka = false;
        }
        private void ЗагрузитьБиблиотекуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            proverka = true;
            Array.Resize<string>(ref massivstrok, 0);
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename2);
            VstavkaFaila(filename2);
            proverka = false;
        }
        private void ЗагрузитьБиблиотекуToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            proverka = true;
            Array.Resize<string>(ref massivstrok, 0);
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename4);
            VstavkaFaila(filename4);
            proverka = false;
        }
        private void ДобавитьСловоВБиблиоткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text.ToLower();
                using (StreamWriter sw = new StreamWriter(filename1, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }
        }
        private void ДобавитьСловоВБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text;
                using (StreamWriter sw = new StreamWriter(filename3, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }
        }
        private void ДобавитьФайлВБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text;
                using (StreamWriter sw = new StreamWriter(filename2, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }
        }
        private void ДобавитьСловоВБиблиотекуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text;
                using (StreamWriter sw = new StreamWriter(filename4, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }
        }
        private void УдалитьСловоИзБиблиотекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Queue q = new Queue();
            string text;
            using (StreamReader sr = new StreamReader(filename1)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }
            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив
            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }
            using (StreamWriter sw = new StreamWriter(filename1, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }
        private void УдалитьСловоИзБиблиотекеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Queue q = new Queue();
            string text;
            using (StreamReader sr = new StreamReader(filename3)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }
            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив
            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }
            using (StreamWriter sw = new StreamWriter(filename3, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }
        private void УдалитьСловоИзБиблиотекиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Queue q = new Queue();
            string text;
            using (StreamReader sr = new StreamReader(filename2)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }
            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив
            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }
            using (StreamWriter sw = new StreamWriter(filename2, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }
        private void УдалитьСловоИзБиблиотекиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Queue q = new Queue();
            string text;
            using (StreamReader sr = new StreamReader(filename4)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }
            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив
            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }
            using (StreamWriter sw = new StreamWriter(filename4, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }
        private void ПитонToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<string> result = massivstrok.Distinct(); //удаляет одинаковые слова
            massivstrok = result.ToArray();//превращает list в массив

            int schet = 1; //указыват порядковый номер слова
            using (StreamWriter writer = new StreamWriter(filename10)) //создает или редактирует файл вывода
            {
                writer.WriteLine("Все ранее добавленные слова:");
                foreach (string stroka in massivstrok) //пока есть слова в массиве
                {
                    writer.WriteLine(schet + ". " + stroka); //добавляет строку
                    schet++; //увеличивает порядковый номер на 1
                }
            }
            System.Diagnostics.Process.Start(filename10);//открывает файл
            Form ifrm = new Form2();
            ifrm.Show(); // отображаем Form2
        }
        private void СловToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Array.Resize<string>(ref massivstrok, 0); //уже описано в первом случае
            proverka = true;
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename6);
            VstavkaFaila(filename6);
            proverka = false;
        }
        private void СловToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Array.Resize<string>(ref massivstrok, 0);
            proverka = true;
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename5);
            VstavkaFaila(filename5);
            proverka = false;
        }
        private void СловToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            proverka = true;
            Array.Resize<string>(ref massivstrok, 0);
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename7);
            VstavkaFaila(filename7);
            proverka = false;
        }
        private void СловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proverka = true;
            Array.Resize<string>(ref massivstrok, 0);
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();
            massivstrok = File.ReadAllLines(filename8);
            VstavkaFaila(filename8);
            proverka = false;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
