using Microsoft.AspNetCore.Mvc;
using MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects;
using MusicEquipmentBooking.BusinessLogicLayer.Interfaces;

namespace MusicalEquipmentBooking.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/serviceobjects")]
    public class ServiceObjectController:Controller
    {
        private ICrudService<ServiceObjectDTO> _crudService;
        public ServiceObjectController(ICrudService<ServiceObjectDTO> crudService)
        {
            _crudService = crudService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_crudService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                return Ok(_crudService.Get(id));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return Problem("Something wrong");
            }
        }
        [HttpPost]
        public IActionResult Create(ServiceObjectDTOToDb obj)
        {
            try
            {
               // return Ok();
                return Ok(_crudService.Create(new ServiceObjectDTO() { Id=0,Name=obj.Name,Amount=obj.Amount}));
            }
            catch(Exception)
            {
                return Problem("Something wrong");
            }
        }
        [HttpDelete("{id}")]
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
            catch(Exception)
            {
                return Problem("Something wrong");
            }
        }
    }
}
