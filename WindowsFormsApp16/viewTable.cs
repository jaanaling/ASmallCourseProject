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
    public partial class viewTable : Form
    {
        public viewTable()
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

        private void viewTable_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
            this.ForeColor = Properties.Settings.Default.FontColor;
            dataGridView1.BackColor = Properties.Settings.Default.DGVColor;
            dataGridView1.ForeColor = Properties.Settings.Default.DGVFontColor;
            button2.BackColor = Properties.Settings.Default.ButColor;

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
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular);
        }
    }
}
