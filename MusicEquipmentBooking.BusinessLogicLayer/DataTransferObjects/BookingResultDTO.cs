
namespace MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects
{
    public class BookingResultDTO
    {
        public int Id { get; }
        public bool Result { get; }
        public int Amount { get; }
        public string? ErrorMessage { get; }
        public BookingResultDTO(int id, bool result, int amount, string? errorMessage = null)
        {
            Id = id;
            Result = result;
            Amount = amount;
            ErrorMessage = errorMessage;
        }
    }
}
