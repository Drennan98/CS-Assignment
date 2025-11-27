using System;
using System.IO;

namespace Timesheet // Container name. 
{
    class Program // Must be same as file name.
    {
        public static void Main(string[] args) // Main method, all executable code starts here. 
        {
            string[] fileLines = File.ReadAllLines("OrganisationWeeklyTimesheet.csv"); // Reading in csv file. 
            int numberOfEmployees = fileLines.Length - 1; // Calculating how many employees are in file and we subtract 1 as we don't need the heading. 

            Employee[] employees = new Employee[numberOfEmployees]; // Array for holding number of employees. 

            int arrayIndex = 0; // To keep count of where we are filling employee array. 

            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] columns = fileLines[i].Split(","); // Gives an array of strings called columns split by ,. 

                Employee employee = new Employee();
            }
        }

    }
}



