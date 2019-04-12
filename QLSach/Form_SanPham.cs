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

        private void btXoa_Click(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {

        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (dgvSanPham.Columns[col] is DataGridViewButtonColumn && dgvSanPham.Columns[col].Name == "Del")
            {
                int row = e.RowIndex;
                string maKH = dgvSanPham.Rows[row].Cells["MaSP"].Value.ToString();
                try
                {
                    int numOfRows = emp.Delete1(maKH);
                    if (numOfRows > 0)
                    {
                        LoadSanPham();
                        MessageBox.Show("Bạn đã xóa khách hàng [" + maKH + "]");

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu\n" + ex.Message);
                }
            }
            if (dgvSanPham.Columns[col] is DataGridViewButtonColumn && dgvSanPham.Columns[col].Name == "Sua")
            {
                int row = e.ColumnIndex;
                string maSP = dgvSanPham.Rows[row].Cells["MaSP"].Value.ToString();
                string tenSP = dgvSanPham.Rows[row].Cells["TenSP"].Value.ToString();
                double dongia = double.Parse(dgvSanPham.Rows[row].Cells["Dongia"].Value.ToString());
               
                try
                {
                    emp.Update(maSP, tenSP, dongia);
                    LoadSanPham();
                    MessageBox.Show("Ban da update thanh cong!!");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi!!" + ex.Message);
                }
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaSP.Text = dgvSanPham.Rows[row].Cells[2].Value.ToString();
            txtTenSP.Text = dgvSanPham.Rows[row].Cells[3].Value.ToString();
            txtDongia.Text = dgvSanPham.Rows[row].Cells[4].Value.ToString();
        }
    }
}
