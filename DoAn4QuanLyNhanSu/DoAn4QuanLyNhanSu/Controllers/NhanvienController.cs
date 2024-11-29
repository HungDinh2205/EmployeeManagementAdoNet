using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private INhanvienBUS _nhanvienbus;

        public NhanvienController(INhanvienBUS nhanvineBusiness, IWebHostEnvironment webHostEnvironment)
        {
            _nhanvienbus = nhanvineBusiness;
            _webHostEnvironment = webHostEnvironment;
        }

        //[HttpPost("UploadFile")]
        //public async Task<string> UploadFileAsync(IFormFile? file, string folder)
        //{
        //    string webRootPath = _webHostEnvironment.WebRootPath;
        //    string relativeFolderPath = folder;
        //    string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

        //    if (!Directory.Exists(uploadsFolder))
        //    {
        //        Directory.CreateDirectory(uploadsFolder);
        //    }

        //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //    string filePath = Path.Combine(relativeFolderPath, uniqueFileName);

        //    using (var stream = new FileStream(Path.Combine(webRootPath, filePath), FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    string absoluteFilePath = Path.Combine(webRootPath, folder, uniqueFileName);
        //    string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

        //    return "/" + relativeFilePath.Replace("\\", "/");
        //}

        [HttpPost("UploadFile")]
        public async Task<string> UploadFileAsync(IFormFile? file, string folder)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/" + Path.Combine(folder, uniqueFileName).Replace("\\", "/");
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromForm] NhanVienData model)
        {
            if (ModelState.IsValid)
            {
                if (model.AnhFile != null)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var extension = Path.GetExtension(model.AnhFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        return BadRequest("Invalid image format. Only .jpg, .jpeg, and .png files are allowed.");
                    }
                    model.anh = await UploadFileAsync(model.AnhFile, "Nhanviens");
                }
                var isCreated =  _nhanvienbus.Create(model);
                if (isCreated)
                {
                    return Ok(model); // Trả về 200 OK với dữ liệu nhân viên
                }
                return BadRequest("Failed to create employee"); // Trả về 400 BadRequest nếu có lỗi
            }
            return BadRequest(ModelState); // Trả về lỗi 400 nếu dữ liệu không hợp lệ
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateItem([FromForm] NhanVienData model)
        {
            // Kiểm tra tính hợp lệ của model
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra và tải lên file ảnh nếu có
                    if (model.AnhFile?.Length > 0)
                    {
                        model.anh = await UploadFileAsync(model.AnhFile, "Nhanviens");
                    }

                    // Cập nhật thông tin nhân viên
                    var isUpdated = _nhanvienbus.Update(model);
                    if (!isUpdated)
                    {
                        return BadRequest(new { Message = "Failed to update employee. Update operation was not successful.", Model = model });
                    }

                    return Ok(new { Message = "Employee updated successfully", Model = model });
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ, trả về lỗi chi tiết
                    return StatusCode(500, new { Message = "An error occurred while updating the employee", Error = ex.Message });
                }
            }

            // Nếu ModelState không hợp lệ, trả về chi tiết lỗi validation
            return BadRequest(new { Message = "Invalid model data", Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idnv)
        {
            var isDeleted = _nhanvienbus.Delete(idnv);
            if (isDeleted)
            {
                return Ok("Xoá thành công");
            }
            return BadRequest("Xoá thất bại");
        }
        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> SaveItem([FromForm] NhanVienData model)
        {
            if (ModelState.IsValid)
            {
                if (model.AnhFile?.Length > 0)
                {
                    model.anh = await UploadFileAsync(model.AnhFile, "Nhanviens");
                }
                var isSaved = _nhanvienbus.Save(model);
                if (isSaved)
                {
                    return Ok("lưu thành công");
                }
                return BadRequest("Không thành công");
            }
            return BadRequest(ModelState);
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllItem()
        {
            var items = _nhanvienbus.GetAll();

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
        [Route("GetDetail")]
        [HttpGet]
        public IActionResult GetDetail()
        {
            var items = _nhanvienbus.GetDetailById();

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

        [Route("get_hopdong_nhanvien")]
        [HttpGet]
        public IActionResult GetNhanVienHopDong()
        {
            var items = _nhanvienbus.GetNhanVienHopDong();

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

        [Route("get_hoten_hopdong_nhanvien/{idnv}")]
        [HttpGet]
        public NhanVienData GetHotenNhanVienHopDong(int idnv)
        {
            return _nhanvienbus.GetHotenNhanVienHopDong(idnv);
        }

        //[Route("GetDetail")]
        //[HttpGet]
        //public IActionResult GetById( int idnv)
        //{
        //    var nhanVien = _nhanvienbus.GetDetailById(idnv);
        //    if (nhanVien == null)
        //        return NotFound();
        //    return Ok(nhanVien);
        //}

        //[Route("get_all")]
        //[HttpGet]
        //public List<NhanVienData> GetAll()
        //{
        //    return _nhanvienbus.GetAll();

        //}
    }
}
