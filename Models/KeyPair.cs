using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anomy.Models {
    class KeyPair {
        private string _publicKeyFilePath = "./public.cert";
        private string _privateKeyFilePath = "./private.key";

        public string PublicKeyPath {
            get => _publicKeyFilePath;
            set => _publicKeyFilePath = value;
        }

        public string PrivateKeyPath {
            get => _publicKeyFilePath;
            set => _publicKeyFilePath = value;
        }
    }
}