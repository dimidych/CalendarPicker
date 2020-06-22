using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarPicker.Model;
using Microsoft.AspNetCore.Mvc;

namespace CalendarPicker.Controllers
{
    [ApiController]
    [Route("api/v1/StoredDates")]
    public class StoredDatesController : ControllerBase
    {
        private readonly IRepository<DateSelection> _repository;

        public StoredDatesController(IRepository<DateSelection> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetDateSelections")]
        public async Task<IEnumerable<DateSelection>> GetDateSelections()
        {
            return await _repository.GetAll();
        }

        [HttpPost]
        [Route("AddDateSelection")]
        public async Task<IActionResult> AddDateSelection([FromBody] DateSelection dateSelection)
        {
            if (dateSelection?.SelectedDates == null || !dateSelection.SelectedDates.Any())
                return BadRequest();

            await _repository.Add(dateSelection);
            return Ok();
        }
    }
}