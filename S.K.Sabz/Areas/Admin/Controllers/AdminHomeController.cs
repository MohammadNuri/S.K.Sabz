﻿using Microsoft.AspNetCore.Mvc;

namespace S.K.Sabz.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
