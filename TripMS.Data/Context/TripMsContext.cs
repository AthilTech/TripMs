using Microsoft.EntityFrameworkCore;
using TripMs.Domain.Models;

namespace TripMs.Data.Context
{
    public class TripMsContext : DbContext
    {
        public TripMsContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets 
        //PGH 
        public DbSet<Trip> Trips { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DataSeed:

            #endregion

            #region Settings: set Primary keys

            modelBuilder.Entity<Trip>()
              .HasKey(r => r.TripId);


            #endregion

            #region  Settings: set one to many relations

            // configures one-to-many role-user relationship
            // modelBuilder.Entity<User>()
            //   .HasOne<Role>(r => r.Role)
            // .WithMany(u => u.Users)
            // .HasForeignKey(u => u.fk_Role);







            #endregion

            #region  Settings: set one to one relations 


            #endregion

            #region  Settings: set one to Zero and zero to one relations

            #endregion

            #region maxlength 
            #endregion
        }
    }
}

