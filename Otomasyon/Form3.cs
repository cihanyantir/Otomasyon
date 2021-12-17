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

namespace Otomasyon
{
    public partial class Form3 : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-OE95DLD; Initial Catalog=Otomasyon; User Id=sa; password=sa;");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into musteriarac(aracsahibiadsoyad,musteritelefon,aracmarkamodel,aracyil,aracplaka,musterisikayet,yapilacakislemler,email) values (@aracsahibiadsoyad,@musteritelefon,@aracmarkamodel,@aracyil,@aracplaka,@musterisikayet,@yapilacakislemler,@email)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.

               
                komut.Parameters.AddWithValue("@aracsahibiadsoyad", textBox1.Text);
                komut.Parameters.AddWithValue("@musteritelefon", textBox2.Text);
                komut.Parameters.AddWithValue("@aracmarkamodel", textBox3.Text);
                komut.Parameters.AddWithValue("@aracyil", textBox4.Text);
                komut.Parameters.AddWithValue("@aracplaka", textBox5.Text);
                komut.Parameters.AddWithValue("@musterisikayet", textBox6.Text);
                komut.Parameters.AddWithValue("@yapilacakislemler", textBox7.Text);
                komut.Parameters.AddWithValue("@email", textBox8.Text);

                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglanti.Close();
                MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Menu = new Form2();
            Menu.Show();
        }
    }
}