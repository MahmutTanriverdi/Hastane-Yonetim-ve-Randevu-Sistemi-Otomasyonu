using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    internal class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("server=localhost; Initial Catalog=HastaneProje;Integrated Security=SSPI");
            baglan.Open();
            return baglan;
        }
    }
}
