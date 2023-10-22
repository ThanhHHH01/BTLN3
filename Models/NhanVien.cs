using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLN3.Models
{
    public class NhanVien
    {
        [Key]
        [Required]
        [Display( Name = "Mã nhân viên")]
        public string? MaID{get; set;}
        [Required]
        [Display( Name = "Tên nhân viên")]
        public string? TenNV{get; set;}

         [Required]
         [Display( Name = "Địa chỉ")]
        public string? Address{get; set;}

        [Required]
        [MinLength(10)]
        [Display( Name = "Số điện thoại")]
        public string? SĐT{get; set;}
        
        [Required]
        [Display( Name = "Email")]
        public string? EmailNV{get; set;}

        [Required]
        [Display( Name = "Chức vụ")]
        public string? MaChucVu{get; set;}
        [ForeignKey("MaChucVu")]
        [Display( Name = "Chức vụ")]
        public ChucVu? ChucVu{get; set;}     
    }
}