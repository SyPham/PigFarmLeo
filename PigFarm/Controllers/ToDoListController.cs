using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PigFarm.Controllers
{
    public class ToDoListController : ApiControllerBase
    {
        private readonly IToDoListService _service;

        public ToDoListController(IToDoListService service)
        {
            _service = service;
        }
    
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] ToDoListDto model)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            int accountID = JWTExtensions.GetDecodeTokenByID(accessToken);

            model.CreatedBy = accountID;
            return StatusCodeResult(await _service.AddAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ToDoListDto model)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            int accountID = JWTExtensions.GetDecodeTokenByID(accessToken);

            model.ModifiedBy = accountID;
            return StatusCodeResult(await _service.UpdateAsync(model));
        }

        [HttpPost]
        public async Task<ActionResult> AddRangeAsync([FromBody] List<ToDoListDto> model)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            int accountID = JWTExtensions.GetDecodeTokenByID(accessToken);
            foreach (var item in model)
            {
                item.CreatedBy = accountID;
            }
            return StatusCodeResult(await _service.AddRangeAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRangeAsync([FromBody] List<ToDoListDto> model)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            int accountID = JWTExtensions.GetDecodeTokenByID(accessToken);
            foreach (var item in model)
            {
                item.CreatedBy = accountID;
            }
            return StatusCodeResult(await _service.UpdateRangeAsync(model));
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
        public async Task<ActionResult> GetWithPaginationsAsync(PaginationParams paramater)
        {
            return Ok(await _service.GetWithPaginationsAsync(paramater));
        }
      
        [HttpGet]
        public async Task<IActionResult> ExcelExport()
        {
            string filename = "FHOTemplate.xlsx";
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/excelTemplate", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/octet-stream"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

       
    }
}
