using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace QLSach
{
    public partial class Form_SanPham : Form
    {
        BUS_SanPham emp = new BUS_SanPham();

        public Form_SanPham()
        {
            InitializeComponent();
        }

        private void Form_SanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();
        }
        private void LoadSanPham()
        {
            string sql = "SELECT *FROM SanPham";
            dgvSanPham.DataSource = emp.GetData(sql);
        }

        private void Form_SanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                e.Cancel = true;
        }

        //private void btThem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string MaSP = txtMaSP.Text;
        //        string TenSP = txtTenSP.Text;
        //        double Dongia = txtDongia.Text;
                

        //        Bus_Sanpham.Them(MaSP, TenSP, Dongia);
        //        LoadSanPham();
        //        MessageBox.Show("Thanh cong");

        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("Loi!" + ex.Message);
        //    }
        //}
    }
}
