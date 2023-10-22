using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLN3.Models
{
    public class HoiVien
    {
        [Key]
        [Required]
        [Display( Name = "Hội  viên ID")]
        public string? HoiVienID{get; set;}

        [Required]
        [Display( Name = "Tên hội viên")]
        public string? TenHV{get; set;}

        [Required]
        [Display( Name = "Địa chỉ")]
        public string? Address{get; set;}

        [Required]
        [MinLength(10)]
        [Display( Name = "Số điện thoại")]
        public string? SĐT{get; set;}

        [Required]
        [Display( Name = "Email hội viên")]
        public string? EmailHV{get; set;}

        [Required]
        [Display( Name = "Gói tập")]
        public string? MaGoiTap{get; set;}
        [ForeignKey("MaGoiTap")]
        [Display( Name = "Gói tập")]
        public GoiTap? GoiTap {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display( Name = "Ngày bắt đầu")]

        public DateTime? Ngaybatdau { get; set; }
        [DataType(DataType.Date)]
        [Display( Name = "Ngày kết thúc")]
        public DateTime? Ngayketthuc { get; set; }
 }
}