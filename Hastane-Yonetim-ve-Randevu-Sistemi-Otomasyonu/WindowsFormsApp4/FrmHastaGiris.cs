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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand sorgu = new SqlCommand("SELECT * from Tbl_Hastalar where hastaTC=@TC and hastaSifre=@sifre",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@TC", mskTC.Text);
            sorgu.Parameters.AddWithValue("@sifre", txtSifre.Text);
            SqlDataReader rdr = sorgu.ExecuteReader();
            if (rdr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.TcNo = mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("T.C Kimlik Numarası ya da Şifre Yanlış", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bgl.baglanti().Close();
        }
    }
}
