using Quanli_CuaHang_PTxemay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Quanli_CuaHang_PTxemay.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        private const string CustomerSession = "CustomerSession";
        private const string BillSession = "BillSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            double tongtien = 0;
            foreach (var item in list)
            {
                tongtien += (double)item.ProductID.GIABAN * item.Quantity;
            }
            ViewBag.tt = tongtien;
            return View(list);
        }
        public PHUTUNGXE ViewDetail(int id)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            PHUTUNGXE a = new PHUTUNGXE();
            PHUTUNGXE x = db.PHUTUNGXEs.Where(s => s.MAPT == id).SingleOrDefault();
            a = x;
            return a;
        }
        public ActionResult AddnewItem( int id, int quantity)
        {
            var pro = ViewDetail(id);
            var cart = Session[CartSession];
            if(cart!=null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.ProductID.MAPT == id))
                {
                    foreach (var item in list)
                    {
                        if(item.ProductID.MAPT ==id)
                        {
                            item.Quantity += quantity;
                        }
                        
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.ProductID= pro;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                CartItem item = new CartItem();
                item.ProductID = pro;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index", "Cart");

        }
        public JsonResult Update(string cartModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var Sessioncart = (List<CartItem>)Session[CartSession];

            foreach(var item in Sessioncart)
            {
                var jsonitem = jsoncart.SingleOrDefault(x => x.ProductID.MAPT == item.ProductID.MAPT);
                if(jsonitem!=null)
                {
                    item.Quantity = jsonitem.Quantity;
                }
            }
            Session[CartSession] = Sessioncart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var Sessioncart = (List<CartItem>)Session[CartSession];
            Sessioncart.RemoveAll(x => x.ProductID.MAPT == id);
            Session[CartSession] = Sessioncart;
            return Json(new
            {
                status = true
            });
        }
       
        public JsonResult Delete_Favorite_list_item(int id)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var Sessionkh = (KHACHHANG)Session[CustomerSession];
            List<DANHSACHYEUTHICH> gh = new List<DANHSACHYEUTHICH>();
            gh = db.DANHSACHYEUTHICHes.Where(s => s.SDT == Sessionkh.SDT && s.MAPT == id).ToList();
            foreach(var item in gh)
            {
                var gh_item = item;
                db.DANHSACHYEUTHICHes.DeleteOnSubmit(gh_item);
                db.SubmitChanges();
            }    
            return Json(new
            {
                status = true
            });
        }    
        public KHACHHANG InforCus(string tel)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                KHACHHANG k = new KHACHHANG();
                k = db.KHACHHANGs.FirstOrDefault(s => s.SDT == tel);
                if (k != null)
                    return k;
                else
                {
                    KHACHHANG newcustomer = new KHACHHANG();
                    newcustomer.SDT = tel;
                    db.KHACHHANGs.InsertOnSubmit(newcustomer);
                    db.SubmitChanges();
                    return newcustomer;
                }
            }
            catch
            {
                return null;
            }
             
        }
        public JsonResult LuuDanhsach(string tel)
        {
            if(tel!=null)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var Sessioncart = (List<CartItem>)Session[CartSession];
                Session[CustomerSession] = null;
                KHACHHANG customer = InforCus(tel);
                Session[CustomerSession] = customer;
                var cus = (KHACHHANG)Session[CustomerSession];
                foreach (var item in Sessioncart)
                {
                    DANHSACHYEUTHICH a = new DANHSACHYEUTHICH();
                    a.SDT = cus.SDT;
                    a.MAPT = item.ProductID.MAPT;
                    a.NGAYLAP = DateTime.Now;
                    a.SOLUONG_DS = item.Quantity;
                    db.DANHSACHYEUTHICHes.InsertOnSubmit(a);
                    db.SubmitChanges();
                }                
                HOADON newhd = new HOADON();
                newhd.SDT = cus.SDT;
                newhd.MANV = 1;
                newhd.NGAYBAN = DateTime.Now;
                newhd.TONGTIEN = 0;
                newhd.Tinhtrang = false;
                db.HOADONs.InsertOnSubmit(newhd);
                db.SubmitChanges();
                foreach(var item in Sessioncart)
                {
                    CTHD new_cthd = new CTHD();
                    new_cthd.MAHD = newhd.MAHD;
                    new_cthd.MAPT = item.ProductID.MAPT;
                    new_cthd.SOLUONG = item.Quantity;
                    new_cthd.DONGIA = item.ProductID.GIABAN;
                    new_cthd.THANHTIEN = item.ProductID.GIABAN * item.Quantity;
                    db.CTHDs.InsertOnSubmit(new_cthd);
                    db.SubmitChanges();
                    
                }    
                Session[CartSession] = null;
                return Json(new
                {
                    status = true
                });
            }
            return null;
        }      
        public ActionResult HienthiDanhsachyeuthich(string tel)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var Sessioncus = (KHACHHANG)Session[CustomerSession];
            if (Sessioncus == null)
            {
                if (tel != null)
                {
                    KHACHHANG kh = new KHACHHANG();
                    kh = db.KHACHHANGs.FirstOrDefault(s => s.SDT == tel);
                    if(kh==null)
                    {                       
                        return Json(new { status = false });
                    }
                    else
                    {
                        Sessioncus = kh;
                        List<DANHSACHYEUTHICH> gh = new List<DANHSACHYEUTHICH>();
                        gh = db.DANHSACHYEUTHICHes.Where(s => s.SDT == Sessioncus.SDT).ToList();
                        List<PHUTUNGXE> ptx = new List<PHUTUNGXE>();
                        foreach (var item in gh)
                        {
                            PHUTUNGXE a = new PHUTUNGXE();
                            a = db.PHUTUNGXEs.Where(s => s.MAPT == item.MAPT).FirstOrDefault();
                            ptx.Add(a);
                        }
                        ViewBag.kh = Sessioncus;
                        Session[CustomerSession] = kh;
                        ViewBag.danhsach = ptx.Distinct().ToList();
                        return Json(new { status = true });
                    }                        
                }
                return View();               
            }
            else
            {
                List<DANHSACHYEUTHICH> gh = new List<DANHSACHYEUTHICH>();
                gh = db.DANHSACHYEUTHICHes.Where(s => s.SDT == Sessioncus.SDT).ToList();
                List<PHUTUNGXE> ptx = new List<PHUTUNGXE>();
                foreach (var item in gh)
                {
                    PHUTUNGXE a = new PHUTUNGXE();
                    a = db.PHUTUNGXEs.Where(s => s.MAPT == item.MAPT).FirstOrDefault();
                    ptx.Add(a);
                }
                ViewBag.kh = Sessioncus;
                ViewBag.danhsach = ptx.Distinct().ToList();
                return View();
            }
                     
        }
        public ActionResult TinhTrang_DonHang(string tel)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            KHACHHANG cus = (KHACHHANG)Session[CustomerSession];
            List<HOADON> lstHoadon = new List<HOADON>();
            if (cus == null)
            {
                if (tel != null)
                {
                    KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(s => s.SDT == tel);
                    if (kh == null)
                        return Json(new { status = false });
                    else
                    {
                        Session[CustomerSession] = kh;
                        lstHoadon = db.HOADONs.Where(h => h.SDT == kh.SDT).ToList();
                        ViewBag.kh = kh;
                        ViewBag.dshd = lstHoadon;
                        return Json(new { status = true });

                    }
                }
                return View();
            }
            lstHoadon = db.HOADONs.Where(h => h.SDT == cus.SDT).ToList();
            ViewBag.kh = cus;
            ViewBag.dshd = lstHoadon;
            return View();
        }
        public JsonResult Delete_Giohang(int idHD)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<CTHD> cthd = db.CTHDs.Where(t => t.MAHD == idHD).ToList();
            foreach (var item in cthd)
            {

                db.CTHDs.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            HOADON hd = db.HOADONs.SingleOrDefault(t => t.MAHD == idHD);
            db.HOADONs.DeleteOnSubmit(hd);
            db.SubmitChanges();
            return Json(new
            {
                status = true
            });
        }
        public ActionResult ChitietDonHang(int idHD)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<CTHD> cthd = db.CTHDs.Where(c => c.MAHD == idHD).ToList();
            return View(cthd);
        }


    }
}