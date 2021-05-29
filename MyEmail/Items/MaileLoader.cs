
using MyEmail.Forms;
using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEmail
{
    public class MaileLoader
    {
        private const string mailHost = "pop.gmail.com";
        private const ushort mailPort = 995;
        private const bool MailUserSsl = true;
        public string MailAdress { get; }
        public string MailPassword { get; }
        private Pop3Client MaileClient { get; } = new ();
        private List<Message> Messages { get;  } = new List<Message>();
        public MaileLoader(string mail,string password)
        {
            MailAdress = mail;
            MailPassword = password;
        }

        public async Task<bool> LogginInAsync()
        {
             return  await Task.Run(() =>
             {
                 try
                 {
                    MaileClient.Connect(mailHost, mailPort, MailUserSsl);
                    MaileClient.Authenticate(MailAdress, MailPassword);
                     return true;
                 }
                 catch
                 {
                     return false;
                 }
                               
             });
        }

        public async Task<bool> GetMessagesAsync()
        {
           return await Task.Run(() =>
           {
               try
               {
                   var count = MaileClient.GetMessageCount();
                   for (int i = count; i > 0; --i)
                   {
                       var message = MaileClient.GetMessage(i);
                       var fromStr = string.Format($"{ message.Headers.From.Address} |" +
                           $" {message.Headers.From.DisplayName}");


                       Messages.Add(message);


                       FMaileclient.GetInstance().listBoxLetters.Invoke(new Action(() =>
                       {

                           FMaileclient.GetInstance().listBoxLetters.Items.Add(fromStr);

                       }));
                   }
                   return true;
               }
               catch
               {
                   return false;
               }


           });
        }

        public async Task LoadMessageAsync(int index)
        {
            await Task.Run(() =>
            {

                var message = Messages[index];
                FMaileclient.GetInstance().textBoxСontent.Invoke(new Action(() =>
                {
                    var str = Encoding.Default.GetString(message.FindFirstPlainTextVersion().Body);
                    FMaileclient.GetInstance().textBoxСontent.Text = str;

                }));
            });
        }

    }
}
