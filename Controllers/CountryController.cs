using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using WorldDatabase.Models;

namespace WorldDatabase.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet("/countries")]
        public ActionResult Index()
        {
            List<Country> allCountries = Country.GetAll();
            return View(allCountries);
        }
    }
}