using IniWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEmail.Forms
{
    public partial class FMaileclient : Form
    {
        private FMaileclient()
        {
            InitializeComponent();
            InitializeAdress();
        }
        public MaileLoader Loader { get; set; }
        public IniFile Ini { get; private set; }

        private static  FMaileclient _instance;
        public static FMaileclient GetInstance() => _instance ??= new FMaileclient();
        private void toolStripSplitButtonAvtorization_Click(object sender, EventArgs e)
        {
            var res = FLogin.GetInstance().ShowDialog();
            if (res == DialogResult.OK)
            {
                ValidateLogin();
            }
        }

        private void InitializeAdress()
        {
            Ini = new IniFile("MailCredentials.ini");
            if (Ini.KeyExists("Mail", "Credentials") && Ini.KeyExists("Key", "Credentials"))
            {
                if (FLogin.GetInstance().IsValidEmail(Ini.Read("Mail", "Credentials")))
                {
                    Loader = new MaileLoader(Ini.Read("Mail", "Credentials"), Ini.Read("Key", "Credentials"));
                    ValidateLogin();
                }
                else
                {
                    MessageBox.Show("Email from  faile:MailCredentials.ini - incorrect"
                        , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Ini.DeleteSection("Credentials");
                }
            }
        }

        private async void ValidateLogin()
        {
            var resLogin = await Loader.LogginInAsync();
            var resMessage = await Loader.GetMessagesAsync();

            if (!resLogin || !resMessage)
            {
                MessageBox.Show("Логин или пароль введены не верно",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void listBoxLetters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxLetters.SelectedIndex == -1) return;
            textBoxСontent.Text = string.Empty;
            await Loader.LoadMessageAsync(listBoxLetters.SelectedIndex);
        }

        private void toolStripSplitButtonNewLetter_Click(object sender, EventArgs e)
        {
            FMailewriter mailewriter = new FMailewriter();
            mailewriter.Show();
        }
    }
}
