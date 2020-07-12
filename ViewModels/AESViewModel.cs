using Core;
using System;
using System.Text;
using System.Security.Cryptography;

namespace Anomy.ViewModels {
    class AESViewModel {
        public string input = string.Empty;
        public string ivString = "bb622a0497684ba3";
        public string keyString = "b9e259c9534147af84a7a1d77033d9ab";
        
        public void ApplyAes(bool Encrypt) {
            
            input = null;
            string output = string.Empty;
            byte[] data = null;
            byte[] iv = Encoding.ASCII.GetBytes(ivString);
            byte[] keyC = Encoding.ASCII.GetBytes(keyString);
            

            using (Aes myAes = Aes.Create()) {
                if (Encrypt) {
                    // Encrypt the string to an array of bytes.
                    data = AesTool.EncryptStringToBytes_Aes(input, keyC, iv);
                    output = Convert.ToBase64String(data);
                    Console.WriteLine("Encrypted String: {0}", output);
                }

                else {
                    data = Convert.FromBase64String(input);
                    // Decrypt the bytes to a string.
                    output = AesTool.DecryptStringFromBytes_Aes(data, keyC, iv);
                    Console.WriteLine("Decrypted String: {0}", output);
                }
            }
        }
    }
}