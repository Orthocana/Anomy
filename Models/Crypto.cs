namespace Anomy.Models {
    public class Crypto {
        private string _inputText;
        private string _password;
        private string _privateKey;
        private string _publicKey;
        private string _encryptedText;
        private string _decryptedText;
        private string _publicKeyFilePath = "./public.cert";
        private string _privateKeyFilePath = "./private.key";

        public string InputText {
            get => _inputText;
            set => _inputText = value;
        }

        public string Password {
            get => _password;
            set => _password = value;
        }

        public string PublicKey {
            get => _publicKey;
            set => _publicKey = value;
        }

        public string PrivateKey {
            get => _privateKey;
            set => _privateKey = value;
        }

        public string EncryptedTxt {
            get => _encryptedText;
            set => _encryptedText = value;
        }

        public string DecryptedTxt {
            get => _decryptedText;
            set => _decryptedText = value;
        }

        public string PublicKeyPath {
            get => _publicKeyFilePath;
            set => _publicKeyFilePath = value;
        }

        public string PrivateKeyPath {
            get => _privateKeyFilePath;
            set => _privateKeyFilePath = value;
        }
    }
}