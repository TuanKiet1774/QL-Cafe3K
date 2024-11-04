using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        public static ChiTietHoaDonDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonDAO(); return instance; }
            private set { instance = value; }
        }

        private ChiTietHoaDonDAO() { }

        public bool InsertChiTietHoaDon(string mahd, string mamon, string dongia, string soluong)
        {
            string query = string.Format("Insert CHITIETHOADON (MaHD, MaMon, DonGia, SoLuong) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}')", mahd, mamon, dongia, soluong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateChiTietHoaDon(string mahd, string mamon, string dongia, string soluong)
        {
            string query = string.Format("UPDATE CHITIETHOADON SET DonGia = '{0}', SoLuong = '{1}' where MaHD = '{2}' and MaMon = '{3}'",
                dongia, soluong, mahd, mamon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteChiTietHoaDon(string mahd, string mamon)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from CHITIETHOADON where MaHD= '{0}' and MaMon = '{1}'", mahd, mamon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
