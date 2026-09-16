
using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

namespace School_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=schoolDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> Classrooms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Department>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100); 
            
            modelBuilder.Entity<Department>()
                .Property(d => d.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.FristName).
                IsRequired()
                .HasMaxLength(50);
            
            modelBuilder.Entity<Teacher>()
                .Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50); 
            
            
            modelBuilder.Entity<Teacher>()
                .Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(150);
            
            
            modelBuilder.Entity<Teacher>()
                .Property(t => t.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(20); 
            
           modelBuilder.Entity<Subject>()
                .Property(s => s.Name) 
                .IsRequired() 
                .HasMaxLength(100); 


            modelBuilder.Entity<Subject>()
                .Property(s => s.Description)
                .IsRequired(false)
                .HasMaxLength(500);


            modelBuilder.Entity<Subject>() 
                .Property(s => s.MaxGrade) 
                .IsRequired();
            
            modelBuilder.Entity<ClassRoom>() 
                .Property(c => c.Name) 
                .IsRequired()
                .HasMaxLength(50); 
            
            modelBuilder.Entity<ClassRoom>()
                .Property(c => c.GradeLevel)
                .IsRequired();


            modelBuilder.Entity<ClassRoom>() 
                .Property(c => c.Capacity) 
                .IsRequired(); 
            
            modelBuilder.Entity<Student>()
                .Property(s => s.FristName) 
                .IsRequired() 
                .HasMaxLength(50);
            
            modelBuilder.Entity<Student>() 
                .Property(s => s.LastName) 
                .IsRequired()
                .HasMaxLength(50); 
            
            modelBuilder.Entity<Student>()
                .Property(s => s.Email) 
                .IsRequired() 
                .HasMaxLength(150);
            
            modelBuilder.Entity<Student>() 
                .Property(s => s.PhoneNumber) 
                .IsRequired(false)
                .HasMaxLength(20);

            modelBuilder.Entity<Student>() 
                .Property(s => s.DateOfBirth) 
                .IsRequired();
            
            modelBuilder.Entity<Enrollment>() 
                .Property(e => e.StudentId) 
                .IsRequired(); 

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.SubjectId) 
                .IsRequired();
            
            
            modelBuilder.Entity<Enrollment>() 
                .Property(e => e.EnrollmentDate) 
                .IsRequired();
          
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.teachers)
                .HasForeignKey(s => s.DepartmentId);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Student>()
                .HasOne(c => c.ClassRoom)
                .WithMany(s =>  s.Students)
                .HasForeignKey(s => s.ClassRoomId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(s => s.Subject)
                .WithMany(e => e.enrollments)
                .HasForeignKey(s => s.SubjectId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(s => s.Student)
                .WithMany(e => e.enrollments)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary)
                .HasPrecision(18 ,2);


            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade)
                .HasPrecision (5 ,2);






        }
        




    }
}
