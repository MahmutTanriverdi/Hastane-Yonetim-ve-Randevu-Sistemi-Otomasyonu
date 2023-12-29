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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        public string Tc;


        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = Tc;
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where hastaTc='"+mskTC.Text+"'",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text= dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelefon.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Update Tbl_Hastalar Set hastaAd=@p1, hastaSoyad=@p2, hastaTelefon=@p3, hastaSifre=@p4, hastaCinsiyet=@p5 where hastaTc=@p6",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtAd.Text);
            komut1.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut1.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut1.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut1.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut1.Parameters.AddWithValue("@p6", mskTC.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close() ;
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
