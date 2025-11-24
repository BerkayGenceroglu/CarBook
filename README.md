<h1 align="center">🚗 CarBook - Modern Araç Kiralama Yönetim Sistemi</h1>

<p align="center">
  Araç kiralama şirketlerinin dijital ihtiyaçlarına çözüm sunan, ASP.NET Core MVC ve RESTful API teknolojileriyle geliştirilmiş kapsamlı bir yönetim platformu
</p>

---

## 🧾 Proje Tanıtımı

**CarBook**, araç kiralama sektörü için geliştirilmiş, **çok katmanlı mimari** ve **modern teknolojilerle** tasarlanmış bir **web tabanlı yönetim sistemidir**.

Bu proje sayesinde:

- Müşteriler araç filosunu kolayca inceleyebilir ve online rezervasyon yapabilir
- Lokasyona göre müsait araçları filtreleyebilir ve karşılaştırma yapabilir
- Araçlar hakkında yorum ve değerlendirme bırakabilir
- Blog yazılarını okuyup bilgi edinebilir
- İletişim formu ile işletmeye kolayca ulaşabilir

Yöneticiler ise:

- Gerçek zamanlı dashboard ile işletme istatistiklerini takip edebilir (SignalR)
- Araç filosunu, rezervasyonları ve içerikleri merkezi bir panelden yönetebilir
- Blog, yorum, sosyal medya ve tüm site içeriğini kolayca güncelleyebilir
- Detaylı raporlar ve analizlerle veri odaklı kararlar alabilir

Proje, hem **müşteri deneyimini artırmayı** hem de **araç kiralama operasyonlarını dijitalleştirerek optimize etmeyi** hedeflemektedir.

**CarBook**, geliştiriciler için N-Tier Architecture, CQRS Pattern, Repository Pattern, API tüketimi, SignalR, ViewComponent, AJAX ve modern web teknolojilerini bir arada sunar.

---

## 🚀 Kullanılan Teknolojiler

| Katman | Teknolojiler |
|--------|-------------|
| **Backend** | `ASP.NET Core 8.0 MVC`, `ASP.NET Core Web API`, `Entity Framework Core`, `MSSQL Server`, `ASP.NET Identity`, `JWT`, `MediatR`, `FluentValidation`, `SignalR` |
| **Frontend** | `HTML5`, `CSS3`, `Bootstrap 5`, `JavaScript`, `jQuery`, `AJAX`, `Chart.js`, `Font Awesome`, `Flaticon` |
| **Database** | `MS SQL Server`, `Code First`, `Migration`, `Fluent API` |
| **Veri Taşıma** | `DTO (Data Transfer Object)`, `ViewModel`, `Newtonsoft.Json`, `HttpClientFactory`, `API Consume` |
| **Gerçek Zamanlı** | `SignalR`, `Hub`, `Client Method Invocation` |
| **Mimari** | `N-Tier Architecture`, `Onion Architecture`, `CQRS Pattern`, `Repository Pattern`, `Dependency Injection` |

---

## 🧱 Proje Mimarisi

<pre>
```
CarBook/
│
├── 📁 CarBook.Domain/                    → Domain Layer (Entity Models)
│   └── Entities/                         → 27 veritabanı tablosu
│
├── 📁 Core/
│   └── CarBook.Application/              → Application Layer (Business Logic)
│       ├── Features/
│       │   ├── CQRS/                     → Query & Command Handlers
│       │   └── Mediator/                 → MediatR Handlers
│       ├── Interfaces/                   → Repository Interfaces
│       ├── Services/                     → Service Registrations
│       └── Validators/                   → FluentValidation Rules
│
├── 📁 Infrastructure/
│   └── CarBook.Persistence/              → Infrastructure Layer (Data Access)
│       ├── Context/                      → CarBookContext (DbContext)
│       └── Repositories/                 → Repository Implementations
│
├── 📁 Presentation/
│   └── CarBook.WebApi/                   → RESTful API Layer
│       ├── Controllers/                  → 30+ API Endpoints
│       ├── Hubs/                        → SignalR Hubs
│       └── Extensions/                   → Service Extensions
│
├── 📁 Frontends/
│   └── UdemyCarBook.WebUI/              → MVC Web Application (UI)
│       ├── Controllers/                  → MVC Controllers
│       ├── Views/                       → Razor Views
│       ├── ViewComponents/              → Reusable View Components
│       ├── Areas/                       → Admin Panel (Area)
│       │   └── Admin/
│       │       ├── Controllers/
│       │       └── Views/
│       └── wwwroot/                     → Static Files (CSS, JS, Images)
│
└── 📁 CarBook.ViewModel/                 → ViewModel Layer (DTOs)
    └── ViewModels/                      → Data Transfer Objects
```
</pre>

---

## 💾 Veritabanı Yapısı

Proje, **MSSQL Server** kullanmaktadır ve **27 farklı tablo** içermektedir.

### 📊 Ana Tablolar ve İlişkiler

| Tablo Adı | Açıklama | İlişkiler |
|-----------|----------|-----------|
| **Cars** | Araç bilgileri (marka, model, km, yakıt, şanzıman) | Brand, CarFeature, CarPricing, Reviews, Reservations |
| **Brands** | Araç markaları (Mercedes, BMW, Audi, Ford vb.) | Cars (1:N) |
| **Features** | Araç özellikleri (GPS, Klima, Bluetooth, Airbag) | CarFeature (M:N) |
| **CarFeatures** | Araç-özellik ilişki tablosu (Many-to-Many) | Cars, Features |
| **Pricing** | Fiyatlandırma dönemleri (Günlük, Haftalık, Aylık) | CarPricing (1:N) |
| **CarPricing** | Araçların fiyat bilgileri | Cars, Pricing |
| **Locations** | Şube/lokasyon bilgileri | RentACar, Reservations |
| **Reservations** | Müşteri rezervasyonları | Cars, Locations (Pickup & Dropoff) |
| **Reviews** | Araç değerlendirmeleri ve yorumları | Cars (1:N) |
| **RentACar** | Lokasyona göre müsait araçlar | Cars, Locations |
| **Blogs** | Blog yazıları | Categories, Authors, Comments |
| **Categories** | Blog kategorileri | Blogs (1:N) |
| **Authors** | Blog yazarları | Blogs (1:N) |
| **Comments** | Blog yorumları | Blogs (1:N) |
| **TagClouds** | Blog etiketleri | Blogs (M:N) |
| **AppUsers** | Kullanıcı hesapları (Identity) | - |
| **AppRoles** | Kullanıcı rolleri (Admin, User) | - |
| **Banners** | Ana sayfa banner içerikleri | - |
| **About** | Hakkımızda sayfası içeriği | - |
| **Services** | Sunulan hizmetler | - |
| **Testimonials** | Müşteri referansları | - |
| **Contact** | İletişim form mesajları | - |
| **SocialMedia** | Sosyal medya linkleri | - |
| **FooterAddress** | Footer iletişim bilgileri | - |

### 🔗 Veritabanı İlişki Diyagramı

```
Brand ──(1:N)──> Cars
Car ──(1:N)──> CarPricing
Car ──(1:N)──> Reviews
Car ──(1:N)──> Reservations
Car ──(M:N)──> Features (CarFeature üzerinden)
Pricing ──(1:N)──> CarPricing
Location ──(1:N)──> Reservations (Pickup/Dropoff)
Blog ──(1:N)──> Comments
Category ──(1:N)──> Blogs
Author ──(1:N)──> Blogs
```

---

## ✨ Temel Özellikler

### 🎯 Kullanıcı Tarafı Özellikleri

- 🚗 **Araç Listeleme ve Filtreleme** - Tüm araç filosunu görüntüleme ve özelliklere göre filtreleme
- 📍 **Lokasyona Göre Arama** - Şubelere göre müsait araçları bulma
- 📅 **Online Rezervasyon** - Kullanıcı dostu form ile hızlı rezervasyon
- 💰 **Fiyat Karşılaştırma** - Günlük, haftalık, aylık fiyat seçenekleri
- ⭐ **Yorum ve Değerlendirme** - Araçlar hakkında deneyim paylaşımı
- 📝 **Blog Okuma** - Araç kiralama ve seyahat ile ilgili içerikler
- 💬 **İletişim Formu** - Hızlı mesaj gönderme
- 🔐 **Üyelik Sistemi** - Kayıt olma ve giriş yapma

### 🛡️ Admin Panel Özellikleri

- 📊 **Dashboard (Gerçek Zamanlı İstatistikler)** - SignalR ile anlık veri güncelleme
- 🚙 **Araç Yönetimi** - CRUD işlemleri (Ekleme, Güncelleme, Silme)
- ✨ **Araç Özellik Yönetimi** - Checkbox ile özellik atama
- 🏷️ **Marka Yönetimi** - Araç markalarını yönetme
- 💰 **Fiyatlandırma** - Dönemsel fiyat belirleme
- 📍 **Lokasyon Yönetimi** - Şube bilgilerini güncelleme
- 📋 **Rezervasyon Takibi** - Tüm rezervasyonları listeleme
- ✍️ **Blog Yönetimi** - Blog, kategori, yazar CRUD
- 💬 **Yorum Moderasyonu** - Blog ve araç yorumlarını onaylama
- 🎨 **İçerik Yönetimi** - Banner, hakkımızda, servisler, footer
- 📱 **Sosyal Medya** - Sosyal medya linklerini güncelleme
- 📈 **Detaylı İstatistikler** - Kapsamlı raporlama sayfası

---

## 🖥️ Ekran Görüntüleri ve Sayfa Detayları

## 👤 Kullanıcı Girişi ve Kayıt

### 📝 Kayıt Ol (Register)

Bu ekran, yeni kullanıcıların sisteme üye olması için geliştirilmiş bir kayıt formudur.

**Form Alanları:**
- İsim
- Soyisim
- Kullanıcı Adı
- E-posta
- Şifre
- Şifre Tekrar

**ASP.NET Identity** ile güvenli kayıt işlemi gerçekleştirilir. Şifreler hash'lenerek veritabanında saklanır.

Zaten hesabı olan kullanıcılar için sayfanın altında **"Giriş Yap"** linki bulunur.

> <img width="1916" height="943" alt="image" src="https://github.com/user-attachments/assets/bb28589c-16cb-497a-be74-0999b53d6013" />

---

### 🔐 Giriş Yap (Login)

Kayıtlı kullanıcıların sisteme güvenli bir şekilde giriş yapmasını sağlayan sayfadır.

**Form Alanları:**
- Kullanıcı Adı
- Şifre
- Beni Hatırla (Remember Me)

**Kimlik Doğrulama:**
- ASP.NET Identity ile cookie-based authentication
- Başarılı girişte admin ise dashboard'a, kullanıcı ise ana sayfaya yönlendirilir

