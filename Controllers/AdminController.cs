using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filmsayt.appclass;
using Filmsayt.Models;

namespace Filmsayt.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filmlistesi()
        {
            var data = context.tbl_kinolar.ToList();
            return View(data);
        }

        public ActionResult Filmelaveet()
        {
            ViewBag.Kategoriyalar = context.tbl_kategoriya.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Filmelaveet(tbl_kinolar k)
        {
            context.tbl_kinolar.Add(k);
            context.SaveChanges();
            return RedirectToAction("Filmlistesi");
        }

        public ActionResult Sekil(int kinoid)
        {
            return View(kinoid);
        }

        [HttpPost]
        public ActionResult Sekil(int ID, HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                Image img = Image.FromStream(fileupload.InputStream);

                Bitmap kicikresim = new Bitmap(img, settings.Filmkicikboyut);

                Bitmap ortaresim = new Bitmap(img, settings.Filmortaboyut);

                Bitmap boyukresim = new Bitmap(img, settings.Filmboyukboyut);


                string kicikyol = "/Content/Filmresimler/Kicik/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);

                string ortayol = "/Content/Filmresimler/Orta/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);

                string boyukyol = "/Content/Filmresimler/Boyuk/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);

                kicikresim.Save(Server.MapPath(kicikyol));
                ortaresim.Save(Server.MapPath(ortayol));
                boyukresim.Save(Server.MapPath(boyukyol));

                tbl_resm rsm = new tbl_resm();
                rsm.boyukolculu = boyukyol;
                rsm.ortaolculu = ortayol;
                rsm.kicikolculu = kicikyol;
                rsm.filmid = ID;


                if (context.tbl_resm.FirstOrDefault(x => x.id == ID && x.varsayilan == false) != null)
                {
                    rsm.varsayilan = true;
                }
                else
                {
                    rsm.varsayilan = false;
                }

                context.tbl_resm.Add(rsm);
                context.SaveChanges();
                return View("Sekil");
            }
            return View("Sekil");
        }

        public ActionResult Filmguncelle(int kinoid)
        {
            ViewBag.Kategoriyalar = context.tbl_kategoriya.ToList();
            var kino = context.tbl_kinolar.Where(x => x.id == kinoid).FirstOrDefault();
            ViewBag.KATEGORIYAID = new SelectList(context.tbl_kategoriya, "id", "kategoriyaadi");

            return View(kino);
        }

        [HttpPost]
        public ActionResult Filmguncelle(int kinoid,tbl_kinolar model)
        {
            var kino = context.tbl_kinolar.Where(x => x.id == kinoid).SingleOrDefault();
            kino.kinoadi = model.kinoadi;
            kino.kategoriyaid = model.kategoriyaid;
            kino.kinoaciqlama = model.kinoaciqlama;
            kino.oyuncuadi = model.oyuncuadi;
            kino.yonetmenadi = model.yonetmenadi;
            kino.tarix = model.tarix;
            kino.reyting = model.reyting;
            kino.resmid = model.resmid;
            
            context.SaveChanges();
            return RedirectToAction("Filmlistesi", "Admin");
        }


        public ActionResult Filmsil(int kinoid)
        {
            tbl_resm resm = context.tbl_resm.Where(x => x.filmid == kinoid).FirstOrDefault();
            context.tbl_resm.Remove(resm);
            context.SaveChanges();

            tbl_kinolar kino = context.tbl_kinolar.FirstOrDefault(x => x.id == kinoid);
            context.tbl_kinolar.Remove(kino);
            context.SaveChanges();
            return RedirectToAction("Filmlistesi", "Admin");
        }


        public ActionResult Kategoriyalistesi()
        {
            var data = context.tbl_kategoriya.ToList();
            return View(data);
        }

        public ActionResult Kategoriyaelaveet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kategoriyaelaveet(tbl_kategoriya ktg)
        {
            context.tbl_kategoriya.Add(ktg);
            context.SaveChanges();
            return RedirectToAction("Kategoriyalistesi");
        }

        public ActionResult Kategoriyaguncelle(int id)
        {
            var kategoriya = context.tbl_kategoriya.Where(x => x.id == id).FirstOrDefault();
            return View(kategoriya);
        }

        [HttpPost]
        public ActionResult Kategoriyaguncelle(int id, tbl_kategoriya model)
        {
            var kategoriya = context.tbl_kategoriya.Where(x => x.id == id).FirstOrDefault();
            kategoriya.kategoriyaadi = model.kategoriyaadi;
            context.SaveChanges();
            return RedirectToAction("Kategoriyalistesi", "Admin");
        }

        public ActionResult Kategoriyasil(int id)
        {
            var kat = context.tbl_kategoriya.Where(x => x.id == id).FirstOrDefault();
            context.tbl_kategoriya.Remove(kat);
            context.SaveChanges();
            return RedirectToAction("Kategoriyalistesi", "Admin");
        }





    }
}