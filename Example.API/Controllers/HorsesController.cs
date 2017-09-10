using Microsoft.AspNetCore.Mvc;
using Example.Services.Interfaces;

namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    public class HorsesController : Controller
    {
        private readonly IHorseService _horseService;

        public HorsesController(IHorseService horseService)
        {
            _horseService = horseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var horses = _horseService.GetAll();

            return Ok(horses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var horse = _horseService.Get(id);

            if (horse == null)
            {
                return NotFound("Horse Not Found");

            }

            return Ok(horse);
        }
    }
}