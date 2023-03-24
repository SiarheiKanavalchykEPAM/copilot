using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace bookDestributedLibrary3.Web.Controllers
{
    [Authorize]
    public class SearchBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}