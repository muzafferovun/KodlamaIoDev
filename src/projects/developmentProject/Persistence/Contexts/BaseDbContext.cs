using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramingLanguage> brandEntities { get; set; }
       

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Description).HasColumnName("Description");
                a.HasMany(p => p.ProgramingLanguageTechnologys);
            });

            modelBuilder.Entity<ProgramingLanguageTechnology>(plt =>
            {
                plt.ToTable("ProgramingLanguageTechnologies").HasKey(x => x.Id);
                plt.Property(y => y.Id).HasColumnName("Id");
                plt.Property(y =>y.Name).HasColumnName("Name");
                plt.Property(y=>y.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
                plt.HasOne(y => y.ProgramingLanguage);
            });



            ProgramingLanguage[] brandEntitySeeds = { 
                new(1, "C#", ".net CSharp")
                , new(2, "Java", "Java Springboot")
                , new(3, "JavaScript", "JavaScript")
            };
            modelBuilder.Entity<ProgramingLanguage>().HasData(brandEntitySeeds);


            ProgramingLanguageTechnology[] programingLanguageTechnologySeeds = {
                new(1,1, "WPF")
                ,new(2,1, "Asp.net")
                ,new(3,2, "Spring")
                ,new(4,2, "JSP")
                ,new(5,3, "Vue")
                ,new(6,3, "React")
            };
            modelBuilder.Entity<ProgramingLanguageTechnology>().HasData(programingLanguageTechnologySeeds);
        }
    }
}
