using Microsoft.AspNetCore.Mvc;
using NetUtility;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class DiseaseController : ApiControllerBase
    {
        private readonly IDiseaseService _service;

        public DiseaseController(IDiseaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] DiseaseDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] DiseaseDto model)
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
        public async Task<ActionResult> GetDiseases()
        {
            var top = HttpContext.Request.Query["$top"].ToInt();
            var skip = HttpContext.Request.Query["$skip"].ToInt();
            var farmGuid = HttpContext.Request.Query["farmGuid"].ToSafetyString();
            var search = HttpContext.Request.Query["search"].ToSafetyString();
            var selected = HttpContext.Request.Query["selected"].ToSafetyString();
            return Ok(await _service.GetDiseases(farmGuid, top, skip, search, selected));
        }
        [HttpPost]
        public async Task<ActionResult> LoadData([FromBody] DataManager request, string farmGuid, string lang)
        {

            var data = await _service.LoadData(request,farmGuid, lang);
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
    }
}
