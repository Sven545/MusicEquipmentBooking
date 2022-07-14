using Microsoft.AspNetCore.Mvc;

namespace MusicalEquipmentBooking.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/testcontroller")]
    public class TestController:Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new List<string>() {"1","2","3" };
        }
    }
}
