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
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(I => I.DepartmentId);
            builder.Property(I => I.DepartmentId).UseIdentityColumn();
            builder.Property(I => I.DepartmentName).HasMaxLength(70).IsRequired();
            builder.HasMany(I => I.Members).WithOne(I => I.Department).HasForeignKey(I => I.DepartmentId);
        }
    }
}
