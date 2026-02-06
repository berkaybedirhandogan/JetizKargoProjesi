using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KargoTakibi.Models;

namespace KargoTakibi.Controllers
{
    [Authorize]
    public class HareketController : Controller
    {
        private readonly KargoTakipContext _context;

        public HareketController(KargoTakipContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> KargoHareketleri(int? id)
        {
            if (id == null) return NotFound();

            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            var kargo = await _context.Kargolar
                .Include(k => k.Hareketler)
                .FirstOrDefaultAsync(k => k.KargoID == id && k.KullaniciID == kullaniciId);

            if (kargo == null) return NotFound();

            return View(kargo);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Takip(string? id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "Home");

            var kargo = await _context.Kargolar
                .Include(k => k.Hareketler)
                .FirstOrDefaultAsync(k => k.TakipNo == id);

            if (kargo == null)
            {
                TempData["Error"] = "Kargo bulunamadı. Lütfen takip numarasını kontrol ediniz.";
                return RedirectToAction("Index", "Home");
            }

            return View("KargoHareketleri", kargo);
        }

        public async Task<IActionResult> YeniHareket(int? id)
        {
            if (id == null) return NotFound();

            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            var kargo = await _context.Kargolar
                .FirstOrDefaultAsync(k => k.KargoID == id && k.KullaniciID == kullaniciId);

            if (kargo == null) return NotFound();

            ViewBag.KargoID = id;
            var model = new Hareket { KargoID = id.Value, Tarih = DateTime.Now };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YeniHareket(Hareket hareket)
        {
            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            var kargo = await _context.Kargolar
                .FirstOrDefaultAsync(k => k.KargoID == hareket.KargoID && k.KullaniciID == kullaniciId);

            if (kargo == null) return NotFound();

            kargo.Durum = hareket.Durum;

            _context.Hareketler.Add(hareket);
            await _context.SaveChangesAsync();

            return RedirectToAction("KargoHareketleri", new { id = hareket.KargoID });
        }

        public async Task<IActionResult> HareketListesi()
        {
            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            var hareketler = await _context.Hareketler
                .Include(h => h.Kargo)
                .Where(h => h.Kargo != null && h.Kargo.KullaniciID == kullaniciId)
                .OrderByDescending(h => h.Tarih)
                .ToListAsync();

            return View(hareketler);
        }
    }
}
