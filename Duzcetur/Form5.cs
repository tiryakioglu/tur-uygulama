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
    public partial class Form5 : Form
    {
        TURSQLClass SQL = new TURSQLClass();
        public string musteriid = "",ozelturid = "",sonuc, satisid = "";
        public Form5()
        {
            InitializeComponent();
            comboBox2.DataSource = SQL.Turcombo2();
            comboBox2.DisplayMember = "turtur";
            comboBox2.ValueMember = "turid";
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            DataGridYenile();
        }
        public void DataGridYenile()
        {
            dataGridView3.DataSource = SQL.TurSatisTabloGetir();
        }
        public void satirDegisti()
        {
            
            musteriid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            button3.Enabled = true;
          
        }
        public void satirDegisti2()
        {

            ozelturid = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
            button3.Enabled = true;

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = SQL.TurDetayAra(comboBox2.SelectedValue.ToString(), textBox5.Text, textBox8.Text, textBox6.Text, textBox7.Text, dateTimePicker2.Value, dateTimePicker3.Value, checkBox1.Checked);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SQL.TurMusteriAra(textBox1.Text, textBox2.Text, dateTimePicker1.Value, checkBox2.Checked);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView3.DataSource = SQL.TurSatisAra(textBox3.Text, textBox4.Text, textBox9.Text, dateTimePicker4.Value, checkBox3.Checked);
        }

        private void dataGridView2_KeyUp_1(object sender, KeyEventArgs e)
        {
            satirDegisti2();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            satirDegisti();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            satirDegisti();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQL.TurSatisSil(satisid);
            DataGridYenile();
            button5.Enabled = false;
        }

        private void dataGridView3_KeyUp(object sender, KeyEventArgs e)
        {
            satisid = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString();
            button5.Enabled = true;
        }

        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            satisid = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString();
            button5.Enabled = true;
        }

        private void dataGridView2_CellMouseUp_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            satirDegisti2();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if(ozelturid == "")
            {
                MessageBox.Show("Tur Seçiniz!");
            }
            else {
                if(musteriid == "")
                {
                    MessageBox.Show("Müşteri Seçiniz!");
                }
                else
                {
                    sonuc = SQL.TurSatisEkle(ozelturid, musteriid);
                    if (sonuc == "2")
                    {
                        MessageBox.Show("Satis Basarili");
                        button3.Enabled = false;
                    }
                    else
                        MessageBox.Show("Tur Kapasitesi Doldu,Satis Eklenemedi");
                    MessageBox.Show(sonuc);

                }
            }

        }
    }
}
