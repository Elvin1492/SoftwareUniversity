namespace SoftUniSystem
{
    using System;
    using System.Collections.Generic;

    public  class ProjectCRUD
    {
        public static void CreateProject(
            string name,
            string description, 
            DateTime startDate,
            DateTime endDate,
            ICollection<Employee> employees)
        {
            var db = new SoftUniEntities();           
            using(db)
            {
                var dbTransaction = db.Database.BeginTransaction();
                using(dbTransaction)
                {
                    try
                    {
                        Console.WriteLine("Adding new project to database.");

                        var project = new Project
                        {
                            Name =  name,
                            Description = description,
                            StartDate = startDate,
                            EndDate = endDate,
                            Employees = employees
                        };

                        db.Projects.Add(project);
                        db.SaveChanges();
                        dbTransaction.Commit();

                        Console.WriteLine("Project added successfuly.");
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        Console.WriteLine("Adding new project failed.");
                    }
                }
            }
        }
    }
}
