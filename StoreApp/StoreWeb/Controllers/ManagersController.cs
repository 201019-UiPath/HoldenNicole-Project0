using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreWeb.Data;
using StoreWeb2.Models;

namespace StoreWeb.Controllers
{
    public class ManagersController : Controller
    {
        private readonly EmpDBContext _context;

        public ManagersController(EmpDBContext context)
        {
            _context = context;
        }

        // GET: Managers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manager.ToListAsync());
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .FirstOrDefaultAsync(m => m.ID == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }
        private bool ManagerExists(int id)
        {
            return _context.Manager.Any(e => e.ID == id);
        }
    }
}
