using Microsoft.AspNetCore.Mvc;
using KargoTakibi.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace KargoTakibi.Controllers
{
    public class HomeController : Controller
    {
        private readonly KargoTakipContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, KargoTakipContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
               var kullaniciIdClaim = User.Claims.FirstOrDefault(c => c.Type == "KullaniciID");
               if (kullaniciIdClaim != null) {
                   int uid = int.Parse(kullaniciIdClaim.Value);
                   
                   var activeCargos = await _context.Kargolar
                       .Where(k => k.KullaniciID == uid && k.Durum != "Teslim Edildi")
                       .OrderByDescending(k => k.KargoID)
                       .Take(5)
                       .ToListAsync();
                   
                   ViewBag.ActiveCargos = activeCargos;
                   ViewBag.TotalCount = await _context.Kargolar.CountAsync(k => k.KullaniciID == uid);
                   ViewBag.ActiveCount = await _context.Kargolar.CountAsync(k => k.KullaniciID == uid && k.Durum != "Teslim Edildi");
                   ViewBag.DeliveredCount = await _context.Kargolar.CountAsync(k => k.KullaniciID == uid && k.Durum == "Teslim Edildi");
               }
            }
            return View();
        }

        public IActionResult Hakkimizda() => View();
        public IActionResult Hizmetler() => View();
        public IActionResult Fiyatlar() => View();
        public IActionResult Kariyer() => View();
        public IActionResult Yardim() => View();
        public IActionResult Iletisim() => View();
        public IActionResult Yasal() => View();
        public IActionResult Gizlilik() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
