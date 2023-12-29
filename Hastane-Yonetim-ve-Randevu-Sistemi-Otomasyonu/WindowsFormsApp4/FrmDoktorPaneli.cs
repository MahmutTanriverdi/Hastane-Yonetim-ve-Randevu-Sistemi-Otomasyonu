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
    public partial class DoktorPaneli : Form
    {
        public DoktorPaneli()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            //Bransları Comboboxa Çekme
            SqlCommand komut = new SqlCommand("Select bransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
            
            
            //Doktorları Datagride Aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }



        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Doktorlar(doktorAd,doktorSoyad,doktorBrans,doktorTc,doktorSifre) values(@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Doktorlar where doktorTc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti() .Close();
            MessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar Set doktorAd=@p1, doktorSoyad=@p2, doktorBrans=@p3, doktorSifre=@p4 where doktorTc=@p5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
