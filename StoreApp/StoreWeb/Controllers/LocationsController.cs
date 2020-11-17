using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreWeb.Data;
using StoreWeb2.Models;

namespace StoreWeb.Controllers
{
    public class LocationsController : Controller
    {
        private readonly EmpDBContext _context;

        public LocationsController(EmpDBContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Location.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .FirstOrDefaultAsync(m => m.ID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }
        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.ID == id);
        }
    }
}