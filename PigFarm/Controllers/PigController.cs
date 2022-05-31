using Microsoft.AspNetCore.Mvc;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using System.Threading.Tasks;
using Syncfusion.JavaScript;
using NetUtility;
using PigFarm.Models;

namespace PigFarm.Controllers
{
    public class PigController : ApiControllerBase
    {
        private readonly IPigService _service;

        public PigController(IPigService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> GetPigByManyPen([FromBody] MultiplePigParams model)
        {
            return Ok(await _service.GetPigByManyPen(model));
        }
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] PigDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PigDto model)
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
        [HttpGet]
        public async Task<ActionResult> GetPigs()
        {
            var top = HttpContext.Request.Query["$top"].ToInt();
            var skip = HttpContext.Request.Query["$skip"].ToInt();
            var farmGuid = HttpContext.Request.Query["farmGuid"].ToSafetyString();
            var search = HttpContext.Request.Query["search"].ToSafetyString();
            var selected = HttpContext.Request.Query["selected"].ToSafetyString();
            return Ok(await _service.GetPigs(farmGuid, top, skip, search, selected));
        }
        [HttpPost]
        public async Task<ActionResult> LoadData([FromBody] DataManager request, string lang, string farmGuid, string makeOrderGuid)
        {

            var data = await _service.LoadData(request, farmGuid, makeOrderGuid, lang);
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult> LoadData2([FromBody] DataManager request, string farmGuid, string pen, string pigType, string pigPhase, string lang)
        {

            var data = await _service.LoadData(request, farmGuid, pen, pigType, pigPhase, lang);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> GetPigs2([FromBody] DataManager request, string farmGuid)
        {

            var data = await _service.GetPigs2(request, farmGuid);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> GetPigsByPen([FromBody] DataManager data, string penGuid, string recordGuid, string type)
        {

            return Ok(await _service.GetPigsByPen(data, penGuid, recordGuid, type));
        }
        [HttpGet]
        public async Task<ActionResult> GetFarms()
        {
            return Ok(await _service.GetFarms());
        }

        [HttpGet]
        public async Task<ActionResult> GetAreas(string farmGuid)
        {
            return Ok(await _service.GetAreas(farmGuid));
        }
        [HttpGet]
        public async Task<ActionResult> GetBarns(string farmGuid, string areaGuid)
        {
            return Ok(await _service.GetBarns(farmGuid, areaGuid));
        }
        [HttpGet]
        public async Task<ActionResult> GetCullingTanks(string farmGuid, string areaGuid)
        {
            return Ok(await _service.GetCullingTanks(farmGuid, areaGuid));
        }
        [HttpGet]
        public async Task<ActionResult> GetRooms(string farmGuid, string areaGuid, string barnGuid)
        {
            return Ok(await _service.GetRooms(farmGuid, areaGuid, barnGuid));
        }
        [HttpGet]
        public async Task<ActionResult> GetPens(string farmGuid, string areaGuid, string barnGuid, string roomGuid)
        {
            return Ok(await _service.GetPens(farmGuid, areaGuid, barnGuid, roomGuid));
        }
        [HttpGet]
        public async Task<ActionResult> GetAudit(decimal id)
        {
            return Ok(await _service.GetAudit(id));
        }
        [HttpGet]
        public async Task<ActionResult> GetPigByNo(string no)
        {
            return Ok(await _service.GetPigByNo(no));
        }
        [HttpPost]
        public async Task<ActionResult> GetDataDropdownlist([FromBody] DataManager request)
        {

            return Ok(await _service.GetDataDropdownlist(request));
        }

         [HttpPost]
        public async Task<ActionResult> RemoveRecord2Pig([FromBody]Record2Pig model)
        {
            return Ok(await _service.RemoveRecord2Pig(model));
        }
         [HttpPost]
        public async Task<ActionResult>AddRecord2Pig([FromBody]Record2Pig model)
        {
            return Ok(await _service.AddRecord2Pig(model));
        }

        [HttpGet]
        public async Task<ActionResult> GetPigsByPenAndRecord(string penGuid, string recordGuid, string type)
        {
            return Ok(await _service.GetPigsByPenAndRecord(penGuid, recordGuid, type));
        }
         [HttpGet]
        public async Task<ActionResult>  GetSelectedPig2([FromQuery] string[] guid, [FromQuery] string recordGuid, [FromQuery] string type)
        {
            return Ok(await _service.GetSelectedPig(guid,recordGuid,type));
        }
         [HttpGet]
        public async Task<ActionResult>  GetSelectedPig([FromQuery] string[] guid)
        {
            return Ok(await _service.GetSelectedPig(guid));
        }
          [HttpPost]
        public async Task<ActionResult>  GetSelectedPig3(SelectedPigParams p)
        {
            return Ok(await _service.GetSelectedPig(p));
        }
         [HttpGet]
        public async Task<ActionResult> GetSelectedPigsByRecord(string recordGuid, string type)
        {
            return Ok(await _service.GetSelectedPigsByRecord(recordGuid, type));
        }
    }
}
