using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bookDestributedLibrary3.Web.Controllers
{
    public class SearchBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}