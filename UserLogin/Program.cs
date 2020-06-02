using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    class Program
    {
        public static void printError(String message)
        {
            Console.WriteLine("!!! " + message + " !!!");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                if (LoginValidation.CountFailedLog())
                {
                    Logger.LogActivity("You can not login");
                    Console.WriteLine("You can not login");
                    return;
                }

                Console.WriteLine("Enter username: ");
                String username = Console.ReadLine();

                Console.WriteLine("Enter password: ");
                String password = Console.ReadLine();

                LoginValidation login = new LoginValidation(username, password, printError);

                User user = new User();
                if (login.ValidateUserInput(ref user))
                {
                    Console.WriteLine(user.ToString());

                    Console.WriteLine("Role of user: " + LoginValidation.currentUserRole);
                    switch (user.Role)
                    {
                        case UserRoles.ANONYMOUS:
                            Console.WriteLine("User is anonymous");
                            break;
                        case UserRoles.ADMIN:
                            Console.WriteLine("User is admin");
                            bool showMenu = true;
                            while (showMenu)
                            {
                                showMenu = administrator();
                            }
                            break;
                        case UserRoles.INSPECTOR:
                            Console.WriteLine("User is stident");
                            break;
                        case UserRoles.PROFESSOR:
                            Console.WriteLine("User is professor");
                            break;
                        case UserRoles.STUDENT:
                            Console.WriteLine("User is inspektor");
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
                else
                {
                    Logger.LogActivity("Fail " + DateTime.Now);
                    bool isUserFailedToLogin = LoginValidation.CountFailedLog();
                    if (isUserFailedToLogin)
                    {
                        Console.WriteLine("Now you can`t login.");
                        return;
                    }
                }
            }
        }

        public static bool administrator()
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Select option");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change role");
                Console.WriteLine("2: Change activity");
                Console.WriteLine("3: Print all users");
                Console.WriteLine("4: Visualization of log file");
                Console.WriteLine("5: Visualization of current activity");
                Console.WriteLine("Enter: ");
                int option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter username: ");
                        String username = Console.ReadLine();

                        Console.WriteLine("Enter role: ");
                        Int32 role = Int32.Parse(Console.ReadLine());

                        if (Enum.IsDefined(typeof(UserRoles), role))
                        {
                            UserRoles newRole = (UserRoles)role;
                            UserData.AssignUserRole(username, newRole);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter username: ");
                        String name = Console.ReadLine();

                        Console.WriteLine("Enter role: ");
                        DateTime date = DateTime.Now;
                        Console.WriteLine(date);

                        UserData.SetUserActiveTo(name, date);
                        break;
                    case 3:
                        UserContext context = new UserContext();
                        List<User> usr = (from u in context.Users select u).ToList();
                        foreach (User user in usr)
                        {
                            Console.WriteLine(user.ToString());
                        }
                        break;
                    case 4:
                        StreamReader sr = new StreamReader("test.txt");
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        break;
                    case 5:
                        Logger.GetCurrentSessionActivities();
                        break;
                    case 0:
                        flag = false;
                        break;
                }
            }
            return flag;
        }
    }
}