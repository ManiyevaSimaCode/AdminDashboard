using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.EntityFramework.Context.Mapping
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(I => I.MemberId);
            builder.Property(I => I.MemberId).UseIdentityColumn();
            builder.Property(I => I.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(I => I.LastName).HasMaxLength(50).IsRequired();
            builder.Property(I => I.StartTime).HasMaxLength(250).IsRequired();
            builder.Property(I => I.Age).HasMaxLength(15).IsRequired();
            builder.Property(I => I.Gender).HasMaxLength(15).IsRequired();   
            builder.Property(I => I.Degree).HasMaxLength(15).IsRequired();
            builder.Property(I => I.Salary).HasMaxLength(10000).IsRequired();
            builder.HasOne(I => I.Department).WithMany(I => I.Members).HasForeignKey(I => I.DepartmentId);
            builder.HasOne(I => I.University).WithMany(I => I.Members).HasForeignKey(I => I.UniversityId);
            builder.HasOne(I => I.Speciality).WithMany(I => I.Members).HasForeignKey(I => I.SpecialityId);


        }
    }
}
