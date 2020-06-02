using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace UserLogin
{
    public class LoginValidation
    {
        private String _username;
        private String _password;
        private String _errorMessage;
        private ActionOnError _actionOnError;
        private static UserRoles _userRoles;
        private static String _userUsername;

        public delegate void ActionOnError(String errorMes);

        public LoginValidation(String _username, String _password, ActionOnError _actionOnError)
        {
            this._username = _username;
            this._password = _password;
            this._actionOnError = _actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            Boolean emptyUsername;
            emptyUsername = _username.Equals(String.Empty);
            if (emptyUsername)
            {
                _errorMessage = "Username is empty";
                _actionOnError(_errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = _username.Equals(String.Empty);
            if (emptyPassword)
            {
                _errorMessage = "Password is empty";
                _actionOnError(_errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (_username.Length < 5)
            {
                _errorMessage = "The username is less than 5 symbols";
                _actionOnError(_errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (_password.Length < 5)
            {
                _errorMessage = "The password is less than 5 symbols";
                _actionOnError(_errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.isUserPassCorrect(_username, _password);

            if (user == null)
            {
                _errorMessage = "User is not exist";
                _actionOnError(_errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            currentUserRole = (UserRoles)user.Role;
            currentUserUsername = (String)user.Username;
            Logger.LogActivity("Success Login");
            return true;
        }

        public static bool CountFailedLog()
        {
            List<string> failed = Logger.ReadFile().Where(line => line.Contains("Fail")).Reverse().ToList();

            if (failed.Count() < 3)
            {
                return false;
            }

            DateTime now = DateTime.Now;

            List<string> first = failed[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string firstDate = first[first.Count() - 1];

            TimeSpan diff = new TimeSpan(Math.Abs(now.Subtract(DateTime.Parse(firstDate)).Ticks)); 
            if (diff.TotalMinutes > 3)
            {
                return false;
            }

            List<string> last = failed[2].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string lastDate = last[last.Count() - 1];

            TimeSpan difference = new TimeSpan(Math.Abs(DateTime.Parse(firstDate).Subtract(DateTime.Parse(lastDate)).Ticks));
            if (difference.TotalMinutes <= 3)
            {
                return true;
            }
            return false;
        }   

        public static UserRoles currentUserRole
        {
            get
            {
                return _userRoles;
            }
            private set
            {
            }
        }

        public static String currentUserUsername
        {
            get
            {
                return _userUsername;
            }
            private set
            {
            }
        }
    }
}