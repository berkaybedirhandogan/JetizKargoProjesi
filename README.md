# Jetiz Kargo Takip Sistemi

## Proje Adı

**Jetiz Kargo Takip Sistemi** - Modern, dinamik ve kullanıcı dostu bir lojistik yönetim platformu. Jetiz, taşımacılık süreçlerini dijitalleştirerek hem gönderici hem de alıcı için şeffaf, hızlı ve güvenilir bir deneyim sunar.

## Proje Amacı

Bu proje, kargo gönderi ve takip işlemlerini dijital ortamda uçtan uca yönetmek için geliştirilmiş kapsamlı bir kurumsal web uygulamasıdır. Geleneksel kargo takip sistemlerinin hantal ve karmaşık arayüzlerinin aksine, modern "Glassmorphism" ve "Dark Mode" yaklaşımlarıyla kullanıcı deneyimini (UX) en üst seviyeye çıkarmayı hedefler.

Projenin temel amaçları:

- **Sistematik Kayıt:** Tüm kargo gönderilerinin hatasız ve detaylı bir şekilde veritabanına kaydedilmesi.
- **Anlık Takip:** Gönderi durumlarının (Kabul, Hazırlık, Yolda vb.) anlık olarak güncellenmesi ve paydaşlara sunulması.
- **Görselleştirilmiş Lojistik:** Harita entegrasyonu ile kargonun sadece metin olarak değil, coğrafi olarak da izlenebilmesi.
- **Erişilebilirlik:** QR kod teknolojisi ile takip bilgilerine mobil cihazlardan tek tıkla ulaşım.
- **Veri Güvenliği:** Rol bazlı yetkilendirme ve modern kimlik doğrulama yöntemleriyle kullanıcı verilerinin korunması.
- **Raporlama ve Analiz:** Hareket geçmişi sayesinde geçmişe dönük operasyonel verilerin izlenebilirliği.

Sistem, ölçeklenebilir yapısı sayesinde hem bireysel paket gönderimlerini hem de büyük ölçekli işletmelerin lojistik ağlarını yönetebilecek esnekliktedir.

## Hedef Kullanıcı Kitlesi

Bu uygulama, lojistik ekosistemindeki farklı ihtiyaçlara sahip şu kullanıcı grupları için optimize edilmiştir:

**1. Bireysel Kullanıcılar:**
- Kişisel paketlerini güvenle göndermek ve sevdiklerine ulaştırmak isteyen kişiler.
- Online alışveriş yapan ve paketinin tam olarak nerede olduğunu harita üzerinden görmek isteyen müşteriler.
- Kargo şubesine gitmeden paketinin durumunu merak eden ev kullanıcıları.

**2. İşletmeler ve E-ticaret:**
- Günlük yüzlerce gönderi yapan küçük ve orta ölçekli (KOBİ) e-ticaret siteleri.
- Butik satış yapan sosyal medya satıcıları.
- Müşterilerine profesyonel bir takip arayüzü sunmak isteyen butik markalar.
- Depo ve stok çıkışlarını kargo sistemiyle entegre etmek isteyen mağaza sahipleri.

**3. Kurumsal ve Lojistik Firmalar:**
- Kendi dağıtım ağını kuran yerel kurye şirketleri.
- Saha operasyonlarını dijitalden yönetmek isteyen lojistik koordinatörleri.
- Personel performansını ve teslimat sürelerini optimize etmek isteyen operasyon yöneticileri.

## Senaryo / Kullanım Amacı

### Temel Kullanım Senaryoları

#### Senaryo A: Yeni Bir Gönderi Oluşturma
Sisteme giriş yapan bir operasyon görevlisi, "Yeni Kargo" ekranına geçer. Göndericinin telefon numarasını girdiğinde bilgiler otomatik gelmese de hızlıca doldurur. Alıcının adres bilgilerini Türkiye'nin dinamik il/ilçe veritabanından seçer. Sistem otomatik olarak mesafe hesaplaması yapar ve unik bir **JTZ** takip kodu üretir.

#### Senaryo B: Müşteri Tarafından Takip
Müşteri kendisine gelen takip numarasını veya QR kodu kullanarak sisteme giriş yapmadan (veya yaparak) kargosunu sorgular. Harita üzerinde kargonun gönderici şehrinden alıcı şehrine çizilen rotayı görür. "Yolda" durumunu gördüğünde paketinin hareket halinde olduğunu anlar.

