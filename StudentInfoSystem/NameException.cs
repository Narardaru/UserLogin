using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class NameException : Exception
    {
        public NameException()
        {
            Console.WriteLine("Error in name validation!");
        }
    }
}
