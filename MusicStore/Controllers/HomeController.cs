using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();

        [HttpGet]
        public ActionResult Index()
        {
            List<Album> albums = db.Albums.ToList();
            ViewBag.firstImage = db.Albums.Select(x => x.AlbumArtUrl).FirstOrDefault();

            return View(albums);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<Album> albums;

            if(String.IsNullOrEmpty(searchTerm))
            {
                albums = db.Albums.ToList();
            } else
            {
                albums = db.Albums.Where(x => x.Title.StartsWith(searchTerm)).ToList();
            }
            
            return View(albums);
        }

        public JsonResult GetAlbumTitles(string term)
        {
            List<string> albums;

            albums = db.Albums
                .Where(x => x.Title.StartsWith(term))
                .Select(y => y.Title)
                .ToList();

            return Json(albums, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 1800)]
        public PartialViewResult Genres()
        {
            //System.Threading.Thread.Sleep(3000);
            List<Genre> genres = db.Genres.ToList();
            return PartialView("_Genres", genres);
        }
    }
}