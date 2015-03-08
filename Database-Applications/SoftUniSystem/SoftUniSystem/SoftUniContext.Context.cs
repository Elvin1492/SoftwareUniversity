﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftUniSystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SoftUniEntities : DbContext
    {
        public SoftUniEntities()
            : base("name=SoftUniEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<usp_SelectEmployeesBySeniority_Result> usp_SelectEmployeesBySeniority(Nullable<int> minYearsAtWork)
        {
            var minYearsAtWorkParameter = minYearsAtWork.HasValue ?
                new ObjectParameter("minYearsAtWork", minYearsAtWork) :
                new ObjectParameter("minYearsAtWork", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_SelectEmployeesBySeniority_Result>("usp_SelectEmployeesBySeniority", minYearsAtWorkParameter);
        }
    
        public virtual ObjectResult<usp_SelectProjectsByEmployees_Result> usp_SelectProjectsByEmployees(string employeeFirstName, string employeeLastName)
        {
            var employeeFirstNameParameter = employeeFirstName != null ?
                new ObjectParameter("employeeFirstName", employeeFirstName) :
                new ObjectParameter("employeeFirstName", typeof(string));
    
            var employeeLastNameParameter = employeeLastName != null ?
                new ObjectParameter("employeeLastName", employeeLastName) :
                new ObjectParameter("employeeLastName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_SelectProjectsByEmployees_Result>("usp_SelectProjectsByEmployees", employeeFirstNameParameter, employeeLastNameParameter);
        }
    
        //public virtual ObjectResult<usp_GetProjectsByEmployeeName_Result> usp_GetProjectsByEmployeeName(string employeeFirstName, string employeeLastName)
        //{
        //    var employeeFirstNameParameter = employeeFirstName != null ?
        //        new ObjectParameter("employeeFirstName", employeeFirstName) :
        //        new ObjectParameter("employeeFirstName", typeof(string));
    
        //    var employeeLastNameParameter = employeeLastName != null ?
        //        new ObjectParameter("employeeLastName", employeeLastName) :
        //        new ObjectParameter("employeeLastName", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetProjectsByEmployeeName_Result>("usp_GetProjectsByEmployeeName", employeeFirstNameParameter, employeeLastNameParameter);
        //}
    }
}
