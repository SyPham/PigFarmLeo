using Microsoft.AspNetCore.Mvc;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class Record2PigController : ApiControllerBase
    {
        private readonly IRecord2PigService _service;

        public Record2PigController(IRecord2PigService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateWeightAsync([FromBody] UpdateWeightParams model)
        {
            return StatusCodeResult(await _service.UpdateWeightAsync(model));
        }
    }
}
