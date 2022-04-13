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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                setUser(textBox1.Text, textBox2.Text);
                MessageBox.Show("Вы успешно зарегистрированы");
                Form1 f1 = new Form1();
                f1.Show();
                f1.Location = this.Location;
                this.Hide();
            }
        }
        public void setUser(string login, string password)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                DataSet dataSet = new DataSet();
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("INSERT INTO Users (Login, Password) VALUES ('" + login + "', '" + password + "');", connection);
                mySqlDataAdapter.Fill(dataSet);
                connection.Close();

            }
            catch (Exception ex) { MessageBox.Show("Загрузка не завершенна\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void reg_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
            this.ForeColor = Properties.Settings.Default.FontColor;
            button1.BackColor = Properties.Settings.Default.ButColor;
            label1.ForeColor = Properties.Settings.Default.LabelColor;
            label2.ForeColor = Properties.Settings.Default.LabelColor;
            label3.ForeColor = Properties.Settings.Default.LabelColor;
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
        }
    }
    }

