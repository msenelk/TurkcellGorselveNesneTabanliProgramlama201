using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraBars.Docking2010.Views.BaseRegistrator;

namespace TurkcellGorselveNesneTabanliProgramlama201
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TblMusteriTableAdapter tb = new DataSet1TableAdapters.TblMusteriTableAdapter();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tb.MusteriListesi();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tb.MusteriEkle(txtAd.Text, txtSoyad.Text, txtSehir.Text, decimal.Parse(txtBakiye.Text));
            MessageBox.Show("Müşteri Sisteme Kaydedildi");
            dataGridView1.DataSource = tb.MusteriListesi(); // İşem sonrası otomatik güncelleme yapılması için yazdım
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            tb.MusteriSil(int.Parse(txtMusteriId.Text));
            MessageBox.Show("Müşteri sistemden silindi");
            dataGridView1.DataSource = tb.MusteriListesi(); // İşem sonrası otomatik güncelleme yapılması için yazdım
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusteriId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            tb.MusteriGuncelle(txtAd.Text,txtSoyad.Text,txtSehir.Text,decimal.Parse(txtBakiye.Text),int.Parse(txtMusteriId.Text));
            MessageBox.Show("Müşteri bilgisi güncellendi.");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if(RdbAd.Checked==true) // Eğer Radio butonlarından ad olan seçiliyse;
            {
                dataGridView1.DataSource = tb.AdaGoreListele(txtAranacak.Text);
            }
            if(RdbSehir.Checked==true)
            {
                dataGridView1.DataSource = tb.SehreGoreListele(txtAranacak.Text);
            }
            if (RdbSoyad.Checked == true)
            {
                dataGridView1.DataSource = tb.SoyadaGoreListele(txtAranacak.Text);
            }
        }

        #region Prosedür Nedir?
        // Uzun SQL sorgularını tek kelimelik komutlara sığdıran yapılardır.
        // Programlama dillerindeki metotlara benzerler.
        // Create komutu ile oluşturulurlar.
        // Execute komutu ile çağrılırlar.
        #endregion

        #region Prosedürlerde Parametre Kullanımı
            //Create Procedure UrunGetir(@ID int) prosedür olşuturuyoruz ve dışarıdan bir değer alacağını belirtiyoruz.
            //As
            //Select* from TblUrunler where UrunId=@ID // dışarıdan gelen değer
        #endregion
    }
}
