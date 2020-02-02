using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ChiTietNhapHangDao
    {
        OnlineShopDbContext db = null;
        public ChiTietNhapHangDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool Insert(ChitietNhapHang ctnh)
        {
            try
            {
                db.ChitietNhapHangs.Add(ctnh);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public List<ChitietNhapHang> ListCTNH(int manh)
        {
            return db.ChitietNhapHangs.Where(x => x.MaNH == manh).ToList();
        }
    }
}
