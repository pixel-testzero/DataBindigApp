using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _textValue = "Начальное значение";

        public event PropertyChangedEventHandler PropertyChanged;

        public string TextValue
        {
            get { return _textValue; }
            set
            {
                if (_textValue != value)
                {
                    _textValue = value;
                    OnPropertyChanged();
                }
            }
        }
        private RelayCommand _changeTextCommand;
        public RelayCommand ChangeTextCommand
        {
            get
            {
                return _changeTextCommand ??= new RelayCommand(obj =>
                {
                    TextValue = "Изменено из ViewModel: " + DateTime.Now.ToString("HH:mm:ss");
                });
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