#### Senaryo C: Görevli Tarafından Durum Güncelleme
Kargo bir aktarma merkezine ulaştığında, oradaki görevli kargo numarasını bulur ve "Yeni Hareket" ekleyerek durumu "Aktarma Merkezinde" olarak günceller. Bu işlem anında tüm sistemde ve harita üzerinde görünür hale gelir.

### Örnek Öyküsel Senaryo

Bir e-ticaret mağazası sahibi olan Ahmet Bey, İstanbul'dan Erzurum'daki müşterisi Ayşe Hanım'a bir kitap gönderir. Ahmet Bey kargoyu sisteme işlediğinde sistem **JTZ-A1B2C3D4** numarasını verir. 
1. **09:00:** Kargo "Kabul Edildi" olarak sisteme girer.
2. **14:00:** Ahmet Bey kargoyu kuryeye verir, durum "Yolda" olarak güncellenir.
3. **Ertesi Gün:** Ayşe Hanım, kendisine WhatsApp üzerinden iletilen QR kodu okutur. Harita üzerinde kargonun Ankara civarında olduğunu görür.
4. **Teslimat:** Kurye paketi teslim ettiğinde tabletinden "Teslim Edildi" işaretlemesini yapar ve süreç başarıyla tamamlanır.

## Kullanılan Teknolojiler ve Teknik Detaylar

Uygulama, modern yazılım prensiplerine uygun olarak "Single Responsibility" ve "Clean Code" yaklaşımlarıyla geliştirilmiştir.

### Backend Teknolojileri (Sunucu Tarafı)

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| **C#** | 10.0 | Tip güvenliği ve performans için kullanılan ana dil. |
| **ASP.NET Core** | 6.0 | Cross-platform ve yüksek performanslı web framework. |
| **MVC** | - | Model-View-Controller mimari deseni ile kod ayrımı. |
| **EF Core** | 6.0 | Veritabanı işlemleri için kullanılan nesne-ilişkisel eşleme (ORM). |
| **SQLite** | - | Gömülü, dosya tabanlı ve hızlı ilişkisel veritabanı. |
| **Auth** | Cookies | Cookie-based Authentication ile güvenli oturum yönetimi. |

### Frontend Teknolojileri (Arayüz Tarafı)

| Teknoloji | Kullanım Amacı |
|-----------|----------------|
| **HTML5 & CSS3** | Semantik yapı ve gelişmiş stil özellikleri. |
| **JavaScript** | Sayfa içi dinamik etkileşimler ve API çağrıları. |
| **jQuery** | DOM manipülasyonu ve AJAX tabanlı il/ilçe yükleme işlemleri. |
| **Leaflet.js** | OpenStreetMap tabanlı interaktif harita yönetimi. |
| **Leaflet-AntPath** | Harita üzerinde animasyonlu (akışkan) rota çizimi. |
| **Bootstrap Icons** | Modern, hafif ve vektörel ikon seti. |
| **Google Fonts** | 'Outfit' ve 'Inter' fontları ile premium tipografi. |

### Mimari ve Tasarım Yaklaşımı

- **MVC (Model-View-Controller):** İş mantığı, veri yapısı ve sunum katmanları birbirinden tamamen izole edilmiştir.
- **Glassmorphism UI:** Buzlu cam efekti, yumuşak geçişler ve blur efektleri ile modern bir tasarım dili oluşturulmuştur.
- **Responsive Layout:** CSS Grid ve Flexbox kullanılarak; telefon, tablet ve masaüstü tüm ekranlarla %100 uyum sağlanmıştır.
- **Repository Pattern (Benzeri):** Veri erişim işlemleri DbContext üzerinden merkezi olarak yönetilir.

## Detaylı Özellik Listesi

### 1. Kullanıcı ve Güvenlik Yönetimi
- **Gelişmiş Kayıt Sistemi:** Kullanıcıların isim, e-posta ve şifre ile sisteme dahil olması.
- **Modern Login:** Şeffaf (Glass) tasarımlı, hata geri bildirimli giriş ekranı.
- **Profil Paneli:** Kullanıcıların bilgilerini güncelleyebileceği ve şifrelerini değiştirebileceği özel sayfa.
- **Güvenli Şifreleme:** Veritabanında şifre güvenliği ve validasyon kontrolleri.
- **Şifre Güç Göstergesi:** Şifre belirlenirken gerçek zamanlı (Zayıf, Orta, Güçlü) analiz.
- **Visibility Toggle:** Şifre giriş alanlarında göz ikonu ile göster/gizle fonksiyonu.

