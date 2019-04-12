using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Sanpham
    {
       
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double Dongia { get; set; }
        public DTO_Sanpham(string masp, string tensp, double DonGia)
        {
         
            this.MaSP= masp;
            this.TenSP = tensp;
            this.Dongia = DonGia;     

        }

    }
}
