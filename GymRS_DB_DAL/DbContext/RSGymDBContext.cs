using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GymRS_DB_DAL
{
    public class RSGymDBContext : DbContext
    {
        public RSGymDBContext() : base("RSGymDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<PersonalTrainer> PersonalTrainer { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Request> Request { get; set; }

    }
}
