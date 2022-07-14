using MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects;


namespace MusicEquipmentBooking.BusinessLogicLayer.Interfaces
{
    public interface IBookingService
    {
        List<BookingResultDTO> BookingResults { get; set; }
        BookingResultDTO MakeBook(BookingDTO bookingDTO);
    }
}
