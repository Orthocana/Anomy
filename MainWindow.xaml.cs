using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Core;
using System.Windows;
using Microsoft.Win32;

namespace Anomy {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly RsaTool _rs = new RsaTool();
        private string _publicKeyFilePath, _privateKeyFilePath;

        public MainWindow() {
            InitializeComponent();
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e) {
            StatusLabel.Content = "Generating Keys...";
            _rs.GenerateKeys();
            StatusLabel.Content = "Generated Keys.";
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
            TextEncrypted.Text = EncryptMd5Hash(_rs.Encrypt(_publicKeyFilePath, TextToEncrypt.Text), EncryptionPassword.Password);
            TextEncrypted.IsEnabled = true;
        }

        private void DecryptBtn_Click(object sender, RoutedEventArgs e) {
            DecryptedTextBox.Text = _rs.Decrypt(_privateKeyFilePath, DecryptMd5Hash(BoxToDecrypt.Text, DecryptionPassword.Password));
            DecryptedTextBox.IsEnabled = true;
        }

        private string EncryptMd5Hash(string toBeEncrypted, string passwordToUse) {
            byte[] data = Encoding.UTF8.GetBytes(toBeEncrypted);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordToUse));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider(){Key = keys,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7}) {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results);
                }
            }
        }

        private string DecryptMd5Hash(string toBeDecrypted, string passwordToUse) {
            byte[] data = Convert.FromBase64String(toBeDecrypted);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordToUse));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) {
                    ICryptoTransform transform = tripleDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}