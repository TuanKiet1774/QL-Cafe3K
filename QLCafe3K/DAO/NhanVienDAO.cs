using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        private NhanVienDAO() { }

        public bool InsertNhanVien(string manv, string ho, string ten, DateTime ngaysinh, string gioitinh, string diachi, string sodienthoai, string chucvu, DateTime ngaylam, string luonggio, string sotk)
        {
            string query = string.Format("Insert NHANVIEN (MaNV, HoNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDT, ChucVu, NgayLamViec, LuongGio, SoTK) " +
            "VALUES ('{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}','{6}', N'{7}','{8}', {9}, '{10}' )", manv, ho, ten, ngaysinh, gioitinh, diachi, sodienthoai, chucvu, ngaylam, luonggio, sotk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNhanVien(string manv, string ho, string ten, DateTime ngaysinh, string gioitinh, string diachi, string sodienthoai, string chucvu, DateTime ngaylam, string luonggio, string sotk)
        {
            string query = string.Format("UPDATE NHANVIEN SET HoNV = N'{0}',TenNV = N'{1}', NgaySinh = '{2}', GioiTinh=N'{3}', DiaChi = N'{4}', SoDT = '{5}', ChucVu = N'{6}', NgayLamViec = '{7}', LuongGio = {8}, SoTK = '{9}' where MaNV = '{10}'",
                ho, ten, ngaysinh, gioitinh, diachi, sodienthoai, chucvu, ngaylam, luonggio, sotk, manv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteNhanVien(string manv)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from NHANVIEN where MaNV='{0}'", manv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }

}
