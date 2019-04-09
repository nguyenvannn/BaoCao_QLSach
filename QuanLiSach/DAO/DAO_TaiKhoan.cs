﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_TaiKhoan : Dataprovider
    {
        public List<DTO_TaiKhoan> GetData(string sql)
        {
            Connect();
            List<DTO_TaiKhoan> list = new List<DTO_TaiKhoan>();
            
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                int id;
                string username;
                string password;
                int userid;
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    username = dr.GetString(1);
                    password = dr.GetString(2);
                    userid = dr.GetInt32(3);


                    DTO_TaiKhoan tk = new DTO_TaiKhoan(id, username, password, userid);
                    list.Add(tk);
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
