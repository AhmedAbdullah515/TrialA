using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using TrialA.Models;

namespace TrialA.App_Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Jop> Jops { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Keys
            modelBuilder.Entity<User>().HasKey(a => a.UserId);
            modelBuilder.Entity<Application>().HasKey(a => a.ApplicationId);
            modelBuilder.Entity<Jop>().HasKey(a => a.JopId);
            modelBuilder.Entity<Company>().HasKey(a => a.CompanyId);
            modelBuilder.Entity<CandidateProfile>().HasKey(a => a.CandidateProfileId);


            //relations
            modelBuilder.Entity<CandidateProfile>().HasOne(a => a.User).WithOne(a => a.CandidateProfile).HasForeignKey<CandidateProfile>(a => a.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Company>().HasOne(a => a.User).WithMany(a => a.Companies).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Jop>().HasOne(a => a.Company).WithMany(a => a.Jops).HasForeignKey(a => a.CompanyId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Application>().HasOne(a => a.CandidateProfile).WithMany(a => a.Applications).HasForeignKey(a => a.CandidateProfileId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Application>().HasOne(a => a.Jop).WithMany(a => a.Applications).HasForeignKey(a => a.JopId).OnDelete(DeleteBehavior.NoAction);
            //Properties

            modelBuilder.Entity<User>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Application>().HasIndex(a => new { a.CandidateProfileId, a.JopId });
            //dataseeding
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "Ahmed Hassan", Email = "ahmed@gmail.com", Password = "1234567", Role = Role.Candidate, CeratedAt = DateTime.FromOADate(2026-09-01) },
                new User { UserId = 2, FullName = "Sara Mohamed", Email = "sara@gmail.com", Password = "7654321", Role = Role.Admin, CeratedAt = DateTime.FromOADate(2026 - 09 - 02) },
                new User { UserId = 3, FullName = "Ali Mohamed", Email = "Ali@gmail.com", Password = "000000000", Role = Role.Employer, CeratedAt = DateTime.FromOADate(2026 - 09 - 03) }

                );
            modelBuilder.Entity<CandidateProfile>().HasData(
                new CandidateProfile { CandidateProfileId = 1, Phone = "01012345678", ResumeUrl = "Example.com/resum1", Skill = "Asp.netcore", YearOfExperience = 3, UserId = 3 },
                new CandidateProfile { CandidateProfileId = 2, Phone = "01112345678", ResumeUrl = "Example.com/resuem2", Skill = "flutter", YearOfExperience = 3, UserId = 2 },
                new CandidateProfile { CandidateProfileId = 3, Phone = "01129566806", ResumeUrl = "Example3.com/resuem2", Skill = "logic", YearOfExperience = 5, UserId = 1 }



                );
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, Name = "Teach soluition", Description = "oseihwoefowheofhw", Website = "http://werwerwerwwerwer", Location = "Cairo", UserId = 3 },
                new Company { CompanyId = 2, Name = "FutureSystem", Description = "ioajsfiojasiofj", Website = "http://werwerwerwwerwer", Location = "giza", UserId = 2 },
                new Company { CompanyId = 3, Name = "Agreland", Description = "for potatos", Website = "http://werwerwerwwerwer", Location = "egypt", UserId = 1 }

                );
            modelBuilder.Entity<Jop>().HasData(

                new Jop { JopId = 1, Title = "Backend", Description = "weijweiofjiowejriowerwe", Salary = 30000, Location = "Cairo", EmployeType = EmployerType.Fulltime, PostedDate = DateTime.FromOADate(2026 - 10 - 01), Deadline = DateTime.FromOADate(2026 - 11 - 01), Status = Status.Open, CompanyId = 1 },
                new Jop { JopId = 2, Title = "Frontend", Description = "iwe0rwe0rwrw", Salary = 20000, Location = "Giza", EmployeType = EmployerType.Contract, PostedDate = DateTime.FromOADate(2026 - 11 - 01), Deadline = DateTime.FromOADate(2026 - 11 - 01), Status = Status.Open, CompanyId = 2 },
                new Jop { JopId = 3, Title = "wireframe", Description = "jjjjjjj", Salary = 900, Location = "faysel", EmployeType = EmployerType.PartTime, PostedDate = DateTime.FromOADate(2026 - 21 - 01), Deadline = DateTime.FromOADate(2026 - 5 - 01), Status = Status.Open, CompanyId = 2 }

                );
            modelBuilder.Entity<Application>().HasData(

                new Application { ApplicationId = 1, ApplicationDate = DateTime.FromOADate(2026 - 10 - 05), Status = ApplicationStatus.Pending, CoverLetter = "ewfwfwefwefwf000", JopId = 1, CandidateProfileId = 1 },
                new Application { ApplicationId = 2, ApplicationDate = DateTime.FromOADate(2026 - 10 - 05), Status = ApplicationStatus.Accepted, CoverLetter = "wejrwewerwerw", JopId = 2, CandidateProfileId = 2 }

                );


        }
    }
}
