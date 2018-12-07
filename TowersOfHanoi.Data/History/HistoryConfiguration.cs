using System.Data.Entity.ModelConfiguration;

namespace TowersOfHanoi.Data.History
{
    public class HistoryConfiguration : EntityTypeConfiguration<Domain.Histories.History>
    {
        public HistoryConfiguration()
        {
            ToTable("history");
            Property(p => p.Start)
                .HasColumnName("start")
                .IsRequired();

            Property(p => p.End)
                .HasColumnName("end")
                .IsRequired();
        }
    }
}