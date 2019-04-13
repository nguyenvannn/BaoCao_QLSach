using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAO_Khachhang emp = new DAO_Khachhang();
        public List<DTO_KhachHang> GetData(string sql)
        {
           
                return emp.GetData(sql);
          
            
        }
      
        public int Insert(string maKH, string hotenKH, string diachi, string sdt, string email)
        {
            return emp.Insert(maKH, hotenKH, diachi, sdt, email);
        }
        public int Delete1(string maKH)
        {
            return emp.Delete1(maKH);
        }
        public void Update(string maKH, string hotenKH, string diachi, string sdt, string email)
        {
            emp.Update(maKH, hotenKH, diachi, sdt, email);
        }
        public int Search(string maKH)
        {
            return emp.Search(maKH);
        }
    }
}