### 2. Kargo Operasyon Yönetimi (CRUD)
- **Yeni Gönderi Oluşturma:** Detaylı gönderici/alıcı bilgileri girişi.
- **Dinamik Adresleme:** İl seçildiğinde ilgili ilçelerin AJAX ile anlık yüklenmesi (Türkiye veri seti).
- **Otomatik Takip No:** Karmaşık algoritma ile çakışmayan JTZ formatlı kodlar.
- **Kargo Listeleme:** Tüm kargoların tablo görünümünde, durum renklerine göre ayrıştırılması.
- **Düzenleme Modülü:** Hatalı girilen adres veya telefon bilgilerinin revize edilmesi.
- **Kargo Silme:** İptal edilen gönderilerin sistemden temizlenmesi.

### 3. İzleme ve Harita Özellikleri
- **Canlı Takip Sayfası:** Kargonun tüm yolculuğunun görsel özeti.
- **İnteraktif Harita:** Başlangıç ve bitiş noktalarının koordinat bazlı işaretlenmesi.
- **Rota Animasyonu:** İki nokta arasında çizilen dinamik ve hareketli yol çizgisi.
- **Mesafe Hesaplama:** Haversine formülü veya harita servisleri ile tahmini KM hesaplama.
- **QR Kod Üretimi:** Her kargo detay sayfasında o kargoya özel dinamik QR kod görseli.

### 4. Hareket Ve Log Sistemi
- **Durum Geçmişi:** Kargonun hangi tarihte, hangi saatte hangi aşamada olduğunun listesi.
- **Operasyonel Güncelleme:** Kargoya yeni durum (Yolda, Dağıtımda vb.) ekleme yetkisi.
- **Zaman Damgası:** Her hareketin sistem saatiyle milisaniyelik kaydedilmesi.

### 5. Dashboard (Genel Bakış)
- **İstatistik Kartları:** Toplam kargo, Bekleyen, Yolda ve Teslim Edilen sayıları.
- **Hızlı Erişim:** En çok kullanılan fonksiyonlara (Kargo Ekle, Takip Et) kısayol butonları.
- **Son Hareketler:** Sistem genelindeki son güncellemelerin minyatür listesi.

## Veritabanı Modelleri (Entity Yapısı)

### Kullanici Modeli
- `KullaniciID` (PK)
- `AdSoyad` (string)
- `Email` (string)
- `Sifre` (string)

### Kargo Modeli
- `KargoID` (PK)
- `TakipNo` (unique string)
- `GondericiAd`, `GondericiTel`, `GondericiAdres`, `GondericiIl`, `GondericiIlce`
- `AliciAd`, `AliciTel`, `AliciAdres`, `AliciIl`, `AliciIlce`
- `OlusturmaTarihi` (DateTime)
- `KullaniciID` (FK)

### Hareket Modeli
- `HareketID` (PK)
- `KargoID` (FK)
- `Durum` (enum/string: Kabul Edildi, Yolda vb.)
- `Aciklama` (string)
- `Tarih` (DateTime)

## Proje Dizin Yapısı ve Dosya Görevleri

