using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pig.Models;

namespace Pig.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        var session = new GameSession(HttpContext.Session); // either create new session or pass in current session ID
        var game = session.GetGame();

        return View(game);
    }

}

