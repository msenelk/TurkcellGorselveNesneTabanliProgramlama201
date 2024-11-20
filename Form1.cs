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
using System.Data.SqlClient;

namespace TurkcellGorselveNesneTabanliProgramlama201
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region SQL Komutları
            //--SqlConnection : Bağlantı Sınıfı
            //--SqlCommand : Komut Sınıfı
            //--Sql DataAdapter: Köprü Sınıfı
            //--DataTable : Veri Tablosu 
            #endregion // SQL Komutları
            // AutoSizeColumnsMode = Otomatik Sütun Boyutu - Fiil tam olarak ayarlar.
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSENELK\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        // SqlConneciton sınıfından bağlantı adında bir sınıf oluşturduk.
        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TblKategori", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblKategori (Ad) Values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriniz Başarılı Bir Şekilde Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from TblKategori where Id=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori silme işlemi başarılı bir şekilde gerçekleşti");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TblKategori set Ad=@p1 where Id=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut.Parameters.AddWithValue("@p2",txtId.Text);
            komut.ExecuteNonQuery(); // Değişikleri kaydet veritabanına yansıt
            baglanti.Close();
            MessageBox.Show("Kategori güncelleme işlemi başarılı bir şekilde gerçekleşti.");
        }
    }
}

// Data Source=MSENELK\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True;Encrypt=True;Trust Server Certificate=True