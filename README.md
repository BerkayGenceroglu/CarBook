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


<img width="970" height="864" alt="image" src="https://github.com/user-attachments/assets/81033ead-0c77-4a6e-9774-c89c5a06ea35" />



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

<img width="1919" height="944" alt="image" src="https://github.com/user-attachments/assets/50a552db-5db3-4754-a791-dc0d67700abe" />

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

 <img width="1920" height="947" alt="image" src="https://github.com/user-attachments/assets/caab8b3b-d6c3-4b37-aaee-69d618c26b00" />

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
<img width="1920" height="951" alt="image" src="https://github.com/user-attachments/assets/96b1c585-4b51-45c2-9e3a-0e90b9aca97b" />
<img width="1919" height="952" alt="image" src="https://github.com/user-attachments/assets/8cde0ff1-c1b8-41e5-b68b-8e467d6856e2" />
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/f993b604-efd8-4eb3-bc0e-fd81b9bbd370" />
<img width="1914" height="952" alt="image" src="https://github.com/user-attachments/assets/fcad3b0f-0a4f-4fdf-8be9-61658d8d9b44" />
<img width="1920" height="955" alt="image" src="https://github.com/user-attachments/assets/8d5053a7-c6a6-4d65-9e5a-3c94c39d8918" />
<img width="1920" height="770" alt="image" src="https://github.com/user-attachments/assets/41c3dbf5-fbff-4f1a-8bfe-920f1e1258ef" />
<img width="1917" height="932" alt="image" src="https://github.com/user-attachments/assets/58273e95-d44f-4ee6-b111-11ce6c0f1ea9" />
<img width="1920" height="943" alt="image" src="https://github.com/user-attachments/assets/85c6c818-853c-4b5f-b32e-5ca6ccfb070f" />
<img width="1919" height="950" alt="image" src="https://github.com/user-attachments/assets/4d4be169-93c7-477e-bd09-e957bf1e9952" />
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/174b1558-6531-4ab2-ab25-d0261b7d7796" />
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/d4e88194-4c7f-410c-8ae8-1ac3a9aaf315" />
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/1ff456a6-3fcc-4c36-82e6-b80457d00dd8" />

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
  
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/e152aa5f-095a-4ae1-a58f-f8c5fab5fcfa" />
<img width="1920" height="944" alt="image" src="https://github.com/user-attachments/assets/8aa26d52-70c1-474c-ad7b-3eb6bb0d19d9" />
<img width="1917" height="950" alt="image" src="https://github.com/user-attachments/assets/4c2076f2-d32c-40b3-9552-c6069ef0ab82" />
<img width="1919" height="956" alt="image" src="https://github.com/user-attachments/assets/6fedb616-289a-4fb3-82dd-9a29e3bb1d0d" />
<img width="1916" height="953" alt="image" src="https://github.com/user-attachments/assets/86e1a069-b6cb-47ce-928e-35606e131db4" />
<img width="1915" height="949" alt="image" src="https://github.com/user-attachments/assets/0a005106-add8-4de0-a5cd-12e34c60e5b2" />





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
<img width="1914" height="952" alt="image" src="https://github.com/user-attachments/assets/2d52313a-5c02-4a92-a544-d40073d64f5f" />
<img width="1915" height="453" alt="image" src="https://github.com/user-attachments/assets/4d7f6674-3780-43e0-a55c-5ed68e6f81c0" />
<img width="1921" height="453" alt="image" src="https://github.com/user-attachments/assets/ce580423-70ff-480a-807e-f54bc997d2e1" />
<img width="1920" height="950" alt="image" src="https://github.com/user-attachments/assets/9b9e668a-b530-46fa-93c7-76b1e6ead41d" />

---

#### 4. Lokasyona Göre Araç Arama (Rent A Car List)

**Yol:** `/RentACarList/Index`

**Açıklama:** Belirli bir lokasyonda müsait araçları listeleme.

**Özellikler:**
- 📍 **Lokasyon Seçimi** - Dropdown liste ile şube seçimi
- 📅 **Müsaitlik Kontrolü** - Seçilen lokasyondaki müsait araçlar
- 🔄 **Filtre Formu** - ViewComponent ile dinamik filtreleme
- 📊 **Sonuç Listesi** - Müsait araçların detaylı kartları
<img width="1917" height="948" alt="image" src="https://github.com/user-attachments/assets/a8543cab-74a6-4934-b00e-db992bfb5176" />


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

<img width="1917" height="951" alt="image" src="https://github.com/user-attachments/assets/8f7a57a5-3409-4bc9-86e5-7af69c0a82c0" />
<img width="1919" height="949" alt="image" src="https://github.com/user-attachments/assets/184d4c22-564a-4c97-bd7f-306447d27237" />


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

