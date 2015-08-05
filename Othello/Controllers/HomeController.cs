﻿using System.Web.Mvc;
using Othello.Models;

namespace Othello.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewGame()
        {
            var boardModel = new BoardModel();
            return View(boardModel);
        }

    }
}