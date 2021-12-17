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
    public partial class musteriaracveri : Form
    {
        public string durum;
        public string b;

        //user textbox1.text idi, giriş yapan kullanıcının emaili alınıyor
        public musteriaracveri(string user)
        {
            b = user;
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-OE95DLD; Initial Catalog=Otomasyon; User Id=sa; password=sa;");

        private void musteriaracveri_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from musteriarac where email=@email";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //b'den emaile aktarılıyor ve veriler aranıyor
            komut.Parameters.AddWithValue("@email", b);
            //musterino parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) //Sadece tek bir kayıt döndürüleceği için while kullanmadım.
            {
                textBox1.Text = dr["aracsahibiadsoyad"].ToString();
                textBox1.ReadOnly = true;
                textBox2.Text = dr["musteritelefon"].ToString();
                textBox2.ReadOnly = true;
                textBox3.Text = dr["aracmarkamodel"].ToString();
                textBox3.ReadOnly = true;
                textBox4.Text = dr["aracyil"].ToString();
                textBox4.ReadOnly = true;
                textBox5.Text = dr["aracplaka"].ToString();
                textBox5.ReadOnly = true;
                textBox6.Text = dr["musterisikayet"].ToString();
                textBox6.ReadOnly = true;
                textBox7.Text = dr["yapilacakislemler"].ToString();
                textBox7.ReadOnly = true;
                textBox8.Text = dr["yapilanislemler"].ToString();
                textBox8.ReadOnly = true;
                durum = dr["bittimi"].ToString();
                //Datareader ile okunan verileri form kontrollerine aktardık.
            }

           
            else
                MessageBox.Show("Müşteri Bulunamadı.");

          

            if (durum == "True" )
            {label11.Text = "Tamamlandı";
               
            }
            else label11.Text = "İşlemde";
            baglanti.Close();
        }

    }
    
}