Henüz hesabı olmayan kullanıcılar için **"Kayıt Ol"** butonu mevcuttur.

> <img width="1920" height="937" alt="image" src="https://github.com/user-attachments/assets/62cb48a9-8727-41fa-9336-36d07bdb758f" />


---

## 🏠 Kullanıcı Sayfaları

### 1. Ana Sayfa (Home / Default)

Web sitesinin vitrin sayfasıdır. Ziyaretçileri karşılayan ilk ekrandır.

**Sayfa Bileşenleri (ViewComponents):**

- 🎯 **Hero Banner** - Etkileyici görsel ve arama formu
  - Büyük slider görseller
  - "Rüya arabanızı bulun" başlığı
  - Hızlı arama butonu

- 🔍 **Araç Arama Filtresi**
  - Lokasyon seçimi (dropdown)
  - Tarih aralığı belirleme
  - "Araç Ara" butonu

- 🚗 **Öne Çıkan Araçlar**
  - En popüler 6-8 araç kartları
  - Araç görseli, marka, model
  - Günlük fiyat bilgisi
  - "Detay" butonu

- ℹ️ **Hakkımızda Özeti**
  - Şirket tanıtımı
  - Misyon ve vizyon
  - İstatistikler (araç sayısı, müşteri sayısı)

- 🛠️ **Hizmetler**
  - Sunulan hizmetlerin kartları
  - İkonlar ile görselleştirme

- ⭐ **Müşteri Referansları (Testimonials)**
  - Müşteri yorumları slider
  - 5 yıldızlı değerlendirmeler

- 📝 **Son 3 Blog Yazısı**
  - Blog başlığı, görsel, özet
  - "Devamını Oku" linkleri

- 📊 **İstatistikler**
  - Toplam araç sayısı
  - Toplam lokasyon
  - Mutlu müşteri sayısı

> <img width="1920" height="951" alt="image" src="https://github.com/user-attachments/assets/96b1c585-4b51-45c2-9e3a-0e90b9aca97b" />
<img width="1914" height="952" alt="image" src="https://github.com/user-attachments/assets/fcad3b0f-0a4f-4fdf-8be9-61658d8d9b44" />
<img width="1920" height="955" alt="image" src="https://github.com/user-attachments/assets/8d5053a7-c6a6-4d65-9e5a-3c94c39d8918" />
<img width="1920" height="770" alt="image" src="https://github.com/user-attachments/assets/41c3dbf5-fbff-4f1a-8bfe-920f1e1258ef" />
<img width="1917" height="932" alt="image" src="https://github.com/user-attachments/assets/58273e95-d44f-4ee6-b111-11ce6c0f1ea9" />
<img width="1920" height="859" alt="image" src="https://github.com/user-attachments/assets/34c0e501-c506-4140-b1e4-72892ba4067b" />
<img width="1919" height="950" alt="image" src="https://github.com/user-attachments/assets/4d4be169-93c7-477e-bd09-e957bf1e9952" />
---

### 2. Araç Listeleme Sayfası

**Yol:** `/Car/Index`

Tüm araç filosunun görüntülendiği ana listeleme sayfasıdır.

**Özellikler:**

- 🚙 **Araç Kartları** - Grid layout ile düzenli görünüm
  - Araç görseli (cover image)
  - Marka ve model bilgisi
  - Kilometre
  - Şanzıman tipi (Otomatik/Manuel)
  - Yakıt tipi (Benzin/Dizel/Elektrik)
  - Koltuk sayısı
  - Bagaj kapasitesi
  - Günlük kiralama fiyatı
  - "Detayları Gör" butonu

- 🔍 **Filtreleme (Opsiyonel)**
  - Markaya göre
  - Fiyat aralığına göre
  - Özelliks** | Rezervasyon bilgileri | Cars, Locations |
| **RentACar** | Lokasyona göre müsait araçlar | Cars, Locations |
| **Reviews** | Müşteri yorumları ve puanları | Cars |
| **Blogs** | Blog yazıları | Categories, Authors, Comments |
| **Comments** | Blog yorumları | Blogs |
| **Categories** | Blog kategorileri | Blogs |
| **Authors** | Blog yazarları | Blogs |
| **AppUsers** | Kullanıcı hesapları (ASP.NET Identity) | - |
| **AppRoles** | Kullanıcı rolleri | - |
| **Banners** | Ana sayfa banner'ları | - |
| **About** | Hakkımızda içeriği | - |
| **Services** | Sunulan hizmetler | - |
| **Testimonials** | Müşteri referansları | - |
| **Contact** | İletişim form mesajları | - |
| **SocialMedia** | Sosyal medya linkleri | - |
| **FooterAddress** | Footer adres bilgisi | - |
| **TagClouds** | Blog etiketleri | Blogs |

### Veritabanı İlişkileri (Entity Relations)

```
Brand ──(1:N)──> Cars
Car ──(1:N)──> CarPricing
Car ──(1:N)──> Reviews
Car ──(1:N)──> Reservations
Car ──(M:N)──> Features (CarFeature üzerinden)
Pricing ──(1:N)──> CarPricing
Location ──(1:N)──> Reservations
Blog ──(1:N)──> Comments
Category ──(1:N)──> Blogs
Author ──(1:N)──> Blogs
```

---

## ✨ Temel Özellikler

### 🎯 Kullanıcı Özellikleri

1. **Araç Listeleme ve Filtreleme**
   - Tüm araç filosunu görüntüleme
   - Marka, yakıt tipi, şanzıman türüne göre filtreleme
   - Lokasyon bazlı müsaitlik sorgulama

2. **Rezervasyon Sistemi**
   - Online rezervasyon formu
   - Alış ve teslim lokasyonu seçimi
   - Tarih aralığı belirleme
   - Rezervasyon onay sistemi

3. **Araç Detay Sayfası**
   - Araç özellikleri ve açıklamaları
   - Fiyat bilgileri (günlük/haftalık/aylık)
   - Müşteri yorumları ve puanları
   - İlgili araç önerileri

4. **Blog Sistemi**
   - Blog yazılarını okuma
   - Kategorilere göre filtreleme
   - Yorum yapma
   - En popüler yazılar

5. **İletişim ve Bilgilendirme**
   - İletişim formu
   - Hakkımızda sayfası
   - Servisler ve özellikler
   - Müşteri referansları

### 🔐 Kimlik Doğrulama ve Yetkilendirme

- **ASP.NET Identity** ile kullanıcı girişi
- **JWT Token** tabanlı API authentication
- Rol bazlı yetkilendirme (Admin, User)
- Güvenli şifre saklama

### 📊 Admin Panel Özellikleri

1. **Dashboard (Gösterge Paneli)**
   - Gerçek zamanlı istatistikler (SignalR)
   - Toplam araç sayısı
   - Lokasyon sayısı
   - Marka sayısı
   - Günlük/haftalık/aylık fiyatlandırma ortalamaları
   - Grafik ve görselleştirmeler (Chart.js)

2. **Araç Yönetimi**
   - Araç ekleme, düzenleme, silme
   - Araç özelliklerini atama
   - Fiyatlandırma yönetimi
   - Görsel yükleme

3. **İçerik Yönetimi**
   - Banner yönetimi
   - Hakkımızda düzenleme
   - Servis yönetimi
   - Footer bilgileri
   - Sosyal medya linkleri

4. **Blog Yönetimi**
   - Blog ekleme/düzenleme/silme
   - Kategori yönetimi
   - Yazar yönetimi
   - Yorum moderasyonu

5. **Rezervasyon Yönetimi**
   - Rezervasyon listesi
   - Rezervasyon durumu güncelleme
   - Detaylı rezervasyon bilgileri

6. **İstatistik ve Raporlama**
   - Detaylı istatistik sayfası
   - En çok kiralanan araçlar
   - Lokasyon bazlı analizler
   - Marka bazlı istatistikler

---

## 📄 Sayfa Detayları

### 🏠 Kullanıcı Sayfaları

#### 1. Ana Sayfa (Home / Default)

**Yol:** `/` veya `/Default/Index`

**Açıklama:** Projenin vitrin sayfasıdır. Tüm önemli bilgileri görsel ve etkili bir şekilde sunar.

**Bileşenler:**
- 🎯 **Hero Banner** - Büyük görsel slider ve arama formu
- 🔍 **Araç Arama Filtresi** - Lokasyon ve tarih seçerek müsait araçları bulma
- 🚗 **Öne Çıkan Araçlar** - En popüler ve yeni araçların kartları
- ℹ️ **Hakkımızda Özeti** - Şirket hakkında kısa bilgi
- 🛠️ **Servisler** - Sunulan hizmetlerin özeti
- ⭐ **Müşteri Referansları (Testimonials)** - Müşteri yorumları slider
- 📝 **Son 3 Blog Yazısı** - En güncel blog yazıları
- 📊 **İstatistikler** - Toplam araç, lokasyon gibi sayısal bilgiler

**Özellikler:**
- Responsive tasarım
- Smooth scroll animasyonlar
- AJAX ile dinamik veri yükleme
- ViewComponent yapısı ile modüler kodlama

---

#### 2. Araç Listeleme Sayfası (Car Listing)

**Yol:** `/Car/Index`

**Açıklama:** Tüm araç filosunu görüntüleme ve filtreleme sayfası.

**Özellikler:**
- 🚙 Tüm araçların kart görünümü
- 🏷️ Marka bilgisi
- ⚙️ Şanzıman tipi (Otomatik/Manuel)
- ⛽ Yakıt tipi (Benzin/Dizel/Elektrik)
- 💺 Koltuk sayısı
- 🧳 Bagaj kapasitesi
- 💰 Günlük kiralama fiyatı
- 🔗 Detay sayfasına yönlendirme

**API Çağrısı:**
```csharp
// CarController.cs
public async Task<IActionResult> Index()
{
    var client = _httpClientFactory.CreateClient();
    var responseMessage = await client.GetAsync("https://localhost:7238/api/Cars/GetCarWithBrand");
    
    if (responseMessage.IsSuccessStatusCode)
    {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCarViewModel>>(jsonData);
        return View(values);
    }
    return View();
}
```

---

#### 3. Araç Detay Sayfası (Car Detail)

**Yol:** `/Car/CarDetail/{id}`

**Açıklama:** Seçilen aracın tüm detaylarını gösteren kapsamlı sayfa.

**Bileşenler:**
- 📸 **Araç Görseli** - Büyük araç fotoğrafı
- 📋 **Araç Özellikleri** - Marka, model, yıl, km, yakıt, şanzıman
- ✨ **Özellik Listesi** - GPS, klima, bluetooth gibi özellikler (checkbox)
- 💵 **Fiyatlandırma** - Günlük, haftalık, aylık fiyatlar (tablo)
- 📝 **Detaylı Açıklama** - Araç hakkında uzun açıklama metni
- ⭐ **Müşteri Yorumları** - Önceki kiralayan müşterilerin yorumları ve puanları
- 🔗 **Benzer Araçlar** - Aynı kategoriden diğer araçlar

