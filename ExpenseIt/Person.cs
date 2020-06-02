using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt
{
    public class Person
    {
        private string name;
        private string department;
        //private List<Expense> expenses;

        private Expenses expenses;

        /*public Person(string name, string department, List<Expense> expenses)
        {
            this.name = name;
            this.department = department;
            this.expenses = expenses;
        }*/

        public Person(string name, string department, Expenses expenses)
        {
            this.name = name;
            this.department = department;
            this.expenses = expenses;
        }

        public Person()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        /*public List<Expense> Expenses
        {
            get { return expenses; }
            set { expenses = value; }
        }*/

        public Expenses Expenses
        {
            get { return expenses; }
            set { expenses = value; }

        }
    }
}
