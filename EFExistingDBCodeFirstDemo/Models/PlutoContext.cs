namespace EFExistingDBCodeFirstDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Author>()
            //    .HasMany(e => e.Courses)
            //    .WithOptional(e => e.Author)
            //    .HasForeignKey(e => e.AuthorId);

            //modelBuilder.Entity<Course>()
            //    .HasMany(e => e.Tags)
            //    .WithMany(e => e.Courses)
            //    .Map(m => m.ToTable("TagCourses").MapLeftKey("Course_Id"));

            modelBuilder.Entity<Course>()
                .ToTable("Courses");

            modelBuilder.Entity<Course>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Course>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(2000);

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });

            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
