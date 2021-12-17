using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-OE95DLD; Initial Catalog=Otomasyon; User Id=sa; password=sa;MultipleActiveResultSets=True");



        public static string tcno, adi, soyadi, yetki;
        Form2 yoneticifrm = new Form2();
     
       
       

        private void button1_Click(object sender, EventArgs e)
        {
            if(hak!=0)
            { baglanti.Open();
                SqlCommand selectsorgu = new SqlCommand("select* from kullanicilar", baglanti);
                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();

                //musteri verisi girişi
                SqlCommand selectsorgumusteri = new SqlCommand("select* from musteriarac", baglanti);
                SqlDataReader kayitokumamusteri = selectsorgumusteri.ExecuteReader();

            string user = textBox1.Text;
            string password = textBox2.Text;
                musteriaracveri mst = new musteriaracveri(user);
                while (kayitokuma.Read())
                { if(radioButton1.Checked==true)
            {
                        if (kayitokuma["kullaniciadi"].ToString() == user && kayitokuma["parola"].ToString() == password && kayitokuma["yetki"].ToString() == "Yönetici")
                        {
                            yoneticifrm.Show();
                            durum = true;
                            this.Hide();
                        }

                    }

                }
                while (kayitokumamusteri.Read()) {
                    if (radioButton2.Checked == true)
                    {
                        if (kayitokumamusteri["email"].ToString() == user && kayitokumamusteri["aracplaka"].ToString() == password)
                        {
                            mst.Show();
                            durum = true;
                            this.Hide();
                        }

                    }
                }


                if (durum == false)
                {  hak--; baglanti.Close(); MessageBox.Show("Yanlış Giriş. "  +hak.ToString() + " Hakkınız Kaldı"); }

  label5.Text = Convert.ToString(hak);

            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                button1.Enabled = true;
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int hak = 3;bool durum = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanici Girisi";
            this.AcceptButton = button1;this.CancelButton = button2;
            label5.Text = Convert.ToString(hak);
            button1.Enabled = false;
            radioButton1.Checked = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
           
        }
    }
}
