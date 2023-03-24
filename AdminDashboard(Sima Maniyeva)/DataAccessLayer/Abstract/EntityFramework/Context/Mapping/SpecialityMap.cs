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
    public class SpecialityMap : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.HasKey(I => I.SpecialityId);
            builder.Property(I => I.SpecialityId).UseIdentityColumn();
            builder.Property(I=>I.SpecialityName).HasMaxLength(50).IsRequired();
            builder.HasMany(I => I.Members).WithOne(I => I.Speciality).HasForeignKey(I => I.SpecialityId);
        }
    }
}
