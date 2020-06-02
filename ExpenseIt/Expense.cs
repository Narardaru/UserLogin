using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt
{
    public class Expense
    {
        private string expenseType;
        private double expenseAmount;

        public Expense(string expenseType, double expenseAmount)
        {
            this.expenseType = expenseType;
            this.expenseAmount= expenseAmount;
        }

        public Expense()
        {

        }

        public string ExpenseType
        {
            get { return expenseType; }
            set { expenseType = value; }
        }

        public double ExpenseAmount
        {
            get { return expenseAmount; }
            set { expenseAmount = value; }
        }
    }
}
