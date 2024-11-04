using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class LuongCaDAO
    {
        private static LuongCaDAO instance;

        public static LuongCaDAO Instance
        {
            get { if (instance == null) instance = new LuongCaDAO(); return instance; }
            private set { instance = value; }
        }

        private LuongCaDAO() { }

        public bool InsertLuongCa(string thang, string nam, string manv1, string manv2, string manv3, string maca)
        {
            string query = string.Format("Insert LuongCa (Thang, Nam, MaNV1, MaNV2, MaNV3, MaCa) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", thang, nam, manv1, manv2, manv3, maca);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateLuongCa(string thang, string nam, string manv1, string manv2, string manv3, string maca)
        {
            string query = string.Format("UPDATE LUONGCA SET MaNV1 = '{0}', MaNV2 = '{1}', MaNV3 = '{2}', MaCa = '{3}' where Thang = '{4}' and Nam = '{5}'",
                manv1, manv2, manv3, maca, thang, nam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteLuongCa(string thang, string nam)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from LuongCa where Thang='{0}' and Nam ='{1}'", thang, nam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
