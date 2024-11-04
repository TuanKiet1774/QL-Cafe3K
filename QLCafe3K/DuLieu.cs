using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLCafe3K.DAO;
//DESKTOP-GASMNFP\SQLEXPRESS
namespace QLCafe3K
{
    public partial class DuLieu : Form
    {
        BindingSource nvList = new BindingSource();
        BindingSource clvList = new BindingSource();
        BindingSource lcList = new BindingSource();
        BindingSource khList = new BindingSource();
        BindingSource nccList = new BindingSource();
        BindingSource lmhList = new BindingSource();
        BindingSource mhList = new BindingSource();
        BindingSource auList = new BindingSource();
        BindingSource hdnList = new BindingSource();
        BindingSource ctnList = new BindingSource();
        BindingSource hdList = new BindingSource();
        BindingSource cthdList = new BindingSource();
        public DuLieu()
        {
            InitializeComponent();
            dtgvNhanVien.DataSource = nvList;
            dtgvCaLamViec.DataSource = clvList;
            dtgvLuongCa.DataSource = lcList;
            dtgvKhachHang.DataSource = khList;
            dtgvNhaCungCap.DataSource = nccList;
            dtgvLoaiMatHang.DataSource = lmhList;
            dtgvMatHang.DataSource = mhList;
            dtgvAnUong.DataSource = auList;
            dtgvHoaDonNhap.DataSource = hdnList;
            dtgvChiTietNhap.DataSource = ctnList;
            dtgvHoaDon.DataSource = hdList;
            dtgvChiTietHoaDon.DataSource = cthdList;
            Load();

        }
        void Load()
        {
            LoadNV();
            AddNVBinding();
            LoadCLV();
            AddCLVBinding();
            LoadLC();
            AddLCBinding();
            LoadKH();
            AddKHBinding();
            LoadNCC();
            AddNCCBinding();
            LoadLMH();
            AddLMHBinding();
            LoadMH();
            AddMHBinding();
            LoadAU();
            AddAUBinding();
            LoadHDN();
            AddHDNBinding();
            LoadCTN();
            AddCTNBinding();
            LoadHD();
            AddHDBinding();
            LoadCTHD();
            AddCTHDBinding();
        }
        void LoadNV()
        {
            string query = "SELECT * from NHANVIEN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            nvList.DataSource = data;
        }
        void AddNVBinding()
        {
            txbNVMa.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txbNVHo.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "HoNV", true, DataSourceUpdateMode.Never));
            txbNVTen.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            dtpNVNgaySinh.DataBindings.Add(new Binding("Value", dtgvNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            dtpNVNgayLam.DataBindings.Add(new Binding("Value", dtgvNhanVien.DataSource, "NgayLamViec", true, DataSourceUpdateMode.Never));
            txbNVSDT.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SoDT", true, DataSourceUpdateMode.Never));
            cbNVChucVu.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
            txbNVDiaChi.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txbNVLuongGio.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "LuongGio", true, DataSourceUpdateMode.Never));
            txbNVSoTK.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SoTK", true, DataSourceUpdateMode.Never));
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            string MaNV = txbNVMa.Text;
            string HoNV = txbNVHo.Text;
            string TenNV = txbNVTen.Text;
            DateTime NgaySinh = dtpNVNgaySinh.Value;
            string GioiTinh = cbGioiTinh.Text;
            string DiaChi = txbNVDiaChi.Text;
            string SoDT = txbNVSDT.Text;
            string ChucVu = cbNVChucVu.Text;
            DateTime NgayLam = dtpNVNgayLam.Value;
            string LuongGio = txbNVLuongGio.Text;
            string SoTK = txbNVSoTK.Text;
            if (NhanVienDAO.Instance.InsertNhanVien(MaNV, HoNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDT, ChucVu, NgayLam, LuongGio, SoTK))
            {
                MessageBox.Show("Thêm nhân viên thành công");
                LoadNV();

            }
        }
        private void btnEditNV_Click(object sender, EventArgs e)
        {
            string MaNV = txbNVMa.Text;
            string HoNV = txbNVHo.Text;
            string TenNV = txbNVTen.Text;
            DateTime NgaySinh = dtpNVNgaySinh.Value;
            string GioiTinh = cbGioiTinh.Text;
            string DiaChi = txbNVDiaChi.Text;
            string SoDT = txbNVSDT.Text;
            string ChucVu = cbNVChucVu.Text;
            DateTime NgayLam = dtpNVNgayLam.Value;
            string LuongGio = txbNVLuongGio.Text;
            string SoTK = txbNVSoTK.Text;
            if (NhanVienDAO.Instance.UpdateNhanVien(MaNV, HoNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDT, ChucVu, NgayLam, LuongGio, SoTK))
            {
                MessageBox.Show("Sửa nhân viên thành công");
                LoadNV();
            }

        }
        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            string MaNV = txbNVMa.Text;

            if (NhanVienDAO.Instance.DeleteNhanVien(MaNV))
            {
                MessageBox.Show("Xóa nhân viên thành công");
                LoadNV();
            }
        }

        void LoadCLV()
        {
            string query = "SELECT * from CALAMVIEC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            clvList.DataSource = data;
        }
        void AddCLVBinding()
        {
            txbCLVMaCa.DataBindings.Add(new Binding("Text", dtgvCaLamViec.DataSource, "MaCa", true, DataSourceUpdateMode.Never));
            txbCLVTenCa.DataBindings.Add(new Binding("Text", dtgvCaLamViec.DataSource, "TenCa", true, DataSourceUpdateMode.Never));
            txbCLVGioBatDau.DataBindings.Add(new Binding("Text", dtgvCaLamViec.DataSource, "GioBatDau", true, DataSourceUpdateMode.Never));
            txbCLVGioKetThuc.DataBindings.Add(new Binding("Text", dtgvCaLamViec.DataSource, "GioKetThuc", true, DataSourceUpdateMode.Never));

        }

        private void btnAddCLV_Click(object sender, EventArgs e)
        {
            string MaCa = txbCLVMaCa.Text;
            string TenCa = txbCLVTenCa.Text;
            string GioBatDau = txbCLVGioBatDau.Text;
            string GioKetThuc = txbCLVGioKetThuc.Text;

            if (CaLamViecDAO.Instance.InsertCaLamViec(MaCa, TenCa, GioBatDau, GioKetThuc))
            {
                MessageBox.Show("Thêm ca làm việc thành công");
                LoadCLV();

            }
        }

        private void btnEditCLV_Click(object sender, EventArgs e)
        {
            string MaCa = txbCLVMaCa.Text;
            string TenCa = txbCLVTenCa.Text;
            string GioBatDau = txbCLVGioBatDau.Text;
            string GioKetThuc = txbCLVGioKetThuc.Text;

            if (CaLamViecDAO.Instance.UpdateCaLamViec(MaCa, TenCa, GioBatDau, GioKetThuc))
            {
                MessageBox.Show("Sửa ca làm việc thành công");
                LoadCLV();

            }
        }

        private void btnDeleteCLV_Click(object sender, EventArgs e)
        {
            string MaCa = txbCLVMaCa.Text;

            if (CaLamViecDAO.Instance.DeleteCaLamViec(MaCa))
            {
                MessageBox.Show("Xóa ca làm việc thành công");
                LoadCLV();
            }
        }
        void LoadLC()
        {
            string query = "SELECT * from LUONGCA";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            lcList.DataSource = data;
        }
        void AddLCBinding()
        {
            txbLCThang.DataBindings.Add(new Binding("Text", dtgvLuongCa.DataSource, "Thang", true, DataSourceUpdateMode.Never));
            txbLCNam.DataBindings.Add(new Binding("Text", dtgvLuongCa.DataSource, "Nam", true, DataSourceUpdateMode.Never));
            txbLCMaNV1.DataBindings.Add(new Binding("Text", dtgvLuongCa.DataSource, "MaNV1", true, DataSourceUpdateMode.Never));
            txbLCMaNV2.DataBindings.Add(new Binding("Text", dtgvLuongCa.DataSource, "MaNV2", true, DataSourceUpdateMode.Never));
            txbLCMaNV3.DataBindings.Add(new Binding("Text", dtgvLuongCa.DataSource, "MaNV3", true, DataSourceUpdateMode.Never));
            txbLCMaCa.DataBindings.Add(new Binding("Text", dtgvLuongCa.DataSource, "MaCa", true, DataSourceUpdateMode.Never));
        }

        private void btnAddLC_Click(object sender, EventArgs e)
        {
            string Thang = txbLCThang.Text;
            string Nam = txbLCNam.Text;
            string MaNV1 = txbLCMaNV1.Text;
            string MaNV2 = txbLCMaNV2.Text;
            string MaNV3 = txbLCMaNV3.Text;
            string MaCa = txbLCMaCa.Text;

            if (LuongCaDAO.Instance.InsertLuongCa(Thang, Nam, MaNV1, MaNV2, MaNV3, MaCa))
            {
                MessageBox.Show("Thêm lương ca thành công");
                LoadLC();

            }
        }

        private void btnEditLC_Click(object sender, EventArgs e)
        {
            string Thang = txbLCThang.Text;
            string Nam = txbLCNam.Text;
            string MaNV1 = txbLCMaNV1.Text;
            string MaNV2 = txbLCMaNV2.Text;
            string MaNV3 = txbLCMaNV3.Text;
            string MaCa = txbLCMaCa.Text;

            if (LuongCaDAO.Instance.UpdateLuongCa(Thang, Nam, MaNV1, MaNV2, MaNV3, MaCa))
            {
                MessageBox.Show("Sửa lương ca thành công");
                LoadLC();
            }
        }

        private void btnDeleteLC_Click(object sender, EventArgs e)
        {
            string Thang = txbLCThang.Text;
            string Nam = txbLCNam.Text;

            if (LuongCaDAO.Instance.DeleteLuongCa(Thang, Nam))
            {
                MessageBox.Show("Xóa lương ca thành công");
                LoadLC();
            }
        }
        void LoadKH()
        {
            string query = "SELECT * from KHACHHANG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            khList.DataSource = data;
        }
        void AddKHBinding()
        {
            txbKHMa.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txbKHHo.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "HoKH", true, DataSourceUpdateMode.Never));
            txbKHTen.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            txbKHDiaChi.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txbKHSoDT.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "SoDT", true, DataSourceUpdateMode.Never));
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            string MaKH = txbKHMa.Text;
            string HoKH = txbKHHo.Text;
            string TenKH = txbKHTen.Text;
            string DiaChi = txbKHDiaChi.Text;
            string SoDT = txbKHSoDT.Text;

            if (KhachHangDAO.Instance.InsertKhachHang(MaKH, HoKH, TenKH, DiaChi, SoDT))
            {
                MessageBox.Show("Thêm khách hàng thành công");
                LoadKH();

            }
        }

        private void btnEditKH_Click(object sender, EventArgs e)
        {
            string MaKH = txbKHMa.Text;
            string HoKH = txbKHHo.Text;
            string TenKH = txbKHTen.Text;
            string DiaChi = txbKHDiaChi.Text;
            string SoDT = txbKHSoDT.Text;

            if (KhachHangDAO.Instance.UpdateKhachHang(MaKH, HoKH, TenKH, DiaChi, SoDT))
            {
                MessageBox.Show("Sửa khách hàng thành công");
                LoadKH();

            }
        }

        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            string MaKH = txbKHMa.Text;

            if (KhachHangDAO.Instance.DeleteKhachHang(MaKH))
            {
                MessageBox.Show("Xóa khách hàng thành công");
                LoadKH();
            }
        }
        void LoadNCC()
        {
            string query = "SELECT * from NHACUNGCAP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            nccList.DataSource = data;
        }
        void AddNCCBinding()
        {
            txbNCCMa.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            txbNCCTen.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            txbNCCSoDT.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txbNCCDiaChi.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txbNCCEmail.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "Email", true, DataSourceUpdateMode.Never));
        }

        private void btnAddNCC_Click(object sender, EventArgs e)
        {
            string MaNCC = txbNCCMa.Text;
            string TenNCC = txbNCCTen.Text;
            string SDT = txbNCCSoDT.Text;
            string DiaChi = txbNCCDiaChi.Text;
            string Email = txbNCCEmail.Text;

            if (NhaCungCapDAO.Instance.InsertNhaCungCap(MaNCC, TenNCC, SDT, DiaChi, Email))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công");
                LoadNCC();

            }
        }

        private void btnEditNCC_Click(object sender, EventArgs e)
        {
            string MaNCC = txbNCCMa.Text;
            string TenNCC = txbNCCTen.Text;
            string SDT = txbNCCSoDT.Text;
            string DiaChi = txbNCCDiaChi.Text;
            string Email = txbNCCEmail.Text;

            if (NhaCungCapDAO.Instance.UpdateNhaCungCap(MaNCC, TenNCC, SDT, DiaChi, Email))
            {
                MessageBox.Show("Sửa nhà cung cấp thành công");
                LoadNCC();

            }
        }

        private void btnDeleteNCC_Click(object sender, EventArgs e)
        {
            string MaNCC = txbNCCMa.Text;

            if (NhaCungCapDAO.Instance.DeleteNhaCungCap(MaNCC))
            {
                MessageBox.Show("Xóa nhà cung cấp thành công");
                LoadNCC();
            }
        }
        void LoadLMH()
        {
            string query = "SELECT * from LOAIMATHANG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            lmhList.DataSource = data;
        }
        void AddLMHBinding()
        {
            txbLMHMa.DataBindings.Add(new Binding("Text", dtgvLoaiMatHang.DataSource, "MaLoai", true, DataSourceUpdateMode.Never));
            txbLMHTen.DataBindings.Add(new Binding("Text", dtgvLoaiMatHang.DataSource, "TenLoai", true, DataSourceUpdateMode.Never));
        }

        private void btnAddLMH_Click(object sender, EventArgs e)
        {
            string MaLoai = txbLMHMa.Text;
            string TenLoai = txbLMHTen.Text;

            if (LoaiMatHangDAO.Instance.InsertLoaiMatHang(MaLoai, TenLoai))
            {
                MessageBox.Show("Thêm loại mặt hàng thành công");
                LoadLMH();

            }
        }

        private void btnEditLMH_Click(object sender, EventArgs e)
        {
            string MaLoai = txbLMHMa.Text;
            string TenLoai = txbLMHTen.Text;

            if (LoaiMatHangDAO.Instance.UpdateLoaiMatHang(MaLoai, TenLoai))
            {
                MessageBox.Show("Thêm loại mặt hàng thành công");
                LoadLMH();

            }
        }

        private void btnDeleteLMH_Click(object sender, EventArgs e)
        {
            string MaLoai = txbLMHMa.Text;

            if (LoaiMatHangDAO.Instance.DeleteLoaiMatHang(MaLoai))
            {
                MessageBox.Show("Xóa loại mặt hàng thành công");
                LoadLMH();
            }
        }

        void LoadMH()
        {
            string query = "SELECT * from MATHANG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            mhList.DataSource = data;
        }
        void AddMHBinding()
        {
            txbMHMa.DataBindings.Add(new Binding("Text", dtgvMatHang.DataSource, "MaMH", true, DataSourceUpdateMode.Never));
            txbMHTen.DataBindings.Add(new Binding("Text", dtgvMatHang.DataSource, "TenMH", true, DataSourceUpdateMode.Never));
            txbMHMaLoai.DataBindings.Add(new Binding("Text", dtgvMatHang.DataSource, "MaLoai", true, DataSourceUpdateMode.Never));
            txbMHMaNCC.DataBindings.Add(new Binding("Text", dtgvMatHang.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            txbMHSoLuong.DataBindings.Add(new Binding("Text", dtgvMatHang.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            txbMHDonVi.DataBindings.Add(new Binding("Text", dtgvMatHang.DataSource, "DonVi", true, DataSourceUpdateMode.Never));
            dtpMHNgaySX.DataBindings.Add(new Binding("Value", dtgvMatHang.DataSource, "NgSX", true, DataSourceUpdateMode.Never));
            dtpMHHanSuDung.DataBindings.Add(new Binding("Value", dtgvMatHang.DataSource, "HSD", true, DataSourceUpdateMode.Never));
            txbMHDonGia.DataBindings.Add(new Binding("Text", dtgvMatHang.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
        }

        private void btnAddMH_Click(object sender, EventArgs e)
        {
            string MaMH = txbMHMa.Text;
            string TenMH = txbMHTen.Text;
            string MaLoai = txbMHMaLoai.Text;
            string MaNCC = txbMHMaNCC.Text;
            string SoLuong = txbMHSoLuong.Text;
            string DonVi = txbMHDonVi.Text;
            DateTime NgSX = dtpMHNgaySX.Value;
            DateTime HSD = dtpMHHanSuDung.Value;
            string DonGia = txbMHDonGia.Text;

            if (MatHangDAO.Instance.InsertMatHang(MaMH, TenMH, MaLoai, MaNCC, SoLuong, DonVi, NgSX, HSD, DonGia))
            {
                MessageBox.Show("Thêm mặt hàng thành công");
                LoadMH();

            }
        }
        private void btnEditMH_Click(object sender, EventArgs e)
        {
            string MaMH = txbMHMa.Text;
            string TenMH = txbMHTen.Text;
            string MaLoai = txbMHMaLoai.Text;
            string MaNCC = txbMHMaNCC.Text;
            string SoLuong = txbMHSoLuong.Text;
            string DonVi = txbMHDonVi.Text;
            DateTime NgSX = dtpMHNgaySX.Value;
            DateTime HSD = dtpMHHanSuDung.Value;
            string DonGia = txbMHDonGia.Text;

            if (MatHangDAO.Instance.UpdateMatHang(MaMH, TenMH, MaLoai, MaNCC, SoLuong, DonVi, NgSX, HSD, DonGia))
            {
                MessageBox.Show("Sửa mặt hàng thành công");
                LoadMH();

            }
        }

        private void btnDeleteMH_Click(object sender, EventArgs e)
        {
            string MaMH = txbMHMa.Text;

            if (MatHangDAO.Instance.DeleteMatHang(MaMH))
            {
                MessageBox.Show("Xóa mặt hàng thành công");
                LoadMH();
            }
        }
        void LoadAU()
        {
            string query = "SELECT * from ANUONG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            auList.DataSource = data;
        }
        void AddAUBinding()
        {
            txbAUMa.DataBindings.Add(new Binding("Text", dtgvAnUong.DataSource, "MaMon", true, DataSourceUpdateMode.Never));
            txbAUTen.DataBindings.Add(new Binding("Text", dtgvAnUong.DataSource, "TenMon", true, DataSourceUpdateMode.Never));
            txbAUMaLoai.DataBindings.Add(new Binding("Text", dtgvAnUong.DataSource, "MaLoai", true, DataSourceUpdateMode.Never));
            txbAUMoTa.DataBindings.Add(new Binding("Text", dtgvAnUong.DataSource, "MoTa", true, DataSourceUpdateMode.Never));
            txbAUSize.DataBindings.Add(new Binding("Text", dtgvAnUong.DataSource, "Size", true, DataSourceUpdateMode.Never));
            txbAUGiaTien.DataBindings.Add(new Binding("Text", dtgvAnUong.DataSource, "GiaTien", true, DataSourceUpdateMode.Never));
            txbAUDonVi.DataBindings.Add(new Binding("Text", dtgvAnUong.DataSource, "DonVi", true, DataSourceUpdateMode.Never));
        }

        private void btnAddAU_Click(object sender, EventArgs e)
        {
            string MaMon = txbAUMa.Text;
            string TenMon = txbAUTen.Text;
            string MaLoai = txbAUMaLoai.Text;
            string MoTa = txbAUMoTa.Text;
            string Size = txbAUSize.Text;
            string GiaTien = txbAUGiaTien.Text;
            string DonVi = txbAUDonVi.Text;

            if (AnUongDAO.Instance.InsertAnUong(MaMon, TenMon, MaLoai, MoTa, Size, GiaTien, DonVi))
            {
                MessageBox.Show("Thêm món hàng thành công");
                LoadAU();

            }
        }

        private void btnEditAU_Click(object sender, EventArgs e)
        {
            string MaMon = txbAUMa.Text;
            string TenMon = txbAUTen.Text;
            string MaLoai = txbAUMaLoai.Text;
            string MoTa = txbAUMoTa.Text;
            string Size = txbAUSize.Text;
            string GiaTien = txbAUGiaTien.Text;
            string DonVi = txbAUDonVi.Text;

            if (AnUongDAO.Instance.UpdateAnUong(MaMon, TenMon, MaLoai, MoTa, Size, GiaTien, DonVi))
            {
                MessageBox.Show("Sửa món hàng thành công");
                LoadAU();

            }
        }

        private void btnDeleteAU_Click(object sender, EventArgs e)
        {
            string MaMon = txbAUMa.Text;

            if (AnUongDAO.Instance.DeleteAnUong(MaMon))
            {
                MessageBox.Show("Xóa món thành công");
                LoadAU();
            }
        }
        void LoadHDN()
        {
            string query = "SELECT * from HOADONNHAP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            hdnList.DataSource = data;
        }
        void AddHDNBinding()
        {
            txbHDNMa.DataBindings.Add(new Binding("Text", dtgvHoaDonNhap.DataSource, "MaHDN", true, DataSourceUpdateMode.Never));
            txbHDNMaNCC.DataBindings.Add(new Binding("Text", dtgvHoaDonNhap.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            dtpHDNNgayNhap.DataBindings.Add(new Binding("Value", dtgvHoaDonNhap.DataSource, "NgayNhap", true, DataSourceUpdateMode.Never));
            txbHDNTongTien.DataBindings.Add(new Binding("Text", dtgvHoaDonNhap.DataSource, "TongTien", true, DataSourceUpdateMode.Never));
        }

        private void btnAddHDN_Click(object sender, EventArgs e)
        {
            string MaHDN = txbHDNMa.Text;
            string MaNCC = txbHDNMaNCC.Text; ;
            DateTime NgayNhap = dtpHDNNgayNhap.Value;
            string TongTien = txbHDNTongTien.Text;

            if (HoaDonNhapDAO.Instance.InsertHoaDonNhap(MaHDN, MaNCC, NgayNhap, TongTien))
            {
                MessageBox.Show("Thêm hóa đơn nhập thành công");
                LoadHDN();
            }
        }

        private void btnEditHDN_Click(object sender, EventArgs e)
        {
            string MaHDN = txbHDNMa.Text;
            string MaNCC = txbHDNMaNCC.Text; ;
            DateTime NgayNhap = dtpHDNNgayNhap.Value;
            string TongTien = txbHDNTongTien.Text;

            if (HoaDonNhapDAO.Instance.UpdateHoaDonNhap(MaHDN, MaNCC, NgayNhap, TongTien))
            {
                MessageBox.Show("Sửa hóa đơn nhập thành công");
                LoadHDN();
            }
        }

        private void btnDeleteHDN_Click(object sender, EventArgs e)
        {
            string MaHDN = txbHDNMa.Text;

            if (HoaDonNhapDAO.Instance.DeleteHoaDonNhap(MaHDN))
            {
                MessageBox.Show("Xóa hóa đơn nhập thành công");
                LoadHDN();
            }
        }
        void LoadCTN()
        {
            string query = "SELECT * from CHITIETNHAP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            ctnList.DataSource = data;
        }
        void AddCTNBinding()
        {
            txbCTNMa.DataBindings.Add(new Binding("Text", dtgvChiTietNhap.DataSource, "MaHDN", true, DataSourceUpdateMode.Never));
            txbCTNMaMH.DataBindings.Add(new Binding("Text", dtgvChiTietNhap.DataSource, "MaMH", true, DataSourceUpdateMode.Never));
            txbCTNDonGia.DataBindings.Add(new Binding("Text", dtgvChiTietNhap.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
            txbCTNSoLuong.DataBindings.Add(new Binding("Text", dtgvChiTietNhap.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
        }

        private void btnAddCTN_Click(object sender, EventArgs e)
        {
            string MaHDN = txbCTNMa.Text;
            string MaMH = txbCTNMaMH.Text;
            string DonGia = txbCTNDonGia.Text;
            string SoLuong = txbCTNSoLuong.Text;

            if (ChiTietNhapDAO.Instance.InsertChiTietNhap(MaHDN, MaMH, DonGia, SoLuong))
            {
                MessageBox.Show("Thêm chi tiết hóa đơn nhập thành công");
                LoadCTN();
            }
        }

        private void btnEditCTN_Click(object sender, EventArgs e)
        {
            string MaHDN = txbCTNMa.Text;
            string MaMH = txbCTNMaMH.Text;
            string DonGia = txbCTNDonGia.Text;
            string SoLuong = txbCTNSoLuong.Text;

            if (ChiTietNhapDAO.Instance.UpdateChiTietNhap(MaHDN, MaMH, DonGia, SoLuong))
            {
                MessageBox.Show("Sửa chi tiết hóa đơn nhập thành công");
                LoadCTN();
            }
        }

        private void btnDeleteCTN_Click(object sender, EventArgs e)
        {
            string MaHDN = txbCTNMa.Text;
            string MaMH = txbCTNMaMH.Text;

            if (ChiTietNhapDAO.Instance.DeleteChiTietNhap(MaHDN, MaMH))
            {
                MessageBox.Show("Xóa chi tiết hóa đơn nhập thành công");
                LoadCTN();
            }
        }
        void LoadHD()
        {
            string query = "SELECT * from HOADON";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            hdList.DataSource = data;
        }
        void AddHDBinding()
        {
            txbHDMa.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            txbHDMaNV.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txbHDMaKH.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            dtpHDNgay.DataBindings.Add(new Binding("Value", dtgvHoaDon.DataSource, "Ngay", true, DataSourceUpdateMode.Never));
            txbHDGiamGia.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "GiamGia", true, DataSourceUpdateMode.Never));
            txbHDTongTien.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "TongTien", true, DataSourceUpdateMode.Never));
        }

        private void btnAddHD_Click(object sender, EventArgs e)
        {
            string MaHD = txbHDMa.Text;
            string MaNV = txbHDMaNV.Text;
            string MaKH = txbHDMaKH.Text;
            DateTime Ngay = dtpHDNgay.Value;
            double Giamgia = double.Parse(txbHDGiamGia.Text);
            string TongTien = txbHDTongTien.Text;

            if (HoaDonDAO.Instance.InsertHoaDon(MaHD, MaNV, MaKH, Ngay, Giamgia, TongTien))
            {
                MessageBox.Show("Thêm hóa đơn thành công");
                LoadHD();
            }
        }

        private void btnEditHD_Click(object sender, EventArgs e)
        {
            string MaHD = txbHDMa.Text;
            string MaNV = txbHDMaNV.Text;
            string MaKH = txbHDMaKH.Text;
            DateTime Ngay = dtpHDNgay.Value;
            double Giamgia = double.Parse(txbHDGiamGia.Text);
            string TongTien = txbHDTongTien.Text;

            if (HoaDonDAO.Instance.UpdateHoaDon(MaHD, MaNV, MaKH, Ngay, Giamgia, TongTien))
            {
                MessageBox.Show("Sửa hóa đơn thành công");
                LoadHD();
            }
        }

        private void btnDeleteHD_Click(object sender, EventArgs e)
        {
            string MaHD = txbHDMa.Text;

            if (HoaDonDAO.Instance.DeleteHoaDon(MaHD))
            {
                MessageBox.Show("Xóa hóa đơn thành công");
                LoadHD();
            }
        }
        void LoadCTHD()
        {
            string query = "SELECT * from CHITIETHOADON";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            cthdList.DataSource = data;
        }
        void AddCTHDBinding()
        {
            txbCTHDMa.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            txbCTHDMaMon.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "MaMon", true, DataSourceUpdateMode.Never));
            txbCTHDDonGia.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
            txbCTHDSoLuong.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
        }

        private void btnAddCTHD_Click(object sender, EventArgs e)
        {
            string MaHD = txbCTHDMa.Text;
            string MaMon = txbCTHDMaMon.Text;
            string DonGia = txbCTHDDonGia.Text;
            string SoLuong = txbCTHDSoLuong.Text;

            if (ChiTietHoaDonDAO.Instance.InsertChiTietHoaDon(MaHD, MaMon, DonGia, SoLuong))
            {
                MessageBox.Show("Thêm chi tiết hóa đơn thành công");
                LoadCTHD();
            }
        }

        private void btnEditCTHD_Click(object sender, EventArgs e)
        {
            string MaHD = txbCTHDMa.Text;
            string MaMon = txbCTHDMaMon.Text;
            string DonGia = txbCTHDDonGia.Text;
            string SoLuong = txbCTHDSoLuong.Text;

            if (ChiTietHoaDonDAO.Instance.UpdateChiTietHoaDon(MaHD, MaMon, DonGia, SoLuong))
            {
                MessageBox.Show("Sửa chi tiết hóa đơn thành công");
                LoadCTHD();
            }
        }

        private void btnDeleteCTHD_Click(object sender, EventArgs e)
        {
            string MaHD = txbCTHDMa.Text;
            string MaMon = txbCTHDMaMon.Text; ;

            if (ChiTietHoaDonDAO.Instance.DeleteChiTietHoaDon(MaHD, MaMon))
            {
                MessageBox.Show("Xóa hóa đơn thành công");
                LoadCTHD();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tpCaLamViec_Click(object sender, EventArgs e)
        {

        }

        private void btnExitCLV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitLC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitKH_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitNCC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitAU_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitMH_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitLMH_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitHDN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitCTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitCTHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            double Tien = double.Parse(txbHDTongTien.Text);
            double Giam = double.Parse(txbHDGiamGia.Text);

            double thanhtoan;
            if (Giam != 0)
            {
                thanhtoan = Tien - (Tien * Giam);

            }
            else thanhtoan = Tien;

            txbThanhToan.Text = thanhtoan.ToString();
        }
    }
}
