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
    public partial class Taksas : Form
    {
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        
        public static string a, b;
        public double z;
        public double x;
        public double avf;
        public string av;
        public Taksas()
        {
            InitializeComponent();
        }

        private void Taksas_Load(object sender, EventArgs e)
        {
            
             // TODO: Bu kod satırı '_202503212DataSet1.alıştakas' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.alıştakasTableAdapter.Fill(this._202503212DataSet1.alıştakas);
            // TODO: Bu kod satırı '_202503212DataSet1.sattakas' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sattakasTableAdapter.Fill(this._202503212DataSet1.sattakas);



           
            
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null )
            {
             
                checkedListBox1.Items.Add(comboBox1.Text);

                
                
                label3.Text = comboBox1.SelectedValue.ToString();
                label4.Text = comboBox2.SelectedValue.ToString();
                
            }
           
            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
          
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                checkedListBox2.Items.Add(comboBox2.Text);
                 label3.Text = comboBox1.SelectedValue.ToString();
                 label4.Text = comboBox2.SelectedValue.ToString();
                
                
            }
          
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            checkedListBox2.Items.Remove(checkedListBox2.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0 || checkedListBox2.CheckedItems.Count != 0)
            {
                Hesapla();
            }
            else
            {
                MessageBox.Show("lütfen aldığınız veya verdiğiniz oyunu işaretleyin...");
            }

                

        }
        public void Hesapla()
        {
            a = "";
            b = "";
            z = 0;
            x = 0;
            label6.Text = "";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                a += checkedListBox1.CheckedItems[i];

            }
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                b += checkedListBox2.CheckedItems[i];

            }


            con = new SqlConnection(veritabanı.sqlcon);
            con.Open();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {

                string sorgu = "select Tfiyat from sattakas where Tad ='" + checkedListBox1.CheckedItems[i] + "'";
                da = new SqlDataAdapter(sorgu, con);
                ds = new DataSet();
                da.Fill(ds, "sattakas");
                dataGridView1.DataSource = ds.Tables["sattakas"];
                z += Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);


            }
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {

                string sorgu = "select Tfiyat from alıştakas where Tad ='" + checkedListBox2.CheckedItems[i] + "'";
                da = new SqlDataAdapter(sorgu, con);
                ds = new DataSet();
                da.Fill(ds, "sattakas");
                dataGridView1.DataSource = ds.Tables["sattakas"];
                x += Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);


            }
            con.Close();


            if (z > x)
            {
                avf = z - x;
                label6.Text = "-" + (z - x).ToString();
                label6.ForeColor = Color.Red;
                av = "alındı";
            }
            else
            {
                avf = x - z;
                label6.Text = "+" + (x - z).ToString();
                label6.ForeColor = Color.DarkGreen;
                av = "verildi";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hesapla();
            if (checkedListBox1.CheckedItems.Count != 0 || checkedListBox2.CheckedItems.Count != 0)
            {

                con = new SqlConnection(veritabanı.sqlcon);
                cmd = new SqlCommand();
                string sorgu = "insert into sitealış (aldığıoyun,verdiğioyun, tutar, alankişi,alındıverildi,işlemzaman) values ('" + a + "','" + b + "','" +avf +"','" + Form3.kullanıcım + "','" + av + "','"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +"')";
                veritabanı.KomutAl(sorgu,cmd);
                MessageBox.Show("İşlem Başarlıyla Gerçekletirildi");
                a = "";
                b = "";
                z = 0;
                x = 0;
            }
            else
            {
                MessageBox.Show("lütfen aldığınız veya verdiğiniz oyunu işaretleyin...");
            }





        }

        private void ilanlardanAlışverişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            üyelerarası f = new üyelerarası();
            f.ShowDialog();
        }

        private void geçmişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            geçmiş g = new geçmiş();
            g.ShowDialog();
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            şifredeğiştirme c = new şifredeğiştirme();
            c.ShowDialog();
        }
    }
}
