using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _6002CEM_SophiaDukhota.ViewModels
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy;
        bool isNotBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value)
                    return;
                isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public BaseViewModel() { }
    }
}