**ViewComponents:**
```
- _CarDetailMainCarFeatureComponentPartial     → Ana araç bilgileri
- _CarDetailCarDescriptionByCarIdComponentPartial → Açıklama
- _CarDetailCarFeatureByCarIdComponentPartial   → Özellikler
- _CarDetailCarPricingByCarIdComponentPartial   → Fiyatlar
- _CarDetailReviewByCarIdComponentPartial       → Yorumlar
```

---

#### 4. Lokasyona Göre Araç Arama (Rent A Car List)

**Yol:** `/RentACarList/Index`

**Açıklama:** Belirli bir lokasyonda müsait araçları listeleme.

**Özellikler:**
- 📍 **Lokasyon Seçimi** - Dropdown liste ile şube seçimi
- 📅 **Müsaitlik Kontrolü** - Seçilen lokasyondaki müsait araçlar
- 🔄 **Filtre Formu** - ViewComponent ile dinamik filtreleme
- 📊 **Sonuç Listesi** - Müsait araçların detaylı kartları

**Form İşlemi:**
```csharp
[HttpPost]
public async Task<IActionResult> Index(int locationId)
{
    var client = _httpClientFactory.CreateClient();
    var responseMessage = await client.GetAsync($"https://localhost:7238/api/RentACars?locationId={locationId}&available=true");
    
    if (responseMessage.IsSuccessStatusCode)
    {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<FilterRentACarViewModel>>(jsonData);
        return View(values);
    }
    return View();
}
```

---

#### 5. Rezervasyon Sayfası (Reservation)

**Yol:** `/Reservation/Index`

**Açıklama:** Araç kiralama rezervasyonu yapma formu.

**Form Alanları:**
- 👤 **Kişisel Bilgiler:** Ad, Soyad, Email, Telefon
- 📅 **Tarih Bilgileri:** (Query string ile alınır)
- 📍 **Lokasyon:** Alış ve teslim lokasyonu
- 🚗 **Araç Seçimi:** Kiralana araç (dropdown)
- 🎂 **Yaş:** Müşteri yaşı
- 📜 **Ehliyet Yılı:** Kaç yıldır ehliyeti var
- 📝 **Açıklama:** Ek notlar

**Validation:**
- Tüm zorunlu alanlar kontrol edilir
- Email format kontrolü
- Yaş ve ehliyet yılı sayısal kontrol
- Sunucu tarafında FluentValidation (opsiyonel)

**API Endpoint:**
```
POST /api/Reservation/CreateReservation
```

---

#### 6. Blog Sayfası (Blog)

**Yol:** `/Blog/Index`

**Açıklama:** Tüm blog yazılarını listeleme sayfası.

**Özellikler:**
- 📰 Blog kartları (başlık, görsel, özet, tarih)
- 👤 Yazar bilgisi
- 📂 Kategori etiketi
- 💬 Yorum sayısı
- 🔗 Detay sayfasına link

**Blog Detay Sayfası:** `/Blog/BlogDetail/{id}`

**Detay Sayfası Bileşenleri:**
- 📖 Tam blog yazısı
- 📸 Blog görseli
- 👨‍💼 Yazar bilgileri ve profil fotoğrafı
- 📅 Yayınlanma tarihi
- 🏷️ Etiketler (TagCloud)
- 💬 **Yorum Bölümü** - Önceki yorumlar ve yeni yorum formu
- 📚 Son 3 blog yazısı (sidebar)
- 🏷️ Kategori listesi (sidebar)

---

#### 7. Hakkımızda Sayfası (About)

**Yol:** `/About/Index`

**Açıklama:** Şirket hakkında detaylı bilgi sayfası.

**İçerik:**
- 🏢 Şirket hikayesi ve misyon
- 👥 Ekip bilgileri
- 🎯 Vizyonumuz
- 📊 İstatistikler (kuruluş yılı, araç sayısı, müşteri sayısı)
- 🌟 Neden bizi seçmelisiniz?

---

#### 8. Servisler Sayfası (Services)

**Yol:** `/Service/Index`

**Açıklama:** Sunulan hizmetlerin detaylı tanıtımı.

**İçerik:**
- 🚗 Araç Kiralama Hizmetleri
- 🛡️ Sigorta Paketleri
- 👨‍🔧 Teknik Destek
- 🗺️ GPS ve Navigasyon
- 👶 Çocuk Koltuğu
- ⛽ Yakıt Seçenekleri

Her servis için:
- 🎨 İkon
- 📝 Başlık ve açıklama
- ✅ Avantajlar

---

#### 9. İletişim Sayfası (Contact)

**Yol:** `/Contact/Index`

**Açıklama:** İletişim bilgileri ve mesaj gönderme formu.

