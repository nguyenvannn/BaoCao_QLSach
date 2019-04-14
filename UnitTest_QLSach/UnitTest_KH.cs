using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DTO;
using QLSach;

namespace UnitTest_QLSach
{
    [TestClass]
    public class UnitTest_KH
    {
        DAO_Khachhang dao = new DAO_Khachhang();
        [TestMethod]
        public void ThemKhachHang_NhapDungThongTin()
        {
            //Nhap thong tin dung - neu dung thi pass
            DTO_KhachHang kh1 = new DTO_KhachHang("KH20", "LyLy", "Go Vap", "Nữ", "0838882");
            bool actual = dao.Insert(kh1);
            Assert.IsTrue(actual);
        }


    }





}

 
