using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPham
    {
        public int Id { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double Dongia { get; set; }
        public DTO_SanPham(int id, string masp, string tensp, double DonGia)
        {
            this.Id = id;
            this.MaSP = masp;
            this.TenSP = tensp;
            this.Dongia = DonGia;

        }
    }
}
