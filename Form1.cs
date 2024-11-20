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

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=MSENELK\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
            // SqlConneciton sınıfından bağlantı adında bir sınıf oluşturduk.
            SqlCommand komut = new SqlCommand("Select * From TblKategori", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

// Data Source=MSENELK\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True;Encrypt=True;Trust Server Certificate=True