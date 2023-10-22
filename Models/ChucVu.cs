using System.ComponentModel.DataAnnotations;
namespace BTLN3.Models
{
    public class ChucVu
    {
        [Key]
        [Display( Name = "Mã chức vụ")]
        public string? MaChucVu{ get; set; }
        [Display( Name = "Tên chức vụ")]
        public string? TenChucVu{ get; set; }
    }
}