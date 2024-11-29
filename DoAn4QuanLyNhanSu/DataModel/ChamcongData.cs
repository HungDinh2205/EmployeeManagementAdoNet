using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    //public class ChamcongData
    //{
    //    public int? idchamcong {  get; set; }
    //    public int? idnv { get; set;}
    //    public DateTime? checkIn { get; set; }
    //    public DateTime? checkOut { get; set;}
    //    public int sọphutlamviec
    //    {
    //        get
    //        {
    //            if (checkIn.HasValue && checkOut.HasValue)
    //            {
    //                return (int)(checkOut.Value - checkIn.Value).TotalMinutes;
    //            }
    //            else if (checkIn.HasValue)
    //            {
    //                return (int)(DateTime.Now - checkIn.Value).TotalMinutes;
    //            }
    //            return 0;
    //        }
    //    }
    //}
    //public class ChamcongData2
    //{
    //    public int? idchamcong { get; set; }
    //    public string? hoten { get; set; }
    //    public DateTime? checkIn { get; set; }
    //    public DateTime? checkOut { get; set; }
    //    public int? sophutlamviec
    //    {
    //        get
    //        {
    //            if (checkIn.HasValue && checkOut.HasValue)
    //            {
    //                return (int)(checkOut.Value - checkIn.Value).TotalMinutes;
    //            }
    //            else if (checkIn.HasValue)
    //            {
    //                return (int)(DateTime.Now - checkIn.Value).TotalMinutes;
    //            }
    //            return 0;
    //        }
    //    }
    //    //public string? TuKhoa {  get; set; }
    //}
    //public class ChamcongData3
    //{
    //    public string? TuKhoa { get; set; }
    //    public string? hoten { get; set; }
    //}

    //public class ThoiGianLamViec
    //{
    //    public int? idnv { get; set; }
    //    public DateTime? startDate { get; set; }
    //    public DateTime? endDate { get; set; }
    //}

    public class ChamcongData4
    {
        public int? idchamcong { get; set; }
        public int? idnv { get; set; }
        public DateTime? ngaychamcong { get; set; }
        public DateTime? checkIn { get; set; }
        public DateTime? checkOut { get; set; }
        public string? trangthai { get; set; }
        public string? ghichu { get; set; }
    }
    public class ChamcongData5
    {
        public string? TuKhoa { get; set; }
        public string? hoten { get; set; }
    }

    public class ChamcongDataCheckIn
    {
        public int? idchamcong { get; set; }
        public int? idnv {  get; set; }
        public DateTime? ngaychamcong { get; set; } 
        public DateTime? checkIn {  get; set; }
        //public DateTime? checkOut { get; set; }
        public string? trangthai { get; set; }
        public string? ghichu { get; set; }
    }

    public class ChamcongDataCheckOut
    {
        public int? idchamcong { get; set; }
        public int? idnv { get; set; }
        public DateTime? ngaychamcong { get; set; }
        //public DateTime? checkIn { get; set; }
        public DateTime? checkOut { get; set; }
        public string? trangthai { get; set; }
        public string? ghichu { get; set; }
    }
}
