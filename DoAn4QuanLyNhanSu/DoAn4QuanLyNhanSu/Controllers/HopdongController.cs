using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopdongController : ControllerBase
    {
        private IHopdongBUS  _hopdongbus;
        public HopdongController(IHopdongBUS hopdong) { _hopdongbus = hopdong; }

        [Route("CheckAdd")]
        [HttpPost]
        public IActionResult CheckAddItem([FromBody] HopdongData model)
        {
            try
            {
                // Kiểm tra xem nhân viên đã có hợp đồng hay chưa
                if (!_hopdongbus.CheckEmployeeContract(model.idnv))
                {
                    return BadRequest("Nhân viên đã có hợp đồng. Không thể thêm mới.");
                }

                // Nếu không có hợp đồng, tiếp tục thêm mới
                var isCheckAdded = _hopdongbus.Create(model);
                if (isCheckAdded)
                {
                    return Ok(new { Message = "Hợp đồng đã được thêm thành công." });
                }

                return BadRequest("Có lỗi xảy ra khi thêm hợp đồng.");
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi (nếu cần thiết) và trả về lỗi cho client
                return StatusCode(500, $"Có lỗi xảy ra: {ex.Message}");
            }
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody]HopdongData model)
        {

            if (ModelState.IsValid)
            {
                var isCreated = _hopdongbus.Create(model);
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
        public async Task<IActionResult> UpdateItem([FromBody] HopdongData model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Nếu ModelState không hợp lệ, trả về BadRequest.
            }

            var isUpdate = _hopdongbus.Update(model);
            if (!isUpdate)
            {
                return BadRequest(new { Message = "Cập nhật không thành công", Model = model });
            }

            return Ok(new { Message = "Cập nhật thành công", Model = model });
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idhopdong)
        {
            var isDeleted = _hopdongbus.Delete(idhopdong);
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
            var items = _hopdongbus.GetAll();
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
        [Route("GetHopDongNhanVienDanhSach")]
        [HttpGet]
        public IActionResult GetNhanVienHopDong()
        {
            var items = _hopdongbus.GetNhanVienHopDong();
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
        public async Task<IActionResult> SaveItem([FromBody]HopdongData model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = _hopdongbus.Save(model);
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
