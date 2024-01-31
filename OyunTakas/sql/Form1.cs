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
    
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        
        //Data Source=DESKTOP-7VFJQRM\SQLEXPRESS;Initial Catalog=202503212;Integrated Security=True
       /* 
         void GridDoldur()
         
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("select * from GİRİŞ",con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "GİRİŞ");

            dataGridView1.DataSource = ds.Tables["GİRİŞ"];
            con.Close();
        }
       */
        
        public Form1()
        {
            InitializeComponent();
            if (veritabanı.Baglantidurumu())
            {
                MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            veritabanı.GridDoldur(dataGridView1, "GİRİŞ");
            dataGridView1.Columns[2].Visible = false;
            veritabanı.GridDoldur(dataGridView2, "OYUNLAR");
            veritabanı.GridDoldur(dataGridView3, "ilanişlem");
          
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(veritabanı.sqlcon);
            string sqls = "insert into GİRİŞ (kullanıcı,sifre,giriştarihi) values('"+textBox1.Text+"','"+veritabanı.MD5Sifrele(textBox2.Text)+"','"+dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")+"')";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sqls;
            cmd.ExecuteNonQuery();
            con.Close();
            veritabanı.GridDoldur(dataGridView1, "GİRİŞ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(veritabanı.sqlcon);
            string sqls = "delete from GİRİŞ where kullanıcı = '"+textBox1.Text+"' and sifre = '"+textBox2.Text+"' ";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sqls;
            cmd.ExecuteNonQuery();
            con.Close();
            veritabanı.GridDoldur(dataGridView1, "GİRİŞ");
        }

       

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            şifredeğiştirme a = new şifredeğiştirme();
            a.ShowDialog();
        }
    }
}
