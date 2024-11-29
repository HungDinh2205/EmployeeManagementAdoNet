using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Khenthuong_Kyluat
    {
        public int? id { get; set; }
        public string? soktkl { get; set; }
        public string? noidung { get; set; }
        public DateTime? ngayktkl { get; set; }
        public int? idnv {  get; set; }
        public bool? loai {  get; set; }
        public DateTime? tungay { get; set; }
        public DateTime? denngay { get; set; }
    }
    public class Khenthuong_Kyluat2
    {
        public int? id { get; set;}
        public string? soktkl { get; set; }
        public string? noidung { get; set; }
        public DateTime? ngayktkl { get; set; }
        public string? hoten { get; set; }
        public bool? loai { get; set; }
        public DateTime? tungay { get; set; }
        public DateTime? denngay { get; set; }
    }
}
