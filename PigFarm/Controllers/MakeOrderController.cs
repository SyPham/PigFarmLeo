using Microsoft.AspNetCore.Mvc;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class MakeOrderController : ApiControllerBase
    {
        private readonly IMakeOrderService _service;

        public MakeOrderController(IMakeOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetMakeOrderByFarmGuid(string farmGuid)
        {
            return Ok(await _service.GetMakeOrderByFarmGuid(farmGuid));
        }
 [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] MakeOrderDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] MakeOrderDto model)
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
        public async Task<ActionResult> LoadData([FromBody] DataManager request, [FromQuery] string farmGuid)
        {

            var data = await _service.LoadData(request, farmGuid);
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult> LoadDataByType([FromBody] DataManager request, [FromQuery] string farmGuid, [FromQuery] string pigType, string lang)
        {

            var data = await _service.LoadDataByType(request, farmGuid, pigType, lang);
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult> LoadMobileDataByType([FromBody] DataManager request, [FromQuery] string farmGuid, [FromQuery] string pigType, string lang)
        {

            var data = await _service.LoadMobileDataByType(request, farmGuid, pigType, lang);
            return Ok(data);
        }
        [HttpGet]
        public async Task<ActionResult> GetAudit(decimal id)
        {
            return Ok(await _service.GetAudit(id));
        }
         [HttpPost]
        public async Task<ActionResult> GetDataDropdownlist([FromBody] DataManager request)
        {
           
            return Ok(await _service.GetDataDropdownlist(request));
        }
        [HttpGet]
        public async Task<ActionResult> GetByGuid(string guid)
        {
            return Ok(await _service.GetByGuid(guid));
        }
        [HttpGet]
        public async Task<ActionResult> GetPensByRoom(string roomGuid)
        {
            return Ok(await _service.GetPensByRoom(roomGuid));
        }
        [HttpPut]
        public async Task<ActionResult> StoreRoomGuid([FromBody] UpdateRoomGuidDto model)
        {
            return Ok(await _service.StoreRoomGuid(model));
        }
        [HttpPost]
        public async Task<ActionResult> StoreMakeOrder2Pen([FromBody] StoreMakeOrder2PenDto model)
        {
            return Ok(await _service.StoreMakeOrder2Pen(model));
        }
         [HttpPost]
        public async Task<ActionResult> RemoveMakeOrder2Pen([FromBody]RemoveMakeOrder2PenDto model)
        {
            return Ok(await _service.RemoveMakeOrder2Pen(model));
        }
         [HttpPost]
        public async Task<ActionResult>AddMakeOrder2Pen([FromBody]AddMakeOrder2PenDto model)
        {
            return Ok(await _service.AddMakeOrder2Pen(model));
        }
        [HttpGet]
        public async Task<ActionResult> GetMakeOrderPenDropdown(string makeOrderGuid)
        {
            return Ok(await _service.GetMakeOrderPenDropdown(makeOrderGuid));
        }

        [HttpGet]
        public async Task<ActionResult> GetMakeOrderPen(string makeOrderGuid)
        {
            return Ok(await _service.GetMakeOrderPen(makeOrderGuid));
        }
    }
}
