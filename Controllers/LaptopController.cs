using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVC.Controllers
{
    public class LaptopController : Controller
    {
        // GET: LaptopController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult service()
        {
            return View();
        }

        // GET: LaptopController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LaptopController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaptopController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LaptopController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LaptopController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LaptopController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LaptopController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
