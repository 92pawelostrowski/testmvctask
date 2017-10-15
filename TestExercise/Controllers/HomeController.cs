using DataStore;
using DataStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestExercise.Models;

namespace TestExercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StoreDataDb(Person person)
        {
            var storer = new Storer(new DataStoreDB());
            if (storer.FetchFormData<Person>(person))
            {
                ViewBag.Message = "Data saved in database";
            }
            else
            {
                ViewBag.Message = "Failed to save data in database";
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult StoreDataLog(Person person)
        {
            var storer = new Storer(new DataStoreLog());
            if (storer.FetchFormData<Person>(person))
            {
                ViewBag.Message = "Data saved in logs";
            }
            else
            {
                ViewBag.Message = "Failed to save data in logs";
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult StoreDataXML(Person person)
        {
            var storer = new Storer(new DataStoreXML());
            if (storer.FetchFormData<Person>(person))
            {
                ViewBag.Message = "Data stored to xml";
            }
            else
            {
                ViewBag.Message = "Failed to save data to xml";
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}