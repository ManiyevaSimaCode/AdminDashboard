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
    public class UniversityMap : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.HasKey(I => I.UniversityId);
            builder.Property(I => I.UniversityId).IsRequired();
            builder.Property(I => I.UniversityName).HasMaxLength(50).IsRequired();
            builder.HasMany(I=>I.Members).WithOne(I => I.University).HasForeignKey(I=>I.UniversityId);   
        }
    }
}
