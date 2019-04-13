using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        public string MaKH { get; set; }
        public string HotenKH { get; set; }
        public string Diachi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
  
        public DTO_KhachHang (string maKH, string hotenKH, string diachi, string dienThoai, string email)
        {
            
            this.MaKH = maKH;
            this.HotenKH = hotenKH;
            this.Diachi = diachi;
            this.DienThoai = dienThoai;
            this.Email = email;
            
        }
    }
}
