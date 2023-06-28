using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST05.Models
{
    public class KhachHang
    {
        [Key]
         public string MaKhach{ get; set; }
        public string TenKhachHang{ get; set; }
        public string GioiTinh { get; set; }
       
    }
}