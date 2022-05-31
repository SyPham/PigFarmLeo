using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class PigHouseDisinfectionController : ApiControllerBase
    {
        private readonly IPigHouseDisinfectionService _service;

        public PigHouseDisinfectionController(IPigHouseDisinfectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] PigHouseDisinfectionDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PigHouseDisinfectionDto model)
        {
            return StatusCodeResult(await _service.UpdateAsync(model));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(decimal id)
        {
            return StatusCodeResult(await _service.DeleteAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetByIDAsync(decimal id)
        {
            return Ok(await _service.GetByIDAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetWithPaginationsAsync(PaginationParams paramater)
        {
            return Ok(await _service.GetWithPaginationsAsync(paramater));
        }
        [HttpPost]
        public async Task<ActionResult> LoadData([FromBody] DataManager request, string upperGuid, string lang)
        {

            var data = await _service.LoadData(request, upperGuid, lang);
            return Ok(data);
        }
         [HttpPost]
        public async Task<ActionResult> LoadMobileData([FromBody] DataManager request, [FromQuery] string farmGuid, string lang, string penGuid, string pigGuid, DateTime? recordDate)
        {

            var data = await _service.LoadMobileData(request, farmGuid, lang, penGuid, pigGuid, recordDate);
            return Ok(data);
        }
         [HttpPost]
        public async Task<ActionResult> BatchWorkLoadData([FromBody] DataManager request, [FromQuery] string farmGuid, string lang, string penGuid, string pigGuid, DateTime? estDate)
        {

            var data = await _service.LoadData(request, farmGuid, lang, penGuid, pigGuid, estDate);
            return Ok(data);
        }
        [HttpGet]
        public async Task<ActionResult> GetAudit(decimal id)
        {
            return Ok(await _service.GetAudit(id));
        }

        [HttpGet]
        public async Task<ActionResult> ToggleRecordDate(decimal id)
        {
            return StatusCodeResult(await _service.ToggleRecordDate(id));
        }
         [HttpGet]
        public async Task<ActionResult> ToggleEstDate(decimal id)
        {
            return StatusCodeResult(await _service.ToggleEstDate(id));
        }
    }
}
