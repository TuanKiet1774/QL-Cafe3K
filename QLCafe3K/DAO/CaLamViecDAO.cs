using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class CaLamViecDAO
    {
        private static CaLamViecDAO instance;

        public static CaLamViecDAO Instance
        {
            get { if (instance == null) instance = new CaLamViecDAO(); return instance; }
            private set { instance = value; }
        }

        private CaLamViecDAO() { }

        public bool InsertCaLamViec(string maca, string tenca, string giobatdau, string gioketthuc)
        {
            string query = string.Format("Insert CALAMVIEC (MaCa, TenCa, GioBatDau, GioKetThuc) " +
            "VALUES ('{0}', N'{1}', '{2}', '{3}')", maca, tenca, giobatdau, gioketthuc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCaLamViec(string maca, string tenca, string giobatdau, string gioketthuc)
        {
            string query = string.Format("UPDATE CaLAMVIEC SET TenCa = N'{0}', GioBatDau = '{1}', GioKetThuc = '{2}' where MaCa = '{3}'",
                tenca, giobatdau, gioketthuc, maca);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteCaLamViec(string maca)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from CaLamViec where MaCa='{0}'", maca);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
