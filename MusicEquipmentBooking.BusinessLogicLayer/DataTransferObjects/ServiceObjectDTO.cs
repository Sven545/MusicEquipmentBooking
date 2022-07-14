using System.ComponentModel.DataAnnotations; 

namespace MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects
{
    public class ServiceObjectDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название оборудования")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимая длина названия оборудования")]
        public string Name { get; set; }
        [Range(1, 10000, ErrorMessage = "Недопустимое количество оборудования")]
        public int Amount { get; set; }
    }
}
