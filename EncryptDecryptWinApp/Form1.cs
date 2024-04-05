using EncryptDecryptWinApp.Utils;
using System.Configuration;
using System.Windows.Forms;

namespace EncryptDecryptWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var passPhraseKey = ConfigurationManager.AppSettings.Get("PassPhraseKey"); //"M*!Rhd0b$zB8eKl8@?B2nxJ0^csjtgGR";
            if (rdbEncrypt.Checked)
            {
                txtResponse.Text = Helper.Encrypt(txtRequest.Text, passPhraseKey);
            }
            if(rdbDecrypt.Checked) 
            {
                txtResponse.Text = Helper.Decrypt(txtRequest.Text, passPhraseKey);
            }
        }
    }
}