**Bileşenler:**
- 📍 **Adres Bilgisi** - Şirket adresi (Footer'dan gelir)
- 📞 **İletişim Bilgileri** - Telefon, email
- 📝 **İletişim Formu:**
  - İsim Soyisim
  - Email
  - Konu
  - Mesaj

**Form İşleme:**
```csharp
[HttpPost]
public async Task<IActionResult> Index(CreateContactViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var responseMessage = await client.PostAsync("https://localhost:7238/api/Contact", stringContent);
    
    if (responseMessage.IsSuccessStatusCode)
    {
        return RedirectToAction("Index", "Default");
    }
    return View();
}
```

---

#### 10. Kullanıcı Kayıt ve Giriş

**Kayıt Sayfası:** `/Register/Index`

**Form Alanları:**
- İsim, Soyisim
- Kullanıcı Adı
- Email
- Şifre, Şifre Tekrar

**Giriş Sayfası:** `/Login/LoginAppUser`

**Kimlik Doğrulama:**
- ASP.NET Identity ile kullanıcı girişi
- Cookie-based authentication
- Şifre hash'leme
- Remember me özelliği

```csharp
[HttpPost]
public async Task<IActionResult> LoginAppUser(LoginAppUserViewModel model)
{
    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
    
    if (result.Succeeded)
    {
        return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
    }
    return View();
}
```

---

### 🛡️ Admin Paneli Sayfaları

Admin panel, **Area** yapısı ile ayrılmıştır.

**Yol:** `/Admin/...`

**Erişim:** Sadece Admin rolüne sahip kullanıcılar

**Layout:** `_AdminLayout.cshtml` - Özel admin template

---

#### 1. Dashboard (Admin Ana Sayfa)

**Yol:** `/Admin/AdminDashboard/Index`

**Açıklama:** Admin panelinin ana kontrol merkezi. Tüm önemli metrikleri ve istatistikleri gösterir.

**İstatistikler (ViewComponents ile):**

**📊 Genel İstatistikler:**
- 🚗 Toplam Araç Sayısı
- 📍 Toplam Lokasyon Sayısı
- 👤 Toplam Yazar Sayısı
- 📝 Toplam Blog Sayısı
- 🏷️ Toplam Marka Sayısı

**💰 Fiyatlandırma İstatistikleri:**
- Günlük ortalama fiyat
- Haftalık ortalama fiyat
- Aylık ortalama fiyat

**🔥 En Popüler:**
- En pahalı araç
- En ucuz araç
- En çok yorumlanan araç

**📊 Grafikler (Chart.js):**
- Yakıt türüne göre araç dağılımı (Pie Chart)
- Marka bazlı araç sayıları (Bar Chart)
- Aylık kiralama trendi (Line Chart)

**🔴 Gerçek Zamanlı Veri (SignalR):**
```javascript
// SignalR bağlantısı
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7238/carHub")
    .build();

connection.on("CarCount", (count) => {
    document.getElementById("carCountSpan").innerText = count;
});

connection.start();
```

---

#### 2. Araç Yönetimi (Admin Car)

**Yol:** `/Admin/AdminCar/Index`

**Açıklama:** Araç CRUD işlemleri.

**Tablo Kolonları:**
- ID
- Marka
- Model
- Km
- Şanzıman
- Koltuk
- Bagaj
- Yakıt
- Görsel
- İşlemler (Düzenle/Sil)

**Ekleme Sayfası:** `/Admin/AdminCar/CreateCar`

**Form Alanları:**
- Marka seçimi (Dropdown - Brand listesinden)
- Kapak görseli URL
- Büyük görsel URL
- Kilometre
- Şanzıman tipi (Manuel/Otomatik)
- Koltuk sayısı
- Bagaj kapasitesi
- Yakıt türü (Benzin/Dizel/Elektrik/Hibrit)

**Güncelleme:** `/Admin/AdminCar/UpdateCar/{id}`

**Silme:** `/Admin/AdminCar/DeleteCar/{id}`

---

#### 3. Araç Özellik Yönetimi (Admin Car Feature)

**Yol:** `/Admin/AdminCarFeatureDetail/Index/{id}`

**Açıklama:** Belirli bir araca özellik atama/çıkarma.

**Çalışma Mantığı:**
- Tüm özellikler listelenir (GPS, Klima, Bluetooth vs.)
- Her özellik için checkbox
- İşaretli olanlar o araca ait
- Checkbox ile aktif/pasif yapılır

**Örnek Özellikler:**
- ✅ GPS Navigasyon
- ✅ Bluetooth Bağlantı
- ❌ Deri Koltuk
- ✅ Klima
- ✅ Airbag
- ❌ Sunroof

**API Çağrısı:**
```csharp
// Özelliği aktif/pasif yapma
await client.GetAsync($"https://localhost:7238/api/CarFeature/CarFeatureChangeAvailableToFalse?id={id}");
await client.GetAsync($"https://localhost:7238/api/CarFeature/CarFeatureChangeAvailableToTrue?id={id}");
```

---

#### 4. Marka Yönetimi (Admin Brand)

**Yol:** `/Admin/AdminBrand/Index`

**Özellikler:**
- Marka listesi (Mercedes, BMW, Audi, Ford vs.)
- Yeni marka ekleme
- Marka düzenleme
- Marka silme

---

#### 5. Banner Yönetimi (Admin Banner)

**Yol:** `/Admin/AdminBanner/Index`

**Açıklama:** Ana sayfa hero banner'larını yönetme.

**Form Alanları:**
- Başlık
- Açıklama
- Video URL (opsiyonel)
- Buton metni
- Buton linki

---

#### 6. Hakkımızda Yönetimi (Admin About)

**Yol:** `/Admin/AdminAbout/Index`

**Açıklama:** Hakkımızda sayfası içeriğini düzenleme.

**Form Alanları:**
- Başlık
- Açıklama (Uzun metin - textarea)
- Görsel URL

---

#### 7. Servis Yönetimi (Admin Service)

**Yol:** `/Admin/AdminService/Index`

**Özellikler:**
- Servis listesi
- Yeni servis ekleme
- Her servis için: Başlık, Açıklama, İkon

---

#### 8. Müşteri Referansları (Admin Testimonial)

**Yol:** `/Admin/AdminTestimonial/Index`

**Form Alanları:**
- Müşteri adı
- Müşteri unvanı
- Yorum metni
- Profil fotoğrafı URL

---

#### 9. Blog Yönetimi (Admin Blog)

**Yol:** `/Admin/AdminBlog/Index`

**Tablo Kolonları:**
- ID
- Başlık
- Yazar
- Kategori
- Tarih
- Görsel
- İşlemler

**Ekleme/Güncelleme Formu:**
- Başlık
- Yazar seçimi (Dropdown)
- Kategori seçimi (Dropdown)
- Kapak görseli
- Tarih
- Açıklama (HTML Editor)

---

#### 10. Kategori Yönetimi (Admin Category)

**Yol:** `/Admin/AdminCategory/Index`

**İşlemler:**
- Kategori listesi
- Yeni kategori ekleme
- Kategori düzenleme
- Kategori silme

---

#### 11. Yazar Yönetimi (Admin Author)

**Yol:** `/Admin/AdminAuthor/Index`

**Form Alanları:**
- İsim
- Profil fotoğrafı
- Açıklama
- Blog sayısı (otomatik hesaplanır)

---

#### 12. Yorum Yönetimi (Admin Comment)

**Yol:** `/Admin/AdminComment/Index`

**Özellikler:**
- Blog yorumlarını listeleme
- Yorum onaylama/reddetme
- Yorum silme
- Blog başlığı ile ilişkilendirme

---

#### 13. İletişim Mesajları (Admin Contact)

**Yol:** `/Admin/AdminContact/Index`

**Kolonlar:**
- Ad Soyad
- Email
- Konu
- Mesaj
- Tarih

**İşlemler:**
- Mesajları görüntüleme
- Mesaj detayı
- Mesaj silme
- Okundu işaretleme (opsiyonel)

---

#### 14. Lokasyon Yönetimi (Admin Location)

**Yol:** `/Admin/AdminLocation/Index`

**Form Alanları:**
- Şube adı
- Adres
- Telefon
- Email

---

#### 15. Fiyatlandırma Periyotları (Admin Pricing)

**Yol:** `/Admin/AdminPricing/Index`

**Örnekler:**
- Günlük (Daily)
- Haftalık (Weekly)
- Aylık (Monthly)

**Kullanım:** CarPricing tablosu ile ilişkilendirilir

---

#### 16. Footer Ayarları (Admin Footer Address)

**Yol:** `/Admin/AdminFooterAddress/Index`

**Form Alanları:**
- Adres
- Telefon
- Email
- Açıklama

---

#### 17. Sosyal Medya (Admin Social Media)

**Yol:** `/Admin/AdminSocialMedia/Index`

**İçerik:**
- Facebook URL
- Twitter URL
- Instagram URL
- LinkedIn URL
- İkon seçimi

---

#### 18. Blog Etiketleri (Admin Tag Cloud)

**Yol:** `/Admin/AdminTagCloud/Index`

**Kullanım:**
- Blog yazılarına etiket atama
- Etiket bazlı arama
- Her blog için birden fazla etiket

---

#### 19. İstatistikler Sayfası (Admin Statistics)

**Yol:** `/Admin/AdminStatistics/Index`

**Detaylı İstatistikler:**

**🚗 Araç İstatistikleri:**
- Toplam araç sayısı
- Otomatik şanzıman sayısı
- Manuel şanzıman sayısı
- Elektrikli araç sayısı
- Benzinli araç sayısı
- Dizel araç sayısı

**🏢 Marka İstatistikleri:**
- En çok araca sahip marka
- En az araca sahip marka
- Marka başına ortalama araç

**📝 Blog İstatistikleri:**
- Toplam blog sayısı
- En çok yorumlanan blog
- En aktif yazar

**📍 Lokasyon İstatistikleri:**
- Toplam lokasyon sayısı
- Her lokasyondaki araç sayısı

**💰 Fiyat İstatistikleri:**
- Ortalama günlük fiyat
- En pahalı araç
- En ucuz araç
- Fiyat aralığı

**API Çağrıları:**
```csharp
// Örnek istatistik çağrısı
var carCountResponse = await client.GetAsync("https://localhost:7238/api/Statistics/CarCount");
var brandCountResponse = await client.GetAsync("https://localhost:7238/api/Statistics/BrandCount");
var avgPriceResponse = await client.GetAsync("https://localhost:7238/api/Statistics/AvgPriceForDaily");
```

---

## 🔌 API Kullanımı

Proje, **RESTful API** mimarisi kullanmaktadır. API, `https://localhost:7238` adresinde çalışır.

### Ana API Endpoints

#### Cars (Araçlar)

```http
GET    /api/Cars                          → Tüm araçları listele
GET    /api/Cars/{id}                     → ID'ye göre araç getir
GET    /api/Cars/GetCarWithBrand          → Markası ile birlikte araçlar
POST   /api/Cars                          → Yeni araç ekle
PUT    /api/Cars                          → Araç güncelle
DELETE /api/Cars/{id}                     → Araç sil
```

#### Brands (Markalar)

```http
GET    /api/Brands                        → Tüm markaları listele
GET    /api/Brands/{id}                   → ID'ye göre marka
POST   /api/Brands                        → Yeni marka ekle
PUT    /api/Brands                        → Marka güncelle
DELETE /api/Brands/{id}                   → Marka sil
```

#### CarPricing (Araç Fiyatlandırma)

```http
GET    /api/CarPricings                   → Tüm fiyatlandırmalar
GET    /api/CarPricings/GetCarPricingWithTimePeriod  → Fiyat + dönem bilgisi
```

#### Statistics (İstatistikler)

```http
GET    /api/Statistics/CarCount                    → Toplam araç sayısı
GET    /api/Statistics/LocationCount               → Toplam lokasyon sayısı
GET    /api/Statistics/BrandCount                  → Toplam marka sayısı
GET    /api/Statistics/BlogCount                   → Toplam blog sayısı
GET    /api/Statistics/AvgPriceForDaily            → Günlük ort. fiyat
GET    /api/Statistics/AvgPriceForWeekly           → Haftalık ort. fiyat
GET    /api/Statistics/AvgPriceForMonthly          → Aylık ort. fiyat
GET    /api/Statistics/CarCountByTransmissionAuto  → Otomatik araç sayısı
GET    /api/Statistics/CarCountByFuelElectric      → Elektrikli araç sayısı
```

#### RentACar (Müsaitlik)

```http
GET    /api/RentACars?locationId={id}&available=true  → Lokasyona göre müsait araçlar
```

#### Reservation (Rezervasyon)

```http
GET    /api/Reservation                   → Tüm rezervasyonlar
POST   /api/Reservation/CreateReservation → Yeni rezervasyon oluştur
```

#### Blog

```http
GET    /api/Blog                          → Tüm bloglar
GET    /api/Blog/{id}                     → ID'ye göre blog
GET    /api/Blog/GetLast3BlogsWithAuthorsAndCategories  → Son 3 blog
GET    /api/Blog/GetAllBlogsWithAuthorsAndCategories     → Tüm bloglar (ilişkili)
POST   /api/Blog                          → Yeni blog ekle
PUT    /api/Blog                          → Blog güncelle
DELETE /api/Blog/{id}                     → Blog sil
```

#### Comments (Yorumlar)

```http
GET    /api/Comment                       → Tüm yorumlar
GET    /api/Comment/CommentListByBlog/{blogId}  → Blog'a ait yorumlar
POST   /api/Comment                       → Yeni yorum ekle
DELETE /api/Comment/{id}                  → Yorum sil
```

#### Reviews (Araç Yorumları)

```http
GET    /api/Review                        → Tüm değerlendirmeler
GET    /api/Review/GetReviewByCarId/{carId}     → Araca ait yorumlar
POST   /api/Review                        → Yeni değerlendirme
PUT    /api/Review                        → Değerlendirme güncelle
DELETE /api/Review/{id}                   → Değerlendirme sil
```

#### Contact (İletişim)

```http
GET    /api/Contact                       → Tüm mesajlar
POST   /api/Contact                       → Yeni mesaj gönder
DELETE /api/Contact/{id}                  → Mesaj sil
```

### API Kullanım Örnekleri

#### 1. Araç Listesi Çekme (GET)

```csharp
// Controller'da
public async Task<IActionResult> Index()
{
    var client = _httpClientFactory.CreateClient();
    var responseMessage = await client.GetAsync("https://localhost:7238/api/Cars/GetCarWithBrand");
    
    if (responseMessage.IsSuccessStatusCode)
    {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCarViewModel>>(jsonData);
        return View(values);
    }
    return View();
}
```

#### 2. Yeni Araç Ekleme (POST)

```csharp
[HttpPost]
public async Task<IActionResult> CreateCar(CreateCarViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var responseMessage = await client.PostAsync("https://localhost:7238/api/Cars", stringContent);
    
    if (responseMessage.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return View();
}
```

#### 3. Araç Güncelleme (PUT)

```csharp
[HttpPost]
public async Task<IActionResult> UpdateCar(UpdateCarViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var responseMessage = await client.PutAsync("https://localhost:7238/api/Cars", stringContent);
    
    if (responseMessage.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return View();
}
```

#### 4. Araç Silme (DELETE)

```csharp
public async Task<IActionResult> DeleteCar(int id)
{
    var client = _httpClientFactory.CreateClient();
    var responseMessage = await client.DeleteAsync($"https://localhost:7238/api/Cars/{id}");
    
    if (responseMessage.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return View();
}
```

---

## 🏗 Proje Mimarisi

### Katmanlar ve Sorumluluklar

```
┌─────────────────────────────────────────┐
│   📱 Presentation Layer (WebUI/WebApi) │
│   - UI/UX                               │
│   - HTTP Request/Response               │
│   - View Components                     │
│   - Controllers                         │
└──────────────┬──────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────┐
│   🧠 Application Layer                  │
│   - Business Logic                      │
│   - CQRS Handlers                       │
│   - Validation Rules                    │
│   - Interfaces                          │
└──────────────┬──────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────┐
│   🗄️ Infrastructure Layer               │
│   - DbContext                           │
│   - Repositories                        │
│   - Database Operations                 │
│   - Migrations                          │
└──────────────┬──────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────┐
│   📦 Domain Layer                       │
│   - Entities                            │
│   - Domain Models                       │
│   - No Dependencies                     │
└─────────────────────────────────────────┘
```

### Design Patterns

#### 1. Repository Pattern
Veri erişim katmanını soyutlar.

```csharp
public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
}
```

#### 2. CQRS (Command Query Responsibility Segregation)
Okuma ve yazma işlemlerini ayırır.

```csharp
// Query (Okuma)
public class GetBrandQuery
{
    public int BrandId { get; set; }
}

public class GetBrandQueryResult
{
    public int BrandId { get; set; }
    public string Name { get; set; }
}

// Command (Yazma)
public class CreateBrandCommand
{
    public string Name { get; set; }
}
```

#### 3. Mediator Pattern
MediatR kütüphanesi ile handler'ları merkezi yönetir.

```csharp
// Handler
public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, GetBrandQueryResult>
{
    private readonly IRepository<Brand> _repository;
    
    public async Task<GetBrandQueryResult> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.BrandId);
        return new GetBrandQueryResult { BrandId = brand.BrandId, Name = brand.Name };
    }
}
```

#### 4. Dependency Injection
ASP.NET Core built-in DI container.

```csharp
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
```

#### 5. ViewModel Pattern
View ile model arasında veri transferi.

```csharp
public class ResultCarViewModel
{
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string Transmission { get; set; }
    public decimal DailyPrice { get; set; }
}
```

---

## 🚀 Kurulum

### Gereksinimler

- ✅ .NET 8.0 SDK veya üzeri
- ✅ Visual Studio 2022 veya üzeri (Community yeterli)
- ✅ MSSQL Server (LocalDB veya Express)
- ✅ Git

### Adım 1: Projeyi Klonlama

```bash
git clone https://github.com/BerkayGenceroglu/CarBook.git
cd CarBook
```

### Adım 2: Veritabanı Bağlantısı

**Infrastructure** katmanındaki `CarBookContext.cs` dosyasını açın ve connection string'i güncelleyin:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Server=YOUR_SERVER_NAME;Database=CarBookDb;Trusted_Connection=True;TrustServerCertificate=True");
}
```

### Adım 3: Database Migration

Package Manager Console'da şu komutları çalıştırın:

```bash
# Infrastructure projesini seçin
Add-Migration InitialCreate
Update-Database
```

### Adım 4: API'yi Çalıştırma

1. `CarBook.WebApi` projesini sağ tıklayın
2. "Set as Startup Project" seçin
3. F5 ile çalıştırın
4. Swagger açılacak: `https://localhost:7238/swagger`

