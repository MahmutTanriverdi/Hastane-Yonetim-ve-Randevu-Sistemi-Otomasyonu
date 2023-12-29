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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string TC;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = TC;

            //Doktor Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select doktorAd, doktorSoyad from Tbl_Doktorlar where doktorTc=" + lblTc.Text,bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] +" " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Listesi Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where randevuDoktor='" +lblAdSoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr = new FrmDoktorBilgiDuzenle();
            fr.TCno = lblTc.Text;
            fr.Show();

        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Randevu Detay
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
