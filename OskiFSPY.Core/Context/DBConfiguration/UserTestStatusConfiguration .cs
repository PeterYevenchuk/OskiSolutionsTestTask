﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core.Context.DBConfiguration;

public class UserTestStatusConfiguration : IEntityTypeConfiguration<UserTestStatus>
{
    public void Configure(EntityTypeBuilder<UserTestStatus> builder)
    {
        builder.HasKey(uts => uts.UserTestStatusId);
        builder.Property(uts => uts.Rating).IsRequired();
        builder.Property(uts => uts.TestId).IsRequired(false);
        builder.HasOne(uts => uts.Test)
            .WithMany()
            .HasForeignKey(uts => uts.TestId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

