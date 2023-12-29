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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string TCno;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCno;
            
            //Doktor Bilgilerini Çekme
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where doktorTc='"+mskTC.Text+"'",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            //Doktor Bilgileri Güncelleme
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar Set doktorAd=@p1, doktorSoyad=@p2, doktorBrans=@p3, doktorSifre=@p4 where doktorTc=@p5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
