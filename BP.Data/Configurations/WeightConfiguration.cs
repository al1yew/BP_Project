using BP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data.Configurations
{
    public class WeightConfiguration : IEntityTypeConfiguration<Weight>
    {
        public void Configure(EntityTypeBuilder<Weight> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