### Adım 5: Web UI'yi Çalıştırma

1. `UdemyCarBook.WebUI` projesini sağ tıklayın
2. "Set as Startup Project" seçin
3. F5 ile çalıştırın
4. Tarayıcıda açılacak

### Adım 6: Multiple Startup Projects (Önerilen)

Her iki projeyi aynı anda çalıştırmak için:

1. Solution'a sağ tıklayın
2. "Properties" → "Multiple startup projects"
3. `CarBook.WebApi` ve `UdemyCarBook.WebUI` için "Start" seçin
4. OK ve F5

---

## 📚 Öğrenme Kaynakları

Bu proje ile şunları öğrenebilirsiniz:

- ✅ ASP.NET Core MVC ile web uygulaması geliştirme
- ✅ RESTful API tasarımı ve implementasyonu
- ✅ Entity Framework Core ile veritabanı işlemleri
- ✅ CQRS ve Mediator pattern kullanımı
- ✅ Repository pattern ile veri erişim katmanı
- ✅ Dependency Injection
- ✅ ASP.NET Identity ile kimlik doğrulama
- ✅ SignalR ile gerçek zamanlı uygulamalar
- ✅ ViewComponent yapısı
- ✅ Area kullanımı (Admin Panel)
- ✅ HttpClient ile API tüketimi
- ✅ JSON serializasyon/deserializasyon
- ✅ Bootstrap ile responsive tasarım
- ✅ AJAX çağrıları
- ✅ Chart.js ile veri görselleştirme

---

## 🤝 Katkıda Bulunma

Projeye katkıda bulunmak isterseniz:

1. Bu repository'yi fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'feat: Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

---

## 📝 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

---

## 👤 Geliştirici

**Berkay Genceroğlu**