<img width="1920" height="956" alt="image" src="https://github.com/user-attachments/assets/d621110a-d6bd-47a4-a488-bde6e6c72421" />

<img width="1920" height="952" alt="image" src="https://github.com/user-attachments/assets/1290fdd6-1086-4d7e-ae98-4a7fe1fd7ea9" />


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

<img width="1915" height="956" alt="image" src="https://github.com/user-attachments/assets/ac597c71-10ae-4ff7-b303-fe4eeecc9ef5" />

<img width="1918" height="953" alt="image" src="https://github.com/user-attachments/assets/09267cef-0e63-4ae5-a273-cba24a69ad88" />

<img width="1915" height="955" alt="image" src="https://github.com/user-attachments/assets/32656454-1e73-469f-825f-1f34ed69341c" />

<img width="1916" height="947" alt="image" src="https://github.com/user-attachments/assets/09c7f4eb-d21a-4da6-9c30-62434de475ad" />

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
<img width="1919" height="950" alt="image" src="https://github.com/user-attachments/assets/1ac05cb5-2383-4eb4-9e0e-2356ac18954e" />
<img width="1919" height="950" alt="image" src="https://github.com/user-attachments/assets/22f01d78-f6f3-43be-b0be-e92768a409e7" />

---
#### 8. Kampanya Sayfası (CampaignCar)

**Yol:** `/CampaignCar/Index`

**Açıklama:** Aktif kampanyalar, özel teklifler ve indirimli kiralama fırsatlarının listelendiği sayfa.

**İçerik:**
- 🏢 Kampanya Kategorileri
- 👥  Son günler (süresi dolmak üzere)
- 🎯 En yüksek indirimler
- 📊  Uzun dönem fırsatları
- 🌟 Öğrenci/kurumsal indirimler
<img width="1920" height="960" alt="image" src="https://github.com/user-attachments/assets/8e8b5772-dc85-46a4-898c-e4a472202c6d" />

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

<img width="1920" height="858" alt="image" src="https://github.com/user-attachments/assets/4704a243-c6a7-4124-b41e-bb998fab1749" />

<img width="1920" height="948" alt="image" src="https://github.com/user-attachments/assets/ab39f375-0fa3-4c91-8f58-64ccb5f34844" />

<img width="1920" height="946" alt="image" src="https://github.com/user-attachments/assets/9b09c4fc-46d1-49fa-9e0d-bc1a5366a35c" />



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
<img width="1920" height="956" alt="image" src="https://github.com/user-attachments/assets/4cd6b43b-6339-49dd-ba9b-32e7905ce38c" />
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/689fe7d8-08f1-4e05-8446-22877f69e227" />



---
#### 2. İstatistikler Sayfası (Admin Statistics)

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

<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/627eb869-af1d-4c22-aee4-5d126b13df70" />
<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/94427b52-5169-41fd-a486-f5da5734d566" />

---

#### 3. Araç Yönetimi (Admin Car)

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
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/e472db7e-19dd-4da3-976b-3ea57dfe533a" />

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
<img width="1920" height="957" alt="image" src="https://github.com/user-attachments/assets/a5db41ec-4640-4ab8-932a-d9e95a64aaab" />
<img width="1133" height="824" alt="image" src="https://github.com/user-attachments/assets/e20c365f-9813-4063-8e0a-95041adba988" />


**Güncelleme:** `/Admin/AdminCar/UpdateCar/{id}`
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/1743c469-6a6a-40fd-8f13-493b1aa21b0a" />
<img width="1471" height="881" alt="image" src="https://github.com/user-attachments/assets/b0266ddd-c3c6-43e4-855f-bb6f2c9a19f1" />




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
<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/c24af145-e9ab-411f-a1cd-cac8e1c423be" />
<img width="1920" height="952" alt="image" src="https://github.com/user-attachments/assets/46098ecc-48ff-42df-aec0-24ff1c083822" />



#### 4. Araç Özellik Listesi (Admin Feature)
**Çalışma Mantığı:**
- Tüm özellikler listelenir (GPS, Klima, Bluetooth vs.)
<img width="1920" height="946" alt="image" src="https://github.com/user-attachments/assets/ef0e5f24-ea01-49f0-9adb-2699fdd2b00d" />
<img width="1920" height="958" alt="image" src="https://github.com/user-attachments/assets/c87130e5-1b7d-4dc1-9585-f766b60abfe7" />
<img width="1918" height="955" alt="image" src="https://github.com/user-attachments/assets/0b5eb048-71ab-441a-977c-77a017ad9cc9" />



---

#### 4. Marka Yönetimi (Admin Brand)

**Yol:** `/Admin/AdminBrand/Index`

