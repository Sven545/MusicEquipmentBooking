using Microsoft.AspNetCore.Mvc;
using MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects;
using MusicEquipmentBooking.BusinessLogicLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MusicalEquipmentBooking.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServiceController : Controller
    {
        private ICrudService<ServiceObjectDTO> _crudService;
        private IBookingService _bookingService;
        public ServiceController(ICrudService<ServiceObjectDTO> crudService, IBookingService bookingService)
        {
            _crudService = crudService;
            _bookingService = bookingService;
        }


        [HttpGet("get")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_crudService.GetAll());
            }
            catch (Exception)
            {
                return Problem("Что то пошло не так");
            }


        }


        [HttpGet("getone/{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                return Ok(_crudService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return Problem("Что то пошло не так");
            }
        }


        [HttpGet("booking/getall")]
        public IActionResult GetAllBookings()
        {
            try
            {
                return Ok(_bookingService.BookingResults);
            }
            catch (Exception)
            {
                return Problem("Что то пошло не так");
            }


        }


        [HttpPost("create")]
        public IActionResult Create(ServiceObjectDTOToDb obj)
        {
            try
            {
                return Ok(_crudService.Create(new ServiceObjectDTO() { Id = 0, Name = obj.Name, Amount = obj.Amount }));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException)
            {
                return BadRequest("Объект с таким именем уже создан ранее");
            }
            catch (Exception)
            {
                return Problem("Что то пошло не так");
            }
        }


        [HttpPost("update/{id}")]
        public IActionResult Update(int id, ServiceObjectDTOToDb obj)
        {
            try
            {
                return Ok(_crudService.Update(new ServiceObjectDTO() { Id = id, Name = obj.Name, Amount = obj.Amount }));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return Problem("Что то пошло не так");
            }
        }

        
        [HttpPost("booking")]
        public IActionResult MakeBooking(BookingDTO newBooking)
        {
            try
            {
                return Ok(_bookingService.MakeBook(newBooking));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return Problem("Что то пошло не так");
            }
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _crudService.Delete(id);
                return Ok($"Object id:{id} deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return Problem("Что то пошло не так");
            }
        }
    }
}
