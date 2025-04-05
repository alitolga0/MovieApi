
# 🎬 Movie REST API

Bu proje, film, oyuncu, yönetmen ve kategori verilerini yöneten bir .NET 8 tabanlı RESTful Web API'dir. Başlangıçta .NET 7 ve MSSQL kullanılarak geliştirilen proje, Docker Compose ile containerize edilmiş; sonrasında PostgreSQL'e geçilerek .NET 8'e yükseltilmiş ve Azure'a deploy edilmiştir.

## 🚀 Özellikler

- Film, Oyuncu, Yönetmen ve Kategori CRUD işlemleri
- Katmanlı mimari (Controller, Service, Repository)
- Unit of Work & Generic Repository Pattern
- FluentValidation ile veri doğrulama
- PostgreSQL veritabanı entegrasyonu
- Docker Compose ile container bazlı mimari
- Azure App Service’e deploy edilmiştir

---

## 🧱 Proje Mimarisi

```
MovieRestApi/
├── Controllers          # API uç noktaları
├── Core                # Service & Repository arayüzleri ve yardımcılar
├── Migrations          # EF Core migration dosyaları
├── Models              # Entity sınıfları
├── Repository          # DB context ve repository implementasyonları
├── Service             # İş katmanı (abstract + concrete servisler)
├── Validators          # FluentValidation sınıfları
├── Program.cs          # Uygulama giriş noktası
├── appsettings.json    # Konfigürasyon dosyaları
```

---

## 🧪 Kullanılan Teknolojiler

- .NET 8
- Entity Framework Core
- PostgreSQL
- Docker & Docker Compose
- Azure App Service
- FluentValidation
- AutoMapper
- C#

---

## ⚙️ Kurulum

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/alitolga0/MovieApi.git
cd MovieRestApi
```

### 2. .env Dosyasını Oluşturun (isteğe bağlı)

Ortam değişkenlerini yönetmek için bir `.env` dosyası oluşturabilirsiniz.

### 3. Docker ile Başlatın

```bash
docker-compose up --build
```

> Docker Compose, API’yi ve PostgreSQL veritabanını birlikte ayağa kaldıracaktır.

---

## 🌐 API Endpoint Örnekleri

| Metot | Endpoint                  | Açıklama             |
|-------|---------------------------|----------------------|
| GET   | /api/movies               | Tüm filmleri getirir |
| POST  | /api/actors               | Yeni aktör ekler     |
| PUT   | /api/categories/{id}      | Kategori günceller   |
| DELETE| /api/directors/{id}       | Yönetmen siler       |

---

## 🧪 EF Core Migration Komutları

Yeni migration oluşturmak için:

```bash
Add-Migration MigrationAdi
Update-Database
```

> Not: `MovieRestApi` projesi, `MainDbContext` içeren ana proje olmalıdır.

---

## ☁️ Azure Deploy Bilgisi

Proje, Azure App Service'e **Zip Deploy** yöntemiyle yayınlanmıştır. İlgili profil `Properties/ServiceDependencies/` klasöründe yer almaktadır.

---

## 🛠 Geliştirme Notları

- Proje ilk olarak MSSQL veritabanı ile geliştirilmiş, daha sonra PostgreSQL’e taşınmıştır.
- `.NET 7` kullanılarak başlanan proje `.NET 8`’e yükseltilmiştir.
- Controller katmanı sade ve yalnızca servisleri çağırır, business logic service katmanında yönetilir.
- Validasyon işlemleri `FluentValidation` ile yapılmaktadır.
- API dışa kapalı olup, kimlik doğrulama özelliği henüz eklenmemiştir (isteğe bağlı olarak genişletilebilir).

---
