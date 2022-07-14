using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicEquipmentBooking.DataAcsessLayer.Interfaces;
using MusicEquipmentBooking.DataAcsessLayer.Entities;
using MusicEquipmentBooking.DataAcsessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace MusicEquipmentBooking.DataAcsessLayer.Repositories
{
    public class ServiceObjectRepository : IRepository<ServiceObject>
    {

        public int Create(ServiceObject item)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                dbContext.Add(item);
                dbContext.SaveChanges();

                var lastNumber = (from el in dbContext.ServiceObjects
                                 orderby el.Id descending
                                 select el.Id).FirstOrDefault();
                return lastNumber;
            }
            
        }

        public void Delete(ServiceObject item)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                dbContext.Remove(item);
                dbContext.SaveChanges();
               
            }
            
        }

        public ServiceObject Get(int id)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                return dbContext.ServiceObjects.FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<ServiceObject> GetAll()
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                return dbContext.ServiceObjects.ToList();
            }

        }
        /*
        public ServiceObject GetLast()
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                return dbContext.ServiceObjects.LastOrDefault();
            }
        }
        */
        public void Update(ServiceObject item)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                dbContext.Entry(item).State = EntityState.Modified;
            }

        }
    }
}
