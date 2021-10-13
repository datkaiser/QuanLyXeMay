using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoanCNPM.DAL;

namespace DoanCNPM
{
    class codexuly
    {

       public static DataClassesTestDataContext db = new DataClassesTestDataContext();

        public static bool kiemtraSDTKH(string sdt)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(k => k.SDT.Equals(sdt));
            if (kh != null)
                return true;
            return false;

        }

        public static bool kTRDoiMK(string userName, string Phanquyen)
        {
            var q = from p in db.NHANVIENs
                    where p.SDT == userName
                    && p.MAPQ == Phanquyen
                    select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool DoiMK(string userName, string Phanquyen,string password )
        {
            if (kTRDoiMK(userName, Phanquyen) == true)
            {
                NHANVIEN tb = db.NHANVIENs.SingleOrDefault(s => s.SDT == userName && s.MAPQ == Phanquyen);
                tb.MatKhau = password;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

       

        public static bool checkgiamgia(string ma)
        {
            var ggs = db.GIAMGIAs.Where(x => x.MAGIAMGIA == ma.ToUpper() && x.NGAYBATDAU <= DateTime.Now && x.NGAYKETTHUC >= DateTime.Now);

            if (ggs.Any())
            {
               
                return true;
            }
            else
            {
                return false;
            }

        }






    }
}





//mã phụ tùng nó sẽ làm khi chọn 1 mã thì nó sẽ lấy cái mã cũa nó 
/// ngày bàn lấy ngày cũa hệ thống 
/// nhập mã vào thì lấy được cái gái tiền để giảm 
/// đơn giá là khi lấy  từ phụ tùng 
/// thành tiền là khi lấy các đơn giá các món hàng mình sẽ ra là thành tiền
/// 
/// 