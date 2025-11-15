using System;
using System.Windows.Forms;

namespace QLKS.Views
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            LoadEventHandlers();
        }

        private void LoadEventHandlers()
        {
            // Hệ thống
            menuDangNhap.Click += MenuDangNhap_Click;
            menuDangXuat.Click += MenuDangXuat_Click;
            menuThoat.Click += MenuThoat_Click;

            // Quản lý
            menuPhong.Click += MenuPhong_Click;
            menuDatPhong.Click += MenuDatPhong_Click;
            menuKhachHang.Click += MenuKhachHang_Click;
            menuDichVu.Click += MenuDichVu_Click;
            menuThanhToan.Click += MenuThanhToan_Click;

            // Báo cáo
            menuDoanhThu.Click += MenuDoanhThu_Click;
            menuPhongTrong.Click += MenuPhongTrong_Click;
        }

        private void MenuDangNhap_Click(object sender, EventArgs e)
        {
            // TODO: Mở form đăng nhập
            MessageBox.Show("Chức năng đăng nhập - Chưa triển khai", "Thông báo");
        }

        private void MenuDangXuat_Click(object sender, EventArgs e)
        {
            // TODO: Xử lý đăng xuất
            MessageBox.Show("Đăng xuất thành công", "Thông báo");
        }

        private void MenuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MenuPhong_Click(object sender, EventArgs e)
        {
            // TODO: Mở form quản lý phòng
            MessageBox.Show("Chức năng quản lý phòng - Chưa triển khai", "Thông báo");
        }

        private void MenuDatPhong_Click(object sender, EventArgs e)
        {
            // TODO: Mở form đặt phòng
            MessageBox.Show("Chức năng đặt phòng - Chưa triển khai", "Thông báo");
        }

        private void MenuKhachHang_Click(object sender, EventArgs e)
        {
            // TODO: Mở form quản lý khách hàng
            MessageBox.Show("Chức năng quản lý khách hàng - Chưa triển khai", "Thông báo");
        }

        private void MenuDichVu_Click(object sender, EventArgs e)
        {
            // TODO: Mở form quản lý dịch vụ
            MessageBox.Show("Chức năng quản lý dịch vụ - Chưa triển khai", "Thông báo");
        }

        private void MenuThanhToan_Click(object sender, EventArgs e)
        {
            // TODO: Mở form thanh toán
            MessageBox.Show("Chức năng thanh toán - Chưa triển khai", "Thông báo");
        }

        private void MenuDoanhThu_Click(object sender, EventArgs e)
        {
            // TODO: Mở báo cáo doanh thu
            MessageBox.Show("Báo cáo doanh thu - Chưa triển khai", "Thông báo");
        }

        private void MenuPhongTrong_Click(object sender, EventArgs e)
        {
            // TODO: Mở báo cáo phòng trống
            MessageBox.Show("Báo cáo phòng trống - Chưa triển khai", "Thông báo");
        }
    }
}
