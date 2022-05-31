﻿using Microsoft.AspNetCore.Mvc;
using NetUtility;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Models;
using PigFarm.Services;
using Syncfusion.JavaScript;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class RoomController : ApiControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetRoomsByFarmGuid(string farmGuid, string barnGuid)
        {
            return Ok(await _service.GetRoomsByFarmGuid(farmGuid, barnGuid));
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] RoomDto model)
        {
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RoomDto model)
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
        public async Task<ActionResult> GetRooms()
        {
            var top = HttpContext.Request.Query["$top"].ToInt();
            var skip = HttpContext.Request.Query["$skip"].ToInt();
            var farmGuid = HttpContext.Request.Query["farmGuid"].ToSafetyString();
            var search = HttpContext.Request.Query["search"].ToSafetyString();
            var selected = HttpContext.Request.Query["selected"].ToSafetyString();
            return Ok(await _service.GetRooms(farmGuid, top, skip, search, selected));
        }
        [HttpGet]
        public async Task<ActionResult> GetWithPaginationsAsync(PaginationParams paramater)
        {
            return Ok(await _service.GetWithPaginationsAsync(paramater));
        }
        [HttpPost]
        public async Task<ActionResult> LoadData([FromBody] DataManager request, [FromQuery] string farmGuid, [FromQuery] string areaGuid, [FromQuery] string barnGuid)
        {

            var data = await _service.LoadData(request, farmGuid, areaGuid, barnGuid);
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
        public async Task<ActionResult>  GetRoomByRecord(string recordGuid, string type)
        {
            return Ok(await _service.GetRoomByRecord(recordGuid,type));
        }
         [HttpPost]
         public async Task<ActionResult> RemoveRecord2Room([FromBody]Record2Room model)
        {
            return Ok(await _service.RemoveRecord2Room(model));
        }
         [HttpPost]
        public async Task<ActionResult>AddRecord2Room([FromBody]Record2Room model)
        {
            return Ok(await _service.AddRecord2Room(model));
        }
    }
}
