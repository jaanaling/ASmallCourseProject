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
    public partial class chang : Form
    {
        public chang()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            m.Location = this.Location;
            this.Hide();
        }

        private void chang_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
            this.ForeColor = Properties.Settings.Default.FontColor;
            button1.BackColor = Properties.Settings.Default.ButColor;
            button2.BackColor = Properties.Settings.Default.ButColor;
            button3.BackColor = Properties.Settings.Default.ButColor;
            label1.ForeColor = Properties.Settings.Default.LabelColor;
            label2.ForeColor = Properties.Settings.Default.LabelColor;
            label3.ForeColor = Properties.Settings.Default.LabelColor;
            label4.ForeColor = Properties.Settings.Default.LabelColor;
            label5.ForeColor = Properties.Settings.Default.LabelColor;
            label6.ForeColor = Properties.Settings.Default.LabelColor;
            label7.ForeColor = Properties.Settings.Default.LabelColor;
            checkBox1.ForeColor = Properties.Settings.Default.LabelColor;
            dataGridView1.ForeColor = Properties.Settings.Default.DGVColor;
            View();
        }
        void View()
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                DataSet dataSet = new DataSet();
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("SELECT * FROM books", connection);
                mySqlDataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                connection.Close();

            }
            catch (Exception ex) { MessageBox.Show("Загрузка не завершенна\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Введите id книги");
            }
            else
            {
                if (getId(textBox6.Text) != 0)
                {
                    getStrings(textBox6.Text);

                    button3.Visible = false;
                    label7.Visible = false;
                    textBox6.Visible = false;
                    dataGridView1.Visible = false;


                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    checkBox1.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;

                    button1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                }

            }
        }
        public void setbook(string id, string title, string author, string year, string name, string term, string taken)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                DataSet dataSet = new DataSet();
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("UPDATE books SET title = '" + title + "', author = '" + author + "', year = '" + year + "', name ='" + name + "', term ='" + term + "', taken ='" + taken + "' WHERE Books.Id = " + id, connection);
                mySqlDataAdapter.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Строка успешно обновлена");
            }
            catch (Exception ex) { MessageBox.Show("Загрузка не завершенна\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public int getId(string id)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT Id FROM books where Id='" + id + "' ", connection);
                connection.Open();
                int Id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return Id;
            }
            catch { return 0; }
        }
        public void getStrings(string id)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT title FROM books where Id='" + id + "' ", connection);
                SqlCommand command2 = new SqlCommand("SELECT author FROM books where Id='" + id + "' ", connection);
                SqlCommand command3 = new SqlCommand("SELECT year FROM books where Id='" + id + "' ", connection);
                SqlCommand command4 = new SqlCommand("SELECT name FROM books where Id='" + id + "' ", connection);
                SqlCommand command5 = new SqlCommand("SELECT term FROM books where Id='" + id + "' ", connection);
                SqlCommand command6 = new SqlCommand("SELECT taken FROM books where Id='" + id + "' ", connection);
                connection.Open();
                string check = Convert.ToString(command6.ExecuteScalar());
                textBox1.Text = Convert.ToString(command.ExecuteScalar());
                textBox2.Text = Convert.ToString(command2.ExecuteScalar());
                textBox3.Text = Convert.ToString(command3.ExecuteScalar());
                textBox4.Text = Convert.ToString(command5.ExecuteScalar());
                textBox5.Text = Convert.ToString(command4.ExecuteScalar());
                if (check=="Да")
                {
                    checkBox1.Checked = true;
                }
                connection.Close();

            }
            catch { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
            textBox3.Text == null )

            {
                MessageBox.Show("Строка пустая", "Внимание!");
                return;
            }
            string id = textBox6.Text;
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

            setbook(id, title, author, year, name, term, taken);

            button3.Visible = true;
            label7.Visible = true;
            textBox6.Visible = true;
            dataGridView1.Visible = true;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button1.Visible = false;
            checkBox1.Visible = false;

            View();
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
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
        }
    }
   
}
