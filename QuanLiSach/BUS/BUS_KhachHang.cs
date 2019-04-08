using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    class BUS_KhachHang
    {
        DAO_KhachHang emp = new DAO_KhachHang();
        public List<DTO_KhachHang> GetData(string sql)
        {

            return emp.GetData(sql);
            

        }
    }
}
