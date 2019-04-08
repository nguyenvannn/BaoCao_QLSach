using System;
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
    }
}
