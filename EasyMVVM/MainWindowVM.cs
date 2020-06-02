using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {

        public MainWindowVM()
        {
            Model m = new Model(); 
            BoundProperty = m.GetData();
        }

        private ObservableCollection<string> _BackingProperty;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> BoundProperty 
        { 
            get { return _BackingProperty; } 
            set { _BackingProperty = value; PropChanged("BoundProperty"); 
            } 
        }

        public void PropChanged(String propertyName) 
        {     
            if (PropertyChanged != null)     
            {         
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));     
            } 
        } 
    }
}
