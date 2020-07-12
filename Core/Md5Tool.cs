using System;
using System.Text;
using System.Security.Cryptography;

namespace Core {
    
    public class Md5Tool {
        
        public string EncryptMd5Hash(string toBeEncrypted, string passwordToUse) {
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

        public string DecryptMd5Hash(string toBeDecrypted, string passwordToUse) {
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