using System.Windows;
using Core;
using Microsoft.Win32;

namespace Anomy.ViewModels {
    class CrypterViewModel {
        private readonly RsaEnc _rs = new RsaEnc();
        private readonly Core.Md5 mdf = new Md5();

        private string _publicKeyFilePath = "./public.cert";
        private string _privateKeyFilePath = "./private.key";

        private void GenerateBtn_Click(object sender, RoutedEventArgs e) {
            //Status_Label.Content = "Generating Keys...";
            _rs.GenerateKeys(_publicKeyFilePath, _privateKeyFilePath);
            //Status_Label.Content = "Generated Keys.";
        }

        private void OpenPublic_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog {
                Multiselect = false,
                Filter = "Public |*.cert",
                DefaultExt = ".cert"
            };
            bool? dialogOk = fileDialog.ShowDialog();

            if (dialogOk == true) {
                string sFilenames = "";
                foreach (string sFileName in fileDialog.FileNames)
                {
                    sFilenames += ";" + sFileName;
                }

                sFilenames = sFilenames.Substring(1);
                _publicKeyFilePath = sFilenames;//Esto solo da la RUTA
            }
        }

        private void OpenPrivate_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog {
                Multiselect = false,
                Filter = "Certificates |*.key",
                DefaultExt = ".key"
            };
            bool? dialogOk = fileDialog.ShowDialog();

            if (dialogOk == true) {
                string sFilenames = "";
                foreach (string sFileName in fileDialog.FileNames)
                {
                    sFilenames += ";" + sFileName;
                }

                sFilenames = sFilenames.Substring(1);
                _privateKeyFilePath = sFilenames; //Esto solo da la RUTA
            }
        }

        private void EncryptBtn_Click(object sender, RoutedEventArgs e) {
            //CryptedTextBox.Text = mdf.EncryptMd5Hash(_rs.Encrypt(_publicKeyFilePath, BoxToEncrypt.Text), EncryptionPassword.Password);
            //CryptedTextBox.IsEnabled = true;
        }

        private void DecryptBtn_Click(object sender, RoutedEventArgs e) {
            //DecryptedTextBox.Text = _rs.Decrypt(_privateKeyFilePath, mdf.DecryptMd5Hash(BoxToDecrypt.Text, DecryptionPassword.Password));
            //DecryptedTextBox.IsEnabled = true;
        }
    }
}