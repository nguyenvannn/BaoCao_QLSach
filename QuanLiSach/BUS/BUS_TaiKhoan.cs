using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        DAO_TaiKhoan emp = new DAO_TaiKhoan();
        public List<DTO_TaiKhoan> GetData(string sql)
        {
            return emp.GetData(sql);
        }
    }
}
