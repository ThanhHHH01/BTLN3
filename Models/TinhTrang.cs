using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLN3.Models
{
    public class TinhTrang
    {
        [Key]

        [Display( Name = "Mã tình trạng")]
        public string? MaTinhTrang{get; set;}

        [Display( Name = "Tên nội dung")]
        public string? TenND{get; set;}
       
        [Display( Name = "Nội dung tình trạng")]
        public string? NoidungTT { get; set; }
         
    }
}