namespace ISS.Models.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBO_iss : DbContext
    {
        public DBO_iss()
            : base("name=DBO_iss")
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<answare> answares { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Courses_Program> Courses_Program { get; set; }
        public virtual DbSet<Current_courses> Current_courses { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<DevamZamani> DevamZamanis { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<quiz> quizs { get; set; }
        public virtual DbSet<type> types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Adress>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Adress>()
                .Property(e => e.neighborhood)
                .IsUnicode(false);

            modelBuilder.Entity<Adress>()
                .Property(e => e.detailes)
                .IsUnicode(false);

            modelBuilder.Entity<Adress>()
                .HasMany(e => e.AspNetUsers)
                .WithOptional(e => e.Adress)
                .HasForeignKey(e => e.AdressID);

            modelBuilder.Entity<Announcement>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<answare>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<answare>()
                .Property(e => e.answare_number)
                .IsFixedLength();

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Announcements)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.teacher_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Current_courses)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.teacher_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.news)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.quizs)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Current_courses1)
                .WithMany(e => e.AspNetUsers)
                .Map(m => m.ToTable("Registered_course").MapLeftKey("student_ID").MapRightKey("currently_courses_ID"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Current_courses)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Current_courses>()
                .Property(e => e.describe)
                .IsUnicode(false);

            modelBuilder.Entity<Current_courses>()
                .HasMany(e => e.Announcements)
                .WithRequired(e => e.Current_courses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Current_courses>()
                .HasMany(e => e.Courses_Program)
                .WithOptional(e => e.Current_courses)
                .HasForeignKey(e => e.Courrnt_course_ID);

            modelBuilder.Entity<Day>()
                .Property(e => e.day1)
                .IsUnicode(false);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.Courses_Program)
                .WithRequired(e => e.Day)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DevamZamani>()
                .HasMany(e => e.Courses_Program)
                .WithOptional(e => e.DevamZamani)
                .HasForeignKey(e => e.devam_ID);

            modelBuilder.Entity<Picture>()
                .Property(e => e.picture_path)
                .IsUnicode(false);

            modelBuilder.Entity<Picture>()
                .HasMany(e => e.AspNetUsers)
                .WithOptional(e => e.Picture)
                .HasForeignKey(e => e.PictureID);

            modelBuilder.Entity<question>()
                .Property(e => e.timestamps)
                .IsFixedLength();

            modelBuilder.Entity<question>()
                .Property(e => e.describe)
                .IsUnicode(false);

            modelBuilder.Entity<quiz>()
                .Property(e => e.time)
                .IsFixedLength();

            modelBuilder.Entity<quiz>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<quiz>()
                .HasMany(e => e.questions)
                .WithRequired(e => e.quiz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<type>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.type)
                .HasForeignKey(e => e.type_ID);

            modelBuilder.Entity<type>()
                .HasMany(e => e.quizs)
                .WithRequired(e => e.type)
                .WillCascadeOnDelete(false);
        }
    }
}
