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
    public class DAO_KhachHang : Dataprovider
    {
        Dataprovider data = new Dataprovider();
        public List<DTO_KhachHang> GetData(string sql)
        {
            Connect();
            List<DTO_KhachHang> list = new List<DTO_KhachHang>();

            try
            {
                SqlDataReader dr = ExecuteReader(sql);

                string MaKH;
                string HoTenKH;
                string DiaChi;
                string DienThoai;
                string Email;
                while (dr.Read())
                {

                    MaKH = dr.GetString(0);
                    HoTenKH = dr.GetString(1);
                    DiaChi = dr.GetString(2);
                    DienThoai = dr.GetString(3);
                    Email = dr.GetString(4);
                    DTO_KhachHang emp = new DTO_KhachHang(MaKH, HoTenKH, DiaChi, DienThoai, Email);
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
        public int Insert(string maKH, string hotenKH, string diachi, string dienthoai, string email)
        {
            string str = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            Connect();
            try
            {
                string sql = "INSERT INTO KhachHang VALUES('" + maKH + "','" + hotenKH + "','" + diachi + "','" + dienthoai + "','" + email + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int numberOfRow = cmd.ExecuteNonQuery();
                return numberOfRow;
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
        public int Delete(string maKH)
        {
            Connect();
            try
            {
                string sql = "DELETE FROM KhachHang WHERE MaKH =" + maKH;
                int numberOfRows = ExecuteNonQuery(sql);
                return numberOfRows;
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
        public int Update(string maKH, string hotenKH, string diachi, string dienthoai, string email)
        {
            
        }
        public int Search(string maKH)
        {
            
        }
    }
}
