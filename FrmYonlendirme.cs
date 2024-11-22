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
    public partial class FrmYonlendirme : Form
    {
        public FrmYonlendirme()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            FrmUrun frm= new FrmUrun();
            frm.Show();
            this.Hide();
        }

        private void PnlKategori_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void PnlIstatistikler_Click(object sender, EventArgs e)
        {
            FrmIstatistik frm=new FrmIstatistik();
            frm.Show();
            this.Hide();
        }

        private void PnlGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm=new FrmGrafikler();
            frm.Show();
            this.Hide();
        }

        private void PnlLogin_Click(object sender, EventArgs e)
        {
            FrmAdmin frm=new FrmAdmin();
            frm.Show();
            this.Hide();
        }
    }
}
