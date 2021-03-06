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

namespace QLSach
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
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void dgvKhachHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaKH.Text = dgvKhachHang.Rows[row].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[row].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[row].Cells[2].Value.ToString();
            txtSdt.Text = dgvKhachHang.Rows[row].Cells[3].Value.ToString();
            txtEmail.Text = dgvKhachHang.Rows[row].Cells[4].Value.ToString();
            
        }

        private void btThemKH_Click_1(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                try
                {
                    string MaKH = txtMaKH.Text.Trim();
                    string HotenKH = txtTenKH.Text.Trim();
                    string Diachi = txtDiaChi.Text.Trim();
                    string Dienthoai = txtSdt.Text.Trim();
                    string Email = txtEmail.Text.Trim();


                    emp.Insert(MaKH, HotenKH, Diachi, Dienthoai, Email);
                    LoadKhachHang();
                    MessageBox.Show("Da them thanh cong");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Loi!" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nhập mã khách hàng");
            }
        }

        private void Form_KhachHang_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.No)
                e.Cancel = true;
        }

        private void btXoaKH_Click_1(object sender, EventArgs e)
        {
            string MaKH = txtMaKH.Text.Trim();
            emp.Delete1(MaKH);
            LoadKhachHang();
            MessageBox.Show("Ban da xoa thanh cong!");
        }

        private void btSuaKH_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtMaKH.Text.Trim();
                string hotenKH = txtTenKH.Text.Trim();
                string diachi = txtDiaChi.Text.Trim();
                string dienthoai = txtSdt.Text.Trim();
                string email = txtEmail.Text.Trim();
               

                emp.Update(maKH, hotenKH, diachi, dienthoai, email);
                LoadKhachHang();
                MessageBox.Show("Ban da Update thanh cong !!");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi!!" + ex.Message);
            }
        }

        private void btSanPham_Click_1(object sender, EventArgs e)
        {
            Form_SanPham formSP = new Form_SanPham();
            formSP.ShowDialog();
        }

        private void btTimKiem_Click_1(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM KhachHang WHERE MaKH Like'" + txtMaKH.Text + "%'";
            dgvKhachHang.DataSource = emp.GetData(sql);
        }

        private void btThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