- GitHub: [@BerkayGenceroglu](https://github.com/BerkayGenceroglu)
- LinkedIn: [Berkay Genceroğlu](https://www.linkedin.com/in/berkay-gencero%C4%9Flu/)

---

## 🙏 Teşekkürler

Bu projeyi geliştirirken şu kaynaklardan faydalanılmıştır:

- ASP.NET Core Documentation
- Entity Framework Core Documentation
- Microsoft Learn
- Stack Overflow Community

---

## 📌 Notlar

### Önemli URL'ler

```
Web UI    : https://localhost:5001
API       : https://localhost:7238
Swagger   : https://localhost:7238/swagger
SignalR   : https://localhost:7238/carHub
```

### Test Kullanıcıları

Sistemi test etmek için aşağıdaki kullanıcıları kullanabilirsiniz:

```
Admin:
Username: admin
Password: Admin123!

User:
Username: user
Password: User123!
```

*(Not: Bu bilgiler seed data ile oluşturulmalıdır)*

---

<div align="center">

### ⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!

**Geliştirmeye devam ediyoruz... 🚀**

</div>
lere göre

**API Çağrısı:**
```csharp
var client = _httpClientFactory.CreateClient();
var responseMessage = await client.GetAsync("https://localhost:7238/api/Cars/GetCarWithBrand");
var jsonData = await responseMessage.Content.ReadAsStringAsync();
var values = JsonConvert.DeserializeObject<List<ResultCarViewModel>>(jsonData);
```

> **Not:** Ekran görüntüsü eklenecek

---

### 3. Araç Detay Sayfası

**Yol:** `/Car/CarDetail/{id}`

Seçilen aracın tüm detaylarını gösteren kapsamlı sayfa.

**Bölümler:**

📸 **Araç Görseli ve Temel Bilgiler**
- Büyük araç fotoğrafı
- Marka ve model
- Yıl bilgisi
- Kilometre
- Yakıt türü
- Şanzıman tipi
- Koltuk sayısı
- Bagaj kapasitesi

✨ **Araç Özellikleri**
- GPS Navigasyon ✅
- Bluetooth Bağlantı ✅
- Klima ✅
- Airbag ✅
- Deri Koltuk ❌
- Sunroof ❌
- Otomatik Park ✅

Checkbox ile gösterilir. İşaretli olanlar mevcuttur.

💵 **Fiyatlandırma Tablosu**
| Dönem | Fiyat |
|-------|-------|
| Günlük | 850 TL |
| Haftalık | 5.500 TL |
| Aylık | 20.000 TL |

📝 **Detaylı Açıklama**
Araç hakkında uzun form açıklama metni.

⭐ **Müşteri Yorumları ve Puanları**
- Kullanıcı adı
- Puan (1-5 yıldız)
- Yorum tarihi
- Yorum metni

Her yorum kartı halinde listelenir.

**ViewComponents:**
- `_CarDetailMainCarFeatureComponentPartial`
- `_CarDetailCarDescriptionByCarIdComponentPartial`
- `_CarDetailCarFeatureByCarIdComponentPartial`
- `_CarDetailCarPricingByCarIdComponentPartial`
- `_CarDetailReviewByCarIdComponentPartial`

> **Not:** Ekran görüntüleri eklenecek

---

### 4. Lokasyona Göre Araç Arama

**Yol:** `/RentACarList/Index`

Belirli bir şubede müsait araçları listeleme sayfası.

**Özellikler:**

📍 **Lokasyon Filtresi (ViewComponent)**
- Şube seçimi (Dropdown)
- "Araçları Listele" butonu

**Form:**
```csharp
[HttpPost]
public async Task<IActionResult> Index(int locationId)
{
    var client = _httpClientFactory.CreateClient();
    var url = $"https://localhost:7238/api/RentACars?locationId={locationId}&available=true";
    var responseMessage = await client.GetAsync(url);
    
    if (responseMessage.IsSuccessStatusCode)
    {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<FilterRentACarViewModel>>(jsonData);
        return View(values);
    }
    return View();
}
```

📊 **Sonuç Listesi**
Seçilen lokasyondaki müsait araçlar kartlar halinde gösterilir.

> **Not:** Ekran görüntüsü eklenecek

---

### 5. Rezervasyon Sayfası

**Yol:** `/Reservation/Index`

Online araç kiralama rezervasyonu yapma formu.

**Form Alanları:**

👤 **Kişisel Bilgiler**
- İsim
- Soyisim
- Email
- Telefon

🚗 **Kiralama Detayları**
- Araç seçimi (Dropdown)
- Alış lokasyonu (Dropdown)
- Teslim lokasyonu (Dropdown)

👨 **Sürücü Bilgileri**
- Yaş
- Ehliyet yılı

📝 **Ek Bilgiler**
- Özel istekler / notlar (textarea)

**API Endpoint:**
```
POST /api/Reservation/CreateReservation
```

**Validation:**
- Tüm zorunlu alanlar kontrol edilir
- Email format doğrulaması
- Yaş minimum 21 olmalı
- Ehliyet yılı minimum 1 olmalı

Başarılı rezervasyon sonrası onay mesajı gösterilir.

> **Not:** Ekran görüntüsü eklenecek

---

### 6. Blog Sayfası

**Yol:** `/Blog/Index`

Araç kiralama, seyahat ve otomobil dünyası hakkında blog yazıları.

**Özellikler:**

📰 **Blog Listesi**
Her blog için:
- Kapak görseli
- Başlık
- Yazar adı ve profil fotoğrafı
- Kategori
- Yayın tarihi
- Kısa özet
- Yorum sayısı
- "Devamını Oku" butonu

📂 **Sidebar (Yan Panel)**
- Son 3 blog yazısı
- Kategori listesi (filtreleme)
- Etiket bulutu (TagCloud)

---

### 7. Blog Detay Sayfası

**Yol:** `/Blog/BlogDetail/{id}`

Tek bir blog yazısının tüm içeriğini gösterir.

**Bölümler:**

📖 **Blog İçeriği**
- Tam blog metni (HTML formatında)
- Blog görseli
- Yayın tarihi

👨‍💼 **Yazar Bilgileri**
- Yazar adı
- Profil fotoğrafı
- Kısa biyografi

🏷️ **Etiketler**
Blog ile ilişkili etiketler

💬 **Yorum Bölümü**

**Mevcut Yorumlar:**
- Kullanıcı adı
- Yorum tarihi
- Yorum metni

**Yeni Yorum Formu:**
- İsim
- Email
- Yorum

```csharp
[HttpPost]
public async Task<IActionResult> AddComment(CreateCommentViewModel model)
{
    model.BlogId = id;
    model.CreatedDate = DateTime.Now;
    
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    await client.PostAsync("https://localhost:7238/api/Comment", content);
    return RedirectToAction("BlogDetail", new { id = model.BlogId });
}
```

> **Not:** Ekran görüntüleri eklenecek

---

### 8. Hakkımızda Sayfası

**Yol:** `/About/Index`

Şirket hakkında detaylı bilgilendirme sayfası.

**İçerik:**

🏢 **Şirket Hikayesi**
- Kuruluş bilgisi
- Misyon ve vizyon
- Değerlerimiz

👥 **Ekibimiz**
- Yönetim kadrosu
- Deneyimli personel

📊 **İstatistikler**
- Kuruluş yılından bu yana geçen süre
- Toplam araç sayısı
- Mutlu müşteri sayısı
- Şube sayısı

🎯 **Neden Biz?**
- Geniş araç filosu
- Uygun fiyatlar
- 7/24 müşteri hizmetleri
- Güvenli araçlar

> **Not:** Ekran görüntüsü eklenecek

---

### 9. Hizmetler Sayfası

**Yol:** `/Service/Index`

Sunulan hizmetlerin detaylı tanıtımı.

**Hizmetler:**

🚗 **Araç Kiralama Seçenekleri**
- Günlük kiralama
- Haftalık kiralama
- Aylık kiralama
- Şoförlü araç kiralama

🛡️ **Sigorta Paketleri**
- Tam kasko
- Mini kasko
- Ek sürücü sigortası

🗺️ **Ek Hizmetler**
- GPS navigasyon
- Çocuk koltuğu
- Ek sürücü
- Havalimanı transferi

⛽ **Yakıt Politikası**
- Tam/Tam
- Tam/Boş seçenekleri

Her hizmet için ikon, başlık ve açıklama bulunur.

> **Not:** Ekran görüntüsü eklenecek

---

### 10. İletişim Sayfası

**Yol:** `/Contact/Index`

İletişim bilgileri ve mesaj gönderme formu.

**Bölümler:**

📍 **İletişim Bilgileri**
- Adres
- Telefon
- Email
- Çalışma saatleri

📝 **İletişim Formu**
- İsim Soyisim
- Email
- Telefon
- Konu
- Mesaj

**Form İşleme:**
```csharp
[HttpPost]
public async Task<IActionResult> Index(CreateContactViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var response = await client.PostAsync("https://localhost:7238/api/Contact", content);
    
    if (response.IsSuccessStatusCode)
    {
        TempData["Success"] = "Mesajınız başarıyla gönderildi!";
    }
    return View();
}
```

🗺️ **Harita**
İşletmenin konumunu gösteren Google Maps entegrasyonu

> **Not:** Ekran görüntüsü eklenecek

---

## 🛡️ Admin Paneli

Admin paneli, **Area** yapısı ile ayrılmıştır ve sadece **Admin** rolüne sahip kullanıcılar erişebilir.

**Yol:** `/Admin/...`

**Layout:** Özel admin template (`_AdminLayout.cshtml`)

---

### 📊 1. Dashboard (Ana Kontrol Paneli)

**Yol:** `/Admin/AdminDashboard/Index`

Yönetim panelinin kalbidir. Tüm önemli metrikleri gösterir.

**İstatistik Kartları (ViewComponents):**

**🚗 Araç İstatistikleri**
- Toplam Araç Sayısı
- Otomatik Şanzıman Araç Sayısı
- Manuel Şanzıman Araç Sayısı
- Elektrikli Araç Sayısı
- Benzinli Araç Sayısı

**📍 Genel İstatistikler**
- Toplam Lokasyon Sayısı
- Toplam Marka Sayısı
- Toplam Blog Sayısı
- Toplam Yazar Sayısı

**💰 Fiyat İstatistikleri**
- Ortalama Günlük Fiyat
- Ortalama Haftalık Fiyat
- Ortalama Aylık Fiyat
- En Pahalı Araç
- En Ucuz Araç

**📊 Grafikler (Chart.js)**

**Pie Chart - Yakıt Türü Dağılımı:**
```javascript
var ctx = document.getElementById('fuelChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ['Benzin', 'Dizel', 'Elektrik', 'Hibrit'],
        datasets: [{
            data: [45, 30, 15, 10],
            backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0']
        }]
    }
});
```

**Bar Chart - Marka Bazlı Araç Sayıları:**
```javascript
var ctx = document.getElementById('brandChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['Mercedes', 'BMW', 'Audi', 'Ford', 'Toyota'],
        datasets: [{
            label: 'Araç Sayısı',
            data: [12, 8, 15, 10, 6],
            backgroundColor: '#36A2EB'
        }]
    }
});
```

**🔴 Gerçek Zamanlı Güncelleme (SignalR)**

Dashboard'daki tüm istatistikler SignalR ile gerçek zamanlı güncellenir.

**SignalR Hub (CarHub.cs):**
```csharp
public class CarHub : Hub
{
    private readonly IHttpClientFactory _httpClientFactory;

    public async Task CarCount()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7238/api/Statistics/CarCount");
        
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<CarCountViewModel>(jsonData);
            await Clients.All.SendAsync("CarCount", value.CarCount);
        }
    }
}
```

**Client-Side JavaScript:**
```javascript
$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7238/carHub")
        .build();

    connection.on("CarCount", function (count) {
        $("#carCountSpan").text(count);
    });

    connection.start().then(function () {
        console.log("SignalR bağlantısı kuruldu");
        setInterval(function () {
            connection.invoke("CarCount");
        }, 5000); // Her 5 saniyede bir güncelle
    });
});
```

> **Not:** Dashboard ekran görüntüsü eklenecek

---

### 🚙 2. Araç Yönetimi

**Yol:** `/Admin/AdminCar/Index`

Tüm araçların listelendiği ve CRUD işlemlerinin yapıldığı sayfa.

**Tablo Kolonları:**
- # (ID)
- Araç Görseli (Thumbnail)
- Marka
- Model
- Km
- Şanzıman
- Koltuk
- Bagaj
- Yakıt
- İşlemler (Düzenle / Sil)

**Üst Kısım:**
- 🔍 Arama çubuğu (araç adı, marka)
- ➕ "Yeni Araç Ekle" butonu

---

#### Araç Ekleme Sayfası

**Yol:** `/Admin/AdminCar/CreateCar`

**Form Alanları:**
- Marka (Dropdown - API'den çekilir)
- Kapak Görseli URL
- Büyük Görsel URL
- Kilometre
- Şanzıman (Otomatik/Manuel - Radio button)
- Koltuk Sayısı
- Bagaj Kapasitesi
- Yakıt Türü (Dropdown)

```csharp
[HttpPost]
public async Task<IActionResult> CreateCar(CreateCarViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var response = await client.PostAsync("https://localhost:7238/api/Cars", content);
    
    if (response.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return View(model);
}
```

---

#### Araç Güncelleme Sayfası

**Yol:** `/Admin/AdminCar/UpdateCar/{id}`

Seçilen aracın bilgilerini düzenleme formu. Mevcut veriler formda dolu gelir.

```csharp
[HttpGet]
public async Task<IActionResult> UpdateCar(int id)
{
    var client = _httpClientFactory.CreateClient();
    var response = await client.GetAsync($"https://localhost:7238/api/Cars/{id}");
    
    if (response.IsSuccessStatusCode)
    {
        var jsonData = await response.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<UpdateCarViewModel>(jsonData);
        return View(value);
    }
    return View();
}

[HttpPost]
public async Task<IActionResult> UpdateCar(UpdateCarViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var response = await client.PutAsync("https://localhost:7238/api/Cars", content);
    
    if (response.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return View(model);
}
```

---

#### Araç Silme

```csharp
public async Task<IActionResult> DeleteCar(int id)
{
    var client = _httpClientFactory.CreateClient();
    var response = await client.DeleteAsync($"https://localhost:7238/api/Cars/{id}");
    
    if (response.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return RedirectToAction("Index");
}
```

> **Not:** Ekran görüntüleri eklenecek

---

### ✨ 3. Araç Özellik Yönetimi

**Yol:** `/Admin/AdminCarFeatureDetail/Index/{id}`

Belirli bir araca özellik atama/çıkarma modülü.

**Çalışma Mantığı:**

1. Tüm özellikler listelenir (GPS, Klima, Bluetooth, Airbag, Deri Koltuk vb.)
2. Her özellik için bir checkbox bulunur
3. ✅ İşaretli olanlar → Araca atanmış özellikler
4. ❌ İşaretsiz olanlar → Araca atanmamış özellikler

**Checkbox Değiştirme:**

Kullanıcı checkbox'a tıkladığında AJAX ile API çağrısı yapılır:

```javascript
$(".carFeatureCheckbox").change(function () {
    var featureId = $(this).data('id');
    var isChecked = $(this).is(':checked');
    
    var url = isChecked 
        ? 'https://localhost:7238/api/CarFeature/CarFeatureChangeAvailableToTrue?id=' + featureId
        : 'https://localhost:7238/api/CarFeature/CarFeatureChangeAvailableToFalse?id=' + featureId;
    
    $.ajax({
        url: url,
        type: 'GET',
        success: function() {
            toastr.success('Özellik durumu güncellendi!');
        },
        error: function() {
            toastr.error('Bir hata oluştu!');
        }
    });
});
```

**API Endpoints:**
```
GET /api/CarFeature/CarFeatureChangeAvailableToTrue?id={id}
GET /api/CarFeature/CarFeatureChangeAvailableToFalse?id={id}
```

> **Not:** Ekran görüntüsü eklenecek

---

### 🏷️ 4. Marka Yönetimi

**Yol:** `/Admin/AdminBrand/Index`

Araç markalarının yönetildiği sayfa.

**Tablo:**
- # (ID)
- Marka Adı
- İşlemler (Düzenle / Sil)

**İşlemler:**
- Marka ekleme
- Marka güncelleme
- Marka silme

**Not:** Marka silinmeden önce, o markaya ait araç olup olmadığı kontrol edilmelidir.

> **Not:** Ekran görüntüsü eklenecek

---

### 🎨 5. Banner Yönetimi

**Yol:** `/Admin/AdminBanner/Index`

Ana sayfa hero banner'larını yönetme modülü.

**Form Alanları:**
- Başlık
- Açıklama
- Video URL (Opsiyonel)
- Buton Metni (örn: "Araçları İncele")
- Buton Linki

> **Not:** Ekran görüntüsü eklenecek

---

### ℹ️ 6. Hakkımızda Yönetimi

**Yol:** `/Admin/AdminAbout/Index`

Hakkımızda sayfası içeriğini düzenleme.

**Form Alanları:**
- Başlık
- Açıklama (Textarea - uzun metin)
- Görsel URL

**⚠️ Önemli:**
Sistem bütünlüğü için sadece **bir adet** "Hakkımızda" kaydı bulunmalıdır.

> **Not:** Ekran görüntüsü eklenecek

---

### 🛠️ 7. Servis Yönetimi

**Yol:** `/Admin/AdminService/Index`

Sunulan hizmetlerin yönetimi.

**Form Alanları:**
- Başlık
- Açıklama
- İkon Sınıfı (Font Awesome, örn: `fa-car`)

**Örnek Servisler:**
- Araç Kiralama
- Sigorta Paketleri
- GPS Navigasyon
- Havalimanı Transferi
- 7/24 Destek

> **Not:** Ekran görüntüsü eklenecek

---

### ⭐ 8. Müşteri Referansları

**Yol:** `/Admin/AdminTestimonial/Index`

Müşteri yorumlarının yönetimi.

**Form Alanları:**
- Müşteri Adı
- Müşteri Unvanı/Meslek
- Yorum Metni
- Profil Fotoğrafı URL
- Durum (Aktif/Pasif)

> **Not:** Ekran görüntüsü eklenecek

---

### 📝 9. Blog Yönetimi

**Yol:** `/Admin/AdminBlog/Index`

Blog yazılarının tam CRUD işlemleri.

**Tablo Kolonları:**
- # (ID)
- Başlık
- Yazar
- Kategori
- Yayın Tarihi
- Görsel
- İşlemler

**Ekleme/Güncelleme Formu:**
- Başlık
- Yazar Seçimi (Dropdown)
- Kategori Seçimi (Dropdown)
- Kapak Görseli URL
- Yayın Tarihi
- İçerik (HTML Editor / Textarea)

> **Not:** Ekran görüntüleri eklenecek

---

### 📂 10. Kategori Yönetimi

**Yol:** `/Admin/AdminCategory/Index`

Blog kategorilerinin yönetimi.

**Kolonlar:**
- # (ID)
- Kategori Adı
- İşlemler

> **Not:** Ekran görüntüsü eklenecek

---

### 👨‍💼 11. Yazar Yönetimi

**Yol:** `/Admin/AdminAuthor/Index`

Blog yazarlarının yönetimi.

**Form Alanları:**
- İsim
- Profil Fotoğrafı URL
- Hakkında (Bio)

> **Not:** Ekran görüntüsü eklenecek

---

### 💬 12. Yorum Yönetimi

**Yol:** `/Admin/AdminComment/Index`

Blog yorumlarının moderasyonu.

**Tablo:**
- # (ID)
- Kullanıcı Adı
- Blog Başlığı
- Yorum
- Tarih
- İşlemler (Onayla / Reddet / Sil)

> **Not:** Ekran görüntüsü eklenecek

---

### 📧 13. İletişim Mesajları

**Yol:** `/Admin/AdminContact/Index`

İletişim formundan gelen mesajlar.

**Kolonlar:**
- Ad Soyad
- Email
- Telefon
- Konu
- Mesaj
- Tarih
- İşlemler (Detay / Sil)

> **Not:** Ekran görüntüsü eklenecek

---

### 📍 14. Lokasyon Yönetimi

**Yol:** `/Admin/AdminLocation/Index`

Şube/lokasyon bilgilerinin yönetimi.

**Form Alanları:**
- Şube Adı
- Adres
- Telefon
- Email

> **Not:** Ekran görüntüsü eklenecek

---

### 💰 15. Fiyatlandırma Periyotları

**Yol:** `/Admin/AdminPricing/Index`

Fiyat dönemlerinin yönetimi.

**Örnekler:**
- Günlük (Daily)
- Haftalık (Weekly)
- Aylık (Monthly)

Bu periyotlar, CarPricing tablosunda kullanılır.

> **Not:** Ekran görüntüsü eklenecek

---

### 📌 16. Footer Ayarları

**Yol:** `/Admin/AdminFooterAddress/Index`

Footer'da gösterilecek iletişim bilgileri.

**Form Alanları:**
- Adres
- Telefon
- Email
- Açıklama

> **Not:** Ekran görüntüsü eklenecek

---

### 📱 17. Sosyal Medya Yönetimi

**Yol:** `/Admin/AdminSocialMedia/Index`

Sosyal medya platformlarının linklerini yönetme.

**Form Alanları:**
- Platform Adı (Facebook, Twitter, Instagram, LinkedIn)
- URL
- İkon

> **Not:** Ekran görüntüsü eklenecek

---

### 🏷️ 18. Blog Etiketleri (Tag Cloud)

**Yol:** `/Admin/AdminTagCloud/Index`

Blog yazılarına etiket atama.

**Kullanım:**
- Blog yazılarına birden fazla etiket atanabilir
- Etiket bazlı blog filtreleme
- SEO dostu URL'ler

> **Not:** Ekran görüntüsü eklenecek

---

### 📈 19. Detaylı İstatistikler Sayfası

**Yol:** `/Admin/AdminStatistics/Index`

Kapsamlı istatistik ve raporlama sayfası.

**İstatistik Grupları:**

**🚗 Araç İstatistikleri**
- Toplam Araç Sayısı
- Otomatik Şanzıman Sayısı
- Manuel Şanzıman Sayısı
- Elektrikli Araç Sayısı
- Benzinli Araç Sayısı
- Dizel Araç Sayısı
- Hibrit Araç Sayısı

**🏢 Marka İstatistikleri**
- En Çok Araca Sahip Marka
- En Az Araca Sahip Marka
- Toplam Marka Sayısı

**📝 Blog İstatistikleri**
- Toplam Blog Sayısı
- En Çok Yorumlanan Blog
- En Aktif Yazar
- Toplam Yorum Sayısı

**📍 Lokasyon İstatistikleri**
- Toplam Lokasyon Sayısı
- Her Lokasyondaki Araç Sayısı

**💰 Fiyat Analizi**
- Ortalama Günlük Fiyat
- Ortalama Haftalık Fiyat
- Ortalama Aylık Fiyat
- En Pahalı Araç
- En Ucuz Araç
- Fiyat Aralığı (Min-Max)

**API Çağrıları:**
```csharp
// İstatistik verilerini çekme
var carCount = await GetStatisticAsync("CarCount");
var brandCount = await GetStatisticAsync("BrandCount");
var avgDailyPrice = await GetStatisticAsync("AvgPriceForDaily");
var avgWeeklyPrice = await GetStatisticAsync("AvgPriceForWeekly");
var avgMonthlyPrice = await GetStatisticAsync("AvgPriceForMonthly");
```

> **Not:** İstatistikler ekran görüntüsü eklenecek

---

## 🔌 API Dokümantasyonu

Proje, **RESTful API** mimarisi kullanır. API, `https://localhost:7238` adresinde çalışır.

### 📍 API Base URL
```
https://localhost:7238/api
```

### 🔑 Ana Endpoint'ler

#### 1. Cars (Araçlar)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Cars` | Tüm araçları listele |
| GET | `/api/Cars/{id}` | ID'ye göre araç getir |
| GET | `/api/Cars/GetCarWithBrand` | Marka bilgisiyle araçlar |
| GET | `/api/Cars/GetLast5CarsWithBrands` | Son 5 araç (marka ile) |
| POST | `/api/Cars` | Yeni araç ekle |
| PUT | `/api/Cars` | Araç güncelle |
| DELETE | `/api/Cars/{id}` | Araç sil |

**Örnek Request (POST):**
```json
{
  "brandId": 1,
  "coverImageUrl": "https://example.com/car1.jpg",
  "km": 15000,
  "transmission": "Otomatik",
  "seat": 5,
  "luggage": 3,
  "fuel": "Benzin",
  "bigImageUrl": "https://example.com/car1-big.jpg"
}
```

**Örnek Response (GET):**
```json
{
  "carId": 1,
  "brandName": "Mercedes",
  "model": "C200",
  "coverImageUrl": "https://example.com/car1.jpg",
  "km": 15000,
  "transmission": "Otomatik",
  "seat": 5,
  "luggage": 3,
  "fuel": "Benzin"
}
```

---

#### 2. Brands (Markalar)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Brands` | Tüm markaları listele |
| GET | `/api/Brands/{id}` | ID'ye göre marka |
| POST | `/api/Brands` | Yeni marka ekle |
| PUT | `/api/Brands` | Marka güncelle |
| DELETE | `/api/Brands/{id}` | Marka sil |

---

#### 3. CarPricing (Araç Fiyatlandırma)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/CarPricings` | Tüm fiyatlandırmalar |
| GET | `/api/CarPricings/GetCarPricingWithTimePeriod` | Fiyat + dönem bilgisi |
| GET | `/api/CarPricings/GetCarPricingWithCar` | Araç bilgisiyle fiyatlar |

---

#### 4. Statistics (İstatistikler)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Statistics/CarCount` | Toplam araç sayısı |
| GET | `/api/Statistics/LocationCount` | Toplam lokasyon sayısı |
| GET | `/api/Statistics/BrandCount` | Toplam marka sayısı |
| GET | `/api/Statistics/BlogCount` | Toplam blog sayısı |
| GET | `/api/Statistics/AvgPriceForDaily` | Günlük ort. fiyat |
| GET | `/api/Statistics/AvgPriceForWeekly` | Haftalık ort. fiyat |
| GET | `/api/Statistics/AvgPriceForMonthly` | Aylık ort. fiyat |
| GET | `/api/Statistics/CarCountByTransmissionAuto` | Otomatik araç sayısı |
| GET | `/api/Statistics/CarCountByTransmissionManuel` | Manuel araç sayısı |
| GET | `/api/Statistics/CarCountByFuelElectric` | Elektrikli araç sayısı |
| GET | `/api/Statistics/CarCountByFuelGasoline` | Benzinli araç sayısı |
| GET | `/api/Statistics/CarCountByFuelDiesel` | Dizel araç sayısı |

**Örnek Response:**
```json
{
  "carCount": 45
}
```

---

#### 5. RentACar (Müsaitlik Sorgulama)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/RentACars?locationId={id}&available=true` | Lokasyona göre müsait araçlar |

---

#### 6. Reservation (Rezervasyon)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Reservation` | Tüm rezervasyonlar |
| POST | `/api/Reservation/CreateReservation` | Yeni rezervasyon oluştur |

**Örnek Request:**
```json
{
  "name": "Ahmet",
  "surname": "Yılmaz",
  "email": "ahmet@example.com",
  "phone": "05551234567",
  "carID": 5,
  "pickUpLocationID": 1,
  "dropOffLocationID": 2,
  "age": 30,
  "driveLicenseYear": 10,
  "description": "Saat 10:00'da teslim almak istiyorum",
  "status": "Pending"
}
```

---

#### 7. Blog

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Blog` | Tüm bloglar |
| GET | `/api/Blog/{id}` | ID'ye göre blog |
| GET | `/api/Blog/GetLast3BlogsWithAuthorsAndCategories` | Son 3 blog (yazar ve kategori ile) |
| GET | `/api/Blog/GetAllBlogsWithAuthorsAndCategories` | Tüm bloglar (ilişkili) |
| POST | `/api/Blog` | Yeni blog ekle |
| PUT | `/api/Blog` | Blog güncelle |
| DELETE | `/api/Blog/{id}` | Blog sil |

---

#### 8. Comments (Yorumlar)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Comment` | Tüm yorumlar |
| GET | `/api/Comment/CommentListByBlog/{blogId}` | Blog'a ait yorumlar |
| POST | `/api/Comment` | Yeni yorum ekle |
| DELETE | `/api/Comment/{id}` | Yorum sil |

---

#### 9. Reviews (Araç Yorumları)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Review` | Tüm değerlendirmeler |
| GET | `/api/Review/GetReviewByCarId/{carId}` | Araca ait yorumlar |
| POST | `/api/Review` | Yeni değerlendirme |
| PUT | `/api/Review` | Değerlendirme güncelle |
| DELETE | `/api/Review/{id}` | Değerlendirme sil |

---

#### 10. Contact (İletişim)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Contact` | Tüm mesajlar |
| POST | `/api/Contact` | Yeni mesaj gönder |
| DELETE | `/api/Contact/{id}` | Mesaj sil |

---

### 📝 API Kullanım Örnekleri (C#)

#### GET Request Örneği
```csharp
public async Task<IActionResult> GetCars()
{
    var client = _httpClientFactory.CreateClient();
    var responseMessage = await client.GetAsync("https://localhost:7238/api/Cars");
    
    if (responseMessage.IsSuccessStatusCode)
    {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCarViewModel>>(jsonData);
        return View(values);
    }
    return View();
}
```

#### POST Request Örneği
```csharp
public async Task<IActionResult> CreateCar(CreateCarViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var responseMessage = await client.PostAsync("https://localhost:7238/api/Cars", stringContent);
    
    if (responseMessage.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return View();
}
```

#### PUT Request Örneği
```csharp
public async Task<IActionResult> UpdateCar(UpdateCarViewModel model)
{
    var client = _httpClientFactory.CreateClient();
    var jsonData = JsonConvert.SerializeObject(model);
    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    
    var responseMessage = await client.PutAsync("https://localhost:7238/api/Cars", stringContent);
    
    if (responseMessage.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return View();
}
```

#### DELETE Request Örneği
```csharp
public async Task<IActionResult> DeleteCar(int id)
{
    var client = _httpClientFactory.CreateClient();
    var responseMessage = await client.DeleteAsync($"https://localhost:7238/api/Cars/{id}");
    
    if (responseMessage.IsSuccessStatusCode)
    {
        return RedirectToAction("Index");
    }
    return RedirectToAction("Index");
}
```

---

## 🚀 Kurulum ve Çalıştırma

### 📋 Gereksinimler

- ✅ .NET 8.0 SDK veya üzeri
- ✅ Visual Studio 2022 (Community/Professional/Enterprise)
- ✅ MSSQL Server (LocalDB, Express veya Developer)
- ✅ Git (Opsiyonel)

### 📥 1. Projeyi İndirme

**Git ile:**
```bash
git clone https://github.com/BerkayGenceroglu/CarBook.git
cd CarBook
```

**ZIP ile:**
- GitHub'dan "Code" → "Download ZIP" ile indir
- ZIP dosyasını çıkart

### 🔧 2. Veritabanı Ayarları

**a) Connection String Güncelleme**

`Infrastructure/CarBook.Persistence/Context/CarBookContext.cs` dosyasını açın:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Server=YOUR_SERVER_NAME;Database=CarBookDb;Trusted_Connection=True;TrustServerCertificate=True");
}
```

**YOUR_SERVER_NAME** kısmını kendi SQL Server isminizle değiştirin.

**Örnek Connection String'ler:**

LocalDB:
```
Server=(localdb)\\mssqllocaldb;Database=CarBookDb;Trusted_Connection=True;
```

SQL Server Express:
```
Server=.\\SQLEXPRESS;Database=CarBookDb;Trusted_Connection=True;TrustServerCertificate=True;
```

SQL Server (Windows Authentication):
```
Server=localhost;Database=CarBookDb;Trusted_Connection=True;TrustServerCertificate=True;
```

**b) Migration ve Database Oluşturma**

Visual Studio'da **Package Manager Console**'u açın (Tools → NuGet Package Manager → Package Manager Console)

```bash
# Default project olarak Infrastructure/CarBook.Persistence seçin
Add-Migration InitialCreate
Update-Database
```

Bu komutlar:
1. Migration dosyasını oluşturur
2. Veritabanını ve tabloları oluşturur

### ⚙️ 3. Projeleri Çalıştırma

**Seçenek 1: Tek Tek Çalıştırma**

1. **API Projesini Çalıştırma:**
   - Solution Explorer'da `CarBook.WebApi` projesine sağ tıklayın
   - "Set as Startup Project" seçin
   - F5 ile çalıştırın
   - Swagger UI açılacak: `https://localhost:7238/swagger`

2. **Web UI Projesini Çalıştırma:**
   - Solution Explorer'da `UdemyCarBook.WebUI` projesine sağ tıklayın
   - "Set as Startup Project" seçin
   - F5 ile çalıştırın
   - Tarayıcıda açılacak: `https://localhost:5001`

**Seçenek 2: Aynı Anda Çalıştırma (Önerilen)**

1. Solution'a sağ tıklayın → Properties
2. "Startup Project" → "Multiple startup projects"
3. Şu projeleri "Start" olarak ayarlayın:
   - `CarBook.WebApi`
   - `UdemyCarBook.WebUI`
4. OK → F5

### 👤 4. İlk Kullanıcı Oluşturma

Sisteme ilk giriş için bir admin kullanıcısı oluşturun:

**a) Kayıt Sayfasından:**
- `https://localhost:5001/Register/Index`
- Formu doldurup kayıt olun

