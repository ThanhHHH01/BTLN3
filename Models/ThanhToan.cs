using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLN3.Models
{
    public class ThanhToan
    {
    [Key]

    [Required]
    [Display(Name = "Mã hóa đơn")]
    public string? MaHD { get; set; }

    [Required]
    [Display(Name = "Tên Hội Viên")]
    public string? HoiVienID { get; set; }
    [ForeignKey("HoiVienID")]
    [Display(Name = "Tên Hội Viên")]
    public HoiVien? HoiVien { get; set; }

    [Required]
    [Display(Name = "Gói tập")]
    public string? MaGoiTap { get; set; }
    [ForeignKey("MaGoiTap")]
    [Display(Name = "Gói tập")]
    public GoiTap? GoiTap { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = " Ngày bán ")]
    public DateTime Ngayban { get; set; }

    [Required]
    [Display(Name = "Tình trạng")]
    public string? MaTinhTrang { get; set; }
    [ForeignKey("MaTinhTrang")]
    public TinhTrang? TinhTrang { get; set; }
    }
}