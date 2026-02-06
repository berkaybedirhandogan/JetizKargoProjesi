using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KargoTakibi.Models;

namespace KargoTakibi.Controllers
{
    public class TakipController : Controller
    {
        private readonly KargoTakipContext _context;

        public TakipController(KargoTakipContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Sorgula(string takipNo)
        {
            if (string.IsNullOrWhiteSpace(takipNo))
            {
                ViewBag.Hata = "Lütfen bir takip numarası girin.";
                return View("Sonuc");
            }

            takipNo = takipNo.Trim().ToUpperInvariant();

            var kargo = await _context.Kargolar
                .Include(k => k.Hareketler)
                .FirstOrDefaultAsync(k => k.TakipNo == takipNo);

            if (kargo == null)
            {
                ViewBag.Hata = "Bu takip numarasına ait kayıt bulunamadı.";
                ViewBag.ArananNo = takipNo;
                return View("Sonuc");
            }

            return View("Sonuc", kargo);
        }
    }
}