**b) Veritabanından Manuel:**
```sql
-- AspNetUsers tablosuna admin kullanıcısı ekleyin
-- AspNetRoles tablosuna "Admin" rolü ekleyin
-- AspNetUserRoles ile kullanıcıyı Admin rolüne atayın
```

### ✅ 5. Test Etme

**Kullanıcı Tarafı:**
- Ana Sayfa: `https://localhost:5001`
- Araç Listesi: `https://localhost:5001/Car/Index`
- Blog: `https://localhost:5001/Blog/Index`

**Admin Paneli:**
- Dashboard: `https://localhost:5001/Admin/AdminDashboard/Index`
- Araç Yönetimi: `https://localhost:5001/Admin/AdminCar/Index`

**API:**
- Swagger: `https://localhost:7238/swagger`

---

## 🎓 Öğrenme Kaynakları

Bu proje ile şunları öğrenebilirsiniz:

### Backend
- ✅ ASP.NET Core 8.0 MVC
- ✅ ASP.NET Core Web API
- ✅ Entity Framework Core (Code First)
- ✅ N-Tier Architecture
- ✅ Onion Architecture
- ✅ CQRS Pattern
- ✅ Repository Pattern
- ✅ MediatR Pattern
- ✅ Dependency Injection
- ✅ ASP.NET Identity
- ✅ JWT Authentication
- ✅ FluentValidation

