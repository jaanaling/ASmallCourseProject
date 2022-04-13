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
    public partial class rem : Form
    {
        public rem()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            m.Location = this.Location;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Строка пустая", "Внимание!");
                return;
            }
            string id = textBox6.Text;
            if (getId(id) != 0)
            {
                removeBook(id);
                View();
                MessageBox.Show("Данные удалены");
            }
            else
            {
                MessageBox.Show("Данные не верны");
            }
        }
        private void rem_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
            this.ForeColor = Properties.Settings.Default.FontColor;
        
            button2.BackColor = Properties.Settings.Default.ButColor;
            button3.BackColor = Properties.Settings.Default.ButColor;
            label1.ForeColor = Properties.Settings.Default.LabelColor;
            label7.ForeColor = Properties.Settings.Default.LabelColor;
            dataGridView1.ForeColor = Properties.Settings.Default.DGVColor;

            View();
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
        public void removeBook(string id)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                DataSet dataSet = new DataSet();
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("DELETE FROM books WHERE Id = " + id, connection);
                mySqlDataAdapter.Fill(dataSet);
                connection.Close();

            }
            catch (Exception ex) { MessageBox.Show("Загрузка не завершенна\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
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
