using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TowersOfHanoi.CrossCutting;
using TowersOfHanoi.Domain.Common;

namespace TowersOfHanoi.Data
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        //Necessario para codefirst.
        public IDbSet<Domain.Users.User> User { get; set; }
        public IDbSet<Domain.Histories.History> History { get; set; }

        public DatabaseService() : base("connection")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Database.CreateIfNotExists();
            Database.Log = log => Debug.WriteLine(log);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType?.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            var typesConfigurations = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                                                     && type.BaseType.GetGenericTypeDefinition() ==
                                                     typeof(EntityTypeConfiguration<>));

            foreach (var type in typesConfigurations)
            {
                dynamic configInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : AbstractEntity => base.Set<TEntity>();

        public new EntityState Entry<TEntity>(TEntity entity) where TEntity : AbstractEntity =>
            base.Entry(entity).State = EntityState.Modified;

    }
}