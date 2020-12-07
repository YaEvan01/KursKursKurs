using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursKursKurs
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        //<Certificates>
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<RenovationAcceptanceCertificate> RenovationAcceptanceCertificates { get; set; }
        public DbSet<RepairCertificate> RepairCertificates { get; set; }
        public DbSet<ScrappingCertificate> ScrappingCertificates { get; set; }
        //</Certificates>

        
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mydatabase;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Position>().HasData(
        //        new Position[]
        //        {
        //            new Position{ Id=1 , Name = "Начальник" },
        //            new Position{ Id=2 , Name = "Подчинённый" }
        //        });
        //}
    }
}
