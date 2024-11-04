using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }

        private KhachHangDAO() { }

        public bool InsertKhachHang(string makh, string hokh, string tenkh, string diachi, string sdt)
        {
            string query = string.Format("Insert KhachHang (MaKH, HoKH, TenKH, DiaChi, SoDT) " +
            "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', '{4}')", makh, hokh, tenkh, diachi, sdt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateKhachHang(string makh, string hokh, string tenkh, string diachi, string sdt)
        {
            string query = string.Format("UPDATE KHACHHANG SET HoKH = N'{0}', TenKH = N'{1}', DiaChi = N'{2}', SoDT = '{3}' where MaKH = N'{4}'",
                hokh, tenkh, diachi, sdt, makh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteKhachHang(string makh)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from KHACHHANG where MaKH= N'{0}'", makh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
