using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DTO;

namespace UnitTest_QLSach
{
    [TestClass]
    public class UnitTest_KH
    {
        DAO_Khachhang dao;
        DTO_KhachHang KhachHang1;
        DTO_KhachHang KhachHang2;
        DTO_KhachHang KhachHang3;
        DTO_KhachHang KhachHang4;
        DTO_KhachHang KhachHang5;
        [TestInitialize]
        public void SetUp()
        {
            dao = new DAO_Khachhang();
            KhachHang1 = new DTO_KhachHang
            {
                MaKH = "KH_001",
                HotenKH = "Khách hàng test 1",
                Diachi = "BT",
                DienThoai = "1",
                Email = "1"

            };
            KhachHang2 = new DTO_KhachHang
            {
                MaKH = "KH_002",
                HotenKH = "Khách hàng test 2",
                Diachi = "BT",
                DienThoai = "1",
                Email = "1"
            };
            KhachHang3 = new DTO_KhachHang
            {
                MaKH = "KH_003",
                HotenKH = "Khách hàng test 3",
                Diachi = "BT",
                DienThoai = "1",
                Email = "1"
            };
            KhachHang4 = new DTO_KhachHang
            {
                MaKH = "KH_004",
                HotenKH = "Khách hàng test 4",
                Diachi = "BT",
                DienThoai = "1",
                Email = "1"
            };
            KhachHang5 = new DTO_KhachHang
            {
                MaKH = "KH_005",
                HotenKH = "Khách hàng test 5",
                Diachi = "BT",
                DienThoai = "1",
                Email = "1"
            };

        }

    }
}
