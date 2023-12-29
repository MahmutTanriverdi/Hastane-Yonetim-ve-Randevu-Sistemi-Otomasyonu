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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmBrans_Load(object sender, EventArgs e)
        {
            //Branşları Datagride Aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Branş Ekleme
            SqlCommand komut = new SqlCommand("Insert into Tbl_Branslar (bransAd) values (@p1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBrans.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Branslar where bransId=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Branslar set bransAd=@p1 where bransId=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBrans.Text);
            komut.Parameters.AddWithValue("@p2", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
