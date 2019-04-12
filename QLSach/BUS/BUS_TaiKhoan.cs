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
    public class BUS_TaiKhoan
    {
        public List<DTO_Taikhoan> GetData()
        {
            try
            {
                return (new DAO_TaiKhoan().GetData());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
