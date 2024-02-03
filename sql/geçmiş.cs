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

namespace sql
{
    public partial class geçmiş : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
       
        public geçmiş()
        {
            InitializeComponent();
        }

        private void geçmiş_Load(object sender, EventArgs e)
        {
            




        }
        public void GriDdoldur(string sor)
        {
            con = new SqlConnection(veritabanı.sqlcon);
            con.Open();
            da = new SqlDataAdapter(sor, con);
            ds = new DataSet();
            da.Fill(ds,"sitealış");
            dataGridView1.DataSource = ds.Tables["sitealış"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string sor = "select * from sitealış where alankişi = '" + Form3.kullanıcım + "'";
                GriDdoldur(sor);
            }
            else if (radioButton2.Checked)
            {
                string sor = "select * from ilanişlem where kim = '" + Form3.kullanıcım + "'";
                GriDdoldur(sor);
            }
            else if (radioButton3.Checked)
            {
                string sor = "select * from OYUNLAR where Ukimden = '" + Form3.kullanıcım + "'";
                GriDdoldur(sor);
            }
        }

        private void takasaDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Taksas t = new Taksas();
            t.ShowDialog();

        }

        private void ilanlaraDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            üyelerarası ü = new üyelerarası();
            ü.ShowDialog();
        }
    }
}
