using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    static public class UserData
    {
        private static UserContext dbContext = new UserContext();
        static private List<User> _testUsers;

        private static void ResetTestUserData()
        {
            if (TestUsersIfEmpty())
            {
                CreateUsers();
                foreach (User user in _testUsers)
                {
                    dbContext.Users.Add(user);
                }
                dbContext.SaveChanges();
            }
        }

        private static bool TestUsersIfEmpty()
        {
            IEnumerable<User> queryStudents = dbContext.Users;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }

        static private void CreateUsers()
        {
            _testUsers = new List<User>();
            _testUsers.Add(new User("admin", "admin", "121217059", UserRoles.ADMIN, DateTime.Now, DateTime.Now.AddYears(1)));
            _testUsers.Add(new User("Georgi", "asdfgh", "232323232", UserRoles.STUDENT, DateTime.Now.AddDays(1), DateTime.Now.AddYears(2)));
            _testUsers.Add(new User("Stamat", "zxcvbn", "343434343", UserRoles.STUDENT, DateTime.Now.AddDays(2), DateTime.Now.AddYears(3)));
        }

        public static void DeleteUserByFacultyNumber(string facultyNumber)
        {
            User user = (from usr in dbContext.Users
                         where usr.FacultyNumber == facultyNumber
                         select usr).First();
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }

        static public User isUserPassCorrect(String username, String password)
        {
            User user = (from u in dbContext.Users
                         where u.Username.Equals(username) &&
                               u.Password.Equals(password)
                         select u).FirstOrDefault();
            return user;
        }

        static public void SetUserActiveTo(String name, DateTime dateTime)
        {
            User user = GetUserByUsername(name);
            user.isActive = dateTime;
            Logger.LogActivity("Activity changed for User : " + name);
        }

        static public void AssignUserRole(String name, UserRoles role)
        {
            UserContext context = new UserContext();
            User usr = (from u in context.Users
                        where u.Username == name
                        select u).First();
            usr.Role = role;
            context.SaveChanges();

            Logger.LogActivity("Change role " + name);
        }

        private static User GetUserByUsername(string username)
        {
            return (from user in dbContext.Users
                    where user.Username == username
                    select user).First();
        }

        static public List<User> testUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            private set
            {
            }
        }
    }
}
