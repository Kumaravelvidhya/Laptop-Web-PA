using ClassLibrary.Models;
using ClassLibrary.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class cricketersController : Controller
    {
        // GET: cricketersController
          public CricketersRepository objcricketers;
           public CountryRepository objcountry;
        public cricketersController()
        {
            objcricketers = new CricketersRepository();
            objcountry = new CountryRepository();
        }
        public ActionResult List()
        {
            return View("List", objcricketers.select());
        }

        // GET: cricketersController/Details/5
        public ActionResult Details(int cricketersId)
        {
            try
            {
                var res = objcricketers.selectwithid(cricketersId);
                return View("Details", res);
            }
            catch(Exception ex)
            {
                return View("Error");


            }


        }

        // GET: cricketersController/Create
        public ActionResult Create(string Name)
        {
            var model = new CricketersModels();
            model.CountryName = objcountry.Getcountryname();
            return View("Create",model);
            
        }

        // POST: cricketersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CricketersModels data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (objcricketers.IsExists(data.Name))
                    {
                        ModelState.AddModelError("Name", "Name Already exists");
                        data.CountryName = objcountry.Getcountryname();
                        return View("Create", data);
                    }

                    objcricketers.Insertcricketers(data);
                    return RedirectToAction(nameof(List));
                }

                else
                {
                    data.CountryName = objcountry.Getcountryname();
                    return View("Create",data);
                }
                //objcricketers.Insertcricketers(data);
                // return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: cricketersController/Edit/5
        public ActionResult Edit(int cricketersId)
        {
            try
            {
                var result = objcricketers.selectwithid(cricketersId);
                result.CountryName = objcountry.Getcountryname();
                return View("Edit", result);

            }
            catch(Exception ex)
            {
                return View("Error");

            }



        }

        // POST: cricketersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Edit(int cricketersId, CricketersModels collect)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (objcricketers.ValidUpdate(collect.Name, collect.cricketersId))
                    {
                        ModelState.AddModelError("Name", "Name Already exists");
                        collect.CountryName = objcountry.Getcountryname();
                        return View("Create", collect);

                    }  
                }
                    else
                    
                    collect.cricketersId = cricketersId;
                    objcricketers.Update(collect);
                    return RedirectToAction(nameof(List));

                  
               

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: cricketersController/Delete/5
        public ActionResult Delete(int cricketersId)
        {
            
            var res = objcricketers.selectwithid(cricketersId);
            /*return RedirectToAction(nameof(List));*/
            return View("Delete", res);
        }

        // POST: cricketersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int cricketersId)
        {
            try
            {

                objcricketers.Delete(cricketersId);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
