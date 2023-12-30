using Microsoft.EntityFrameworkCore;
namespace mvc_project.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryInfo> SalaryInfos { get; set; }
        public EmployeeContext() { }
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmployeeDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Martin",
                   Surname = "Simpson",
                   BirthDate = new DateTime(1992, 12, 3),
                   Position = "Marketing Expert",
                   Image = "/images/Martin.jpg"
               },
                new Employee
                {
                    Id = 2,
                    Name = "Jacob",
                    Surname = "Hawk",
                    BirthDate = new DateTime(1995, 10, 2),
                    Position = "Manager",
                    Image = "/images/Jacob.jpg"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Elizabeth",
                    Surname = "Geil",
                    BirthDate = new DateTime(2000, 1, 7),
                    Position = "Software Engineer",
                    Image = "/images/Elizabeth.jpg"
                },
                new Employee
                {
                    Id = 4,
                    Name = "Kate",
                    Surname = "Metain",
                    BirthDate = new DateTime(1997, 2, 13),
                    Position = "Admin",
                    Image = "/images/Kate.jpg"
                },
                new Employee
                {
                    Id = 5,
                    Name = "Michael",
                    Surname = "Cook",
                    BirthDate = new DateTime(1990, 12, 25),
                    Position = "Marketing expert",
                    Image = "/images/Michael.jpg"
                },
                new Employee
                {
                    Id = 6,
                    Name = "John",
                    Surname = "Snow",
                    BirthDate = new DateTime(2001, 7, 15),
                    Position = "Software Engineer",
                    Image = "/images/John.jpg"
                },
                new Employee
                {
                    Id = 7,
                    Name = "Nina",
                    Surname = "Soprano",
                    BirthDate = new DateTime(1999, 9, 30),
                    Position = "Software Engineer",
                    Image = "/images/Nina.jpg"
                },
                new Employee
                {
                    Id = 8,
                    Name = "Tina",
                    Surname = "Fins",
                    BirthDate = new DateTime(2000, 5, 14),
                    Position = "Team Leader",
                    Image = "/images/Tina.jpg"
                }
                );
                modelBuilder.Entity<Company>().ToTable("Companies").HasData(
                new Company { Id = 1, Name = "Company1", Zipcode = "12345", City = "Ankara", Country = "Turkey" },
                new Company { Id = 2, Name = "Company2", Zipcode = "54321", City = "Istanbul", Country = "Turkey" },
                new Company { Id = 3, Name = "Company3", Zipcode = "98765", City = "Istanbul", Country = "Turkey" },
                new Company { Id = 4, Name = "Company4", Zipcode = "67890", City = "Ankara", Country = "Turkey" },
                new Company { Id = 5, Name = "Company5", Zipcode = "45678", City = "Antalya", Country = "Turkey" }
                );
                 base.OnModelCreating(modelBuilder);
                 modelBuilder.Entity<Employee>()
                .HasOne(e => e.SalaryInfo)
                .WithOne(si => si.Employee)
                .HasForeignKey<SalaryInfo>(si => si.EmployeeId);

        }
    }
}
