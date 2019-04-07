using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAO
{
    public class DAO_KhachHang: Dataprovider
    {
        Dataprovider data = new Dataprovider();
        public List<DTO_KhachHang> GetData(string sql)
        {
            Connect();
            List<DTO_KhachHang> list = new List<DTO_KhachHang>();
            //sql = "SELECT MaKH, HoTenKH, DiaChi, DienThoai, Email FROM KhachHang";
            try
            {
                SqlDataReader dr = ExecuteReader(sql);

                string maKH;
                string hotenKH;
                string diachi;
                string dienthoai;
                string email;
                while (dr.Read())
                {

                    maKH = dr.GetString(0);
                    hotenKH = dr.GetString(1);
                    diachi = dr.GetString(2);
                    dienthoai = dr.GetString(3);
                    email = dr.GetString(4);
                    DTO_KhachHang emp = new DTO_KhachHang(maKH, hotenKH, diachi, dienthoai, email);
                    list.Add(emp);
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
