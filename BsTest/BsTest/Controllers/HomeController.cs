using BsTest.Models;
using BsTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Service albumsService = new Service();
                return View(albumsService.GetAlbumList());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public PartialViewResult Detail(int id)
        {
            try
            {
                Service photoService = new Service();
                IEnumerable<Photo> photos = photoService.GetPhotos();

                var photosById = photos.Where(p => p.AlbumId == id).ToList();

                return PartialView("_AlbumDetail", photosById);
            }
            catch
            {
                throw;
            }
        }

        public PartialViewResult Comments(int id)
        {
            try
            {
                Service commentsService = new Service();
                IEnumerable<Comment> comments = commentsService.GetComments();

                var commentsByPhoto = comments.Where(p => p.PostId == id).ToList();

                return PartialView("_Comments", commentsByPhoto);
            }
            catch
            {

                throw;
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}