using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {

        //static private List<Student> students;
        static private StudentsList students;

        /*
        public static List<Student> getAllStudents()
        {
            students = new List<Student>();

            students.Add(new Student("Pesho", "Peshov", "Peshov", "FKSU", "KSI", "bachelor", Status.CERTIFIED, "121217001", 3, 9, 36));
            students.Add(new Student("Gosho", "Goshov", "Goshov", "FKSU", "KSI", "bachelor", Status.DISCONTINUED,  "121223456", 3, 9, 37));
            students.Add(new Student("Stoyanka", "Ivanova", "Dimitrova", "FKSU", "KSI", "bachelor", Status.SEMESTERS_COMPLETED, "121213285", 3, 9, 38));

            return students;
        }*/

        public static StudentsList getAllStudents()
        {
            students = new StudentsList();

            students.Add(new Student("Pesho", "Peshov", "Peshov", "FKSU", "KSI", "bachelor", Status.CERTIFIED, "121217001", 3, 9, 36));
            students.Add(new Student("Gosho", "Goshov", "Goshov", "FKSU", "KSI", "bachelor", Status.DISCONTINUED, "121223456", 3, 9, 37));
            students.Add(new Student("Stoyanka", "Ivanova", "Dimitrova", "FKSU", "KSI", "bachelor", Status.SEMESTERS_COMPLETED, "121213285", 3, 9, 38));

            return students;
        }

        public static Student IsThereStudent(String facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student result = (from st in context.Students where st.FacultyNumber == facNum select st).First();
            return result;
        }
    }
}