### Frontend
- ✅ Razor View Engine
- ✅ ViewComponent Kullanımı
- ✅ Partial View
- ✅ TempData / ViewBag / ViewData
- ✅ Layout Yapısı
- ✅ Area Kullanımı (Admin Panel)
- ✅ Bootstrap 5
- ✅ jQuery & AJAX
- ✅ Chart.js

### API
- ✅ RESTful API Tasarımı
- ✅ HTTP Metotları (GET, POST, PUT, DELETE)
- ✅ HttpClient Kullanımı
- ✅ API Consume (Tüketme)
- ✅ JSON Serializasyon/Deserializasyon
- ✅ DTO Pattern

### Gerçek Zamanlı
- ✅ SignalR Hub
- ✅ SignalR Client
- ✅ Real-Time Data Updates

---

## 🤝 Katkıda Bulunma

Projeye katkıda bulunmak isterseniz:

1. Bu repository'yi fork edin
2. Yeni bir branch oluşturun:
```bash
git checkout -b feature/YeniOzellik
```
3. Değişikliklerinizi commit edin:
```bash
git commit -m 'feat: Yeni özellik eklendi'
```
4. Branch'inizi push edin:
```bash
git push origin feature/YeniOzellik
```
5. Pull Request oluşturun

### Commit Mesajları
Lütfen anlamlı commit mesajları kullanın:
- `feat:` - Yeni özellik
- `fix:` - Hata düzeltme
- `docs:` - Dokümantasyon
- `style:` - Kod formatı
- `refactor:` - Kod iyileştirme
- `test:` - Test ekleme
- `chore:` - Genel işler

---

## 📝 Lisans

Bu proje eğitim amaçlı geliştirilmiştir ve MIT lisansı altındadır.

---

## 👤 Geliştirici

**Berkay Genceroğlu**

- 🌐 GitHub: [@BerkayGenceroglu](https://github.com/BerkayGenceroglu)
- 💼 LinkedIn: [Berkay Genceroğlu](https://www.linkedin.com/in/berkay-gencero%C4%9Flu/)
- 📧 Email: berkaygenceroglu6@gmail.com

---

## 🙏 Teşekkürler

Bu projeyi geliştirirken şu kaynaklardan faydalanılmıştır:

- Microsoft ASP.NET Core Documentation
- Entity Framework Core Documentation
- SignalR Documentation
- Stack Overflow Community
- GitHub Open Source Projects

---

## 📌 Önemli Notlar

### 🔗 Proje URL'leri

```
Web UI       : https://localhost:5001
API          : https://localhost:7238
Swagger UI   : https://localhost:7238/swagger
SignalR Hub  : https://localhost:7238/carHub
Admin Panel  : https://localhost:5001/Admin
```

### 🔐 Güvenlik

- Şifreler hash'lenerek saklanır
- API endpoint'leri için authentication gereklidir
- HTTPS kullanılır
- SQL Injection koruması (EF Core)
- XSS koruması

### ⚠️ Bilinen Sorunlar

- İlk çalıştırmada bazı görseller yüklenmeyebilir (placeholder görseller kullanılabilir)
- SignalR bağlantısı için her iki projenin de çalışıyor olması gerekir

---

<div align="center">

### ⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!

**Geliştirmeye devam ediyoruz... 🚀**

Made with ❤️ by Berkay Genceroğlu

</div>
