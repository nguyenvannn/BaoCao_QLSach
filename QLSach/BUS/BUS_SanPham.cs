﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_SanPham
    {
        DAO_SanPham emp = new DAO_SanPham();
        public List<DTO_Sanpham> GetData(string sql)
        {

            return emp.GetData(sql);

        }
        //public int Them(string maSP, string tenSP, double dongia)
        //{
        //    return Dao_SP.Them(maSP, tenSP, dongia);
        //}
    }
}
