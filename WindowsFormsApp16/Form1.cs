using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reg r = new reg();
            r.Show();
            r.Location = this.Location;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Не все данные ведены");
            }
            else if (textBox2.Text.Length > 49 || textBox1.Text.Length > 49)
            {
                MessageBox.Show("Введённые данные слишком велеки");
            }
            else
            {
                if (getUser(textBox1.Text, textBox2.Text) != 0)
                {
                    MessageBox.Show("Вход успешно завершен");
                    menu m = new menu();
                    m.Show();
                    m.Location = this.Location;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                }
            }
        }
        public int getUser(string l, string p)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT Id FROM Users where Login='" + l + "' AND Password='" + p + "'", connection);
                connection.Open();
                int id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return id;
            }
            catch { return 0; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Тёмная")
            {
                //присваиваем значение фонового цвета
                this.BackColor = Properties.Settings.Default.BackColor = Color.Black;
                //присваиваем значение шрифта
                this.ForeColor = Properties.Settings.Default.FontColor = Color.White;
                button1.BackColor = Properties.Settings.Default.ButColor = Color.Gray;
                button2.BackColor = Properties.Settings.Default.ButColor = Color.Gray;
                button3.BackColor = Properties.Settings.Default.ButColor = Color.Gray;
                Properties.Settings.Default.DGVColor = Color.Gray;
                Properties.Settings.Default.DGVFontColor = Color.Black;
                label1.ForeColor = Properties.Settings.Default.LabelColor = Color.Wheat;
                label2.ForeColor = Properties.Settings.Default.LabelColor = Color.Wheat;
                label3.ForeColor = Properties.Settings.Default.LabelColor = Color.Wheat;
                Properties.Settings.Default.Save();
            }
            if (comboBox1.Text == "Светлая")
            {
                //присваиваем значение фонового цвета
                this.BackColor = Properties.Settings.Default.BackColor = Color.DarkGray;
                //присваиваем значение шрифта
                this.ForeColor = Properties.Settings.Default.FontColor = Color.Black;
                button1.BackColor = Properties.Settings.Default.ButColor = Color.GhostWhite;
                button2.BackColor = Properties.Settings.Default.ButColor = Color.GhostWhite;
                button3.BackColor = Properties.Settings.Default.ButColor = Color.GhostWhite;
                label1.ForeColor = Properties.Settings.Default.LabelColor = Color.Black;
                label2.ForeColor = Properties.Settings.Default.LabelColor = Color.Black;
                label3.ForeColor = Properties.Settings.Default.LabelColor = Color.Black;
                Properties.Settings.Default.DGVColor = Color.Gray;
                Properties.Settings.Default.DGVFontColor = Color.Black;
                //сохраняем настройки
                Properties.Settings.Default.Save();
            }
            if (comboBox1.Text == "Фиолетовая")
            {
                //присваиваем значение фонового цвета
                this.BackColor = Properties.Settings.Default.BackColor = Color.Indigo;
                //присваиваем значение шрифта
                this.ForeColor = Properties.Settings.Default.FontColor = Color.Pink;
                Properties.Settings.Default.LabelColor = Color.Wheat;
                button1.BackColor = Properties.Settings.Default.ButColor = Color.Indigo;
                button2.BackColor = Properties.Settings.Default.ButColor = Color.Indigo;
                button3.BackColor = Properties.Settings.Default.ButColor = Color.Indigo;
                label1.ForeColor  = Properties.Settings.Default.LabelColor = Color.Pink;
                label2.ForeColor = Properties.Settings.Default.LabelColor = Color.Pink;
                label3.ForeColor = Properties.Settings.Default.LabelColor = Color.Pink;
                Properties.Settings.Default.DGVColor = Color.Gray;
                Properties.Settings.Default.DGVFontColor = Color.Black;
                //сохраняем настройки
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
            this.ForeColor = Properties.Settings.Default.FontColor;
            button1.BackColor = Properties.Settings.Default.ButColor;
            button2.BackColor = Properties.Settings.Default.ButColor;
            button3.BackColor = Properties.Settings.Default.ButColor;
            label1.ForeColor = Properties.Settings.Default.LabelColor;
            label2.ForeColor = Properties.Settings.Default.LabelColor;
            label3.ForeColor = Properties.Settings.Default.LabelColor;
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
        }
    }
}

