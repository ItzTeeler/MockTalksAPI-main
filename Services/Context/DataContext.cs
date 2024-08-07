using Microsoft.EntityFrameworkCore;
using MockTalksAPI.Models;

namespace MockTalksAPI.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<MT_UserModels> MT_UserInfo {get; set;}
        public DbSet<MT_ProfileModels> MT_ProfileInfo {get; set;}
        public DbSet<MT_MessagingModals> MT_MessagingInfo {get; set;}
        public DbSet<MT_ScheduleModals> MT_ScheduleInfo {get; set;}

        public DataContext(DbContextOptions options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}