using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentInfoSystem
{
    class ObservableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChangedEvent(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
