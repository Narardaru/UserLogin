using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public int UserId
        { 
            get; 
            set; 
        }

        public String Username
        {
            get;
            set;
        }

        public String Password
        {
            get;
            set;
        }

        public String FacultyNumber
        {
            get;
            set;
        }

        public UserRoles Role
        {
            get;
            set;
        }

        public DateTime? created 
        { 
            get; 
            set; 
        }

        public DateTime? isActive 
        { 
            get; 
            set; 
        }

        public User(String username, String password, String fakNum, UserRoles role, DateTime created1, DateTime isActive1)
        {
            Username = username;
            Password = password;
            FacultyNumber = fakNum;
            Role = role;
            created = created1;
            isActive = isActive1;
        }

        public User()
        {

        }

        public override string ToString()
        {
            return "Username: " + Username + " " +
                   "Password: " + Password + " " +
                   "FakNum: " + FacultyNumber + " " +
                   "Role: " + Role + " " +
                   "Created: " + created + " " +
                   "IsActive: " + isActive;
        }
    }
}
