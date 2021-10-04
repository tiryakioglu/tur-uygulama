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
    public partial class Form6 : Form
    {
        TURSQLClass SQL = new TURSQLClass();
        public string  sonuc, userid;
        public Form6()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            DataGridYenile();
            if (!Directory.Exists(@"C:\duzcetur"))
            {
                Directory.CreateDirectory(@"C:\duzcetur");
            }
            if (!Directory.Exists(@"C:\duzcetur\db_yedek"))
            {
                Directory.CreateDirectory(@"C:\duzcetur\db_yedek");
            }

        }

        public void DataGridYenile()
        {
            dataGridView2.DataSource = SQL.TurKullaniciTablo();

        }
        public void satirDegisti()
        {
            textBox1.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
            userid = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SQL.TurMusteriTabloGetir();
            TextWriter writer = new StreamWriter(@"C:\duzcetur\turmusteri.txt");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write("," + dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }

                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Data Exported");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader SW = new StreamReader(@"C:\duzcetur\turmusteri.txt");
            string satir;
            int say = 0;
            while ((satir = SW.ReadLine()) != null)
            {
                string[] hobiListe = satir.Split(',');

                    SQL.TurMusteriEkle(hobiListe[1], hobiListe[2], Convert.ToDateTime(hobiListe[3]));

                say = say + 1;
            }
            SW.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = SQL.TurDetayTabloGetir();
            TextWriter writer = new StreamWriter(@"C:\duzcetur\turdetay.txt");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write("," + dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }

                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Data Exported");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader SW = new StreamReader(@"C:\duzcetur\turdetay.txt");
            string satir;
            int say = 0;
            while ((satir = SW.ReadLine()) != null)
            {
                string[] hobiListe = satir.Split(',');
                
                SQL.TurDetayEkle(hobiListe[1], hobiListe[2], hobiListe[3], hobiListe[4], hobiListe[5], hobiListe[6], Convert.ToDateTime(hobiListe[7]));
                say = say + 1;
            }
            SW.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = SQL.TurPersonelTabloGetir();
            TextWriter writer = new StreamWriter(@"C:\duzcetur\turpersonel.txt");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        writer.Write("," + dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }

                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Data Exported");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StreamReader SW = new StreamReader(@"C:\duzcetur\turpersonel.txt");
            string satir;
            int say = 0;
            while ((satir = SW.ReadLine()) != null)
            {
                string[] hobiListe = satir.Split(',');
                
                SQL.TurPersonelEkle(hobiListe[1], hobiListe[2], hobiListe[3], hobiListe[4],  Convert.ToDateTime(hobiListe[6]), Convert.ToDateTime(hobiListe[7]));
                say = say + 1;
            }
            SW.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

           SQL.KullaniciSil(userid);
            DataGridYenile();
        }

        private void dataGridView2_MouseUp(object sender, MouseEventArgs e)
        {
            satirDegisti();
        }

        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            satirDegisti();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQL.Dbyedekle();
            MessageBox.Show("DB Yedeklendi");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SQL.Dbyedekyukle(listBox1.GetItemText(listBox1.SelectedItem));
            MessageBox.Show("DB Yüklendi");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //listBox1'in içinde bulunan Item'ları
            //Items.Clear() methodu ile temizliyoruz.
            listBox1.Items.Clear();
            //Daha sonra DirectoryInfo tipinden bir değişken oluşturup,
            //içindeki dosyaları okumak istediğimiz klasörün dizin bilgisini veriyoruz.
            string path = @"C:\duzcetur\db_yedek";
            DirectoryInfo di = new DirectoryInfo(path);
            //FileInfo tipinden bir değişken oluşturuyoruz.
            //çünkü di.GetFiles methodu, bize FileInfo tipinden bir dizi dönüyor.
            FileInfo[] rgFiles = di.GetFiles();
            //foreach döngümüzle fgFiles içinde dönüyoruz.
            foreach (FileInfo fi in rgFiles)
            {
                //fi.Name bize dosyanın adını dönüyor.
                //fi.FullName ise bize dosyasının dizin bilgisini döner.
                listBox1.Items.Add(fi.Name);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "admin")
            {

                sonuc = SQL.TurKullaniciEkle(textBox1.Text, textBox2.Text, checkBox1.Checked ? 1 : 0, checkBox2.Checked ? 1 : 0, checkBox3.Checked ? 1 : 0, checkBox4.Checked ? 1 : 0);
                DataGridYenile();
                if (sonuc == "1")
                {
                    MessageBox.Show("Kullanıcı eklendi");
                }
                else
                    MessageBox.Show("Kullanıcı adı zaten kayıtlı.");
            }
            
        }
    }
}
