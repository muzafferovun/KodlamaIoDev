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
                plt.Property(y => y.Name).HasColumnName("Name");
                plt.Property(y => y.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
                plt.HasOne(y => y.ProgramingLanguage);
            });

            modelBuilder.Entity<User>(plt =>
            {
                plt.ToTable("Users").HasKey(x => x.Id);
                plt.Property(y => y.Id).HasColumnName("Id");
                plt.Property(y => y.UserTypeId).HasColumnName("UserTypeId");
                plt.Property(y => y.UserName).HasColumnName("UserName");
                plt.Property(y => y.Password).HasColumnName("Password");
                plt.Property(y => y.Email).HasColumnName("Email");
                plt.Property(y => y.PhoneNumber).HasColumnName("PhoneNumber");
                plt.Property(y => y.Name).HasColumnName("Name");
                plt.Property(y => y.Surname).HasColumnName("Surname");
                plt.Property(y => y.UserImage).HasColumnName("UserImage");
                plt.Property(y => y.GitAccount).HasColumnName("GitAccount");
                plt.Property(y => y.IsPhoneConfirmed).HasColumnName("IsPhoneConfirmed");
                plt.Property(y => y.IsActive).HasColumnName("IsActive");
                plt.Property(y => y.IsEmailConfirmed).HasColumnName("IsEmailConfirmed");
                plt.Property(y => y.UserImage).HasColumnName("UserImage");


                plt.HasOne(y => y.UserType);
                plt.HasMany(y=>y.Tokens);
            });
            modelBuilder.Entity<UserType>(plt =>
            {
                plt.ToTable("UserTypes").HasKey(x => x.Id);
                plt.Property(y => y.Id).HasColumnName("Id");
                plt.Property(y => y.Name).HasColumnName("Name");
                plt.HasMany(y => y.Users);
            });
            modelBuilder.Entity<UserToken>(plt =>
            {
                plt.ToTable("UserTokens").HasKey(x => x.Id);
                plt.Property(y => y.Id).HasColumnName("Id");
                plt.Property(y => y.Name).HasColumnName("Name");
                plt.Property(y => y.UserId).HasColumnName("UserId");
                plt.Property(y => y.IsActive).HasColumnName("IsActive");
                plt.Property(y => y.Created).HasColumnName("Created");
                plt.Property(y => y.Expiration).HasColumnName("Expiration");
                plt.Property(y => y.Updated).HasColumnName("Updated");
                plt.Property(y => y.Token).HasColumnName("Token");

                plt.HasOne(y => y.User);
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


            UserType[] userTypeSeeds = {
                new(1,"Admin")
                ,new(2,"Moderator")
                ,new(3,"User")
            };
            modelBuilder.Entity<UserType>().HasData(userTypeSeeds);

            User[] userSeeds = {
                new(1,"muzafferovun@hotmail.com","dsfwerrw324","Muzaffer","Övün","muzafferovun@hotmail.com","05370001415",true,true,true,"","https://github.com/muzafferovun",1)
                ,new(2,"mustafa_kus@hotmail.com","q1w2e3r4t5y6","Mustafa","Kuş","mustafa_kus@hotmail.com","05370007847",true,true,true,"","https://github.com/mustafakus",2)
            };
            modelBuilder.Entity<User>().HasData(userSeeds);



        }
    }
}
