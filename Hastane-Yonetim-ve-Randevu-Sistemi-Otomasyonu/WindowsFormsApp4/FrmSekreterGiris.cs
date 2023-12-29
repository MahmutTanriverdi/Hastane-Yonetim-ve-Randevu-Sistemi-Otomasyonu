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

namespace WindowsFormsApp4
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Sekreter where sekreterTc=@p1 and sekreterSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay fr = new FrmSekreterDetay();
                fr.Tc = mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("T.C Kimlik Numarası ya da Şifreniz Yanlış", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bgl.baglanti().Close();
        }
    }
}