```text
KargoProjesi/
│
├── Controllers/                    # İstekleri karşılayan ve işleyen sınıflar
│   ├── HomeController.cs           # Dashboard ve temel bilgilendirme sayfaları
│   ├── KargoController.cs          # Kargo kayıt, liste, silme, güncelleme işlemleri
│   ├── HareketController.cs        # Takip detayları ve hareket ekleme mantığı
│   └── HesapController.cs          # Register, Login ve Profil güncelleme kodları
│
├── Models/                         # Veri yapıları ve Veritabanı bağlamı
│   ├── Kargo.cs                    # Kargo bilgilerini tutan sınıf
│   ├── Hareket.cs                  # Durum geçmişini tutan sınıf
│   ├── Kullanici.cs                # Üyelik verilerini tutan sınıf
│   ├── ErrorViewModel.cs           # Hata yönetimi için yardımcı model
│   └── KargoTakipContext.cs        # Entity Framework veritabanı bağlantı ayarları
│
├── Views/                          # Kullanıcı arayüzü (Razor HTML)
│   ├── Home/                       # Dashboard, Hakkımızda, İletişim, Vizyon Sayfaları
│   │   ├── Index.cshtml            # Kullanıcı Paneli (Dashboard)
│   │   ├── Hakkimizda.cshtml       # Kurumsal Hakkımızda
│   │   ├── Hizmetler.cshtml        # Hizmet Detayları
│   │   ├── Kariyer.cshtml          # İş Başvuru Sayfası
│   │   ├── Yardim.cshtml           # SSS ve Yardım Merkezi
│   │   ├── Iletisim.cshtml         # İletişim Formu ve Bilgileri
│   │   └── Gizlilik.cshtml         # Veri Güvenliği Politikası
│   ├── Kargo/                      # Kargo Operasyon Sayfaları
│   │   ├── Index.cshtml            # Tüm Kargoların Tablosu
│   │   ├── Ekle.cshtml             # Yeni Kargo Giriş Formu
│   │   ├── Duzenle.cshtml          # Bilgi Güncelleme Ekranı
│   │   └── Detay.cshtml            # Kargo Özet Bilgileri
│   ├── Hareket/                    # Takip ve Lojistik Sayfaları
│   │   ├── HareketListesi.cshtml   # Genel Durum Logları
│   │   ├── KargoHareketleri.cshtml # HARİTALI TAKİP SAYFASI
│   │   └── YeniHareket.cshtml      # Durum Değiştirme Formu
│   ├── Hesap/                      # Hesap Yönetim Sayfaları
│   │   ├── Giris.cshtml            # Login Ekranı
│   │   ├── Kayit.cshtml            # Üye Olma Ekranı
│   │   └── Profil.cshtml           # Şifre ve Bilgi Güncelleme
│   └── Shared/                     # Ortak Temalar
│       ├── _Layout.cshtml          # Ana Şablon (Menu + Footer)
│       └── Error.cshtml            # 404/500 Hata Sayfaları
│
├── wwwroot/                        # Statik Dosyalar (Public)
│   ├── css/                        # Stil Dosyaları
│   │   ├── site.css                # Genel Tasarım ve Glassmorphism
│   │   └── animations.css          # Geçiş ve Yükleme Animasyonları
│   ├── js/                         # Scriptler
│   │   ├── site.js                 # Genel Fonksiyonlar
│   │   ├── turkey_data.js          # İl/İlçe Veri Seti (JSON)
│   │   └── map_logic.js            # Harita ve Rota Hesaplamaları
│   ├── img/                        # Görsel Materyaller
│   │   └── logo.ico                # Favicon ve Logolar
│   └── lib/                        # Bootstrap, jQuery, Leaflet Kütüphaneleri
│
├── Migrations/                     # Entity Framework şema güncellemeleri
├── Properties/                     # Proje meta verileri ve launch settings
├── Program.cs                      # Uygulama ayağa kalkma konfigürasyonu
├── appsettings.json                # Veritabanı bağlantı cümlesi (Connection String)
└── README.md                       # Bu dokümantasyon dosyası
```

## Kurulum ve Çalıştırma Rehberi

### Gereksinimler

- **.NET 6.0 SDK:** Uygulamayı derlemek ve çalıştırmak için gereklidir.
- **SQLite:** Veritabanı olarak kullanılır (Proje içinde otomatik oluşur).
- **IDE:** Visual Studio 2022 veya VS Code önerilir.
- **Tarayıcı:** Modern bir tarayıcı (Chrome, Edge, Firefox).

### Kurulum Adımları

1. **Projeyi Klonlayın:**
   ```bash
   git clone https://github.com/berkaybedirhandogan/KargoProjesi.git
   cd KargoProjesi
   ```

2. **Bağımlılıkları Geri Yükleyin:**
   NuGet paketlerini indirmek için terminale şunu yazın:
   ```bash
   dotnet restore
   ```

3. **Veritabanı Şemasını Oluşturun:**
   Migration'ları SQLite dosyasına aktarmak için:
   ```bash
   dotnet ef database update
   ```
   *(Not: Eğer dotnet-ef aracı yüklü değilse `dotnet tool install --global dotnet-ef` komutunu kullanın.)*

4. **Uygulamayı Çalıştırın:**
   ```bash
   dotnet run
   ```

5. **Arayüze Erişin:**
   Tarayıcınızı açın ve aşağıdaki adrese gidin:
   ```
   http://localhost:5000
   ```

## Sayfa Detayları ve Fonksiyonel Açıklamalar

### Giriş Sayfası (Login)
Modern bir arka plan üzerine oturtulmuş, cam efektli (glass) giriş kutusu. Kullanıcı e-posta ve şifresini yazarak sisteme giriş yapar. Şifre alanı için "Göz İkonu" ile gizlilik kontrolü mevcuttur. Yanlış girişte kullanıcıya kırmızı uyarı rozetleri gösterilir.

