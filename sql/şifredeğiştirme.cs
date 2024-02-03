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
    public partial class şifredeğiştirme : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
        public int sonuc;
       
        public şifredeğiştirme()
        {
            InitializeComponent();
        }

        private void şifredeğiştirme_Load(object sender, EventArgs e)
        {
            label1_mesaj.Text = "";
            RobotMu();
        }
        public void RobotMu()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            sonuc = ilk + ikinci;
            label4_kontrol.Text = ilk.ToString() + "+" + ikinci.ToString();
            
        }
        public void Eskişifrekontrol()
        {

            string sorgu = "select * from GİRİŞ where kullanıcı=@k and sifre=@ş";
            con = new SqlConnection(veritabanı.sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@k", Form3.kullanıcım);
            cmd.Parameters.AddWithValue("@ş", veritabanı.MD5Sifrele(textBox1_EŞ.Text));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if(textBox1_EŞ.Text != textBox2_YŞ.Text)
                {
                    string sor = "update GİRİŞ set sifre='" + veritabanı.MD5Sifrele(textBox2_YŞ.Text) + "'where kullanıcı = '" + Form3.kullanıcım + "'";
                    cmd = new SqlCommand();
                    veritabanı.KomutAl(sor,cmd);
                    MessageBox.Show("şifre değiştirildi");
                    Application.Exit();

                }
                else
                {
                    label1_mesaj.Text = "Eski şifre ile yeni şifre aynı olamaz....";
                    RobotMu();
                }
                
            }
            else
            {
                label1_mesaj.Text = "Eski şifre yanlış ...";
                RobotMu();
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox4_kontrol.Text.Equals(sonuc.ToString()))
            {
                label1_mesaj.Text = "";
                if (textBox2_YŞ.Text == textBox3_YŞT.Text)
                {
                    Eskişifrekontrol();

                }
                else
                {
                    label1_mesaj.Text = "Yeni şifreler uyuşmuyor...";
                    RobotMu();
                }
            }
            else
            {
                label1_mesaj.Text = "Robotsun....";
                RobotMu();
            }
        }
    }
}
