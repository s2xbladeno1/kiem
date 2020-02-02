using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Common;
using Model.ViewModel;

namespace Model.DAO
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public int Insert(NguoiDung user)
        {
            db.NguoiDungs.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public int Login(string tk, string mk, bool isAdmin = false)
        {
            var user = db.NguoiDungs.SingleOrDefault(x => x.TaiKhoan == tk);
            if (user == null)
            {
                return 0; // Tài khoản không tồn tại
            }
            else
            {
                if(isAdmin == true)
                {
                    if(user.GroupID == GroupUser.ADMIN_GROUP || user.GroupID == GroupUser.NVBH_GROUP || user.GroupID == GroupUser.NVK_GROUP || user.GroupID == GroupUser.CSKH_GROUP)
                    {
                        if (user.TinhTrang == false)
                            return -1; // Tài khoản bị khóa
                        else
                        {
                            if (user.MatKhau == mk)
                                return 1; // Admin đăng nhập OK
                            else
                                return -2; // Sai mật khẩu
                        }
                    }
                    else
                        return -3; // Không phải là admin
                }
                else
                {
                    if (user.TinhTrang == false)
                        return -1; // Tài khoản bị khóa
                    else
                    {
                        if (user.MatKhau == mk)
                            return 1; // Member đăng nhập OK
                        else
                            return -2; // Sai mật khẩu
                    }
                }
               
            }
        }
        public List<string> GetListQuyenUser(string tk)
        {
            var user = db.NguoiDungs.Single(x => x.TaiKhoan == tk);
            var data = (from a in db.QuyenNguoiDungs
                        join b in db.Quyens on a.QuyenID equals b.ID
                        join c in db.NhomNguoiDungs on a.GroupID equals c.ID
                        where c.ID == user.GroupID
                        select new QuyenUserViewModel
                        {
                            GroupID = a.GroupID,
                            QuyenID = a.QuyenID
                        }).Select(x => x.QuyenID).ToList();
            return data;
        }
        public NguoiDung getByTK(string tk)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.TaiKhoan == tk);
        }
        public string getGroupID(int id)
        {
            return db.NguoiDungs.Where(x=>x.ID == id).Select(x=>x.GroupID).SingleOrDefault();
        }
        public IEnumerable<NguoiDung> ListUser(string SearchUser,int page = 1, int pageSize = 10)
        {
            IQueryable<NguoiDung> user = db.NguoiDungs;
            if (!String.IsNullOrEmpty(SearchUser))
            {
                return user.Where(x => x.HoTen.Contains(SearchUser) || x.TaiKhoan.Contains(SearchUser)).OrderByDescending(x => x.GroupID).ToPagedList(page, pageSize);
            }
            else
            {
                return user.OrderByDescending(x => x.GroupID).ToPagedList(page, pageSize);
            }
            
        }
        public NguoiDung Lock(int id)
        {
            return db.NguoiDungs.Where(x=>x.ID == id).SingleOrDefault();
        }
        public bool SaveLock(int id, bool tt)
        {
            var user = db.NguoiDungs.Find(id);
            user.TinhTrang = !tt;
            db.SaveChanges();
            return true;
        }
        public bool CheckTK(string tk)
        {
            return db.NguoiDungs.Count(x => x.TaiKhoan == tk) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.NguoiDungs.Count(x => x.Email == email) > 0;
        }
        public bool DoiMatKhau(int id,string mkcu, string mkmoi)
        {
            var user = db.NguoiDungs.Where(x => x.ID == id).SingleOrDefault();
            if(user.MatKhau == mkcu)
            {
                user.MatKhau = mkmoi;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<NguoiDung> ListMember(string group, int page, int pageSize)
        {
            return db.NguoiDungs.Where(x => x.GroupID == group).OrderByDescending(x => x.GroupID).ToPagedList(page,pageSize);
        }
        public IEnumerable<NguoiDung> ListQTV(string group, int page, int pageSize)
        {
            return db.NguoiDungs.Where(x => x.GroupID == "ADMIN" || x.GroupID == "CSKH" || x.GroupID == "NVBH" || x.GroupID == "NVK" || x.GroupID == group).OrderByDescending(x => x.GroupID).ToPagedList(page, pageSize);
        }
    }
}