**Özellikler:**
- Marka listesi (Mercedes, BMW, Audi, Ford vs.)
- Yeni marka ekleme
- Marka düzenleme
- Marka silme
<img width="1918" height="950" alt="image" src="https://github.com/user-attachments/assets/ba249642-4b2e-472b-acc2-c119625514d7" />
<img width="1920" height="946" alt="image" src="https://github.com/user-attachments/assets/5c5debab-2dda-4760-b8f8-968c430e4412" />
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/a03b3f04-381f-4c2a-b0d7-74e0e003ffcd" />
<img width="1918" height="954" alt="image" src="https://github.com/user-attachments/assets/e5ddb726-4c3e-48e6-994e-8460e8b61e32" />

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
<img width="1920" height="955" alt="image" src="https://github.com/user-attachments/assets/ad19ecd7-bd13-4417-8ea6-7b1f82a92407" />
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/0297f144-18e5-4bc4-bb26-8a624dd776d3" />
<img width="1919" height="947" alt="image" src="https://github.com/user-attachments/assets/f276c2b6-a729-4bc7-8c0d-f4579831597b" />


---

#### 6. Hakkımızda Yönetimi (Admin About)

**Yol:** `/Admin/AdminAbout/Index`

**Açıklama:** Hakkımızda sayfası içeriğini düzenleme.

**Form Alanları:**
- Başlık
- Açıklama (Uzun metin - textarea)
- Görsel URL
<img width="1920" height="952" alt="image" src="https://github.com/user-attachments/assets/9d92da5c-298d-4b22-960b-ed8365a4b601" />
<img width="1920" height="956" alt="image" src="https://github.com/user-attachments/assets/4bb2fe1f-19ed-4a5f-be1b-f6ca0650d63c" />
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/242fe54d-5b6c-4227-924b-5d887a01f207" />
<img width="1919" height="950" alt="image" src="https://github.com/user-attachments/assets/93bbb205-156f-4849-8340-25c8f52af3e8" />
---

#### 7. Servis Yönetimi (Admin Service)

**Yol:** `/Admin/AdminService/Index`

**Özellikler:**
- Servis listesi
- Yeni servis ekleme
- Her servis için: Başlık, Açıklama, İkon
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/f3efdcce-c297-4bb4-ad1c-43f76b45ec50" />
<img width="1920" height="948" alt="image" src="https://github.com/user-attachments/assets/c965fc96-2792-442a-942d-bca28392d6fb" />
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/5314dc6e-68b3-4e82-b84a-2ee820c1c298" />
<img width="1919" height="952" alt="image" src="https://github.com/user-attachments/assets/ba3c635f-e733-4755-9b81-9edd15173807" />

---

#### 8. Müşteri Referansları (Admin Testimonial)

**Yol:** `/Admin/AdminTestimonial/Index`

**Form Alanları:**
- Müşteri adı
- Müşteri unvanı
- Yorum metni
- Profil fotoğrafı URL
<img width="1918" height="951" alt="image" src="https://github.com/user-attachments/assets/a3afaf43-1d2a-4b81-a122-2a964c31837e" />
<img width="1918" height="953" alt="image" src="https://github.com/user-attachments/assets/fe4c6b2b-6dbb-4b91-b25b-6c7fded2ad1d" />
<img width="1918" height="956" alt="image" src="https://github.com/user-attachments/assets/19d000c0-18ba-48b2-81d8-e277290a2e06" />


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
<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/7898b43a-d100-4dfd-8730-0096b17838d3" />
<img width="1920" height="940" alt="image" src="https://github.com/user-attachments/assets/9144fd98-1ec4-4e0f-95d6-f8fc7ffb2bb5" />
<img width="1910" height="948" alt="image" src="https://github.com/user-attachments/assets/ebb92073-0672-4147-a0f9-dbd8475ac8fc" />
---

#### 10. Kategori Yönetimi (Admin Category)

**Yol:** `/Admin/AdminCategory/Index`

**İşlemler:**
- Kategori listesi
- Yeni kategori ekleme
- Kategori düzenleme
- Kategori silme
<img width="1920" height="958" alt="image" src="https://github.com/user-attachments/assets/a4ad44a9-d41f-4ef9-a61e-4e8613eab0c8" />
<img width="1920" height="950" alt="image" src="https://github.com/user-attachments/assets/d735e137-e09d-486a-86a7-bad371e0ecaf" />
<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/77659ebb-6069-45fe-a659-509d0e4e5035" />

<img width="1914" height="947" alt="image" src="https://github.com/user-attachments/assets/5ed6d7b7-88b1-4298-ab44-46ad2676a9e3" />
---

#### 11. Yazar Yönetimi (Admin Author)

**Yol:** `/Admin/AdminAuthor/Index`

