namespace SimpleTimesheet
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Call the method to read the file
            Employee[] allEmployees = ReadDataFromFile();

            // 2. Call the method to find unique departments
            string[] uniqueDepartments = FindUniqueDepartments(allEmployees);

            // 3. Helper: We need to count how many departments were actually found
            // (Because the array has null slots, we need to count the non-null ones)
            int deptCount = CountValidDepartments(uniqueDepartments);

            // 4. Call the method to do the math and create the text lines
            string[] linesToSave = CalculateAndGenerateReport(allEmployees, uniqueDepartments, deptCount);

            // 5. Call the method to save the file
            SaveFile(linesToSave, deptCount);
        }

        static Employee[] ReadDataFromFile()
        {
            // Read the entire text file from the hard drive into a String Array.
            string[] lines = File.ReadAllLines("Resources/OrganisationWeeklyTimesheet.csv");

            // Calculate how many employees are in the file (minus header).
            int numberOfEmployees = lines.Length - 1;

            // Create an empty Array of 'Employee' objects.
            Employee[] employees = new Employee[numberOfEmployees];

            int arrayIndex = 0;

            // Loop through the file lines (start at 1 to skip Header).
            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');

                Employee newEmp = new Employee();
                newEmp.Name = columns[0].Trim();
                newEmp.Department = columns[1].Trim();

                double mon = double.Parse(columns[2]);
                double tue = double.Parse(columns[3]);
                double wed = double.Parse(columns[4]);
                double thu = double.Parse(columns[5]);
                double fri = double.Parse(columns[6]);

                newEmp.Hours = mon + tue + wed + thu + fri;

                employees[arrayIndex] = newEmp;
                arrayIndex++;
            }

            // Send the filled array back to Main
            return employees;
        }
        static string[] FindUniqueDepartments(Employee[] allEmployees)
        {
            // Create an array to hold the department names.
            string[] uniqueDepartments = new string[allEmployees.Length];
            int deptCount = 0;

            for (int i = 0; i < allEmployees.Length; i++)
            {
                string currentDept = allEmployees[i].Department;
                bool alreadyExists = false;

                for (int j = 0; j < deptCount; j++)
                {
                    if (uniqueDepartments[j] == currentDept)
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                if (alreadyExists == false)
                {
                    uniqueDepartments[deptCount] = currentDept;
                    deptCount++;
                }
            }

            return uniqueDepartments;
        }

        static int CountValidDepartments(string[] depts)
        {
            // We loop until we hit a "null" (empty) slot to find the real count.
            int count = 0;
            for(int i = 0; i < depts.Length; i++)
            {
                if (depts[i] != null)
                {
                    count++;
                }
            }
            return count;
        }
        static string[] CalculateAndGenerateReport(Employee[] allEmployees, string[] uniqueDepartments, int deptCount)
        {
            int totalLinesNeeded = deptCount * 5;
            string[] linesToSave = new string[totalLinesNeeded];
            int currentLineIndex = 0;

            for (int i = 0; i < deptCount; i++)
            {
                string deptName = uniqueDepartments[i];

                double totalHours = 0;
                int employeeCount = 0;
                double highestHoursFound = -1;
                string bestEmployeeName = "";

                // Loop through the full list of employees.
                for (int j = 0; j < allEmployees.Length; j++)
                {
                    if (allEmployees[j].Department == deptName)
                    {
                        totalHours = totalHours + allEmployees[j].Hours;
                        employeeCount++;

                        if (allEmployees[j].Hours > highestHoursFound)
                        {
                            highestHoursFound = allEmployees[j].Hours;
                            bestEmployeeName = allEmployees[j].Name;
                        }
                    }
                }

                double averageHours = totalHours / employeeCount;

                // Fill the output array.
                linesToSave[currentLineIndex] = "Department – " + deptName;
                linesToSave[currentLineIndex + 1] = "Total Hours Worked by Department: " + totalHours + " Hours";
                linesToSave[currentLineIndex + 2] = "Average Hours Worked by Employees: " + averageHours + " Hours";
                linesToSave[currentLineIndex + 3] = "Employee with Most Hours Worked: " + bestEmployeeName;
                linesToSave[currentLineIndex + 4] = "";

                currentLineIndex = currentLineIndex + 5;
            }

            return linesToSave;
        }
        static void SaveFile(string[] linesToSave, int deptCount)
        {
            // Take the array of strings and write it to the hard drive.
            File.WriteAllLines("OrganisationDepartmentTotals.txt", linesToSave);

            Console.WriteLine("Done! Created report for " + deptCount + " departments.");
            Console.ReadLine();
        }
    }
}
