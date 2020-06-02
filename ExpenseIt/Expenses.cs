using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ExpenseIt
{
    public class Expenses : IList
    {

        private Expense[] _expenses = new Expense[20];
        private int _count;

        public Expenses()
        {
            _count = 0;
        }

        public object this[int index] {
            get
            {
                return _expenses[index];
            }
            set
            {
                _expenses[index] = (Expense)value;
            }
        }

        /*Expense IList<Expense>.this[int index]
        {
            get { return _expenses[index]; }
            set { this._exp = _expenses[index]; }
        }*/



        public bool IsReadOnly => false;

        public int Count
        {
            get { return _count; }
        }

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public bool IsFixedSize => true;

        public int Add(object value)
        {
            if (_count < _expenses.Length)
            {
                _expenses[_count] = (Expense)value;
                _count++;

                return (_count - 1);
            }

            return -1;
        }

        public void Clear()
        {
            _count = 0;
        }

        /*public bool Contains(Expense item)
        {
            if (item == null)
                throw new Exception("Null object entered");
            return _expenses.Contains(item);
        }*/

        public bool Contains(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_expenses[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        /*public void CopyTo(Expense[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /*public void CopyTo(Array array, int index)
        {
            _expenses.CopyTo(array, index);
        }*/

         public void CopyTo(Array array, int index)
         {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_expenses[i], index++);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _expenses.GetEnumerator();
        }

       /* public int IndexOf(Expense item)
        {
            if (item == null)
                throw new Exception("Null object entered");
            return _expenses.IndexOf(item);
        }*/

        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_expenses[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, Expense item)
        {/*
            if (index < 0)
            {
                if (item != null)
                {
                    _expenses.Insert(index, item);
                }
                else
                {
                    throw new NullReferenceException();
                }
            } 
            else
            {
                throw new IndexOutOfRangeException();
            }*/
        }

        public void Insert(int index, object value)
        {
            if ((_count + 1 <= _expenses.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _expenses[i] = _expenses[i - 1];
                }
                _expenses[index] = (Expense)value;
            }
        }

        /*public bool Remove(Expense item)
        {
            return _expenses.Remove(item);
        }*/

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            /*if (index < 0 && _expenses.Count < index)
                _expenses.RemoveAt(index);
            throw new IndexOutOfRangeException();*/
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _expenses[i] = _expenses[i + 1];
                }
                _count--;
            }
        }

    }
}
