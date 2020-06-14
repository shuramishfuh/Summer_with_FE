namespace Summer.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<AdvanceLevel> AdvanceLevels { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OrdinaryLevel> OrdinaryLevels { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TestScore> TestScores { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<WeekNumber> WeekNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.TestScores)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasOptional(e => e.AdvanceLevel)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .HasOptional(e => e.OrdinaryLevel)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.TestScores)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<WeekNumber>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.WeekNumbers)
                .HasForeignKey(e => e.WeekNumber)
                .WillCascadeOnDelete();
        }


    }
}
