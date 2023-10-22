using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLN3.Models
{
    public class GoiTap
    {
        [Key]
        [Display( Name = "Mã Gói Tập")]
        public string? MaGoiTap{ get; set; }

        [Display( Name = "Tên Gói")]
        public string? TenGoi{ get; set; }
        
        [Display( Name = "Giá Gói")]
        public string? GiaGoi { get; set; }      
    }
}