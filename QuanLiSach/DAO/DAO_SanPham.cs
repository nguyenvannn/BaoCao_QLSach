using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_SanPham : Dataprovider
    {
        public List<DTO_SanPham> GetData(string sql)
        {
            Connect();
            List<DTO_SanPham> list = new List<DTO_SanPham>();
            
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                int id;
                string masp;
                string tensp;
                double dongia;


                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    masp = dr.GetString(1);
                    tensp = dr.GetString(2);
                    dongia = dr.GetDouble(3);


                    DTO_SanPham sp = new DTO_SanPham(id, masp, tensp, dongia);
                    list.Add(sp);
                }
                dr.Close();
                return list;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
