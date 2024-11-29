using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhenthuongKyluatController : ControllerBase
    {
        private IKhenthuongKyluatBUS _khenthuongkyluat;
        public KhenthuongKyluatController(IKhenthuongKyluatBUS khenthuongkyluat)
        {
            _khenthuongkyluat = khenthuongkyluat;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Khenthuong_Kyluat model)
        {

            if (ModelState.IsValid)
            {
                var isCreated = _khenthuongkyluat.Create(model);
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
        public async Task<IActionResult> UpdateItem([FromBody] Khenthuong_Kyluat model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Nếu ModelState không hợp lệ, trả về BadRequest.
            }

            var isUpdate = _khenthuongkyluat.Update(model);
            if (!isUpdate)
            {
                return BadRequest(new { Message = "Cập nhật không thành công", Model = model });
            }

            return Ok(new { Message = "Cập nhật thành công", Model = model });
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            var isDeleted = _khenthuongkyluat.Delete(id);
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
            var items = _khenthuongkyluat.GetAll();
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
        [Route("GetAllandhoten")]
        [HttpGet]
        public IActionResult GetAllandhoten()
        {
            var items = _khenthuongkyluat.GetAllandhoten();
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
