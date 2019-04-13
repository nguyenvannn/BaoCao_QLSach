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
            string MaSP = txtMaSP.Text.Trim();
            emp.Delete1(MaSP);
            LoadSanPham();
            MessageBox.Show("Ban da xoa thanh cong!");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "" && txtDongia.Text != "" && txtTenSP.Text !="")
            {
                try
                {
                    string MaSP = txtMaSP.Text.Trim();
                    string TenSP = txtTenSP.Text.Trim();
                    float Dongia = float.Parse(txtDongia.Text.Trim());


                    emp.Insert(MaSP, TenSP, Dongia);
                    LoadSanPham();
                    MessageBox.Show("Da them thanh cong");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Loi!" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Phải nhập mã sản phẩm");
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaSP.Text = dgvSanPham.Rows[row].Cells[0].Value.ToString();
            txtTenSP.Text = dgvSanPham.Rows[row].Cells[1].Value.ToString();
            txtDongia.Text = dgvSanPham.Rows[row].Cells[2].Value.ToString();
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            try
            {
                string maSP = txtMaSP.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();
                double dongia = double.Parse(txtDongia.Text.Trim());



                emp.Update(maSP, tenSP, dongia);
                LoadSanPham();
                MessageBox.Show("Ban da Update thanh cong !!");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi!!" + ex.Message);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM SanPham WHERE MaSP Like'" + txtMaSP.Text + "%'";
            dgvSanPham.DataSource = emp.GetData(sql);
        }
    }
}
