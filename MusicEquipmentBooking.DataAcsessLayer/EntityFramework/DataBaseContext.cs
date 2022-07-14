using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicEquipmentBooking.DataAcsessLayer.Entities;

namespace MusicEquipmentBooking.DataAcsessLayer.EntityFramework
{
    public class DataBaseContext:DbContext
    {
        public DbSet<ServiceObject> ServiceObjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataBase/test.db");
        }
    }

}
