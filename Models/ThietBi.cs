using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLN3.Models;

public class ThietBi
{
    [Key]
     [Required]
    [Display(Name = "Mã thiết bị")]
    public string? MaTB { get; set; }
    [Required]
    [Display(Name = "Tên thiết bị")]
    public string? TenTB { get; set; }
    [Required]
    [Display(Name = "Kích thước")]
    public string? size { get; set; }
    [Required]
    [Display(Name = "Số lượng")]
     public int Soluong { get; set; }

    [Required]
    [Display(Name = "Tình trạng")]
    public string? MaTinhTrang { get; set; }
    [ForeignKey("MaTinhTrang")]
    public TinhTrang? TinhTrang{get; set;} 
}