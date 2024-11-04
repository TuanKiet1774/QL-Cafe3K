using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class ChiTietNhapDAO
    {
        private static ChiTietNhapDAO instance;

        public static ChiTietNhapDAO Instance
        {
            get { if (instance == null) instance = new ChiTietNhapDAO(); return instance; }
            private set { instance = value; }
        }

        private ChiTietNhapDAO() { }

        public bool InsertChiTietNhap(string mahdn, string mamh, string dongia, string soluong)
        {
            string query = string.Format("Insert CHITIETNHAP (MaHDN, MaMH, DonGia, SoLuong) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}')", mahdn, mamh, dongia, soluong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateChiTietNhap(string mahdn, string mamh, string dongia, string soluong)
        {
            string query = string.Format("UPDATE CHITIETNHAP SET DonGia = '{0}', SoLuong = '{1}' where MaHDN = '{2}' and MaMH = '{3}'",
                dongia, soluong, mahdn, mamh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteChiTietNhap(string mahdn, string mamh)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from CHITIETNHAP where MaHDN= '{0}' and MaMH = '{1}'", mahdn, mamh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
