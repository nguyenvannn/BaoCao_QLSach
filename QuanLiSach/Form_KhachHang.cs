﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;

namespace QuanLiSach
{
    public partial class Form_KhachHang : Form
    {
        BUS_KhachHang emp = new BUS_KhachHang();
        public Form_KhachHang()
        {
            InitializeComponent();
        }

        private void Form_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }
        private void LoadKhachHang()
        {
            string sql = "SELECT *FROM KhachHang";
            dgvKhachHang.DataSource = emp.GetData(sql);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = txtMaKH.Text.Trim();
                string HotenKH = txtHoten.Text.Trim();
                string Diachi = txtDiachi.Text.Trim();
                string Dienthoai = txtDienthoai.Text.Trim();
                string Email = txtEmail.Text.Trim();

                emp.Insert(MaKH, HotenKH, Diachi, Dienthoai, Email);
                LoadKhachHang();
                MessageBox.Show("Thanh cong");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi!" + ex.Message);
            }
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (dgvKhachHang.Columns[col] is DataGridViewButtonColumn && dgvKhachHang.Columns[col].Name == "Del")
            {
                int row = e.RowIndex;
                string maKH = dgvKhachHang.Rows[row].Cells["MaKH"].Value.ToString();
                try
                {
                    int numOfRows = emp.Delete1(maKH);
                    if (numOfRows > 0)
                    {
                        LoadKhachHang();
                        MessageBox.Show("Bạn đã xóa khách hàng [" + maKH + "]");

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu\n" + ex.Message);
                }
            }
            if (dgvKhachHang.Columns[col] is DataGridViewButtonColumn && dgvKhachHang.Columns[col].Name == "Sua")
            {
                int row = e.ColumnIndex;
                string maKH = dgvKhachHang.Rows[row].Cells["MaKH"].Value.ToString();
                string hotenKH = dgvKhachHang.Rows[row].Cells["HotenKH"].Value.ToString();
                string diachi = dgvKhachHang.Rows[row].Cells["Diachi"].Value.ToString();
                string dienthoai = dgvKhachHang.Rows[row].Cells["DienThoai"].Value.ToString();
                string email = dgvKhachHang.Rows[row].Cells["Email"].Value.ToString();
                try
                {
                    emp.Update(maKH, hotenKH, diachi, dienthoai, email);
                    LoadKhachHang();
                    MessageBox.Show("Ban da update thanh cong!!");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi!!" + ex.Message);
                }
            }
        }
    }
}