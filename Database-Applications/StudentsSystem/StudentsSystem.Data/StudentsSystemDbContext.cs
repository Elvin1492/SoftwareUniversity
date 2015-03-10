namespace StudentsSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using StudentsSystem.Data.Migrations;
    using StudentsSystem.Models;

    public class StudentsSystemDbContext : DbContext, IStudentsSystemDbContext
    {
        public StudentsSystemDbContext()
            : base("StudentsSystem")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        //public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
