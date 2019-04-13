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
    public class DAO_Khachhang : Dataprovider
    {
        Dataprovider data = new Dataprovider();
        public List<DTO_KhachHang> GetData(string sql)
        {
            Connect();
            List<DTO_KhachHang> list = new List<DTO_KhachHang>();
           
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
        public int Delete1(string maKH)
        {
            data.Connect();
            string sql = "DELETE FROM KhachHang WHERE MaKH ='"+ maKH +"'";
            int numberOff = data.ExecuteNonQuery(sql);
            return numberOff;
        }
        public int Update(string maKH, string hotenKH, string diachi, string dienthoai, string email)
        {
            try
            {
                data.Connect();
                string sql = "UPDATE KhachHang set HotenKH =N'" + hotenKH + "', Diachi=N'" + diachi + "', DienThoai =N'" + dienthoai + "', Email =N'" + email + "' WHERE MaKH ='" + maKH+"'";
                int numberRow = data.ExecuteNonQuery(sql);
                return numberRow;
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
        public int Search(string maKH)
        {
            Connect();
            string str = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            try
            {
                string sqlSearch = "IF EXISTS(SELECT FROM KhachHang WHERE MaKH='" + maKH.ToString() + "') BEGIN SELECT MaKH FROM KhachHang WHERE MaKH='" + maKH.ToString() + "'END";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                con.Open();
                int numberOfSearch = cmd.ExecuteNonQuery();
                return numberOfSearch;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
    
}
