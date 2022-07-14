
namespace MusicEquipmentBooking.DataAcsessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        int Create(T item);
        int Update(T item);
        T Get(int id);
        void Delete(T item);

    }
}
