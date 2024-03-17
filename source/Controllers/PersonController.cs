using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab07_3.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        MVCLibraryEntities _context = new MVCLibraryEntities();
        public ActionResult Index(FormCollection searchdata)
        {
            var listofperson = _context.People.ToList();

            if (searchdata["RollNo"] != null)
                listofperson = listofperson.Where(x => x.RollNo.Contains(searchdata["RollNo"])).ToList();

            if (searchdata["Name"] != null)
                listofperson = listofperson.Where(x => x.Name.Contains(searchdata["Name"])).ToList();
            if (searchdata["Email"] != null)
                listofperson = listofperson.Where(x => x.Email.Contains(searchdata["Email"])).ToList();
            

            return View(listofperson);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            ViewBag.Message = "Data insert Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.People.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            var data = _context.People.Where(x => x.Id == person.Id).FirstOrDefault();
            if (data != null)
            {
                data.RollNo = person.RollNo;
                data.Name = person.Name;
                data.Email = person.Email;
                
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }


        public ActionResult Details(int id)
        {
            var data = _context.People.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }


        public ActionResult Delete(int id)
        {
            var data = _context.People.Where(x => x.Id == id).FirstOrDefault();
            _context.People.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("index");
        }
    }
}