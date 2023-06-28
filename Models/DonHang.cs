using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST05.Models
{
    public class DonHang
    {
        [Key]
        public string MaKhach{ get; set; }
        [ForeignKey("MaKhach")]
        public KhachHang? KhachHang {get; set;}
        public string MaDonHang{ get; set; }
        public string SoLuong { get; set; }
       
    }
}