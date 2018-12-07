using System.Data.Entity.ModelConfiguration;

namespace TowersOfHanoi.Data.User
{
    public class UserConfiguration : EntityTypeConfiguration<Domain.Users.User>
    {
        public UserConfiguration()
        {
            ToTable("user");
            Property(u => u.Name)
                .HasColumnName("name")
                .IsRequired();

            HasMany(x => x.History);
        }
    }
}
