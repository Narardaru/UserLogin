using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace StudentInfoSystem
{
    public class StudentsList : IList
    {
        private Student[] _students = new Student[100];
        private int _count;


        public StudentsList()
        {
            _count = 0;
            Console.WriteLine("patka");
        }


        public object this[int index]
        {
            get
            {
                return _students[index];
            }
            set
            {
                _students[index] = (Student)value;
            }
        }


        public bool IsReadOnly => false;

        public bool IsFixedSize => true;

        public int Count
        {
            get { return _count; }
        }

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public int Add(object value)
        {
             
                if (_count < _students.Length)
                {
                    _students[_count] = (Student)value;
                    _count++;

                    return (_count - 1);
                }
            

            return -1;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(object value)
        {
            for(int i = 0; i < Count; i++)
            {
                if(_students[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            for(int i = 0; i < Count; i++)
            {
                array.SetValue(_students[i], index++);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            for(int i = 0; i < Count; i++)
            {
                if(_students[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, object value)
        {
            if ((_count + 1 <= _students.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for(int i = Count - 1; i > index; i--)
                {
                    _students[i] = _students[i - 1];
                }
                _students[index] = (Student)value;
            }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if((index >= 0) && (index < Count))
            {
                for(int i = index; i < Count - 1; i++)
                {
                    _students[i] = _students[i + 1];
                }
                _count--;
            }
        }

        //my methods

        public void RemoveGroup(int group)
        {
            for(int i = 0; i <= Count; i++)
            {
                if (_students[i].Group == group)
                {
                    RemoveAt(i);
                }
            }
        }

        public StudentsList GetByStatus(Status status)
        {
            StudentsList stList = new StudentsList();

            for(int i = 0; i <= Count; i++)
            {
                if(_students[i].Status == status)
                {
                    stList.Add(_students[i]);
                }
            }
            return stList;
        }

        /*
        public Student GetByLastName(string name)
        {
            foreach(Student st in _students)
            {
                if (st.LastName.Equals(name)) return st;
            }
            return null;
        }*/

        public StudentsList GetByLastName(string name)
        {
            StudentsList stList = new StudentsList();

            for (int i = 0; i <= Count; i++)
            {
                if (_students[i].LastName.Equals(name))
                {
                    stList.Add(_students[i]);
                }
            }
            return stList;
        }


        public StudentsList GetByFstAndLstName(string fname, string lname)
        {
            StudentsList stList = new StudentsList();

            for (int i = 0; i <= Count; i++)
            {
                if (_students[i].FirstName.Equals(fname)&&(_students[i].LastName.Equals(lname)))
                {
                    stList.Add(_students[i]);
                }
            }
            return stList;
        }

        public void SortStudentsList() //Използвайки insertionsort, сортира студентите спрямо курса си във възходящ ред с цел бързодействие при обхождане на масива.
        {
            for(int i = 1; i < Count; ++i)
            {
                int key = _students[i].Course;
                int j = i - 1;

                while(j >= 0 && _students[j].Course > key)
                {
                    _students[j + 1] = _students[j];
                    j = j - 1;
                }
                _students[j + 1].Course = key;
            }
        }

        public StudentsList GetByCourse(string degree, int course)
        {
            StudentsList stList = new StudentsList();

            for (int i = 0; i <= Count; i++)
            {
                if (_students[i].Degree.Equals(degree))
                {
                    if (_students[i].Course == course)
                    {
                        stList.Add(_students[i]);
                    }
                }
            }
            return stList;
        }
    }
}
