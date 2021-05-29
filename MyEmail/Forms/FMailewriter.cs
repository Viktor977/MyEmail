using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEmail.Forms
{
    public partial class FMailewriter : Form
    {
        public FMailewriter()
        {
            InitializeComponent();
        }
        private MailAddress[] Addresses { get; } = new MailAddress[2];
        private const string mailHost = "smtp.gmail.com";
        private const ushort mailPort = 587;
        private const bool MailUserSsl = true;
        private void btnSend_Click(object sender, EventArgs e)
        {
            MessageSendAsync();
            this.Close();
        }

        private async void MessageSendAsync()
        {
            await Task.Run(() => {

                var message = InitialMessage();
                if (message != null)
                {
                    message.Subject = txtBoxTopic.Text ??= "БЕЗ_ТЕМЫ";
                    message.Body = $"<h1>{txtBoxLetter.Text}</h1>";
                    //TODO форматировать текст письма
                    message.IsBodyHtml = MailUserSsl;
                    MessageSend(message);
                }

                return;
            });
        }
        private void MessageSend(MailMessage message)
        {
            SmtpClient Mail = new SmtpClient(mailHost, mailPort);
            string address = FMaileclient.GetInstance().Loader.MailAdress;
            string password = FMaileclient.GetInstance().Loader.MailPassword;


            Mail.Credentials = new NetworkCredential(address, password);
            Mail.EnableSsl = true;

            try
            {
                Mail.Send(message);
                MessageBox.Show("Письмо отправлено", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Письмо не отправлено", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Clear();
        }

        private MailMessage InitialMessage()
        {
            string email = txtBoxAdress.Text;

            if (FLogin.GetInstance().IsValidEmail(email))
            {
                Addresses[0] = new MailAddress(FMaileclient.GetInstance().
                    Loader.MailAdress, txtBoxName.Text);

                Addresses[1] = new MailAddress(email);
                var message = new MailMessage(Addresses[0], Addresses[1]);
                return message;
            }
            else
            {
                MessageBox.Show("Не верно указан адресс", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        private void Clear()
        {
            txtBoxAdress.Text = "";
            txtBoxTopic.Text = "";
            txtBoxLetter.Text = "";
            txtBoxName.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //©
    }
}
