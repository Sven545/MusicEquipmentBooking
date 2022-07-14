using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEquipmentBooking.BusinessLogicLayer.Interfaces
{
    public interface ICrudService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Create(T item);
        void Update(T item);     
        void Delete(int id);
        
    }
}
