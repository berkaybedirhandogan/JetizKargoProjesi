using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KargoTakibi.Models;

namespace KargoTakibi.Controllers
{
    [Authorize]
    public class KargoController : Controller
    {
        private readonly KargoTakipContext _context;

        public KargoController(KargoTakipContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            var kargolar = await _context.Kargolar
                .Include(k => k.Hareketler)
                .Where(k => k.KullaniciID == kullaniciId)
                .OrderByDescending(k => k.KargoID)
                .ToListAsync();

            return View(kargolar);
        }

        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null) return NotFound();

            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            var kargo = await _context.Kargolar
                .Include(k => k.Hareketler)
                .FirstOrDefaultAsync(k => k.KargoID == id && k.KullaniciID == kullaniciId);

            if (kargo == null) return NotFound();

            return View(kargo);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                kargo.KullaniciID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
                kargo.Durum = "Kabul Edildi";
                kargo.TakipNo = "JTZ-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                
                _context.Kargolar.Add(kargo);
                await _context.SaveChangesAsync();
                
                var hareket = new Hareket
                {
                    KargoID = kargo.KargoID,
                    Tarih = DateTime.Now,
                    Durum = "Kabul Edildi"
                };
                
                _context.Hareketler.Add(hareket);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Detay", new { id = kargo.KargoID });
            }
            return View(kargo);
        }

        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null) return NotFound();

            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            var kargo = await _context.Kargolar
                .FirstOrDefaultAsync(k => k.KargoID == id && k.KullaniciID == kullaniciId);

            if (kargo == null) return NotFound();

            return View(kargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, Kargo kargo)
        {
            if (id != kargo.KargoID) return NotFound();

            var kullaniciId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value ?? "0");
            if (kargo.KullaniciID != kullaniciId) return Unauthorized();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KargoExists(kargo.KargoID)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kargo);
        }

        private bool KargoExists(int id)
        {
            return _context.Kargolar.Any(e => e.KargoID == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            var kullaniciIdClaim = User.Claims.FirstOrDefault(c => c.Type == "KullaniciID");
            if (kullaniciIdClaim == null) return RedirectToAction("Giris", "Hesap");

            int kullaniciId = int.Parse(kullaniciIdClaim.Value);

            var kargo = await _context.Kargolar
                .Include(k => k.Hareketler)
                .FirstOrDefaultAsync(k => k.KargoID == id && k.KullaniciID == kullaniciId);

            if (kargo == null) return NotFound();

            try
            {
                if (kargo.Hareketler != null && kargo.Hareketler.Any())
                {
                    _context.Hareketler.RemoveRange(kargo.Hareketler);
                }

                _context.Kargolar.Remove(kargo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
