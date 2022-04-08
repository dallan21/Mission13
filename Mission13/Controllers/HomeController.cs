using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using Mission13.Models.ViewModel;


namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlerRepository _repo { get; set; }

        private ITeamRepository _repo2 { get; set; }

        public HomeController(IBowlerRepository temp, ITeamRepository temp2)
        {
            _repo = temp;
            _repo2 = temp2;
        }

        public IActionResult Index(int? team)
        {
            ViewBag.SelectedTeam = RouteData?.Values["team"];
            var x = new BowlerViewModel
            {
                
                Bowlerss = _repo.Bowlers
                    .Where(b => b.TeamId == team || team == null)
                    .OrderBy(b => b.BowlerId)
                    
            };

            ViewBag.Teams = _repo2.Teams.ToList();
            
                return View(x);

            //}
 
           
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _repo2.Teams.ToList();
            ViewBag.Bowlers = _repo.Bowlers.ToList();

            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.AddBowler(b);
                _repo.SaveBowler(b);
                
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Bowlers = _repo.Bowlers.ToList();
                return View("AddBowlerForm", b);

            }


        }


        [HttpGet]
        public IActionResult Edit(int id)

        {
            ViewBag.Teams = _repo2.Teams.ToList();
            ViewBag.Bowlers = _repo.Bowlers.ToList();

            var bowl = _repo.Bowlers.Single(b => b.BowlerId == id);

            return View("AddBowlerForm", bowl);
        }
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.EditBowler(b);
            _repo.SaveBowler(b);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowl = _repo.Bowlers.Single(b => b.BowlerId == id);
            return View(bowl);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {

            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }


    }
}
