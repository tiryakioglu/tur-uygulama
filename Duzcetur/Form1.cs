using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duzcetur
{
    public partial class Form1 : Form
    {
        TURSQLClass SQL = new TURSQLClass();
        public string userid, userpass;
        public int turdetay, turmusteri, turpersonel, tursatis;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            textBox2.PasswordChar = '*';
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = SQL.UserLogin(textBox1.Text, textBox2.Text);
            userpass = dataGridView1.Rows[0].Cells[2].Value.ToString();
            turdetay = Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value);
            turmusteri = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
            turpersonel = Convert.ToInt32(dataGridView1.Rows[0].Cells[5].Value);
            tursatis = Convert.ToInt32(dataGridView1.Rows[0].Cells[6].Value);
            if (textBox2.Text == userpass
                && userpass != "")
            {
               
                if (turdetay == 1)
                {
                    button1.Enabled = true;
                }
                if (turmusteri == 1)
                {
                    button2.Enabled = true;
                }
                if (turpersonel == 1)
                {
                    button3.Enabled = true;
                }
                if (tursatis == 1)
                {
                    button4.Enabled = true;
                }
                if (textBox1.Text == "admin")
                {
                    button5.Enabled = true;
                }
                button6.Enabled = false;
                groupBox1.Visible = false;
            }
            else
            {
                MessageBox.Show("Bilgiler Hatalı");
            }
        }
    }
}
