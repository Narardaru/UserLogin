using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public override string ToString() { return this.FirstName; }
    }
}
