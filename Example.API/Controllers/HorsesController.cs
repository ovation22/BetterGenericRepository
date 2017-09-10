using System.Collections.Generic;
using Example.API.Attributes;
using Example.DTO.Horse;
using Microsoft.AspNetCore.Mvc;
using Example.Services.Interfaces;
using Microsoft.AspNetCore.Http;

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

        /// <summary>
        /// Gets the full list of horses
        /// </summary>
        /// <response code="200">Horses found</response>
        /// <response code="500">Oops! Something went horribly wrong</response>
        /// <returns>IEnumerable&lt;Models.HorseSummary&gt;</returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<HorseSummary>))]
        [ProducesResponseType(typeof(IEnumerable<HorseSummary>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            var horses = _horseService.GetAll();

            return Ok(horses);
        }

        /// <summary>
        /// Gets an individual horse's information
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Horse found</response>
        /// <response code="404">Horse not found</response>
        /// <response code="500">Oops! Something went horribly wrong</response>
        /// <returns>string</returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(HorseDetail))]
        [ProducesResponseType(typeof(HorseDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            var horse = _horseService.Get(id);

            if (horse == null)
            {
                return NotFound("Horse Not Found");
            }

            return Ok(horse);
        }

        /// <summary>
        /// Creates a new horse
        /// </summary>
        /// <param name="horse"></param>
        /// <response code="202">Horse accepted</response>
        /// <response code="400">BadRequest or underlying services has failed, check error message</response>
        /// <response code="500">Oops! Something went horribly wrong</response>
        /// <returns>string</returns>
        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] HorseCreate horse)
        {
            _horseService.Create(horse);

            return Accepted();
        }
    }
}