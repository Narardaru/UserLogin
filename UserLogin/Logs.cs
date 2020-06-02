using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Logs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogsId
        {
            get;
            set;
        }
        public DateTime? Date
        {
            get; set;
        }
        public string Activity
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }
        public UserRoles Role
        {
            get; set;
        }

        public Logs()
        {

        }
        public Logs(string username, UserRoles role, string activity)
        {
            Date = DateTime.Now;
            Username = username;
            Role = role;
            Activity = activity;
        }
        public override string ToString()
        {
            return Date + " " + Username + " " + Role + " " + Activity + "\r\n";
        }
    }
}
