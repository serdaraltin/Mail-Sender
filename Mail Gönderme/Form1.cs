using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
namespace Mail_Gönderme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = textBox1.Text.Substring(textBox1.Text.IndexOf("@") + 1);//mail servisi host adresi icin gelen mail adresini parcaladik
            MessageBox.Show(host);
            MailMessage eposta = new MailMessage(); //mail göndermek için bir değişken oluşturuyoruz.
            eposta.From = new MailAddress(textBox1.Text);//Burada hangi mail adresinden gönderileceğini belirliyoruz.
            eposta.To.Add(textBox2.Text);//Buraya gödermek istediğimiz eposta adresini belirliyoruz.Birden çok yapabiliriz.
            //eposta.To.Add("meyta.tr2@gmail.com");//Birden fazla eposta adresine aynı anda gönderebilriz.
            eposta.Subject = textBox4.Text;// mailin konusunu belirliyoruz.
            eposta.Body = textBox5.Text;//Buraya mailin içeriğini bleirliyoruz.
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox6.Text);//Göderen eopsta adresi ve şifresini giriyoruz.
            smtp.Port = 587;// gödereceğimiz mail servisinin portunu giriyoruz.
            smtp.Host = "smtp."+host;// gödereceğimiz mail servisinin host adresini giriyoruz.
            smtp.EnableSsl = true;//ssl i aktif ediyoruz.
            object userState = eposta;//epostamızı bir objecte aktardık.
            try
            {
                smtp.SendAsync(eposta, (object)eposta);//epostamızı gönderdik.
                MessageBox.Show("Mail başarıyla gönderildi.", "Mail Gönderici", MessageBoxButtons.OK, MessageBoxIcon.Information);//Mesajın iletildiğine dair mesaj kutusu oluşturmak için.
            }
            catch (SmtpException hata)
            {
                MessageBox.Show(hata.Message.ToString(), "Mail Gönderici", MessageBoxButtons.OK, MessageBoxIcon.Error);//Burda ise hataya dahil bir mesaj iletisi almak için hatayı belirttik.
            }
            
        }
    }
}
