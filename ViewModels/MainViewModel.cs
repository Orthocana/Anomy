namespace Anomy.ViewModels {
    public class MainViewModel : ViewModelBase {
        private string _lineOne;

        public string LineOne {
            get => _lineOne;
            set {
                if (value != _lineOne) {
                    _lineOne = value;
                    RaisePropertyChanged("Crypted"); 
                }
            }
        }

    }
}