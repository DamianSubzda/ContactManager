using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<EmailCampaign> EmailCampaigns { get; set; }
        public DbSet<EmailSent> EmailSents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactGroup>()
                .HasKey(cg => new { cg.ContactId, cg.GroupId });

            modelBuilder.Entity<ContactGroup>()
                .HasOne(cg => cg.Contact)
                .WithMany(c => c.ContactGroups)
                .HasForeignKey(cg => cg.ContactId);

            modelBuilder.Entity<ContactGroup>()
                .HasOne(cg => cg.Group)
                .WithMany(g => g.ContactGroups)
                .HasForeignKey(cg => cg.GroupId);

            modelBuilder.Entity<EmailSent>()
                .HasOne(e => e.EmailCampaign)
                .WithMany()
                .HasForeignKey(e => e.EmailCampaignId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
