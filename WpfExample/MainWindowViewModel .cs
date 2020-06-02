using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand;
        private bool canExecute = true;
        private string greetingText = "";
        private string dateText = "";

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string HiButtonContent
        {
            get
            {
                return "click to say hi";
            }
        }

        public string GreetingText
        {
            get { return this.greetingText; }
            set { this.greetingText = value; OnPropertyChanged("GreetingText"); }
        }

        public string DateText
        {
            get { return this.dateText; }
            set { this.dateText = value; OnPropertyChanged("DateText"); }
        }

        public bool CanExecute
        {
            get { return this.canExecute; }
            set { this.canExecute = value; }
        }

        public ICommand HiButtonCommand
        {
            get { return this.hiButtonCommand; }
            set { this.hiButtonCommand = value; }
        }

        public ICommand ToggleExecuteCommand
        {
            get { return toggleExecuteCommand; }
            set { this.toggleExecuteCommand = value; }
        }

        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            ToggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public void ShowMessage(object obj)
        {
            this.GreetingText = "Здрасти!";
            this.DateText = DateTime.Now.ToLongTimeString();
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
    }
}
