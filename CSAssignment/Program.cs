using System;
using System.IO;

namespace Timesheet // Container name. 
{
    class Program // Must be same as file name.
    {
        public static void Main(string[] args) // Main method, all executable code starts here. 
        {
            string[] fileLines = File.ReadAllLines("./Resources/OrganisationWeeklyTimesheet.csv"); // Reading in csv file. s
            int numberOfEmployees = fileLines.Length - 1; // Calculating how many employees are in file and we subtract 1 as we don't need the heading. 

            Employee[] employees = new Employee[numberOfEmployees]; // Array for holding number of employees. 

            int arrayIndex = 0; // To keep count of where we are filling employee array. 

            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] columns = fileLines[i].Split(","); // Gives an array of strings called columns split by ,. 

                Employee newEmployee = new Employee(); // New instance of employee. 

                newEmployee.Name = columns[0]; // New employee name which is given index 0 as Name is first heading in our array of columns. 
                newEmployee.Department = columns[1]; // New employee Department which is given index 1 as Department is second heading in our array of columns. 


                // We need to convert numbers into doubles, i.e 8.0. The CSV file currently has them in strings. 

                double mon = double.Parse(columns[2]); // Monday 
                double tues = double.Parse(columns[3]); // Tuesday
                double wed = double.Parse(columns[4]); // Wednesday
                double thurs = double.Parse(columns[5]); // Thursday
                double fri = double.Parse(columns[6]); // Friday 

                newEmployee.Hours = mon + tues + wed + thurs + fri; // Adding up 5 days together to get employee hours. 

                employees[arrayIndex] = newEmployee; // New employee is placed into main array.
                arrayIndex++; // Increments as next employee goes into next slot. 
            }

            string[] differentDepartments = new string[numberOfEmployees]; // Create array for different departments. 

            int deptCount = 0; 
        }
    }

}



