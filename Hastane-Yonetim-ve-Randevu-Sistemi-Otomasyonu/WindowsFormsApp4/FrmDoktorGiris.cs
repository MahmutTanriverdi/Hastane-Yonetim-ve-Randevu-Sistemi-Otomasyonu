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

namespace WindowsFormsApp4
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where doktorTc=@p1 and doktorSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frd = new FrmDoktorDetay();
                frd.TC = mskTC.Text;
                frd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("T.C Kimlik Numarası ya da Şifre Yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
