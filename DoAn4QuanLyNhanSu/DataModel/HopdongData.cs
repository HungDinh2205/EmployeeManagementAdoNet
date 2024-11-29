using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HopdongData
    {
        public int? idhopdong {  get; set; }
        public DateTime? ngaybatdau { get; set; }
        public DateTime? ngayketthuc { get; set; }
        public DateTime? ngayky {  get; set; }
        public string? noidung { get; set; }
        public int? lanky { get; set; }
        public float? hesoluong { get; set; }
        public string? thoihan { get; set; }
        public int idnv {  get; set; }
    }
    public class HopdongData2
    {
        public int? idhopdong { get; set; }
        public DateTime? ngaybatdau { get; set; }
        public DateTime? ngayketthuc { get; set; }
        public DateTime? ngayky { get; set; }
        public string? noidung { get; set; }
        public int? lanky { get; set; }
        public float? hesoluong { get; set; }
        public string? thoihan { get; set; }
        public string? hoten { get; set; }
    }
}
