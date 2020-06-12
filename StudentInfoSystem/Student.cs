using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Faculty { get; set; }
        public String Specialty { get; set; }
        public String Degree { get; set; }
        public Status Status { get; set; }
        public String FacultyNumber { get; set; }
        public int Course { get; set; }
        public int Stream { get; set; }
        public int Group { get; set; }

        public Student()
        {

        }
        /*
        public Student(string firstName, string middleName, string lastName, string faculty, string specialty, string degree, Status status, string facultyNumber, int course, int stream, int group)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Faculty = faculty;
            Specialty = specialty;
            Degree = degree;
            Status = status;
            FacultyNumber = facultyNumber;
            Course = course;
            Stream = stream;
            Group = group;
        }*/

        public Student(string firstName, string middleName, string lastName, string faculty, string specialty, string degree, Status status, string facultyNumber, int course, int stream, int group)
        {
            if (ValidateString(firstName)) { FirstName = firstName; } else { throw new NameException(); }
            if(ValidateString(middleName)) { MiddleName = middleName; } else { throw new NameException(); }
            if(ValidateString(lastName)) { LastName = lastName; } else { throw new NameException(); }
            if(ValidateString(faculty)) { Faculty = faculty; } else { throw new Exception("Error in faculty!"); }
            if (ValidateString(specialty)) { Specialty = specialty; } else { throw new Exception("Error in specialty!"); }
            if (ValidateString(degree)) { Degree = degree; } else { throw new Exception("Error in degree!"); }
            Status = status;
            if (ValidateFacultyNum(facultyNumber)) { FacultyNumber = facultyNumber; } else { throw new Exception("Incorroect Faculty Number!"); }
            if(ValidateCourse(course)) { Course = course; } else { throw new Exception("Incorrect course year!"); }
            if (ValidateStream(stream)) { Stream = stream; } else { throw new Exception("Incorrect stream number!"); }
            if (ValidateStream(group)) { Group = group; } else { throw new Exception("Incorrect group number!"); } 
            //Изполваме ValidateStream отново понеже не знам как точно се определят групите, само знам, че над двуцифрени не може да са и няма нужда от пренаписване на същия метод с различно име.
        }


        private bool ValidateString(string name)
        {
            Regex regex = new Regex("^[A-Za-z]+$");
            if (regex.IsMatch(name)) { return true; }
            return false;
        }
        private bool ValidateFacultyNum(string num)
        {
            Regex regex = new Regex("^[0-9]{9}$");
            if (regex.IsMatch(num)) { return true; }
            return false;
        }

        private bool ValidateCourse(int course)
        {
            Regex regex = new Regex("^[1-4]{1}$");
            if (regex.IsMatch(course.ToString())) { return true; }
            return false;
        }

        private bool ValidateStream(int stream)
        {
            Regex regex = new Regex("^[0-9]{2}$");
            if (regex.IsMatch(stream.ToString())) { return true; }
            return false;
        }


        public override string ToString() { return this.FirstName; }
    }
}
