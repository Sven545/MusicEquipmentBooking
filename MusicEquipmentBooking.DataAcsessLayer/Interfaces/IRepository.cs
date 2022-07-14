using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEquipmentBooking.DataAcsessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();   
        int Create(T item);
        void Update(T item);
        T Get(int id);
       // T GetLast();
        void Delete(T item);
        
    }
}
