using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_SanPham
    {
        DAO_SanPham emp = new DAO_SanPham();
        public List<DTO_Sanpham> GetData(string sql)
        {

            return emp.GetData(sql);

        }
        public int Insert(string maSP, string tenSP, double dongia)
        {
            return emp.Insert(maSP, tenSP, dongia);
        }
        public int Delete1(string maSP)
        {
            return emp.Delete1(maSP);
        }
        public void Update(string maSP, string tenSP, double dongia)
        {
            emp.Update(maSP, tenSP, dongia);
        }
        //public int Search(string maSP)
        //{
        //    return emp.Search(maSP);
        //}
    }
}
