using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Nhanvien_Phucap
    {
        public int? idnvpc {  get; set; }
        public int? idnv {  get; set; }
        public int? idphucap { get; set; }
        public DateTime? ngayphucap { get; set; }
        public string? noidung { get; set; }
        public float? sotien {  get; set; }
    }
    public class Nhanvien_Phucap2
    {
        public int? idnvpc { get; set; }
        public string? hoten { get; set; }
        public string? tenphucap { get; set; }
        public DateTime? ngayphucap { get; set; }
        public string? noidung { get; set; }
        public float? sotien { get; set; }
    }
}
