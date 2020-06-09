namespace Anomy.Models {
    class DecryptedText {
        private string _decryptedText;
        private string _privateKey;

        public string DecryptedTxt {
            get => _decryptedText;
            set => _decryptedText = value;
        }

        public string PrivateKey{
            get => _privateKey;
            set => _privateKey = value;
        }
    }
}
