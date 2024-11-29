using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaohiemController : ControllerBase
    {
        private IBaohiemBUS  _baohiembus;
        public BaohiemController(IBaohiemBUS baohiem)
        {
            _baohiembus = baohiem;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] BaohiemData model)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _baohiembus.Create(model);
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
        public async Task<IActionResult> Update([FromBody] BaohiemData model)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _baohiembus.Update(model);
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
        public IActionResult DeleteItem(int idbaohiem)
        {
            var isDeleted = _baohiembus.Delete(idbaohiem);
            if (isDeleted)
            {
                return Ok("Xoa thanh cong");
            }
            return BadRequest("Xoa thanh cong");
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _baohiembus.GetAll();
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
        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> SaveItem([FromBody]BaohiemData model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = _baohiembus.Save(model);
                if (isSaved)
                {
                    return Ok("Thanh cong");
                }
                return BadRequest("Không thành công");
            }
            return BadRequest(ModelState);
        }
    }
}
