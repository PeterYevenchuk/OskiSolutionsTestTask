using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Questions;

namespace OskiFSPY.Core.Context.DBConfiguration;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.QuestionId);
        builder.Property(q => q.QuestionText).IsRequired().HasMaxLength(500);
        builder.Property(q => q.Points).IsRequired();
        builder.HasOne(q => q.Test)
            .WithMany()
            .HasForeignKey(q => q.TestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
