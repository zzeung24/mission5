using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private WebApplicationContext _movieContext { get; set; }

        //Constructor
        public HomeController(WebApplicationContext someName)
        {
            _movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Movie(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(ar);
                _movieContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else //If Invalid
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View();
            }
        }

        [HttpGet]
        public IActionResult AllMoviesCollection()
        {
            var applications = _movieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var application = _movieContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View("Movie", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            _movieContext.Update(blah);
            _movieContext.SaveChanges();

            return RedirectToAction("AllMoviesCollection");
        }

        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = _movieContext.Responses.Single(x => x.ApplicationId == applicationid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            _movieContext.Responses.Remove(ar);
            _movieContext.SaveChanges();
            return RedirectToAction("AllMoviesCollection");
        }
    }
}
