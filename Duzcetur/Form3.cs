using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Duzcetur
{
    public partial class Form3 : Form
    {
        TURSQLClass SQL = new TURSQLClass();
        public string personelid;
        public Form3()
        {
            InitializeComponent();
            DataGridYenile();
            comboBox1.Items.Add("Mudur");
            comboBox1.Items.Add("Şoför");
            comboBox1.Items.Add("Muavin");
            comboBox1.Items.Add("Rehber");
            comboBox2.Items.Add("");
            comboBox2.Items.Add("Mudur");
            comboBox2.Items.Add("Şoför");
            comboBox2.Items.Add("Muavin");
            comboBox2.Items.Add("Rehber");
        }
        public void DataGridYenile()
        {
            dataGridView1.DataSource = SQL.TurPersonelTabloGetir();
        }
        public void satirDegisti()
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            personelid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());

            //datetimepicker guncelle
            char[] ayrac = { '.', ' ', ':' };
            string tarih = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            string[] parcalar = tarih.Split(ayrac);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Value = new DateTime(Int32.Parse(parcalar[2]), Int32.Parse(parcalar[1]), Int32.Parse(parcalar[0]), Int32.Parse(parcalar[3]), Int32.Parse(parcalar[4]), 00);
            //datetimepicker guncelle
            //datetimepicker guncelle
            char[] ayrac2 = { '.', ' ', ':' };
            string tarih2 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            string[] parcalar2 = tarih2.Split(ayrac2);
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Value = new DateTime(Int32.Parse(parcalar2[2]), Int32.Parse(parcalar2[1]), Int32.Parse(parcalar2[0]), Int32.Parse(parcalar2[3]), Int32.Parse(parcalar2[4]), 00);
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
            SQL.TurPersonelEkle(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            DataGridYenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Detaylı Tur Guncelleme
            SQL.TurPersonelGuncelle(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, personelid);
            DataGridYenile();
            //Turu guncelledikten sonra butonları deaktif etme
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SQL.TurPersonelAra(textBox4.Text, textBox5.Text,comboBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dataGridView1, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ToCsV(DataGridView dgv, string filename)
        {
            string outputStr = string.Empty;
            string headersStr = string.Empty;

            for (int col = 0; col < dgv.Columns.Count; col++)
            {
                headersStr += '\"' + dgv.Columns[col].HeaderText + "\","; // "header",
            }
            outputStr += headersStr + Environment.NewLine; // "header1","header2",[...],CRLF

            for (int row = 0; row < dgv.RowCount; row++)
            {
                string line = string.Empty;
                for (int cell = 0; cell < dgv.Rows[row].Cells.Count; cell++)
                {
                    line += '\"' + Convert.ToString(dgv.Rows[row].Cells[cell].Value) + "\","; // "cellvalue",
                }
                outputStr += line + Environment.NewLine; // "cellvalue1","cellvalue2",[...],CRLF
            }

            Encoding utf16 = Encoding.GetEncoding(1254); //Türkçe karakter kod tablosu
            //Info.CodePage      Info.Name                    Info.DisplayName
            //1254               windows-1254                 Turkish (Windows)
            //28599              iso-8859-9                   Turkish (ISO)
            byte[] output = utf16.GetBytes(outputStr);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(output, 0, output.Length);
                    bw.Flush();
                    bw.Close();
                }
                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQL.TurPersonelSil(personelid);
            DataGridYenile();
            //Personeli sildikten sonra butonları deaktif etme
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
