using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string TcNo;
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = TcNo;
            //Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select hastaAd, hastaSoyad from Tbl_Hastalar where hastaTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where hastaTc=" + lblTc.Text, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşları Çekme
            SqlCommand komut1 = new SqlCommand("Select bransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                cmbBrans.Items.Add(dr1[0]);
            }
            bgl.baglanti().Close();



        }

        //Doktorları Çekme
        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand komut2 = new SqlCommand("Select doktorAd, doktorSoyad from Tbl_Doktorlar where doktorBrans=@p2 ", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", cmbBrans.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbDoktor.Items.Add(dr2[0] + " " + dr2[1]);
            }
            bgl.baglanti().Close();


        }

        //Aktif Randevuları Çekme
        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where randevuBrans='" + cmbBrans.Text + "' and randevuDoktor='" + cmbDoktor.Text + "' and randevuDurum=0 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        //Bilgileri Düzenle
        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.Tc = TcNo;
            fr.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular set randevuDurum=1, hastaTc=@p1, randevuBrans=@p2, randevuDoktor=@p3, hastaSikayet=@p4 where randevuId=@p5 ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            komut.Parameters.AddWithValue("@p2", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p3", cmbDoktor.Text);
            komut.Parameters.AddWithValue("@p4", rchSikayet.Text);
            komut.Parameters.AddWithValue("@p5", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
