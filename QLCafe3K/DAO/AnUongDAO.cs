using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class AnUongDAO
    {
        private static AnUongDAO instance;

        public static AnUongDAO Instance
        {
            get { if (instance == null) instance = new AnUongDAO(); return instance; }
            private set { instance = value; }
        }

        private AnUongDAO() { }

        public bool InsertAnUong(string mamon, string tenmon, string maloai, string mota, string size, string giatien, string donvi)
        {
            string query = string.Format("Insert ANUONG (MaMon, TenMon, MaLoai, MoTa, Size, GiaTien, DonVi) " +
            "VALUES ('{0}', N'{1}', '{2}', N'{3}', N'{4}', '{5}', N'{6}')", mamon, tenmon, maloai, mota, size, giatien, donvi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAnUong(string mamon, string tenmon, string maloai, string mota, string size, string giatien, string donvi)
        {
            string query = string.Format("UPDATE ANUONG SET TenMon = N'{0}', MaLoai = '{1}', MoTa = N'{2}', Size = N'{3}', GiaTien = '{4}', DonVi = N'{5}' where MaMon = '{6}'",
                tenmon, maloai, mota, size, giatien, donvi, mamon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteAnUong(string mamon)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from ANUONG where MaMon= '{0}'", mamon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
