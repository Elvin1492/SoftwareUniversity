namespace SoftUniSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Project
    {
        public override string ToString()
        {
            var employees = new StringBuilder();
            foreach (var employee in this.Employees)
            {
                employees.AppendLine(employee.ToString());
            }
   
            return string.Format(" Project name: {0}\n-------------------------\n Description: {1}" +
                "\n StartDate: {2}\n Enddate: {3}\n Employees:\n--------------------------\n {4}",
                this.Name,
                this.Description != null ? this.Description : "N/A",
                this.StartDate,
                this.EndDate,
                employees.ToString()
            );
        }
    }
}
