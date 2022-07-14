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
                try
                {
                    dbContext.Add(item);
                    dbContext.SaveChanges();

                    var lastNumber = (from el in dbContext.ServiceObjects
                                      orderby el.Id descending
                                      select el.Id).FirstOrDefault();
                    return lastNumber;
                }
                catch(DbUpdateException ex)
                {
                    if(ex.InnerException!=null)
                    {
                        throw new ArgumentException(ex.InnerException.Message);                     
                    }
                    
                }
               
                return -1;
                
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
       
        public int Update(ServiceObject item)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                try
                {
                    var objectForUpdate = dbContext.ServiceObjects.First(x => x.Id == item.Id);
                    objectForUpdate.Name = item.Name;
                    objectForUpdate.Amount = item.Amount;
                    dbContext.Entry(objectForUpdate).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return item.Id;
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null)
                    {
                        throw new ArgumentException(ex.InnerException.Message);
                    }

                }
                return -1;

            }

        }
    }
}