### Ana Sayfa (Dashboard / Kontrol Paneli)
Giriş yapan kullanıcıyı karşılayan özet ekranıdır. 
- **Sol Taraf:** "Hoş geldiniz [İsim]" karşılaması ve hızlı işlemler.
- **Üst Kısım:** Canlı sayaçlar (Teslim edilenler, yoldaki kargolar).
- **Alt Kısım:** Son eklenen kargoların hızlı listesi ve durumları.

### Kargo Yönetim Sayfaları
- **Kargo Listesi:** Tüm verilerin filtrelenebilir bir tabloda gösterilmesi. Durum kolonundaki rozetler (Badge) kargonun durumuna göre renk değiştirir (Yeşil: Teslim Edildi, Kırmızı: İptal, Mavi: Yolda).
- **Yeni Kargo:** İki sütunlu form yapısı. Sol tarafta gönderici, sağ tarafta alıcı bilgileri yer alır. İl seçimi yapıldığında ilçe listesi anlık olarak değişir.

### Canlı Harita Takibi (Nerve Center)
Projenin en prestijli sayfasıdır.
- **Harita:** Leaflet.js altyapısı ile dünya haritası üzerinde Türkiye odaklı görünüm.
- **Rota:** Gönderici adresi ile alıcı adresi arasına çekilen dinamik, animasyonlu rota çizgisi.
- **Bilgi Kartı:** Haritanın üzerinde asılı duran cam panelde kargonun o anki konumu, hızı (varsayımsal) ve kalan mesafe bilgisi yer alır.
- **QR Paylaşım:** "Bu kargoyu paylaş" butonu ile çıkan QR kod, mobil cihazlarla taratılabilir.

### Durum Güncelleme (Terminal)
Kargonun tarihsel gelişimini değiştirmek için kullanılır. "Kargo Hareketlerine Git" butonu ile açılan ekranda, yetkili kullanıcı yeni bir durum seçebilir ve açıklama yazabilir. Her bir durum değişikliği "Workflow" mantığıyla veritabanına işlenir.

## Proje Yol Haritası (Gelecek Özellikler)

- [ ] **E-posta Bildirimi:** Kargo durumu değiştiğinde alıcıya otomatik mail gitmesi.
- [ ] **SMS Entegrasyonu:** Teslimat anında doğrulama kodu (OTP) gönderimi.
- [ ] **Mobil Uygulama:** Flutter veya React Native ile kurye takip uygulaması.
- [ ] **Gelişmiş Raporlama:** PDF ve Excel formatında haftalık teslimat raporları.
- [ ] **AI Tahminleme:** Geçmiş verilere dayanarak kargonun ne zaman ulaşacağını tahmin eden yapay zeka modeli.

## Yazılım Standartları ve Optimizasyon

- **SEO Dostu:** Tüm sayfalarda uygun meta etiketleri ve semantik HTML başlıkları (`h1`, `h2`) kullanılmıştır.
- **Performans:** Resimler WebP formatında, scriptler ise sayfa sonunda (deferred) yüklenmektedir.
- **Güvenlik:** XSS ve CSRF saldırılarına karşı ASP.NET Core'un yerleşik koruma mekanizmaları aktiftir.
- **Temiz Kod:** Klasörleme yapısı ve isimlendirme standartları (CamelCase) titizlikle uygulanmıştır.

## Tanıtım Videosu

YouTube üzerinden projenin canlı kullanımını izlemek için:
[Jetiz Kargo Tanıtım Videosu - İzle](https://youtu.be/98RoNk6NPn0)

## Geliştirici Hakkında

**Berkay Bedirhan Doğan 132130029**

*Bu proje, modern web teknolojilerinin lojistik sektöründeki verimliliğini kanıtlamak amacıyla geliştirilmiş bir portfolyo çalışmasıdır.*

## Lisans

Bu proje **Eğitim ve Portfolyo** amaçlı geliştirilmiştir. Tüm hakları saklıdır. Ticari olmayan kullanımlar için kodlar referans gösterilerek kullanılabilir.

---

### Sıkça Sorulan Sorular (SSS)

- **S: Veritabanı şifresi nedir?**
  - C: SQLite kullandığımız için özel bir şifre gerekmez, `KargoTakip.db` dosyası otomatik olarak yönetilir.
- **S: Harita çalışmıyor, ne yapmalıyım?**
  - C: İnternet bağlantınızı kontrol edin; harita verileri Leaflet CDN üzerinden çekilmektedir.
- **S: Yeni il eklenebilir mi?**
  - C: `wwwroot/js/turkey_data.js` dosyasına yeni veri ekleyerek tüm sistemi güncelleyebilirsiniz.

---

*Son Güncelleme: Ocak 2026*

