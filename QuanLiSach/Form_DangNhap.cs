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

namespace QuanLiSach
{
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin" && txtPassword.Text == "12345")
                MessageBox.Show(" Đăng nhập thành công ");
            else
            {
                if (txtUser.Text == "admin" && txtPassword.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu hoặc tài khoản không tồn tại");
                }
            }
            Form_KhachHang formKH = new Form_KhachHang();
            formKH.ShowDialog();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                e.Cancel = true;
        }
    }
}
