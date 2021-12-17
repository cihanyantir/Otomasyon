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
using System.Net.Mail;
using System.Net;

namespace Otomasyon
{
    public partial class Form4 : Form
    {
        public string tutucu;
        public Form4()
        {
         
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-OE95DLD; Initial Catalog=Otomasyon; User Id=sa; password=sa;MultipleActiveResultSets=True");
        private void Form4_Load(object sender, System.EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM musteriarac";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["aracplaka"]);
            }
            baglanti.Close();

        }

        string yapilanislemilk;
        string yapilanislemson;
        bool bittimicheck1;
        string email;
        
        //void clear()
        //{
        //    checkBox1.Checked=false;
        //}

        public void button1_Click(object sender, EventArgs e)
        {

             string bittimi="";
            baglanti.Open();
            string kayit = "SELECT * from musteriarac where aracplaka=@aracplaka";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@aracplaka", comboBox1.Text);
            //musterino parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) //Sadece tek bir kayıt döndürüleceği için while kullanmadım.
            {
                textBox1.Text = dr["aracsahibiadsoyad"].ToString();
                textBox2.Text = dr["musteritelefon"].ToString();
                textBox3.Text = dr["aracmarkamodel"].ToString();
                textBox4.Text = dr["aracyil"].ToString();
                textBox5.Text = dr["aracplaka"].ToString();
                textBox6.Text = dr["musterisikayet"].ToString();
                textBox7.Text = dr["yapilacakislemler"].ToString();
                textBox8.Text = dr["yapilanislemler"].ToString();
                bittimi=dr["bittimi"].ToString();
                email = dr["email"].ToString();
                //Datareader ile okunan verileri form kontrollerine aktardık.
            }
            else
                MessageBox.Show("Müşteri Bulunamadı.");

            ////////////////////////////////////////////////////////////////////////////////////////////////
            if(bittimi=="False" || bittimi==null)
                bittimicheck1 =false;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            yapilanislemilk = textBox8.Text;

            if (bittimi == "True")
                checkBox1.Checked = true;
            else checkBox1.Checked = false;

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "update musteriarac set aracsahibiadsoyad=@aracsahibiadsoyad,musteritelefon=@musteritelefon,aracmarkamodel=@aracmarkamodel," +
                "aracyil=@aracyil,aracplaka=@aracplaka,musterisikayet=@musterisikayet,yapilacakislemler=@yapilacakislemler,bittimi=@bittimi where aracplaka=@aracplaka";
            // müşteriler tablomuzun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            komut.Parameters.AddWithValue("@aracsahibiadsoyad", textBox1.Text);
            komut.Parameters.AddWithValue("@musteritelefon", textBox2.Text);
            komut.Parameters.AddWithValue("@aracmarkamodel", textBox3.Text);
            komut.Parameters.AddWithValue("@aracyil", textBox4.Text);
            komut.Parameters.AddWithValue("@aracplaka", textBox5.Text);
            komut.Parameters.AddWithValue("@musterisikayet", textBox6.Text);
            komut.Parameters.AddWithValue("@yapilacakislemler", textBox7.Text);
            komut.Parameters.AddWithValue("@yapilanislemler", textBox8.Text);
            komut.Parameters.AddWithValue("@bittimi", checkBox1.Checked);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
         
             string kime = email;
           
            void maill(string konu,string icerik) {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("mailadresiniz@gmail.com", "şifreniz");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("posta@gmail.com", "Cihan Yantır");
                mail.To.Add(email);
                //mail.To.Add("alici2@mail.com");
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;

                sc.Send(mail);

            }


            if (bittimicheck1 != checkBox1.Checked )
            {
               

                string konu = "Aracınızı Teslim Alabilirsiniz - XXXServis";
                string icerik = "Aracınızı Teslim Alabilirsiniz - XXXServis";

                //maill(konu,icerik);
               



                MessageBox.Show("Araç Bitti Mail Gönderiliyor");
            }
           

            //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
            komut.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi.");
            yapilanislemson = textBox8.Text;
           

            if(yapilanislemilk!=yapilanislemson)
            {
                MessageBox.Show("Yapılan islem degisti");

               

                    string konu = "Aracınıza eklenen işlem var - XXXServis";
                string icerik = "Aracınıza eklenen işlem var - XXXServis";

                 //maill(konu, icerik);


                ;
            }

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu = "SELECT * from musteriarac where aracplaka=@aracplaka";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
            secmeKomutu.Parameters.AddWithValue("@aracplaka", comboBox1.Text);
            //musterino parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();
            //DataReader ile müşteri verilerini veritabanından belleğe aktardık.
            if (dr.Read()) //Datareader herhangi bir okuma yapabiliyorsa aşağıdaki kodlar çalışır.
            {
                
                //Datareader ile okunan müşteri ad ve soyadını isim değişkenine atadım.
                //Datareader açık olduğu sürece başka bir sorgu çalıştıramayacağımız için dr nesnesini kapatıyoruz.
                DialogResult durum = MessageBox.Show( "Araç kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                //Kullanıcıya silme onayı penceresi açıp, verdiği cevabı durum değişkenine aktardık.
                if (DialogResult.Yes == durum) // Eğer kullanıcı Evet seçeneğini seçmişse, veritabanından kaydı silecek kodlar çalışır.
                {
                    string silmeSorgusu = "DELETE from musteriarac where aracplaka=@aracplaka";
                    //musterino parametresine bağlı olarak müşteri kaydını silen sql sorgusu
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                    silKomutu.Parameters.AddWithValue("@aracplaka", comboBox1.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");
                    //Silme işlemini gerçekleştirdikten sonra kullanıcıya mesaj verdik.
                    
                }
            }
            else
                MessageBox.Show("Müşteri Bulunamadı.");
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Menu = new Form2();
            Menu.Show();

        }
    }
    }
