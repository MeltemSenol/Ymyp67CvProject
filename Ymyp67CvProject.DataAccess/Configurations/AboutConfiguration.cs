using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;

namespace Ymyp67CvProject.DataAccess.Configurations
{
    //Aynı katmandaki context sınıfı içinde kullanacağımız için public yapmaya gerek yok.
    internal class AboutConfiguration : IEntityTypeConfiguration<About>
    {


        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<About> builder)
        {
            builder.Property(a => a.Description).HasMaxLength(500).IsRequired();

        }
    }
}
