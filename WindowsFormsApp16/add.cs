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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            m.Location = this.Location;
            this.Hide();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            getСBox();
        }
        void getСBox()
        {
            if (checkBox1.Checked == true)
            {
                textBox4.Visible = true;
                textBox5.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            else
            {
             textBox4.Visible = false;
             textBox5.Visible = false;
             label5.Visible = false;
             label6.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null ||
              textBox2.Text == null ||
              textBox3.Text == null 
             )
            {
                MessageBox.Show("Строка пустая", "Внимание!");
                return;
            }

            string title = textBox1.Text;
            string author = textBox2.Text;
            string year = textBox3.Text;
            string name = textBox4.Text;
            string term = textBox5.Text;

            string taken;
            if (checkBox1.Checked == true)
            {
                taken = "Да";
            }
            else
            {
                taken = "Нет";

            }

                setbook(title, author, year, name, term, taken);
        }
        public void setbook(string title, string author, string year, string name, string term, string taken)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                DataSet dataSet = new DataSet();
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("INSERT INTO Books (title, author, year,name, term, taken) VALUES ('" + title + "', '" + author + "', '" + year + "', '" + name + "', '" + term + "', '" + taken + "');", connection);
                mySqlDataAdapter.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Строка успешно добавлена");
            }
            catch (Exception ex) { MessageBox.Show("Загрузка не завершенна\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void add_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
            this.ForeColor = Properties.Settings.Default.FontColor;
            button1.BackColor = Properties.Settings.Default.ButColor;
            button2.BackColor = Properties.Settings.Default.ButColor;
         
            label1.ForeColor = Properties.Settings.Default.LabelColor;
            label2.ForeColor = Properties.Settings.Default.LabelColor;
            label3.ForeColor = Properties.Settings.Default.LabelColor;
            label4.ForeColor = Properties.Settings.Default.LabelColor;
            label5.ForeColor = Properties.Settings.Default.LabelColor;
            label6.ForeColor = Properties.Settings.Default.LabelColor;
          
            checkBox1.ForeColor = Properties.Settings.Default.LabelColor;
      
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
        }
    }
    
}