**Form Alanları:**
- İsim
- Profil fotoğrafı
- Açıklama
- Blog sayısı (otomatik hesaplanır)
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/93e1f7e0-3c85-4405-bd42-2efa4379393b" />
<img width="1920" height="943" alt="image" src="https://github.com/user-attachments/assets/2be06754-1af6-4877-a147-1b792dec1c9c" />
<img width="1919" height="952" alt="image" src="https://github.com/user-attachments/assets/7f259090-8b31-48a5-b4b5-2fe6819475bc" />
<img width="1920" height="942" alt="image" src="https://github.com/user-attachments/assets/ef502f83-8509-4fc9-8a8e-09d6c83ba7ee" />
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
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/730e642c-845b-4fa1-9017-400a572d8690" />

---

#### 14. Lokasyon Yönetimi (Admin Location)

**Yol:** `/Admin/AdminLocation/Index`

**Form Alanları:**
- Şube adı
- Adres
- Telefon
- Email
<img width="1920" height="960" alt="image" src="https://github.com/user-attachments/assets/b8516818-3a39-47c7-8384-c0de33b53cad" />
<img width="1920" height="950" alt="image" src="https://github.com/user-attachments/assets/b65d9ae1-fbb1-4402-a907-1797a0b27542" />
<img width="1919" height="958" alt="image" src="https://github.com/user-attachments/assets/91e4ee11-57cb-4b8f-a0b3-e2ad80904f60" />
<img width="1920" height="940" alt="image" src="https://github.com/user-attachments/assets/70b95654-6041-455e-ad1d-509f10a1275b" />

---

#### 15. Fiyatlandırma Periyotları (Admin Pricing)

**Yol:** `/Admin/AdminPricing/Index`

**Örnekler:**
- Günlük (Daily)
- Haftalık (Weekly)
- Aylık (Monthly)

<img width="1920" height="946" alt="image" src="https://github.com/user-attachments/assets/f7c4609d-5ca8-495e-8d95-e94ed0ae66b9" />
<img width="1912" height="946" alt="image" src="https://github.com/user-attachments/assets/c7b92add-79f7-45a6-9754-559cddb0fb7c" />
<img width="1920" height="947" alt="image" src="https://github.com/user-attachments/assets/16bbf547-644a-4c17-8711-763a20bfebd3" />



---

#### 16. Footer Ayarları (Admin Footer Address)

**Yol:** `/Admin/AdminFooterAddress/Index`

**Form Alanları:**
- Adres
- Telefon
- Email
- Açıklama
<img width="1919" height="957" alt="image" src="https://github.com/user-attachments/assets/cf4b5719-e70a-413c-8555-5280cb9691a1" />
<img width="1920" height="944" alt="image" src="https://github.com/user-attachments/assets/d20a970c-d5bb-4c20-9edd-7a0dc0c58e3e" />
<img width="1920" height="957" alt="image" src="https://github.com/user-attachments/assets/0054c572-201e-427c-b522-56afc9c011c2" />
<img width="1920" height="955" alt="image" src="https://github.com/user-attachments/assets/106d6b5d-9737-4288-916e-c8028e4a57e1" />

---

#### 17. Sosyal Medya (Admin Social Media)

**Yol:** `/Admin/AdminSocialMedia/Index`

**İçerik:**
- Facebook URL
- Twitter URL
- Instagram URL
- LinkedIn URL
- İkon seçimi

<img width="1920" height="948" alt="image" src="https://github.com/user-attachments/assets/45bcbf99-a49f-42a7-89f8-9bfefd22b7b5" />
<img width="1920" height="943" alt="image" src="https://github.com/user-attachments/assets/fb31b179-349f-4e9e-894f-8228ec274e30" />

---

#### 18. Blog Etiketleri (Admin Tag Cloud)

**Yol:** `/Admin/AdminTagCloud/Index`

**Kullanım:**
- Blog yazılarına etiket atama
- Etiket bazlı arama
- Her blog için birden fazla etiket
<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/151e1f5a-c0cc-4a7a-a187-4c2ce60fa2af" />
<img width="1920" height="951" alt="image" src="https://github.com/user-attachments/assets/1360bfe9-63a0-4613-a46b-12b718f2a0c9" />
<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/200b7355-663d-4439-8034-1c25a130eeed" />
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/e26825f3-79e1-4db2-ab10-76014abd6e7e" />



---
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


## 📝 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

---

## 👤 Geliştirici

**Berkay Genceroğlu**

- GitHub: [@BerkayGenceroglu](https://github.com/BerkayGenceroglu)
- LinkedIn: [Berkay Genceroğlu](https://www.linkedin.com/in/berkay-gencero%C4%9Flu/)

---








