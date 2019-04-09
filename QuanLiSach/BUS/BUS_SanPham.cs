using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_SanPham
    {
        BUS_SanPham emp = new BUS_SanPham();
        public List<DTO_SanPham> GetData(string sql)
        {
            return emp.GetData(sql);

        }
    }
}
