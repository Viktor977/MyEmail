using MyEmail.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEmail
{
    public partial class FLogin : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
     (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
      );
        private FLogin()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        private static FLogin _instance;
        public static FLogin GetInstance() => _instance ??= new FLogin();

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
           // this.Close();
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {

                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));


                string DomainMapper(Match match)
                {

                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException ex)
            {
                return false;
            }
            catch (ArgumentException ex)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void FLogin_Shown(object sender, EventArgs e)
        {
            if (FMaileclient.GetInstance().Ini is not null) return;

            var existMail = FMaileclient.GetInstance().Ini.KeyExists("Mail", "Credentials");
            var existPass = FMaileclient.GetInstance().Ini.KeyExists("Key", "Credentials");

            if (existMail)
                txtBoxLogin.Text = FMaileclient.GetInstance().Ini.Read("Mail", "Credentials");
            if (existPass)
                txtBoxPassword.Text = FMaileclient.GetInstance().Ini.Read("Key", "Credentials");

            if (existMail && existPass)
            {
                checkBox1.Checked = true;
            }
            if (FMaileclient.GetInstance().Loader is not null)
                btnConnect.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(txtBoxLogin.Text))
            {
                if (checkBox1.Checked)
                {
                    FMaileclient.GetInstance().Ini.Write("Mail",
                        txtBoxLogin.Text, "Credentials");
                    FMaileclient.GetInstance().Ini.Write("Key",
                        txtBoxPassword.Text, "Credentials");

                }
                FMaileclient.GetInstance().Loader =
                new MaileLoader(txtBoxLogin.Text, txtBoxPassword.Text);
                _instance.DialogResult = DialogResult.OK;
                _instance.Hide();
            }
            else
            {
                MessageBox.Show("Не верно указан адресс!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
