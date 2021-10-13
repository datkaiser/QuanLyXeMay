using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanli_CuaHang_PTxemay.Models;

namespace Quanli_CuaHang_PTxemay.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        public ActionResult DOchoiXemay()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(1)).ToList();
                return View(dsQt);

            }

        }

        public ActionResult Phutungthaythe()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(2)).ToList();
                return View(dsQt);

            }

        }
        public ActionResult VoXemay()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(3)).ToList();
                return View(dsQt);

            }

        }
        public ActionResult NhotXemay()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(4)).ToList();
                return View(dsQt);

            }

        }
        public ActionResult PhuKien()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(5)).ToList();
                return View(dsQt);

            }

        }
        public ActionResult Dokieng()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(2)).ToList();
                return View(dsQt);

            }

        }
        public ActionResult ChitietSp(int masp)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            PHUTUNGXE ptx = db.PHUTUNGXEs.SingleOrDefault(n => n.MAPT == masp);
            if (ptx == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<PHUTUNGXE> x = db.PHUTUNGXEs.Where(t => t.MALOAI == ptx.MALOAI).Take(6).ToList();
            ViewBag.ptungloai = x;
            return View(ptx);
        }
    }
}