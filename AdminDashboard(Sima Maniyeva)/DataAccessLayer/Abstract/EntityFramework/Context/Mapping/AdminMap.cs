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
    public class AdminMap : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(I => I.AdminId);
            builder.Property(I => I.AdminId).UseIdentityColumn();
            builder.Property(I=>I.FirstName).HasMaxLength(50).IsRequired(); 
            builder.Property(I => I.LastName).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(50).IsRequired();
            


        }
    }
}
