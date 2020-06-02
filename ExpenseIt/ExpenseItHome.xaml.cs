using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        private DateTime lastChecked;

        public ExpenseItHome()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
            
            //Filling the Expenses:IList class with data that would've been filled to the List<Expense>
            ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name = "Mike",
                    Department = "Legal",
                    Expenses = new Expenses()
                    {
                        new Expense() { ExpenseType = "Lunch", ExpenseAmount = 50 },
                        new Expense() { ExpenseType = "Transportation", ExpenseAmount = 50 }
                    }
                },
                new Person()
                {
                    Name = "Lisa",
                    Department = "Marketing",
                    Expenses = new Expenses()
                    {
                        new Expense() { ExpenseType = "Document printing", ExpenseAmount = 50 },
                        new Expense() { ExpenseType = "Gift", ExpenseAmount = 125 }
                    }
                },
                new Person()
                {
                    Name = "John",
                    Department = "Engineering",
                    Expenses = new Expenses()
                    {
                        new Expense() { ExpenseType = "Magazine subscription", ExpenseAmount = 50 },
                        new Expense() { ExpenseType = "New machine", ExpenseAmount = 600 },
                        new Expense() { ExpenseType = "Software", ExpenseAmount = 500 }
                    }
                },
                new Person()
                {
                    Name = "Mary",
                    Department = "Finance",
                    Expenses = new Expenses()
                    {
                        new Expense() { ExpenseType = "Dinner", ExpenseAmount = 100 }
                    }
                },
                new Person()
                {
                    Name = "Theo",
                    Department = "Marketing",
                    Expenses = new Expenses()
                    {
                        new Expense() { ExpenseType = "Dinner", ExpenseAmount = 100 }
                    }
                },
                new Person()
                {
                    Name = "James",
                    Department = "Restourant",
                    Expenses = new Expenses()
                    {
                        new Expense() { ExpenseType = "Lunch", ExpenseAmount = 50 }
                    }
                },
                 new Person()
                 {
                    Name = "David",
                    Department = "Mall",
                    Expenses = new Expenses()
                    {
                        new Expense() { ExpenseType = "Clothes", ExpenseAmount = 120 }
                    }
                 }
            };



            //Previous type of entering the data
            /*ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name = "Mike",
                    Department = "Legal",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType = "Lunch", ExpenseAmount = 50 },
                        new Expense() { ExpenseType = "Transportation", ExpenseAmount = 50 }
                    }
                },
                new Person()
                {
                    Name = "Lisa",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType = "Document printing", ExpenseAmount = 50 },
                        new Expense() { ExpenseType = "Gift", ExpenseAmount = 125 }
                    }
                },
                new Person()
                {
                    Name = "John",
                    Department = "Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType = "Magazine subscription", ExpenseAmount = 50 },
                        new Expense() { ExpenseType = "New machine", ExpenseAmount = 600 },
                        new Expense() { ExpenseType = "Software", ExpenseAmount = 500 }
                    }
                },
                new Person()
                {
                    Name = "Mary",
                    Department = "Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType = "Dinner", ExpenseAmount = 100 }
                    }
                },
                new Person()
                {
                    Name = "Theo",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType = "Dinner", ExpenseAmount = 100 }
                    }
                },
                new Person()
                {
                    Name = "James",
                    Department = "Restourant",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType = "Lunch", ExpenseAmount = 50 }
                    }
                },
                 new Person()
                 {
                    Name = "David",
                    Department = "Mall",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType = "Clothes", ExpenseAmount = 120 }
                    }
                 }
            };*/
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReport = new ExpenseReport(this.peopleListBox.SelectedItem)
            {
                Height = this.Height,
                Width = this.Width
            };
            expenseReport.ShowDialog();
            this.Close();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }


        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public string MainCaptionText { get; set; }

        public List<Person> ExpenseDataSource { get; set; }
    }
}
