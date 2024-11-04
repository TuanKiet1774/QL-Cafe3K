using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class HoaDonNhapDAO
    {
        private static HoaDonNhapDAO instance;

        public static HoaDonNhapDAO Instance
        {
            get { if (instance == null) instance = new HoaDonNhapDAO(); return instance; }
            private set { instance = value; }
        }

        private HoaDonNhapDAO() { }

        public bool InsertHoaDonNhap(string mahdn, string mancc, DateTime ngaynhap, string tongtien)
        {
            string query = string.Format("Insert HOADONNHAP (MaHDN, MaNCC, NgayNhap, TongTien) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}')", mahdn, mancc, ngaynhap, tongtien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHoaDonNhap(string mahdn, string mancc, DateTime ngaynhap, string tongtien)
        {
            string query = string.Format("UPDATE HOADONNHAP SET MaNCC = '{0}', NgayNhap = '{1}', TongTien = '{2}' where MaHDN = '{3}'",
                mancc, ngaynhap, tongtien, mahdn);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteHoaDonNhap(string mahdn)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from HOADONNHAP where MaHDN= '{0}'", mahdn);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
