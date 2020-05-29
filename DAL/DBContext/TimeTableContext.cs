using DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
    public class TimeTableContext : IdentityDbContext<Teacher>
    {
        public TimeTableContext(DbContextOptions<TimeTableContext> options):base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherProfile> TeacherProfiles { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TimeTableOfTheDay> TimeTableOfTheDays { get; set; }
        public DbSet<TimetableOfTheWeek> TimetableOfTheWeeks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .Entity<Teacher>()
                .HasOne(u => u.TeacherUserProfile)
                .WithOne(p => p.Teacher)
                .HasForeignKey<TeacherProfile>(p => p.TeacherId);
        }

    }
}
