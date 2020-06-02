using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    static class Logger
    {
        private static List<Logs> currentSessionActivities = new List<Logs>();

        static public void LogActivity(string activity)
        {
            Logs logs = new Logs(LoginValidation.currentUserUsername, LoginValidation.currentUserRole, activity);
            currentSessionActivities.Add(logs);
            SaveInDb(logs);

            if (File.Exists("test.txt") == true)
            {
                File.AppendAllText("test.txt", logs.ToString());
            }
        }

        private static void SaveInDb(Logs logs)
        {
            LogsContext dbContext = new LogsContext();
            dbContext.Logs.Add(logs);
            dbContext.SaveChanges();
        }

        static public void GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Logs line in currentSessionActivities)
            {
                sb.Append(line);
            }

            Console.WriteLine(sb.ToString().Trim());

        }

        static public List<string> ReadFile()
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines("test.txt");
            foreach (string line in lines)
            {
                sb.Append(line + " \n");
            }

            List<string> loggs = sb.ToString().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return loggs;
        }
    }
}