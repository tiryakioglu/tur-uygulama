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
    public partial class Form2 : Form
    {
        TURSQLClass SQL = new TURSQLClass();
        public string ozelturid,ozelturidara = "",personelidara = "",sonuc, detaypersonelid;
         
        public Form2()
        {
            InitializeComponent();
            DataGridYenile();
            comboBox1.DataSource = SQL.Turcombo();
            comboBox1.DisplayMember = "turtur";
            comboBox1.ValueMember = "turid";
            comboBox2.DataSource = SQL.Turcombo2();
            comboBox2.DisplayMember = "turtur";
            comboBox2.ValueMember = "turid";
            comboBox6.DataSource = SQL.Turcombo2();
            comboBox6.DisplayMember = "turtur";
            comboBox6.ValueMember = "turid";
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            dateTimePicker4.Enabled = false;
            dateTimePicker6.Enabled = false;
            dateTimePicker7.Enabled = false;
            comboBox5.Items.Add("");
            comboBox5.Items.Add("Mudur");
            comboBox5.Items.Add("Şoför");
            comboBox5.Items.Add("Muavin");
            comboBox5.Items.Add("Rehber");
            dataGridView3.DataSource = SQL.TurDetayPAra(textBox11.Text, textBox10.Text, textBox9.Text, dateTimePicker4.Value, checkBox2.Checked);

        }

        public void DataGridYenile()
        {
            dataGridView1.DataSource = SQL.TurDetayTabloGetir();
        }
        public void satirDegisti()
        {
            comboBox1.SelectedValue = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            ozelturid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            //datetimepicker guncelle
            char[] ayrac = { '.', ' ', ':' };
            string tarih = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            string[] parcalar = tarih.Split(ayrac);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Value = new DateTime(Int32.Parse(parcalar[2]), Int32.Parse(parcalar[1]), Int32.Parse(parcalar[0]), Int32.Parse(parcalar[3]), Int32.Parse(parcalar[4]), 00);
            //datetimepicker guncelle
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            satirDegisti();
            //tabloda secim yapinca butonları aktif ediyoruz
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            satirDegisti();
            //tabloda secim yapinca butonları aktif ediyoruz
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Detaylı Tur Ekleme
            SQL.TurDetayEkle(comboBox1.SelectedValue.ToString(), textBox1.Text, textBox4.Text, richTextBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value );
            DataGridYenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Detaylı Tur Silme
            SQL.TurDetaySil(ozelturid);
            DataGridYenile();
            //Turu sildikten sonra butonları deaktif etme
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Detaylı Tur Guncelleme
                        if (dateTimePicker1.Value != Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value))
            {
                DialogResult dialogResult = MessageBox.Show("Tarih değiştirildiği için görevli personel turdan kaldırılacak.\n \t\t  Güncellensin mi?", "Dikkat!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.TurDetayGuncelle(comboBox1.SelectedValue.ToString(), textBox1.Text, textBox4.Text, richTextBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, ozelturid);
                }
            }
            else
            {
                SQL.TurDetayGuncelle(comboBox1.SelectedValue.ToString(), textBox1.Text, textBox4.Text, richTextBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, ozelturid);
            }
            DataGridYenile();
            //Turu guncelledikten sonra butonları deaktif etme
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SQL.TurDetayAra(comboBox2.SelectedValue.ToString() , textBox5.Text, textBox8.Text, textBox6.Text, textBox7.Text, dateTimePicker2.Value , dateTimePicker3.Value, checkBox1.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
            }
            else
            {
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = SQL.TurPersonelAra(textBox16.Text, textBox15.Text, comboBox5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = SQL.TurDetayAra(comboBox6.SelectedValue.ToString(), textBox20.Text, textBox17.Text, textBox19.Text, textBox18.Text, dateTimePicker7.Value, dateTimePicker6.Value, checkBox3.Checked);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                dateTimePicker6.Enabled = true;
                dateTimePicker7.Enabled = true;
            }
            else
            {
                dateTimePicker6.Enabled = false;
                dateTimePicker7.Enabled = false;
            }
        }

        private void dataGridView5_KeyUp(object sender, KeyEventArgs e)
        {
            ozelturidara = dataGridView5.Rows[dataGridView4.CurrentRow.Index].Cells[5].Value.ToString();
            button9.Enabled = true;
        }

        private void dataGridView5_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            ozelturidara = dataGridView5.Rows[dataGridView5.CurrentRow.Index].Cells[0].Value.ToString();
            button9.Enabled = true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            dataGridView3.DataSource = SQL.TurDetayPAra(textBox11.Text, textBox10.Text, textBox9.Text, dateTimePicker4.Value, checkBox2.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQL.TurDetayPSil(detaypersonelid);
        }

        private void dataGridView3_KeyUp(object sender, KeyEventArgs e)
        {
            detaypersonelid = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            detaypersonelid = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ozelturidara == "")
            {
                MessageBox.Show("Tur Seçiniz!");
            }
            else
            {
                if (personelidara == "")
                {
                    MessageBox.Show("Müşteri Seçiniz!");
                }
                else
                {
                    sonuc = SQL.TurDetayPEkle(ozelturidara, personelidara);
                    if (sonuc == "1")
                    {
                        MessageBox.Show("Personel tura eklendi");
                        button9.Enabled = false;
                    }
                    else
                        MessageBox.Show("Personel tur tarihleri arasında farklı bir turda çalışıyor.");

                }
            }
        }

        private void dataGridView4_KeyUp(object sender, KeyEventArgs e)
        {
            personelidara = dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value.ToString();
            button9.Enabled = true;
        }

        private void dataGridView4_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            personelidara = dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value.ToString();
            button9.Enabled = true;
        }
    }
}
