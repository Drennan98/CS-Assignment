using System;
using System.IO;

namespace Timesheet // Container name. 
{
    class Program // Must be same as file name.
    {
        public static void Main(string[] args) // Main method, all executable code starts here. 
        {
            string filePath = "Resources/OrganisationWeeklyTimesheet.csv";
            string[] data = File.ReadAllLines(filePath);

            for(int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }

        }

    }
}



