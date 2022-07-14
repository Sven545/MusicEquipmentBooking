
namespace MusicEquipmentBooking.BusinessLogicLayer.Interfaces
{
    public interface ICrudService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Create(T item);
        int Update(T item);     
        void Delete(int id);
        
    }
}
