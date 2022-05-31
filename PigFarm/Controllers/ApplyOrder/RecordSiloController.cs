using Microsoft.AspNetCore.Mvc;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class RecordSiloController : ApiControllerBase
    {
        private readonly IRecordSiloService _service;

        public RecordSiloController(IRecordSiloService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] RecordSiloDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RecordSiloDto model)
        {
            return StatusCodeResult(await _service.UpdateAsync(model));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return StatusCodeResult(await _service.DeleteAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetByIDAsync(int id)
        {
            return Ok(await _service.GetByIDAsync(id));
        }
        [HttpGet]
        public async Task<ActionResult> GetByRecordGuidAsync(string upperGuid, string upperRecord)
        {
            return Ok(await _service.GetByRecordGuidAsync(upperGuid, upperRecord));
        }

        [HttpGet]
        public async Task<ActionResult> GetWithPaginationsAsync(PaginationParams paramater)
        {
            return Ok(await _service.GetWithPaginationsAsync(paramater));
        }
        [HttpPost]
        public async Task<ActionResult> LoadData([FromBody] DataManager request, [FromQuery] string farmGuid, [FromQuery] string makeOrderGuid, string lang)
        {

            var data = await _service.LoadData(request, farmGuid, makeOrderGuid, lang);
            return Ok(data);
        }
      
        [HttpGet]
        public async Task<ActionResult> GetAudit(int id)
        {
            return Ok(await _service.GetAudit(id));
        }

        [HttpGet]
        public async Task<ActionResult> ToggleRecordDate(int id)
        {
            return StatusCodeResult(await _service.ToggleRecordDate(id));
        }
    }
}
