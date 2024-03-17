using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab07_3.Controllers
{
    public class BorrowController : Controller
    {
        MVCLibraryEntities _context = new MVCLibraryEntities();
        public ActionResult Index(FormCollection searchdata)
        {
            
            var listofborrow = _context.Borrows.ToList();

            if (searchdata["PersonRollNo"] != null)
                listofborrow = listofborrow.Where(x => x.Person.RollNo.Contains(searchdata["PersonRollNo"])).ToList();

            

            return View(listofborrow);
        }

        public ActionResult Index2()
        {
            var listofbook = _context.Books.ToList();
            ViewData["Books"] = listofbook;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var listofbook = _context.Books.ToList();
            ViewBag.books = listofbook;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Borrow borrow)
        {
            _context.Borrows.Add(borrow);
            _context.SaveChanges();
            ViewBag.Message = "Data insert Successfully";
            // ViewData["Books"] = _context.Books.ToList();
            return View();
        }
        public ActionResult Create2()
        {
            var listofbook = _context.Books.ToList();
            ViewData["Books"] = listofbook;
            var listofperson = _context.People.ToList();
            ViewBag.person = listofperson;
            // ViewData["People"] = listofbook;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Borrows.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Borrow borrow)
        {
            var data = _context.Borrows.Where(x => x.Id == borrow.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = borrow.Id;
                data.Borrow_date = borrow.Borrow_date;
                data.Expire_date = borrow.Expire_date;
                data.Person_id = borrow.Person_id;
                data.Person = data.Person;
                data.Books = data.Books;
                

                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }


        public ActionResult Details(int id)
        {
            var data = _context.Borrows.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }


        public ActionResult Delete(int id)
        {
            var data = _context.Borrows.Where(x => x.Id == id).FirstOrDefault();
            
            _context.Borrows.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("index");
        }
    }
}