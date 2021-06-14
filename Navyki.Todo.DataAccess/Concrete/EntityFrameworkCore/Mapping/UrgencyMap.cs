using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UrgencyMap : IEntityTypeConfiguration<Urgency>
    {
        public void Configure(EntityTypeBuilder<Urgency> builder)
        {
            builder.Property(I => I.Description).HasMaxLength(100);

        }
    }
}
