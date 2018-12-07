using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using TowersOfHanoi.Api.Data.Abstracts;
using TowersOfHanoi.Api.Data.Entities;

namespace TowersOfHanoi.Api.Data.Concretes
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public DbSet<PegHistory> PegHistory { get; set; }
        public DbSet<User> UserHistory { get; set; }

        public MyDbContext() : base("connection")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Database.Log = log => Debug.WriteLine(log);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType?.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity => base.Set<TEntity>();
        
    }
}