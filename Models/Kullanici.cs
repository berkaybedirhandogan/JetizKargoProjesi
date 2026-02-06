using System.ComponentModel.DataAnnotations;

namespace KargoTakibi.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }

        [Required(ErrorMessage = "Ad Soyad alanı zorunludur")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Ad Soyad en az 3 karakter olmalıdır")]
        [Display(Name = "Ad Soyad")]
        public string? AdSoyad { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email formatı geçersiz")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalıdır")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&.])[A-Za-z\d@$!%*?&.]{8,}$", 
            ErrorMessage = "Şifre en az 8 karakter olmalı; harf, rakam ve özel karakter (@$!%*?&.) içermelidir")]
        public string? Sifre { get; set; }

        public virtual ICollection<Kargo>? Kargolar { get; set; }
    }
}
