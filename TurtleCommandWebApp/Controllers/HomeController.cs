using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurtleCommandWebApp.Models;

namespace TurtleCommandWebApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TurtleCommand turtle, string Command)
        {
            const string TurtleSession = "TurtleSession";
            TurtleCommand myTurtle = new TurtleCommand();

            if (ModelState.IsValid)
            {
                Direction _direction = (Direction)Enum.Parse(typeof(Direction), turtle.Facing.ToString());

                myTurtle = (Session[TurtleSession] == null) ? new TurtleCommand() : (TurtleCommand)Session[TurtleSession];

                switch (Command)
                {
                    case "Place":
                        myTurtle.Place(turtle.X, turtle.Y, _direction);
                        break;

                    case "Move":
                        myTurtle.Move();
                        break;

                    case "Left":
                        myTurtle.Left();
                        break;

                    case "Right":
                        myTurtle.Right();
                        break;

                    case "Report":
                        string result = myTurtle.Report();

                        ViewBag.Result = result;
                        break;

                }

                Session[TurtleSession] = myTurtle;
            }

            var data = (TurtleCommand)Session[TurtleSession];
            return View(data);
        }

    }
}