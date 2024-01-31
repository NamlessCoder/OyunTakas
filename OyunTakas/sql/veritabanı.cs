using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace sql
{
    class veritabanı
    {
        veritabanı()
        {

        }
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static System.Data.DataSet ds;
        static SqlDataReader dr;
        public static string sqlcon = @"Data Source=DESKTOP-7VFJQRM\SQLEXPRESS;Initial Catalog=202503212;Integrated Security=True";
        // DESKTOP-7VFJQRM kısmını sadece buradan düzetmeniz yeterli
        public static bool Baglantidurumu()
        {
            using (con = new SqlConnection(sqlcon))
            {
                
                try
                {
                    con.Open();
                    return true;
                }
                catch(SqlException)
                {
                    return false;                }
               
            }
            
            
        }
        public static DataGridView GridDoldur(DataGridView dg , string tablo )
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("select * from " + tablo, con);
            ds = new  System.Data.DataSet();
            con.Open();
            da.Fill(ds,tablo);

            dg.DataSource = ds.Tables[tablo];
            con.Close();
            return dg;
        }
        public static bool GİRİŞİ (string kullanıcı,string şifre)
        {

            string sorgu = "select * from GİRİŞ where kullanıcı=@k and sifre=@ş";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@k", kullanıcı);
            cmd.Parameters.AddWithValue("@ş", veritabanı.MD5Sifrele(şifre));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
          
            }
            
        }


        public static string MD5Sifrele(string şirelenecek)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(şirelenecek);

            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();
        }

        public static void KomutAl(string sorgu,SqlCommand cmd)
        {
            con = new SqlConnection(sqlcon);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sorgu;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
  

}


