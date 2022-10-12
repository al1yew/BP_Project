using BP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data.Configurations
{
    public class AssessmentConfiguration : IEntityTypeConfiguration<Assessment>
    {
        public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.Property(x => x.DistanceId).IsRequired();
            builder.Property(x => x.FrequencyId).IsRequired();
            builder.Property(x => x.WeightId).IsRequired();
        }
    }
}
