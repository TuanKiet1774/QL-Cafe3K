using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe3K.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            private set { instance = value; }
        }

        private NhaCungCapDAO() { }

        public bool InsertNhaCungCap(string mancc, string tenncc, string sdt, string diachi, string email)
        {
            string query = string.Format("Insert NhACUNGCAP (MaNCC, TenNCC, SDT, DiaChi, Email) " +
            "VALUES ('{0}', N'{1}', '{2}', N'{3}', '{4}')", mancc, tenncc, sdt, diachi, email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNhaCungCap(string mancc, string tenncc, string sdt, string diachi, string email)
        {
            string query = string.Format("UPDATE NHACUNGCAP SET TenNCC = N'{0}', SDT = '{1}', DiaChi = N'{2}', Email = '{3}' where MaNCC = '{4}'",
                tenncc, sdt, diachi, email, mancc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //lưu ý : khi xóa thì phải xóa mấy cái chính ban đầu trước mà cái này có liên quan đến cái này
        //vào DAO cần xóa thực hiện : public void _tênhàm_(int id){
        //  DataProvider.Instance.ExecuteQuery("delete _tênbảng_ where idNV ="", + id);}

        public bool DeleteNhaCungCap(string mancc)
        {
            //###DAO.Instance.TênHàm(manv);
            string query = string.Format("Delete from NHACUNGCAP where MaNCC= '{0}'", mancc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
