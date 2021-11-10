using Filmsayt.appclass;
using Filmsayt.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmsayt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searcing)
        {
            return View();
        }

        public ActionResult Axtar(string searcing)
        {
            var data = context.tbl_kinolar.Where(x => x.kinoadi.Contains(searcing) || searcing == null).FirstOrDefault();

           


            return RedirectToAction("Details",new {id = data.id});
        }


        Context context = new Context();    
        public PartialViewResult Slider()
        {
            return PartialView();
        }

        public PartialViewResult Navigasiya()
        {
            var data = context.tbl_kategoriya.ToList();
            return PartialView(data);
        }

        public PartialViewResult MultiSlider()
        {
            var data = context.tbl_kinolar.ToList();
            return PartialView(data);
        }


       
        public ActionResult Details(int id)
        {
            var data = context.tbl_kinolar.Where(x => x.id == id).FirstOrDefault();
            ViewBag.oyuncular = context.tbl_kinolar.Where(x => x.id == id).Select(x => x.oyuncuadi).ToList();

            data.goruntulenme++;
            
            context.SaveChanges();
            return View(data);
        }

        [HttpPost]
        public string Goruntulendi(int id)
        {
            tbl_kinolar mql = context.tbl_kinolar.FirstOrDefault(x => x.id == id);
            mql.goruntulenme++;
            context.SaveChanges();
            return mql.goruntulenme.ToString();
        }

        [AllowAnonymous]
        public string Begen(int id)
        {
            tbl_kinolar mql = context.tbl_kinolar.FirstOrDefault(x => x.id == id);
            mql.begen++;
            context.SaveChanges();
            return mql.begen.ToString();
        }
        [AllowAnonymous]
        public string Begenme(int id)
        {
            tbl_kinolar mql = context.tbl_kinolar.FirstOrDefault(x => x.id == id);
            mql.begenme++;
            context.SaveChanges();
            return mql.begenme.ToString();
        }




      


        [HttpPost]
        public ActionResult Yorumyaz(int id, string yorum,string istifadeci,tbl_yorum model)
        {
            if (Session["username"] != null)
            { 
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_kullanici.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

                //context.tbl_yorum.Add(new tbl_yorum { yorumkullaniciid = kullanici.id, yorumfilmid = id, tarix = DateTime.Now, yorumicerik = yorum });
                var comment = new tbl_yorum();
                comment.yorumkullaniciid = kullanici.id;
                comment.yorumfilmid = id;
                comment.rayting = model.rayting;
                comment.tarix = DateTime.Now;
               
                comment.yorumicerik = yorum;
                context.tbl_yorum.Add(comment);
                context.SaveChanges();
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
            else
            {
                //context.tbl_yorum.Add(new tbl_yorum { istifadeci = istifadeci, yorumfilmid = id, tarix = DateTime.Now, yorumicerik = yorum});
                var comment = new tbl_yorum();
                comment.istifadeci = istifadeci;
                comment.yorumfilmid = id;
                comment.tarix = DateTime.Now;
                comment.rayting = model.rayting;
                comment.yorumicerik = yorum;
                context.tbl_yorum.Add(comment);
                context.SaveChanges();
                return Redirect(Request.UrlReferrer.PathAndQuery);

            }

           

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult REPLY(tbl_replies model,int id,string yorumm)
        {
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_kullanici.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();
            int userid = kullanici.id;
            if (userid == 0)
            {
                return RedirectToAction("Login","Home");
            }
            tbl_replies r = new tbl_replies();
            r.text = yorumm;
            r.commentid = id;
            r.userid = userid;
            r.tarix = DateTime.Now;
            context.tbl_replies.Add(r);
            context.SaveChanges();
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }


        public PartialViewResult Basliqlar()
        {
            return PartialView();
        }

        public PartialViewResult Basliqlar2()
        {
            return PartialView();
        }

        public PartialViewResult Meshur()
        {
            var data = context.tbl_kinolar.OrderBy(x => x.kinoadi).ToList();
            return PartialView(data);
        }

        public PartialViewResult Tezlikle()
        {
            var data = context.tbl_kinolar.OrderByDescending(x => x.tarix).ToList();
            return PartialView(data);
        }

        public PartialViewResult Baxilan()
        {
            var data = context.tbl_kinolar.OrderByDescending(x => x.reyting).ToList();
            return PartialView(data);
        }

        public PartialViewResult imdb()
        {
            var data = context.tbl_kinolar.OrderByDescending(x => x.kinoadi).ToList();
            return PartialView(data);
        }

        public PartialViewResult Sinema()
        {
            var data = context.tbl_kinolar.ToList();
            return PartialView(data);
        }

        public ActionResult Qeydiyyat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Qeydiyyat(tbl_kullanici model)
        {

            var varmi = context.tbl_kullanici.Where(i => i.istifadeciadi == model.istifadeciadi).SingleOrDefault();

            if (varmi != null)
            {
                return View();
            }

            if (string.IsNullOrEmpty(model.sifre))
            {
                return View();
            }


            context.tbl_kullanici.Add(model);
            context.SaveChanges();

            Session["username"] = model.istifadeciadi;

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(tbl_kullanici model)
        {
            var varmi = context.tbl_kullanici.Where(i => i.istifadeciadi == model.istifadeciadi).SingleOrDefault();
            if (varmi == null)
            {
                return View();
            }
            if (varmi.sifre == model.sifre)
            {
                Session["username"] = model.istifadeciadi;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email not found or matched";
                return View();
            }
        }

        public ActionResult Xosunuz()
        {
            var data = context.tbl_kinolar.OrderByDescending(x => x.reyting).ToList();
            return View(data);
        }
        public ActionResult Navencox()
        {
            var data = context.tbl_kinolar.OrderBy(x => x.reyting).ToList();
            return View(data);       
        }
        public ActionResult Navimdb()
        {
            var data = context.tbl_kinolar.OrderBy(x => x.kinoaciqlama).ToList();
            return View(data);
        }

        public ActionResult KategoriyaFilm(int id)
        {
            var data = context.tbl_kinolar.Where(x => x.kategoriyaid == id).ToList();
            return View(data);
        }
        public ActionResult Profilim()
        {
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_kullanici.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult Profilim(HttpPostedFileBase fileupload)
        {
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_kullanici.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();
            if (fileupload != null)
            {
                Image img = Image.FromStream(fileupload.InputStream);

                Bitmap kicikresim = new Bitmap(img, settings.KullaniciBoyut);



                string kicikyol = "/Content/Filmresimler/Kicik/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);


                kicikresim.Save(Server.MapPath(kicikyol));
               
                tbl_resm rsm = new tbl_resm();

                
                var k1 = context.tbl_kullanici.Where(x => x.id == kullanici.id).FirstOrDefault();
                var k2 = context.tbl_resm.Where(x => x.kullaniciid == k1.id).FirstOrDefault();

                if (k2 != null)
                {
                    context.tbl_resm.Remove(k2);
                    context.SaveChanges();

                }

                rsm.kullaniciolculu = kicikyol;
                rsm.kullaniciid = kullanici.id;
                var data = context.tbl_resm.OrderByDescending(x => x.kullaniciid == kullanici.id).First();

                if (context.tbl_resm.FirstOrDefault(x => x.id == kullanici.id && x.varsayilan == false) != null)
                {
                    rsm.varsayilan = true;
                }
                else
                {
                    rsm.varsayilan = false;
                }

                context.tbl_resm.Add(rsm);
                context.SaveChanges();
                return View("Index");
            }
            return View("Index");
        }
        
        public ActionResult Profilpassword()
        {
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_kullanici.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();


            return View(kullanici);

        }
        [HttpPost]
        public ActionResult Profilpassword(tbl_kullanici model)
        {
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_kullanici.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

            if (kullanici.sifre != model.sifre)
            {
                return View();
            }
            else if (kullanici.istifadeciadi != model.istifadeciadi)
            {
                return View();
            }
            else
            {
                kullanici.istifadeciadi = model.istifadeciadi;
                kullanici.sifre = model.yenisifre;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

      

        
    }


}













