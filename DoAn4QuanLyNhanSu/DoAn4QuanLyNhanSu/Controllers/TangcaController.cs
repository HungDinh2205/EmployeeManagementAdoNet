using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TangcaController : ControllerBase
    {
        private ITangcaBUS  _tangcabus;
        public TangcaController(ITangcaBUS tangca) { _tangcabus = tangca; }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody]TangcaData model)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _tangcabus.Create(model);
                if (isCreated)
                {
                    return Ok(model);
                }
                return BadRequest("Thêm 0 thành công");
            }
            return BadRequest(ModelState);
        
        }
        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateItem([FromBody] TangcaData model)
        {
            if (!ModelState.IsValid)
            {
                var isUpdated = _tangcabus.Update(model);
                if (isUpdated)
                {
                    return Ok(model);
                }
                return BadRequest("Cap nhat thanh cong");
            }
            return BadRequest(ModelState);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idtangca)
        {
            var isDeleted = _tangcabus.Delete(idtangca);
            if (isDeleted)
            {
                return Ok("Xoa thanh cong");
            }
            return BadRequest("Xoa thanh cong");
        }
        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _tangcabus.GetAll();
            if (items != null && items.Any())
            {
                return Ok(new
                {
                    Message = " thành công",
                    Status = true,
                    Data = items
                });
            }
            return NotFound(new
            {
                Message = "Không có dữ liệu",
                Status = false
            });
        }
    }
}
