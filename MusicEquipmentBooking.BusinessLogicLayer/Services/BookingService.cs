using MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects;
using MusicEquipmentBooking.BusinessLogicLayer.Interfaces;
using MusicEquipmentBooking.DataAcsessLayer.Entities;
using MusicEquipmentBooking.DataAcsessLayer.Interfaces;
using MusicEquipmentBooking.DataAcsessLayer.Repositories;

namespace MusicEquipmentBooking.BusinessLogicLayer.Services
{
    public class BookingService : IBookingService
    {
        private IRepository<ServiceObject> _repository;
        public List<BookingResultDTO> BookingResults { get; set; }

        public BookingService()
        {
            _repository = new ServiceObjectRepository();
            BookingResults = new List<BookingResultDTO>();
        }
        public BookingResultDTO MakeBook(BookingDTO bookingDTO)
        {
            var objectFromDb = _repository.Get(bookingDTO.Id) ?? throw new ArgumentException($"Объект с id:{bookingDTO.Id} не найден");
            if (bookingDTO.Amount != 0)
            {
                int oldObjectAmount = objectFromDb.Amount;
                objectFromDb.Amount -= bookingDTO.Amount;
                if (objectFromDb.Amount >= 0)
                {
                    _repository.Update(objectFromDb);
                    var bookingResult = new BookingResultDTO(bookingDTO.Id, true, objectFromDb.Amount);
                    BookingResults.Add(bookingResult);
                    return bookingResult;
                }
                if (objectFromDb.Amount < 0)
                {
                    var bookingResult = new BookingResultDTO(bookingDTO.Id, false, oldObjectAmount, "Такого количества оборудования нет в наличии");
                    BookingResults.Add(bookingResult);
                    return bookingResult;
                }
            }

            return new BookingResultDTO(bookingDTO.Id, false, objectFromDb.Amount, "Нельзя заказать 0 единиц оборудования");


        }


    }
}
