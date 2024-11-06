using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.EF
{
    public class EContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
        public DbSet<Reminder> Reminders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<RSVP>()
                .HasRequired(r => r.User)
                .WithMany(u => u.RSVPs)
                .HasForeignKey(r => r.UserId)
                .WillCascadeOnDelete(false); 

            
            modelBuilder.Entity<RSVP>()
                .HasRequired(r => r.Event)
                .WithMany(e => e.RSVPs)
                .HasForeignKey(r => r.EventId)
                .WillCascadeOnDelete(false); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
