using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private MusicStoreDB storeDB = new MusicStoreDB();

        public ActionResult Index()
        {
            List<Genre> genres = storeDB.Genres.ToList();

            return View(genres);
        }

        public ActionResult Browse(string genre)
        {
            if (genre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = storeDB.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }
    }
}