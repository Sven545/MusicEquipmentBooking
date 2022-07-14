using Microsoft.EntityFrameworkCore;
using MusicEquipmentBooking.DataAcsessLayer.Entities;

namespace MusicEquipmentBooking.DataAcsessLayer.EntityFramework
{
    public class DataBaseContext:DbContext
    {
        public DbSet<ServiceObject>? ServiceObjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataBase/test.db");
        }
    }

}
