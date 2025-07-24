using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;

namespace Ymyp67CvProject.DataAccess.Context
{
    public sealed class Ymyp67CvProjectDbContext(DbContextOptions<Ymyp67CvProjectDbContext> options) :DbContext(options)

    {
        //Burada primary constructor kullandık, aşağıdaki alternatifi yerine.
        //public Ymyp67CvProjectDbContext(DbContextOptions<Ymyp67CvProjectDbContext>options):base(options)
        //{

        //}

        //connection stringi artık burada vermiyoruz. appsettings.json dosyasında tanımladık. profesyonelce böyle yapılıyor.

        // modelBuilder'ı da artık burada yapmıyoruz.Configurations klasöründe yapıyoruz 11 tane entity için ayrı ayrı yapmak burayı şişirirdi.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Certificate>Certificates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialAccount> SocialAccounts { get; set; }
    }
}
