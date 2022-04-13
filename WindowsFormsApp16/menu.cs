using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewTable v = new viewTable();
            v.Show();
            v.Location = this.Location;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add a = new add();
            a.Show();
            a.Location = this.Location;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chang c = new chang();
            c.Show();
            c.Location = this.Location;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rem r = new rem();
            r.Show();
            r.Location = this.Location;
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            f1.Location = this.Location;
            this.Hide();

        }

        private void menu_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
            this.ForeColor = Properties.Settings.Default.FontColor;
            button1.BackColor = Properties.Settings.Default.ButColor;
            button2.BackColor = Properties.Settings.Default.ButColor;
            button3.BackColor = Properties.Settings.Default.ButColor;
            button4.BackColor = Properties.Settings.Default.ButColor;
            button5.BackColor = Properties.Settings.Default.ButColor;
            button6.BackColor = Properties.Settings.Default.ButColor;
            label1.ForeColor = Properties.Settings.Default.LabelColor;

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
            button3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
        }
    }
}
