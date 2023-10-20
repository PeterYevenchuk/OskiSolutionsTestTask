using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Answers;
using OskiFSPY.Core.Questions;
using OskiFSPY.Core.Tests;
using OskiFSPY.Core.Users;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core.Context;

public class OskiTestTaskContext : DbContext
{
    public OskiTestTaskContext(DbContextOptions<OskiTestTaskContext> options) : base(options) { }

    public DbSet<UserTestStatus> UserTestStatuses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}
