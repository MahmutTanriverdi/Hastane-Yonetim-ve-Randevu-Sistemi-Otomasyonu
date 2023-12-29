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
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp4
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string Tc;
        public string Id;
        public string Tarih;
        public string Saat;
        public string Brans;
        public string Doktor;
        public string hastaTC;
        public string Durum;

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = Tc;


            //Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select sekreterAdSoyad from Tbl_Sekreter where sekreterTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları Datagride Aktarma 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Doktorları Datagride Aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (doktorAd +' '+ doktorSoyad) as 'Doktorlar', doktorBrans From Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Bransları Comboboxa Çekme
            SqlCommand komut3 = new SqlCommand("Select bransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbBrans.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();

            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Insert into Tbl_Randevular (randevuTarih,randevuSaat,randevuBrans,randevuDoktor) values (@p1,@p2,@p3,@p4)",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", mskTarih.Text);
            komut2.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut2.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut2.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevunuz Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Seçilen Branşa Göre Doktorları Comboboxa Çekme
            cmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select doktorAd, doktorSoyad from Tbl_Doktorlar where doktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Duyurular(duyuru) values (@p1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyurunuz Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDoktorPanel_Click(object sender, EventArgs e)
        {
            DoktorPaneli drp = new DoktorPaneli();
            drp.Show();
        }

        private void btnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans frb = new FrmBrans();
            frb.Show();
        }

        private void btnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frl = new FrmRandevuListesi();
            frl.Show();
        }

        

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }

        
    }
}
