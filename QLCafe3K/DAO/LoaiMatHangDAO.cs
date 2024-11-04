using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class LoaiMatHangDAO
    {
        private static LoaiMatHangDAO instance;

        public static LoaiMatHangDAO Instance
        {
            get { if (instance == null) instance = new LoaiMatHangDAO(); return instance; }
            private set { instance = value; }
        }

        private LoaiMatHangDAO() { }

        public bool InsertLoaiMatHang(string maloai, string tenloai)
        {
            string query = string.Format("Insert LOAIMATHANG (MaLoai, TenLoai) " +
            "VALUES ('{0}', N'{1}')", maloai, tenloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateLoaiMatHang(string maloai, string tenloai)
        {
            string query = string.Format("UPDATE LOAIMATHANG SET TenLoai= N'{0}' where MaLoai = '{1}'",
                tenloai, maloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteLoaiMatHang(string maloai)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from LOAIMATHANG where MaLoai= '{0}'", maloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
