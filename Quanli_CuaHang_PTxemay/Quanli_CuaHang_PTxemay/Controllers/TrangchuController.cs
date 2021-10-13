using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Quanli_CuaHang_PTxemay.Models;

namespace Quanli_CuaHang_PTxemay.Controllers
{
    public class TrangchuController : Controller
    {

       
        // GET: Trangchu
        public ActionResult Index()
        {
            
            
            return View();
        }               
        public JsonResult GimmeArray()
        {
            string[] theArray ;
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<PHUTUNGXE> ptx = db.PHUTUNGXEs.ToList();
            List<string> tenpt1 = new List<string>();
            foreach (PHUTUNGXE x in ptx)
            {
                tenpt1.Add(x.TENPT);
            }
            theArray = tenpt1.ToArray();
            return Json(theArray, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search_box()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Search(FormCollection c)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string t = c["txtTen"];
            List<PHUTUNGXE> dstimkiem = db.PHUTUNGXEs.Where(x => x.TENPT.Contains(t)).ToList();
            if(dstimkiem.Count==1)
            {
                PHUTUNGXE x =  dstimkiem.First();
                return RedirectToAction("ChitietSp", "Sanpham", new { masp = x.MAPT });
            }
            else
                return View(dstimkiem);
        }
        public ActionResult Danhsach_PT()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = new List<PHUTUNGXE>();
                for(int i =1; i<7;i++)
                {
                    dsQt.Add((PHUTUNGXE)db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(i)).FirstOrDefault());
                }
                return PartialView(dsQt);
            }
                
        }

        public ActionResult Danhsach_Conten_PT()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(1)).Take(6).ToList();
                return PartialView(dsQt);
                
            }

        }

        public ActionResult Danhsach_Conten_PT1()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(2)).Take(6).ToList();
                return PartialView(dsQt);

            }

        }
        public ActionResult Danhsach_Conten_PT2()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(3)).Take(6).ToList();
                return PartialView(dsQt);

            }

        }
        public ActionResult Danhsach_Conten_PT3()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {               
                List<PHUTUNGXE> dsQt = db.PHUTUNGXEs.Where(t => t.MALOAI.Equals(4)).Take(6).ToList();
                return PartialView(dsQt);

            }

        }


    }
}