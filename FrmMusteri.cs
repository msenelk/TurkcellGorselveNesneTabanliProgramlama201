﻿using System;
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
    }
}
