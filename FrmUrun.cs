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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSENELK\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select * from TblUrunler", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("select * from TblKategori", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox1.DisplayMember = "Ad"; // Gösterilecek olan veri alanı
            comboBox1.ValueMember = "Id"; // Seçim yapıldığında geri dönecek olan değerin veri alanı.
            comboBox1.DataSource = dt2;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into tblurunler (Urunad, Stok, AlisFiyat,SatisFiyat,Kategori) values (@p1, @p2,@p3,@p4,@p5)", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
            komut3.Parameters.AddWithValue("@p2", numericUpDown1.Value);
            komut3.Parameters.AddWithValue("@p3", txtAlisFiyat.Text);
            komut3.Parameters.AddWithValue("@p4", txtSatisFiyat.Text);
            komut3.Parameters.AddWithValue("@p5", comboBox1.SelectedValue); // Seçilen değer
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün kaydı başarılı bir şekilde gerçekleşti.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("delete from tblurunler where urunId=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtUrunId.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İstediğiniz ürünün silme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CellClik hücreye tıklandığı anlamına gelir
            // e harfi kullanılır.
            // Cells ise sütun olarak hangi veriyi alacağımızı belirtiyoruz
            txtUrunId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("update tblurunler set urunad=@p1,stok=@p2,AlisFiyat=@p3,SatisFiyat=@p4,Kategori=@p5 where urunId=@p6", baglanti);
            komut5.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
            komut5.Parameters.AddWithValue("@p2", numericUpDown1.Value);
            komut5.Parameters.AddWithValue("@p3", decimal.Parse(txtAlisFiyat.Text)); // Fiyatlar virgüllü olduğu için gelen değeri decimal e çevirdik
            komut5.Parameters.AddWithValue("@p4", decimal.Parse(txtSatisFiyat.Text));
            komut5.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut5.Parameters.AddWithValue("@p6", txtUrunId.Text);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün bilgileri başarıyla güncellendi.","Güncelleme",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
