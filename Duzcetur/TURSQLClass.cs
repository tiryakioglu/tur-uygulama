using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Duzcetur
{
    class TURSQLClass
    {
        private SqlConnection conn = new SqlConnection("Data Source=7SNMASTER\\SQLEXPRESS;Initial Catalog=tursirket;User ID=sa;Password=123deneme");

        protected void sqlcontrol()
        {
            try { conn.Close(); }
            catch { }
        }
        public DataTable TurDetayTabloGetir()
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select ozelturid , turtur  , turadi , turkapasite , kapasitekalan , TurGun , TurAciklama , TurTarih , turfiyat from [Tur_Detay]", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public void TurDetayEkle (string turtur, string turadi, string turfiyat, string turaciklama, string turkapasite, string turgun, DateTime turtarih )
        {
            sqlcontrol();
            //turdetay ekle
           
                String query = "Insert into  Tur_Detay (turtur,turadi,turfiyat,TurAciklama,TurKapasite,kapasitekalan,TurGun,TurTarih) Values (@turtur,@turadi,@turfiyat, @turaciklama,@turkapasite,@turkapasite,@turgun,@turtarih)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@turtur", turtur);
                    command.Parameters.AddWithValue("@turadi", turadi);
                    command.Parameters.AddWithValue("@turfiyat", turfiyat);
                    command.Parameters.AddWithValue("@turaciklama", turaciklama);
                    command.Parameters.AddWithValue("@turkapasite", turkapasite);
                    command.Parameters.AddWithValue("@turgun", turgun);
                    command.Parameters.AddWithValue("@turtarih", SqlDbType.Date).Value = turtarih;

                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    // Hata Kontrolu
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else //hata yoksa listviewe ekle
                    {
                        
                    }
                }
        }
        public void TurDetayGuncelle(string turtur, string turadi, string turfiyat, string turaciklama, string turkapasite, string turgun, DateTime turtarih, string ozelturid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "UPDATE  Tur_Detay set turtur = @turtur,turadi = @turadi,turfiyat = @turfiyat,TurAciklama = @turaciklama,TurKapasite = @turkapasite,TurGun = @turgun,TurTarih = @turtarih where ozelturid= @ozelturid ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@turtur", turtur);
                command.Parameters.AddWithValue("@turadi", turadi);
                command.Parameters.AddWithValue("@turfiyat", turfiyat);
                command.Parameters.AddWithValue("@turaciklama", turaciklama);
                command.Parameters.AddWithValue("@turkapasite", turkapasite);
                command.Parameters.AddWithValue("@turgun", turgun);
                command.Parameters.AddWithValue("@turtarih", SqlDbType.Date).Value = turtarih;
                command.Parameters.AddWithValue("@ozelturid", ozelturid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }
        public void TurDetaySil(string ozelturid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "DELETE  Tur_Detay where ozelturid= @ozelturid";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@ozelturid", ozelturid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }

        public DataTable TurPersonelTabloGetir()
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT TOP 1000 [personelid],[personelad],[personelsoyad],[personelgorev],[personelmaas],[personelisegiris],[personeldogum] FROM [tursirket].[dbo].[Tur_Personel]", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public DataTable Turcombo()
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT TOP 1000 [turid],[turtur] FROM Tur", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public DataTable Turcombo2()
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT TOP 1000 [turid],[turtur] FROM Tur", conn);
            DataTable tbl = new DataTable();

            adap.Fill(tbl);
            DataRow row = tbl.NewRow();
            row[0] = 0;
            row[1] = "Hepsi";
            tbl.Rows.InsertAt(row, 0);
            conn.Close();
            return tbl;
        }

        public void TurPersonelEkle(string personelad, string personelsoyad, string personelgorev, string personelmaas, DateTime personelisegiris,  DateTime personeldogum)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "Insert into [Tur_Personel]  (personelad,personelsoyad,personelgorev,personelmaas,personelisegiris,personeldogum) Values (@personelad,@personelsoyad,@personelgorev, @personelmaas,@personelisegiris,@personeldogum)";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@personelad", personelad);
                command.Parameters.AddWithValue("@personelsoyad", personelsoyad);
                command.Parameters.AddWithValue("@personelgorev", personelgorev);
                command.Parameters.AddWithValue("@personelmaas", personelmaas);
                command.Parameters.AddWithValue("@personelisegiris", SqlDbType.Date).Value = personelisegiris;
                command.Parameters.AddWithValue("@personeldogum", SqlDbType.Date).Value = personeldogum;

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }
        public void TurPersonelGuncelle(string personelad, string personelsoyad, string personelgorev, string personelmaas, DateTime personelisegiris, DateTime personeldogum, string personelid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "UPDATE  Tur_Personel set personelad = @personelad, personelsoyad = @personelsoyad, personelgorev = @personelgorev, personelmaas = @personelmaas, personelisegiris = @personelisegiris, personeldogum = @personeldogum where personelid= @personelid ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@personelad", personelad);
                command.Parameters.AddWithValue("@personelsoyad", personelsoyad);
                command.Parameters.AddWithValue("@personelgorev", personelgorev);
                command.Parameters.AddWithValue("@personelmaas", personelmaas);
                command.Parameters.AddWithValue("@personelisegiris", SqlDbType.Date).Value = personelisegiris;
                command.Parameters.AddWithValue("@personeldogum", SqlDbType.Date).Value = personeldogum;
                command.Parameters.AddWithValue("@personelid", personelid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }
        public DataTable TurPersonelAra(string personelad,string personelsoyad,string personelgorev)
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT TOP 1000 [personelid],[personelad],[personelsoyad],[personelgorev],[personelmaas],[personelisegiris],[personeldogum] FROM Tur_Personel where  [personelad] LIKE'%" + personelad + "%' and [personelsoyad] LIKE'%" + personelsoyad + "%' and [personelgorev] LIKE'%" + personelgorev + "%' ", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public void TurPersonelSil(string personelid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "DELETE  Tur_Personel where personelid= @personelid";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@personelid", personelid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }
        public DataTable TurMusteriTabloGetir()
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select musteriid ,musteriad ,musterisoyad ,musteridogumtar from Tur_Musteri", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public void TurMusteriEkle(string musteriad, string musterisoyad, DateTime musteridogumtar)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "Insert into Tur_Musteri  (musteriad,musterisoyad,musteridogumtar) Values (@musteriad,@musterisoyad,@musteridogumtar)";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@musteriad", musteriad);
                command.Parameters.AddWithValue("@musterisoyad", musterisoyad);
                command.Parameters.AddWithValue("@musteridogumtar", SqlDbType.Date).Value = musteridogumtar;

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }

        public void TurMusteriSil(string musteriid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "DELETE  Tur_Musteri where musteriid= @musteriid";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@musteriid", musteriid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }

        public void TurMusteriGuncelle(string musteriad, string musterisoyad, DateTime musteridogumtar, string musteriid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "UPDATE  Tur_Musteri set musteriad = @musteriad, musterisoyad = @musterisoyad, musteridogumtar = @musteridogumtar where musteriid= @musteriid ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@musteriad", musteriad);
                command.Parameters.AddWithValue("@musterisoyad", musterisoyad);
                command.Parameters.AddWithValue("@musteridogumtar", SqlDbType.Date).Value = musteridogumtar;
                command.Parameters.AddWithValue("@musteriid", musteriid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }

        public DataTable TurDetayAra(string turtur,string turadi, string turfiyat, string turkapasite, string turgun, DateTime turtarih1, DateTime turtarih2, bool checkbox)
        {
            string turtursql = "", turfiyatsql = "", turkapasitesql = "", turgunsql = "", turtarihsql = "";
            if (checkbox== true)
            {
                turtarihsql = "TurTarih BETWEEN @turtarih1 AND @turtarih2 and";
            }
            
            sqlcontrol();
            conn.Open();
            if (turfiyat != "") { turfiyatsql = "turfiyat = '" + turfiyat + "'  and "; }
            if (turtur != "0") { turtursql = "turtur = '" + turtur + "'  and "; }
            if (turgun != "") { turgunsql = "turgun = '" + turgun + "'  and "; }
            if (turkapasite != "") { turkapasitesql = "TurKapasite = '" + turkapasite + "'  and "; }
            SqlDataAdapter adap = new SqlDataAdapter("select ozelturid , turtur  , turadi , turkapasite , kapasitekalan , TurGun , TurAciklama , TurTarih , turfiyat from Tur_Detay where   " + turfiyatsql + "  " + turgunsql + "  " + turtursql + turkapasitesql + turtarihsql + " [turadi] LIKE'%" + turadi + "%' ", conn);
            adap.SelectCommand.Parameters.AddWithValue("@turtarih1", SqlDbType.Date).Value = turtarih1;
            adap.SelectCommand.Parameters.AddWithValue("@turtarih2", SqlDbType.Date).Value = turtarih2;
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public DataTable TurSatisTabloGetir()
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT Tur_Satis.satisid,Tur_Musteri.musteriad,Tur_Musteri.musterisoyad,Tur_Detay.turadi,Tur_Detay.TurTarih,Tur_Satis.satistarih FROM Tur_Satis INNER JOIN Tur_Detay ON Tur_Satis.ozelturid = Tur_Detay.ozelturid INNER JOIN Tur_Musteri ON Tur_Satis.musteriid = Tur_Musteri.musteriid", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public DataTable TurMusteriAra(string musteriad, string musterisoyad, DateTime musteridogumtar, bool checkbox)
        {

            sqlcontrol();
            conn.Open();
 
            SqlDataAdapter adap = new SqlDataAdapter("MusteriGetir @musteriad,@musterisoyad,@musteridogumtar,@checkbox", conn);
            adap.SelectCommand.Parameters.AddWithValue("@musteridogumtar", SqlDbType.Date).Value = musteridogumtar;
            adap.SelectCommand.Parameters.AddWithValue("@musteriad", musteriad);
            adap.SelectCommand.Parameters.AddWithValue("@musterisoyad", musterisoyad);
            adap.SelectCommand.Parameters.AddWithValue("@checkbox", checkbox);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public string TurSatisEkle(string ozelturid, string musteriid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "exec TurSatisEkle @ozelturid,@musteriid ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@ozelturid", ozelturid);
                command.Parameters.AddWithValue("@musteriid", musteriid);
                conn.Open();
                int result = command.ExecuteNonQuery();
                return result.ToString();
            }
        }

        public DataTable TurSatisAra(string turadi, string musteriad, string musterisoyad, DateTime turtarih, bool checkbox)
        {

            sqlcontrol();
            conn.Open();

            SqlDataAdapter adap = new SqlDataAdapter("SatisGetir @turadi,@musteriad,@musterisoyad,@turtarih,@checkbox", conn);
            adap.SelectCommand.Parameters.AddWithValue("@turtarih", SqlDbType.Date).Value = turtarih;
            adap.SelectCommand.Parameters.AddWithValue("@turadi", turadi);
            adap.SelectCommand.Parameters.AddWithValue("@musteriad", musteriad);
            adap.SelectCommand.Parameters.AddWithValue("@musterisoyad", musterisoyad);
            adap.SelectCommand.Parameters.AddWithValue("@checkbox", checkbox);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public DataTable TurMusteriAra2(string musteriad, string musterisoyad, DateTime musteridogumtar, bool checkbox)
        {
            string musteridogumtarsql = "";
            if (checkbox == true)
            {
                musteridogumtarsql = "and musteridogumtar = @musteridogumtar";
            }

            sqlcontrol();
            conn.Open();

            SqlDataAdapter adap = new SqlDataAdapter("select musteriid ,musteriad ,musterisoyad ,musteridogumtar from Tur_Musteri where musteriad LIKE'%@musteriad%' and musterisoyad LIKE'%@musterisoyad%' " + musteridogumtarsql , conn);
            adap.SelectCommand.Parameters.AddWithValue("@musteridogumtar", SqlDbType.Date).Value = musteridogumtar;
            adap.SelectCommand.Parameters.AddWithValue("@musteriad", musteriad);
            adap.SelectCommand.Parameters.AddWithValue("@musterisoyad", musterisoyad);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public string TurDetayPEkle(string ozelturid, string personelid)
        {
            sqlcontrol();
            //turdetay personel ekle

            String query = "exec TurDetayPEkle @ozelturid,@personelid ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@ozelturid", ozelturid);
                command.Parameters.AddWithValue("@personelid", personelid);
                command.Parameters.Add("@DonusDegeri", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                conn.Open();
                int result = command.ExecuteNonQuery();
                return result.ToString();
            }
        }

        public DataTable TurDetayPAra(string turadi, string personelad, string personelsoyad, DateTime turtarih, bool checkbox)
        {
            //Tur Personelini Ara
            sqlcontrol();
            conn.Open();

            SqlDataAdapter adap = new SqlDataAdapter("DetayPGetir @turadi,@personelad,@personelsoyad,@turtarih,@checkbox", conn);
            adap.SelectCommand.Parameters.AddWithValue("@turtarih", SqlDbType.Date).Value = turtarih;
            adap.SelectCommand.Parameters.AddWithValue("@turadi", turadi);
            adap.SelectCommand.Parameters.AddWithValue("@personelad", personelad);
            adap.SelectCommand.Parameters.AddWithValue("@personelsoyad", personelsoyad);
            adap.SelectCommand.Parameters.AddWithValue("@checkbox", checkbox);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public void TurSatisSil(string satisid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "DELETE  Tur_satis where satisid= @satisid";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@satisid", satisid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Kayıt Silinemedi!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }
        public void TurDetayPSil(string detaypersonelid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "DELETE  Tur_DetayP where detaypersonelid= @detaypersonelid";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@detaypersonelid", detaypersonelid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Error deleting data into Database!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }

        public DataTable UserLogin(string hesapad, string hesapsifre)
        {
            sqlcontrol();
            //
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT COUNT(hesapid)as toplamhesap  FROM  Tur_Giris where hesapad =  @hesapad and hesapsifre = @hesapsifre";
            cmd.Parameters.AddWithValue("@hesapad", hesapad);
            cmd.Parameters.AddWithValue("@hesapsifre", hesapsifre);
            conn.Open();
            object toplamhesap = cmd.ExecuteScalar();
            conn.Close();
            //admin varmi
            cmd.Connection = conn;
            cmd.CommandText = "SELECT COUNT(hesapid)as adminvarmi  FROM  Tur_Giris";
            conn.Open();
            object hesapvarmi = cmd.ExecuteScalar();
            conn.Close();
            if(hesapvarmi.ToString() == "0")
            {
                cmd.CommandText = "INSERT INTO Tur_Giris (hesapad, hesapsifre, turdetay, turmusteri, turpersonel, tursatis) VALUES ('admin', '123456',1,1,1,1)";
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            //

            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT TOP 1 hesapid  , hesapad  , hesapsifre  , turdetay  , turmusteri  , turpersonel  , tursatis FROM  Tur_Giris where hesapad =  @hesapad and hesapsifre = @hesapsifre ", conn);
            adap.SelectCommand.Parameters.AddWithValue("@hesapad", hesapad);
            adap.SelectCommand.Parameters.AddWithValue("@hesapsifre", hesapsifre);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);

           if(toplamhesap.ToString() == "0") {
                DataRow row = tbl.NewRow();
                row[0] = 0;
                row[1] = "";
                row[2] = "";
                row[3] = 0;
                row[4] = 0;
                row[5] = 0;
                row[6] = 0;
                tbl.Rows.InsertAt(row, 0);
            }


            conn.Close();
            return tbl;
        }

        public DataTable TurKullaniciTablo()
        {
            sqlcontrol();
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select hesapid  , hesapad  , hesapsifre  , turdetay  , turmusteri, turpersonel, tursatis FROM Tur_Giris where hesapad NOT IN ('admin')", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }

        public string TurKullaniciEkle(string hesapad, string hesapsifre, int turdetay, int turmusteri, int turpersonel, int tursatis)
        {
            sqlcontrol();
            //turdetay personel ekle

            String query = "exec KullaniciEkle @hesapad,@hesapsifre,@turdetay,@turmusteri,@turpersonel,@tursatis";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@hesapad", hesapad);
                command.Parameters.AddWithValue("@hesapsifre", hesapsifre);
                command.Parameters.AddWithValue("@turdetay", turdetay);
                command.Parameters.AddWithValue("@turmusteri", turmusteri);
                command.Parameters.AddWithValue("@turpersonel", turpersonel);
                command.Parameters.AddWithValue("@tursatis", tursatis);
                command.Parameters.Add("@DonusDegeri", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                conn.Open();
                int result = command.ExecuteNonQuery();
                return result.ToString();
            }
        }

        public void KullaniciSil (string hesapid)
        {
            sqlcontrol();
            //turdetay ekle

            String query = "DELETE  Tur_Giris where hesapid= @hesapid";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@hesapid", hesapid);

                conn.Open();
                int result = command.ExecuteNonQuery();

                // Hata Kontrolu
                if (result < 0)
                    Console.WriteLine("Kayıt Silinemedi!");
                else //hata yoksa listviewe ekle
                {

                }
            }
        }

        public void Dbyedekle()
        {
            sqlcontrol();
            //turdetay ekle

            String query = @"declare @tarih varchar(150) 
set @tarih = N'c:\duzcetur\db_yedek\tursirketyedek-' + replace(str(year(getdate()))+'-'+str(month(getdate()))+'-'+str(day(getdate())),' ', '')+'.bak'
BACKUP DATABASE [tursirket] TO  DISK = @tarih WITH NOFORMAT, NOINIT,  NAME = N'tursirket-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            using (SqlCommand command = new SqlCommand(query, conn))
            {

                conn.Open();
                int result = command.ExecuteNonQuery();

            }
        }

        public void Dbyedekyukle(string dbisim)
        {
            sqlcontrol();
            //turdetay ekle

            String query = @"USE master 
RESTORE DATABASE [tursirket] FROM  DISK = N'c:\duzcetur\db_yedek\"+dbisim+"' WITH  RESTRICTED_USER,  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10";
            using (SqlCommand command = new SqlCommand(query, conn))
            {

                conn.Open();
                int result = command.ExecuteNonQuery();

            }
        }




    }
}
