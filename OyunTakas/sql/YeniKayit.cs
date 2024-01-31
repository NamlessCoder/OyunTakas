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
    public partial class YeniKayit : Form
    {
       
        public YeniKayit()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
        public int sonuc;
       

        private void YeniKayit_Load(object sender, EventArgs e)
        {
            RobotMu();
        }
        public void RobotMu()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            sonuc = ilk + ikinci;
            label4_robot.Text = ilk.ToString() + "+" + ikinci.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5_mesaj.Text = "";
            if(textBox2.Text == textBox3.Text)
            {
                if(textBox4.Text == sonuc.ToString())
                {
                    KullanıcıSorgu();
                }
                else
                {
                    label5_mesaj.Text = "sadece insanlar robotlara yer yok...";
                    RobotMu();
                }

            }
            else
            {
                label5_mesaj.Text = "şifreler uyuşmuyor....";
                RobotMu();
            }
        }
        public void KullanıcıSorgu()
        {
            string sorgu = "select * from GİRİŞ where kullanıcı=@k";
            con = new SqlConnection(veritabanı.sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@k", textBox1.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label5_mesaj.Text = "Kullanıcı Adı Kullanılıyor....";
                RobotMu();
            }
            else
            {
                string sqls = "insert into GİRİŞ (kullanıcı,sifre,giriştarihi) values('" + textBox1.Text + "','" + veritabanı.MD5Sifrele(textBox2.Text) + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                cmd = new SqlCommand();
                veritabanı.KomutAl(sqls,cmd);
                MessageBox.Show("kayıt başarılı...");
                this.Hide();
                Form3 b = new Form3();
                b.ShowDialog();
            }
            con.Close();

        }
    }
}
