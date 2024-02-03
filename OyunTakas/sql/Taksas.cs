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
        SqlDataReader dr2;

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

            con = new SqlConnection(veritabanı.sqlcon);
            con.Open();
            cmd = new SqlCommand("select * from sattakas",con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            da.Fill(dt);
            comboBox1.ValueMember = "Tfiyat";
            comboBox1.DisplayMember = "Tad";
            comboBox1.DataSource = dt;

            comboBox2.ValueMember = "Talışfiyat";
            comboBox2.DisplayMember = "Tad";
            comboBox2.DataSource = dt2;

            con.Close();
       
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        
           


        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
          
        
          
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
               cmd = new SqlCommand(sorgu,con);
               dr = cmd.ExecuteReader();
               if (dr.Read())
                {
                    z += Convert.ToDouble(dr["Tfiyat"]);
                }
                
               


            }
            dr.Close();
            
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {

                string sorgu = "select Talışfiyat from sattakas where Tad ='" + checkedListBox2.CheckedItems[i] + "'";
                cmd = new SqlCommand(sorgu, con);
                dr2 = cmd.ExecuteReader();
                if (dr2.Read())
                {
                    x += Convert.ToDouble(dr2["Talışfiyat"]);
                }
                


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

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                checkedListBox1.Items.Add(comboBox1.Text);



                label3.Text = comboBox1.SelectedValue.ToString();
                label4.Text = comboBox2.SelectedValue.ToString();


            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                checkedListBox2.Items.Add(comboBox2.Text);
                label3.Text = comboBox1.SelectedValue.ToString();
                label4.Text = comboBox2.SelectedValue.ToString();


            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            şifredeğiştirme c = new şifredeğiştirme();
            c.ShowDialog();
        }
    }
}
