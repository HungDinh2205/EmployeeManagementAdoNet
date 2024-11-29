using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamcongController : ControllerBase
    {
        private IChamcongBUS _chamcongbus;
        public ChamcongController(IChamcongBUS chamcongBusiness)
        {
            _chamcongbus = chamcongBusiness;
        }

        //[Route("CheckIn")]
        //[HttpPost]
        //public IActionResult CheckIn([FromBody] ChamcongData model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        bool result = _chamcongbus.CheckIn(model);
        //        if (result)
        //        {
        //            return Ok(new { message = "Check in thành công" });
        //        }
        //        else
        //        {
        //            return BadRequest(new {message = "Check out không thành công"});
        //        }
        //    }catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[Route("CheckOut")]
        //[HttpPost]
        //public IActionResult CheckOut([FromBody] ChamcongData model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        bool result = _chamcongbus.CheckOut(model);
        //        if (result)
        //        {
        //            return Ok(new { message = "Check out thành công" });
        //        }
        //        else { return BadRequest(new { message = "Check out thất bại" }); }
        //    }catch(Exception ex) { return BadRequest(ex.Message); }
        //}

        //[Route("GetChamcongAll")]
        //[HttpGet]
        //public IActionResult GetChamcongAll( [FromQuery] DateTime startDate, [FromQuery] DateTime endDate )
        //{
        //    try
        //    {
        //        var chamcong = _chamcongbus.GetChamcongAll(startDate, endDate);
        //        return Ok(chamcong);
        //    }catch (Exception ex) { return BadRequest(ex.Message); }
        //}
        //[Route("Search")]
        //[HttpPost]
        //public IActionResult Search([FromBody] ChamcongData3 model) 
        //{
        //    try
        //    {
        //        if(model == null || string.IsNullOrWhiteSpace(model.TuKhoa))
        //        {
        //            return BadRequest("Bắt buộc từ khoá");
        //        }
        //        var chamcong = _chamcongbus.Search(model.TuKhoa);
        //        if(chamcong == null || !chamcong.Any())
        //        {
        //            return NotFound("Không tìm thấy kết quả nào cho từ đã tìm kiếm");
        //        }
        //        return Ok(chamcong);
        //    }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}
        //[Route("TinhThoiGianLamViec")]
        //[HttpGet]
        //public IActionResult TinhThoiGianLamViec([FromQuery] int idnv, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        if (idnv <= 0)
        //        {
        //            return BadRequest("Mã nhân viên không hợp lệ");
        //        }
        //        if(startDate >= endDate)
        //        {
        //            return BadRequest("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
        //        }
        //        var chamcong = _chamcongbus.TinhThoiGianLamViec(idnv, startDate, endDate);
        //        if (chamcong == null || !chamcong.Any())
        //        {
        //            return NotFound("Không tìm thấy dữ liệu thời gian làm việc cho nhân viên trong khoảng thời gian đã chọn");
        //        }
        //        return Ok(chamcong);
        //    }catch (Exception ex) { return BadRequest(ex.Message); }
        //}

        [Route("GetChamcongAll")]
        [HttpGet]
        public IActionResult GetChamcongAll()
        {
            var items = _chamcongbus.GetChamcongAll();

            // Kiểm tra items không null và không rỗng
            if (items != null && items.Any())
            {
                return Ok(new
                {
                    Message = "Thành công",
                    Status = true,
                    Data = items
                });
            }

            // Trả về NotFound nếu không có dữ liệu
            return NotFound(new
            {
                Message = "Không có dữ liệu",
                Status = false
            });
        }

        [Route("CheckIn")]
        [HttpPost]
        public IActionResult CheckIn([FromForm] ChamcongDataCheckIn model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //if (model.ngaychamcong.HasValue)
                //{
                //    DateTime ngayChamCong = model.ngaychamcong.Value.Date;  // Chỉ lấy ngày
                //    model.ngaychamcong = ngayChamCong;
                //}
                bool result = _chamcongbus.CheckIn(model);
                if (result)
                {
                    return Ok(new { message = "Check in thành công" });
                }
                else
                {
                    return BadRequest(new { message = "Check in không thành công" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CheckOut")]
        [HttpPost]
        public IActionResult CheckOut([FromForm] ChamcongDataCheckOut model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //if (model.ngaychamcong.HasValue)
                //{
                //    DateTime ngayChamCong = model.ngaychamcong.Value.Date;  // Chỉ lấy ngày
                //    model.ngaychamcong = ngayChamCong;

                //}
                bool result = _chamcongbus.CheckOut(model);
                if (result)
                {
                    return Ok(new { message = "Check out thành công" });
                }
                else { return BadRequest(new { message = "Check out thất bại" }); }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult<ChamcongData4>> UpdateItem([FromForm] ChamcongData4 model)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _chamcongbus.Update(model);
                if (isUpdated)  // Nếu cập nhật thành công
                {
                    return Ok(model);  // Trả về status 200 OK với model
                }
                else  // Nếu không cập nhật thành công
                {
                    return BadRequest("Cập nhật không thành công");  // Trả về status 400 với thông báo lỗi
                }
            }
            // Nếu model không hợp lệ, trả về lỗi 400 với thông tin của ModelState
            return BadRequest(ModelState);
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idchamcong)
        {
            var isDeleted = _chamcongbus.Delete(idchamcong);
            if (isDeleted)
            {
                return Ok("Xoá thành công");
            }
            return BadRequest("Xoá thất bại");
        }

        [Route("GetChamcong")]
        [HttpGet]
        public List<ChamcongData4> GetDanhSachNgayChamCong(DateTime ngaychamcong)
        {
            return _chamcongbus.GetDanhSachNgayChamCong(ngaychamcong);
        }
    }
}
