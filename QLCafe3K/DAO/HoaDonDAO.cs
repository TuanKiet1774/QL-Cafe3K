using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set { instance = value; }
        }

        private HoaDonDAO() { }

        public bool InsertHoaDon(string mahd, string manv, string makh, DateTime ngay, double giamgia, string tongtien)
        {
            string query = string.Format("Insert HOADON (MaHD, MaNV, MaKH, Ngay, GiamGia,TongTien) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", mahd, manv, makh, ngay, giamgia,tongtien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHoaDon(string mahd, string manv, string makh, DateTime ngay, double giamgia, string tongtien)
        {
            string query = string.Format("UPDATE HOADON SET MaNV = '{0}', MaKH = '{1}', Ngay = '{2}', TongTien = '{3}', GiamGia = {4} where MaHD = '{5}'",
                manv, makh, ngay, tongtien, giamgia, mahd);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteHoaDon(string mahd)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from HOADON where MaHD= '{0}'", mahd);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
