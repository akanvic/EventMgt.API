using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMgt.Repo.Data
{
    public class EventMgtContext : DbContext
    {
        public EventMgtContext(DbContextOptions<EventMgtContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<ParticipantInvitation> ParticipantInvitations { get; set; }
    }
}
