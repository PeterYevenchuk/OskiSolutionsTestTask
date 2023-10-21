using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Answers;

namespace OskiFSPY.Core.Context.DBConfiguration;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(a => a.AnswerId);
        builder.Property(a => a.AnswerText).IsRequired().HasMaxLength(300);
        builder.Property(a => a.RightAnswer).IsRequired();
        builder.HasOne(a => a.Question)
            .WithMany()
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
