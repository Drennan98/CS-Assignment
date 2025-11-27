using System;
using System.IO;

namespace Timesheet // Container name. 
{
    class Program // Must be same as file name.
    {
        public static void Main(string[] args) // Main method, all executable code starts here. 
        {
            string fileLines = "Resources/OrganisationWeeklyTimesheet.csv"; // Reading in csv file. 
            int numberOfEmployees = fileLines.Length - 1; // Calculating how many employees are in file and we subtract 1 as we don't need the heading. 

            Employee[] employees = new Employee[numberOfEmployees]; 
        }

    }
}



