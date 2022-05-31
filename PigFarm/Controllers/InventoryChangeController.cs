using Microsoft.AspNetCore.Mvc;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class InventoryChangeController : ApiControllerBase
    {
        private readonly IInventoryChangeService _service;

        public InventoryChangeController(IInventoryChangeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] InventoryChangeDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] InventoryChangeDto model)
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
        public async Task<ActionResult> LoadChangeMaterialData([FromBody] DataManager request, string farmGuid, string fromInventoryGuid)
        {

            var data = await _service.LoadChangeMaterialData(request, farmGuid, fromInventoryGuid);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> LoadChangeThingData([FromBody] DataManager request, string farmGuid, string fromInventoryGuid)
        {

            var data = await _service.LoadChangeThingData(request, farmGuid, fromInventoryGuid);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> LoadData([FromBody] DataManager request, string farmGuid)
        {

            var data = await _service.LoadData(request, farmGuid);
            return Ok(data);
        }
        [HttpGet]
        public async Task<ActionResult> GetAudit(decimal id)
        {
            return Ok(await _service.GetAudit(id));
        }
    }
}
