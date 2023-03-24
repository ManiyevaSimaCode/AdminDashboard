using DataAccessLayer.Abstract.EntityFramework.Context.Mapping;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.EntityFramework.Context
{
    public class MemberContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=WINDOWS-84ER0LR;database=AdminDashboardVTP;Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new SpecialityMap());
            modelBuilder.ApplyConfiguration(new UniversityMap());
            modelBuilder.ApplyConfiguration(new AdminMap());
        }
        public DbSet<Member>Members  { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<University>Universities { get; set; }
        public DbSet<Speciality>Specialities { get; set; }
        public DbSet<Admin>Admins { get; set; }
    }

}
