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
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
       
        static int denemesayısı;
        public static string kullanıcım = "";
        public Form3()
        {
            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            if(veritabanı.GİRİŞİ(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Giriş Başarılı");
                this.Hide();
                kullanıcım = textBox1.Text;
                if (kullanıcım == "apo")
                {
                    Form1 a = new Form1();
                    a.Show();
                }
                else
                {
                    Taksas a = new Taksas();
                    a.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("şifre hatalı....");
                denemesayısı++;
                if(denemesayısı == 3)
                {
                    MessageBox.Show("hadi git hatırlayınca gel");
                    Application.Exit();
                }
            }
                
                

            







           /*
            string sorgu ="select * from GİRİŞ where kullanıcı='"+textBox1.Text+"' and sifre='"+ veritabanı.MD5Sifrele(textBox2.Text) + " ' ";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre yanlış...");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            con.Close();
           */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeniKayit a = new YeniKayit();
            a.ShowDialog();
        }
    }
}
