using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonsController : Controller
    {

        private readonly ApplicationDbMemory _db;

        public PersonsController(ApplicationDbMemory db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}