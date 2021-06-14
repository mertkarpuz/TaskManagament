using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Navyki.Todo.Entities.Concrete;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnType("ntext");
            builder.HasOne(I => I.Urgency).WithMany(I => I.Works).HasForeignKey(I => I.UrgencyId);
        }
    }
}
