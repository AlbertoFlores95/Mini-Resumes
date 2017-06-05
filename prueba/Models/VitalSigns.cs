using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VitalSigns
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public int Token { get; set; }

        public DateTime Date { get; set; }

        public double CorporalTemperature { get; set; }

        public double Arterialpresion { get; set; }

        public Boolean PanicButton { get; set; }



    }

    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("DatabaseContext")
        {
        }

        public DbSet<VitalSigns> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}