namespace NewsSystem.Data
{
    using System.Data.Entity;

    using NewsSystem.Models;

    public class NewsSystemDbContext : DbContext, INewsSystemDbContext
    {
        public NewsSystemDbContext()
            : base("NewsSystem")
        {
        }

        public IDbSet<News> News { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
