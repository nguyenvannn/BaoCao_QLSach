using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using DTO;

namespace DAO
{
    public class Dataprovider
    {
        
        SqlConnection cn = null;
        public Dataprovider()
        {
            string cnStr = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            cn = new SqlConnection(cnStr);
        }
        public void Connect()
        {
            try
            {
                if (cn != null && cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            if (cn != null && cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            
            }
        }
        public SqlDataReader ExecuteReader(string sql)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteReader();
            }
            //catch (InvalidCastException ex)
            //{
            //    throw ex;
            //}
            catch (SqlException ex)
            {
                throw ex;
            }
            //catch (InvalidOperationException ex)
            //{
            //    throw ex;
            //}
        }
        public int ExecuteNonQuery(string sql)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
