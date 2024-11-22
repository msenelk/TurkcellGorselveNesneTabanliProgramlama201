using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TurkcellGorselveNesneTabanliProgramlama201
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSENELK\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            // Toplam Kategori Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from tblkategori", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                lblToplamKategori.Text = dr[0].ToString();
            }
            baglanti.Close();


            // Toplam Ürün Sayısı
            baglanti.Open();
            SqlCommand toplamUrun = new SqlCommand("Select count(*) from TblUrunler", baglanti);
            SqlDataReader dr2 = toplamUrun.ExecuteReader();
            while (dr2.Read())
            {
                lblToplamUrunSayisi.Text = dr2[0].ToString();
            }
            baglanti.Close();
        }
    }
}
