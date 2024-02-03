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
    public partial class ilanekle : Form
    {
        SqlCommand cmd;
        public ilanekle()
        {
            InitializeComponent();
        }

        private void ilanekle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if(comboBox1.Text != "")
                {
                    if(comboBox2.Text != "")
                    {
                        if(textBox2.Text != "")
                        {
                            cmd = new SqlCommand();
                            string sorgu = "insert into OYUNLAR (Uad,Uplatform,Udurum,Ufiyat,Ukimden,nezaman) values (@adı,@pl,@dur,@f,@kim,@zaman)";
                            cmd.Parameters.AddWithValue("@adı", textBox1.Text);
                            cmd.Parameters.AddWithValue("@pl", comboBox1.Text);
                            cmd.Parameters.AddWithValue("@dur", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@f", Convert.ToInt32(textBox2.Text));
                            cmd.Parameters.AddWithValue("@kim", Form3.kullanıcım);
                            cmd.Parameters.AddWithValue("@zaman", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            veritabanı.KomutAl(sorgu, cmd);
                            MessageBox.Show("İlan başarıyla eklendi...");
                        }
                        else
                        {
                            label5_mesaj.Text = "fiyat vermeden satamazsınız...";
                        }
                    }
                    else
                    {
                        label5_mesaj.Text = "oyunun durmunu bildiriniz...";
                    }

                }
                else
                {
                    label5_mesaj.Text = "lütfen platform adı seçiniz....";
                }
            }
            else
            {
                label5_mesaj.Text = "oyun adı boş bıraklıamaz...";
            }
        }

        private void ilanlaraDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            üyelerarası ü = new üyelerarası();
            ü.ShowDialog();

        }
    }
}
