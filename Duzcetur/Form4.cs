using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Duzcetur
{
    public partial class Form4 : Form
    {
        TURSQLClass SQL = new TURSQLClass();
        public string musteriid;
        public Form4()
        {
            InitializeComponent();
            DataGridYenile();
        }

        public void DataGridYenile()
        {
            dataGridView1.DataSource = SQL.TurMusteriTabloGetir();

        }
        public void satirDegisti()
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            musteriid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            //datetimepicker guncelle
            char[] ayrac = { '.', ' ', ':' };
            string tarih = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            string[] parcalar = tarih.Split(ayrac);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Value = new DateTime(Int32.Parse(parcalar[2]), Int32.Parse(parcalar[1]), Int32.Parse(parcalar[0]));
            //datetimepicker guncelle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Musteri Ekleme
            SQL.TurMusteriEkle(textBox1.Text, textBox2.Text, dateTimePicker1.Value);
            DataGridYenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Musteri Silme
            SQL.TurMusteriSil(musteriid);
            DataGridYenile();
            //Mustteri sildikten sonra butonları deaktif etme
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            //Musteri Guncelleme
            SQL.TurMusteriGuncelle(textBox1.Text, textBox2.Text,  dateTimePicker1.Value, musteriid);
            DataGridYenile();
            //Musteri guncelledikten sonra butonları deaktif etme
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SQL.TurMusteriAra(textBox3.Text, textBox4.Text, dateTimePicker2.Value, checkBox1.Checked);
        }

       
    }
}
