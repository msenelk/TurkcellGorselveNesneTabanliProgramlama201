using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

    }
}
