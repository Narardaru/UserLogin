using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public static Student GetStudentDataByUser(User user)
        {
            return StudentData.IsThereStudent(user.FacultyNumber);
        }
    }
}
