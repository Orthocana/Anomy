namespace Anomy.Models {
    class EncryptedText {
        private string _encryptedText;
        private string _publicKey;

        public string EncryptedTxt {
            get => _encryptedText;
            set => _encryptedText = value;
        }

        public string PublicKey {
            get => _publicKey;
            set => _publicKey = value;
        }
    }
}