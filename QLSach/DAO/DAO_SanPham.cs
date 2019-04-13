using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class DAO_SanPham : Dataprovider
    {
        Dataprovider data = new Dataprovider();
        public List<DTO_Sanpham> GetData(string sql)
        {
            Connect();

            List<DTO_Sanpham> list = new List<DTO_Sanpham>();
           
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                string masp;
                string tensp;
                double dongia;


                while (dr.Read())
                {

                    masp = dr.GetString(0);
                    tensp = dr.GetString(1);
                    dongia = dr.GetDouble(2);


                    DTO_Sanpham emp = new DTO_Sanpham(masp, tensp, dongia);
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
        public int Insert(string maSP, string tenSP, double dongia)
        {

            try
            {
                Connect();
                string sql = "INSERT INTO SanPham VALUES('" + maSP + "',N'" + tenSP + "','" + dongia + "')";
                int numOfRow = ExecuteNonQuery(sql);
                return numOfRow;
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
        public int Delete1(string maSP)
        {
            data.Connect();
            string sql = "DELETE FROM SanPham WHERE MaSP ='" + maSP+"'";
            int numberOff = data.ExecuteNonQuery(sql);
            return numberOff;
        }
        public int Update(string maSP, string tenSP, double dongia)
        {
            try
            {
                data.Connect();
                string sql = "UPDATE SanPham set TenSP =N'" + tenSP + "', Dongia=N'" + dongia + "' WHERE MaSP ='" + maSP +"'";
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
        public int Search(string maSP)
        {
            Connect();
            string str = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            try
            {
                string sqlSearch = "IF EXISTS(SELECT FROM SanPham WHERE MaSP='" + maSP.ToString() + "') BEGIN SELECT MaSP FROM SanPham WHERE MaSP='" + maSP.ToString() + "'END";
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
