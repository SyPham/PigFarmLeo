using Microsoft.AspNetCore.Mvc;
using NetUtility;
using PigFarm.DTO;
using PigFarm.Models;
using PigFarm.Helpers;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class PenController : ApiControllerBase
    {
        private readonly IPenService _service;

        public PenController(IPenService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetPensByFarmGuidAndRoomGuid(string farmGuid, string roomGuid)
        {
            return Ok(await _service.GetPensByFarmGuidAndRoomGuid(farmGuid, roomGuid));
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] PenDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PenDto model)
        {
            return StatusCodeResult(await _service.UpdateAsync(model));
        }
        [HttpPut]
        public async Task<ActionResult> MapMakeOrderToPen([FromBody] MapMakeOrderToPenDto model)
        {
            return StatusCodeResult(await _service.MapMakeOrderToPen(model));
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
        public async Task<ActionResult> LoadData([FromBody] DataManager request, [FromQuery] string farmGuid, [FromQuery] string areaGuid, [FromQuery] string barnGuid, [FromQuery] string roomGuid)
        {

            var data = await _service.LoadData(request, farmGuid, areaGuid, barnGuid, roomGuid);
            return Ok(data);
        }
          [HttpPost]
        public async Task<ActionResult> LoadDataByRoom([FromBody] DataManager request, [FromQuery] string roomGuid, [FromQuery] string makeOrderGuid)
        {

            var data = await _service.LoadData(request,  roomGuid, makeOrderGuid);
            return Ok(data);
        }
          [HttpGet]
        public async Task<ActionResult> GetPensMultiDropdowns()
        {
            var top = HttpContext.Request.Query["$top"].ToInt();
            var skip = HttpContext.Request.Query["$skip"].ToInt();
            var farmGuid = HttpContext.Request.Query["farmGuid"].ToSafetyString();
            var search = HttpContext.Request.Query["search"].ToSafetyString();
            var selected = HttpContext.Request.Query["selected"].ToSafetyString();
            var roomGuid = HttpContext.Request.Query["roomGuid"].ToSafetyString();
            return Ok(await _service.GetPensMultiDropdowns(farmGuid,roomGuid, top, skip, search, selected));
        }
        [HttpGet]
        public async Task<ActionResult> GetPens()
        {
            var top = HttpContext.Request.Query["$top"].ToInt();
            var skip = HttpContext.Request.Query["$skip"].ToInt();
            var farmGuid = HttpContext.Request.Query["farmGuid"].ToSafetyString();
            var search = HttpContext.Request.Query["search"].ToSafetyString();
            var selected = HttpContext.Request.Query["selected"].ToSafetyString();
            return Ok(await _service.GetPens(farmGuid, top, skip, search, selected));
        }
        [HttpGet]
        public async Task<ActionResult> GetAudit(decimal id)
        {
            return Ok(await _service.GetAudit(id));
        }
        [HttpGet]
        public async Task<ActionResult> GetPenByMakeOrderGuid(string makeOrderGuid)
        {
            return Ok(await _service.GetPenByMakeOrderGuid(makeOrderGuid));
        }
         [HttpPost]
        public async Task<ActionResult> GetDataDropdownlist([FromBody] DataManager request)
        {
           
            return Ok(await _service.GetDataDropdownlist(request));
        }
         [HttpPost]
          public async Task<ActionResult> RemoveRecord2Pen([FromBody]Record2Pen model)
        {
            return Ok(await _service.RemoveRecord2Pen(model));
        }
         [HttpPost]
        public async Task<ActionResult>AddRecord2Pen([FromBody]Record2Pen model)
        {
            return Ok(await _service.AddRecord2Pen(model));
        }

         [HttpGet]
        public async Task<ActionResult>  GetPenByRecord(string recordGuid, string type)
        {
            return Ok(await _service.GetPenByRecord(recordGuid,type));
        }
         [HttpGet]
        public async Task<ActionResult>  GetSelectedPen([FromQuery] string[] guid)
        {
            return Ok(await _service.GetSelectedPen(guid));
        }
         [HttpGet]
        public async Task<ActionResult> GetPensByRoomAndRecord(string roomGuid, string recordGuid, string type)
        {
            return Ok(await _service.GetPensByRoomAndRecord(roomGuid, recordGuid, type));
        }
    }
}
