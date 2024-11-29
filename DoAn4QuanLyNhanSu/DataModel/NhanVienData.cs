using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace DataModel
{
    public class NhanVienData
    {
        public int?  idnv  {get; set; }
        public string? hoten { get; set; }
        public bool? gioitinh { get; set; }
        public DateTime? ngaysinh { get; set; }
        public string? sdt { get; set; }
        public string? cccd { get; set; }
        public string? diachi {  get; set; }
        public IFormFile? AnhFile { get; set; }
        public string? anh { get; set; }
        public int? idphongban { get; set; }
        public int? idbophan { get; set; }
        public int? idchucvu { get; set; }
        public int? idtrinhdo { get; set; }
        public string? quoctich { get; set; }
        public int? iddantoc { get; set; }
        public int? idtongiao { get; set; }
    }

    public class NhanVienData2
    {
        public int? idnv { get; set; }
        public string? hoten { get; set; }
        public bool? gioitinh { get; set; }
        public DateTime? ngaysinh { get; set; }
        public string? sdt { get; set; }
        public string? cccd { get; set; }
        public string? diachi { get; set; }
        public IFormFile? AnhFile { get; set; }
        public string? anh { get; set; }
        public string? tenpb { get; set; }
        public string? tenbp { get; set; }
        public string? tencv { get; set; }
        public string? tentd { get; set; }
        public string? quoctich { get; set; }
        public string? tendantoc { get; set; }
        public string? tentongiao { get; set; }
    }
}
