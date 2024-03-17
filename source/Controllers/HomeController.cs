using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab07_3.Controllers
{
    public class HomeController : Controller
    {
        MVCLibraryEntities _context = new MVCLibraryEntities();
        public ActionResult Index(FormCollection searchdata)
        {
            var listofbook = _context.Books.ToList();
            

            if (searchdata["BookCode"] != null)
                listofbook = listofbook.Where(x => x.Code.Contains(searchdata["BookCode"])).ToList();

            if (searchdata["BookTitle"] != null)
                listofbook = listofbook.Where(x => x.Title.Contains(searchdata["BookTitle"])).ToList();
            if (searchdata["BookAuthor"] != null)
                listofbook = listofbook.Where(x => x.Author.Contains(searchdata["BookAuthor"])).ToList();
            if (searchdata["Category"] != null)
                listofbook = listofbook.Where(x => x.Category.Name.Contains(searchdata["Category"])).ToList();
            return View(listofbook);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            ViewBag.Message = "Data insert Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            var data = _context.Books.Where(x => x.Id == book.Id).FirstOrDefault();
            if(data != null)
            {
                data.Code = book.Code;
                data.Title = book.Title;
                data.Author = book.Author;
                data.Importer_date = book.Importer_date;
                data.Category_id = book.Category_id;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        
        public ActionResult Details(int id)
        {
            var data = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        
        public ActionResult Delete(int id)
        {
            var data = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            _context.Books.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("index");
        }

        public ActionResult TieuThuyet()
        {
            var data = _context.Books.ToList();
            int i = 1;
            data = data.Where(x => x.Category_id == i).ToList();
            return View(data);
        }

        public ActionResult VanHoc()
        {
            var data = _context.Books.ToList();
            int i = 2;
            data = data.Where(x => x.Category_id == i).ToList();
            return View(data);
        }

        public ActionResult KhoaHoc()
        {
            var data = _context.Books.ToList();
            int i = 3;
            data = data.Where(x => x.Category_id == i).ToList();
            return View(data);
        }

        public ActionResult GiaoTrinh()
        {
            var data = _context.Books.ToList();
            int i = 4;
            data = data.Where(x => x.Category_id == i).ToList();
            return View(data);
        }

        public ActionResult ListOfBook()
        {
            var listofbook = _context.Books.ToList();
            return View(listofbook);
        }
    }
}