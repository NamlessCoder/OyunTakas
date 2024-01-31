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
    public partial class üyelerarası : Form
    {
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmdd;
        DataSet ds;
        SqlDataReader dr;
       
        public üyelerarası()
        {
            InitializeComponent();
        }
        public void GridDoldur(string sor)
        {
            con = new SqlConnection(veritabanı.sqlcon);
            da = new SqlDataAdapter(sor, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "OYUNLAR");
            dataGridView1.DataSource = ds.Tables["OYUNLAR"];
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (radioButton1.Checked)
                {

                    if (radioButton4.Checked)
                    {
                        string sor = "select * from OYUNLAR where Uad like '%" + textBox1.Text + "%' order by Uad ASC";
                        GridDoldur(sor);
                    }
                    else if (radioButton5.Checked)
                    {
                        string sor = "select * from OYUNLAR where Uad like '%" + textBox1.Text + "%' order by Uad desc";
                        GridDoldur(sor);
                    }
                    else
                    {
                        MessageBox.Show("artan azalan birini işaretleyiniz...");
                    }
                }

                
                
            }
           
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string sorggu = "insert into ilanişlem (oyunad,oyunplatform,oyundurum,oyunfiyat,kimden,kim,nezaman) values(@oyunad,@p,@dur,@fiyat,@kimden,@kim,@zaman)";
            cmd = new SqlCommand(sorggu, con);
            cmd.Parameters.AddWithValue("@oyunad", Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value));
            cmd.Parameters.AddWithValue("@p", Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value));
            cmd.Parameters.AddWithValue("@dur", Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value));
            cmd.Parameters.AddWithValue("@fiyat", dataGridView1.CurrentRow.Cells[4].Value);
            cmd.Parameters.AddWithValue("@kimden", Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value));
            cmd.Parameters.AddWithValue("@kim", Form3.kullanıcım);
            cmd.Parameters.AddWithValue("@zaman", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            veritabanı.KomutAl(sorggu, cmd);
            string silsor = "delete from OYUNLAR where Uıd = @id ";
            cmdd = new SqlCommand();
            cmdd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            veritabanı.KomutAl(silsor, cmdd);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (radioButton4.Checked)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat < 100 order by Ufiyat ASC";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat between 100 and 200 order by Ufiyat ASC";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat between 200 and 300 order by Ufiyat ASC";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat between 300 and 500 order by Ufiyat ASC";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat > 500 order by Ufiyat ASC";
                        GridDoldur(sor);
                    }

                }
                else if (radioButton5.Checked)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat < 100 order by Ufiyat desc";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat between 100 and 200 order by Ufiyat desc";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat between 200 and 300 order by Ufiyat desc";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat between 300 and 500 order by Ufiyat desc";
                        GridDoldur(sor);
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        string sor = "select * from OYUNLAR where Ufiyat > 500 order by Ufiyat desc";
                        GridDoldur(sor);
                    }

                }
                else
                {
                    MessageBox.Show("artan azalan birini işaretleyiniz...");
                }
            }
        }

        private void sitedenAlSatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Taksas f = new Taksas();
            f.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (radioButton4.Checked)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        string sor = "select * from OYUNLAR where Uplatform = 'PS4' order by Ufiyat ASC";
                        GridDoldur(sor);
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        string sor = "select * from OYUNLAR where Uplatform = 'PS5' order by Ufiyat ASC";
                        GridDoldur(sor);
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        string sor = "select * from OYUNLAR where Uplatform = 'XBOX' order by Ufiyat ASC";
                        GridDoldur(sor);
                    }
                   

                }
                else if (radioButton5.Checked)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        string sor = "select * from OYUNLAR where Uplatform = 'PS4' order by Ufiyat desc";
                        GridDoldur(sor);
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        string sor = "select * from OYUNLAR where Uplatform = 'PS5' order by Ufiyat desc";
                        GridDoldur(sor);
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        string sor = "select * from OYUNLAR where Uplatform = 'XBOX' order by Ufiyat desc";
                        GridDoldur(sor);
                    }


                }
                else
                {
                    MessageBox.Show("artan azalan birini işaretleyiniz...");
                }
            }
        }

        private void oyunSatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ilanekle i = new ilanekle();
            i.ShowDialog();
        }
    }
}
