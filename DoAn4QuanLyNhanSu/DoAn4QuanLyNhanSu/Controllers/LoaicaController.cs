using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaicaController : ControllerBase
    {
        public ILoaicaBUS _loaicabus;
        public LoaicaController(ILoaicaBUS loaicaBusiness)
        {
            _loaicabus = loaicaBusiness;
        }
        [Route("get_all")]
        [HttpGet]
        public List<LoaicaData> GetAll()
        {
            return _loaicabus.GetAll();

        }


        [Route("Create")]
        [HttpPost]
        public async Task<LoaicaData> CreateItem([FromBody] LoaicaData model)
        {
            _loaicabus.Create(model);
            return model;

        }

        [Route("Update")]
        [HttpPost]
        public async Task<LoaicaData> UpdateItem([FromBody] LoaicaData model)
        {
            _loaicabus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idloaica)
        {
            var isDeleted = _loaicabus.Delete(idloaica);
            if (isDeleted)
            {
                return Ok("Xoa thanh cong");
            }
            return BadRequest("Xoa thanh cong");
        }

        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> SaveItem([FromBody] LoaicaData model)
        {
            var result = _loaicabus.Save(model.idloaica, model.tenloaica, model.hesoca);
            if (result)
            {
                return Ok("Lưu thành công!");
            }
            else
            {
                return BadRequest("Lỗi khi lưu dữ liệu.");
            }
        }
    }
}
