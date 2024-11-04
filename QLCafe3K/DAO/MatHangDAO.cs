using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class MatHangDAO
    {
        private static MatHangDAO instance;

        public static MatHangDAO Instance
        {
            get { if (instance == null) instance = new MatHangDAO(); return instance; }
            private set { instance = value; }
        }

        private MatHangDAO() { }

        public bool InsertMatHang(string mamh, string tenmh, string maloai, string mancc, string soluong, string donvi, DateTime ngaysx, DateTime hansudung, string dongia )
        {
            string query = string.Format("Insert MATHANG (MaMH, TenMH, MaLoai, MaNCC, SoLuong, DonVi, NgSX, HSD, DonGia) " +
            "VALUES ('{0}', N'{1}', '{2}', '{3}', '{4}', N'{5}', '{6}', '{7}', '{8}')", mamh, tenmh, maloai, mancc, soluong, donvi, ngaysx, hansudung, dongia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMatHang(string mamh, string tenmh, string maloai, string mancc, string soluong, string donvi, DateTime ngaysx, DateTime hansudung, string dongia)
        {
            string query = string.Format("UPDATE MATHANG SET TenMH = N'{0}', MaLoai = '{1}', MaNCC = '{2}', SoLuong = '{3}', DonVi = N'{4}', NgSX = '{5}', HSD = '{6}', DonGia = '{7}'   where MaMH = '{8}'",
                tenmh, maloai, mancc, soluong, donvi, ngaysx, hansudung, dongia, mamh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteMatHang(string mamh)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from MATHANG where MaMH= '{0}'", mamh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
