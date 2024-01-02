using MVS_Prg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Sockets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MVS_Prg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public async Task<IActionResult> Index(int? minPassQuont, int? maxPassQuont, int page = 1, SortState sortOrder = SortState.PassQuontAsc)
        {
            int pageSize = 5;

            IQueryable<Plane> source = db.Planes.Include(x => x.Airline);


            if (minPassQuont.HasValue)
            {
                source = source.Where(s => s.Max_Plane_Quont >= minPassQuont.Value);
            }

            if (maxPassQuont.HasValue)
            {
                source = source.Where(s => s.Max_Plane_Quont <= maxPassQuont.Value);
            }

            var count = await source.CountAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewData["AirlineSort"] = sortOrder == SortState.AirlineAsc ? SortState.AirlineDesc : SortState.AirlineAsc;
            ViewData["PassQuontSort"] = sortOrder == SortState.PassQuontAsc ? SortState.PassQupntDesc : SortState.PassQuontAsc;

            source = sortOrder switch
            {
                SortState.PassQupntDesc => source.OrderByDescending(s => s.Max_Plane_Quont),
                SortState.AirlineAsc => source.OrderBy(s => s.Airline_id),
                SortState.AirlineDesc => source.OrderByDescending(s => s.Airline_id),
                _ => source.OrderBy(s => s.Max_Plane_Quont),
            };

            var items1 = await source.ToListAsync();

            var items = items1.Skip((page - 1) * pageSize).Take(pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
            return View(viewModel);
        }
        public IActionResult CreatePlane()
        {
            var airIds = db.Airlines.Select(z => z.Airline_id).ToList();
            ViewBag.AirIds = new SelectList(airIds);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlane(Plane plane)
        {
            
                db.Planes.Add(plane);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            

            return View(plane);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePlane(int? id)
        {
            if (id != null)
            {
                Plane? plane = await db.Planes.FirstOrDefaultAsync(p => p.PlaneId == id);
                if (plane != null)
                {
                    db.Planes.Remove(plane);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditPlane(int? id)
        {
            if (id != null)
            {
                Plane? plane = await db.Planes.FirstOrDefaultAsync(p => p.PlaneId == id);
                var airIds = db.Airlines.Select(z => z.Airline_id).ToList();
                ViewBag.AirIds = new SelectList(airIds);
                if (plane != null) return View(plane);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditPlane(Plane plane, int selectedPlane)
        {
            
                db.Planes.Update(plane);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            

           
        }

        public IActionResult CreateAirline()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAirline(Airline airline)
        {
            db.Airlines.Add(airline);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAirline(int? id)
        {
            if (id != null)
            {
                Airline? airline = await db.Airlines.FirstOrDefaultAsync(a => a.Airline_id == id);
                if (airline != null)
                {
                    db.Airlines.Remove(airline);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditAirline(int? id)
        {
            if (id != null)
            {
                Airline? airline = await db.Airlines.FirstOrDefaultAsync(a => a.Airline_id == id);
                if (airline != null) return View(airline);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditAirline(Airline airline)
        {
            db.Airlines.Update(airline);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}