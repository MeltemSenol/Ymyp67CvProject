using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;

namespace Ymyp67CvProject.DataAccess.Configurations
{
    internal class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PersonalInfo> builder)
        {
           builder.Property(p=>p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.ImageUrl).HasMaxLength(500);
            builder.Property(p => p.MaritalStatus).HasColumnType("bit"); // bit türü SQL Server'da boolean değerleri tutar. 0 ya da 1'dir.
            builder.Property(p=>p.Gender).HasConversion<string>().HasMaxLength(10).IsRequired();
            //Gender bilgisi enumdan geliyor, enum'ı string'e çevirip saklayacağız.
            builder.Property(p => p.DrivingLicence).HasMaxLength(10).HasDefaultValue("Yok");
            //Hiçbir değer girilmezse "Yok" olarak varsayılan değer alacak.
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.BirthPlace).HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Nationality).HasMaxLength(50).IsRequired().HasDefaultValue("TC");
        }
    }
}
