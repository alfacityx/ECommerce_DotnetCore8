# ECommerce_DotnetCore8

## 🛒 Modern E-Ticaret Projesi

Bu proje, .NET Core 8 teknolojisi kullanılarak geliştirilmiş modern bir e-ticaret uygulamasıdır. Clean Architecture prensipleri ile tasarlanmış, sürdürülebilir ve genişletilebilir bir e-ticaret çözümü sunar.

---

## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Teknolojiler](#-teknolojiler)
- [Mimari](#-mimari)
- [Kurulum](#-kurulum)
- [Proje Yapısı](#-proje-yapısı)
- [Kullanım](#-kullanım)
- [Katkıda Bulunma](#-katkıda-bulunma)
- [Lisans](#-lisans)
- [İletişim](#-iletişim)

---

## ✨ Özellikler

- 🔄 N-Tier mimarisi
- 📦 Repository ve Unit of Work desenleri
- 🧩 MediatR ile CQRS yapısı
- 🔒 Kapsamlı kullanıcı yetkilendirme ve kimlik doğrulama
- 🛍️ Gelişmiş sepet yönetimi
- 📊 Ürün kataloğu ve kategori yapısı
- 📱 Responsive tasarım
- 🔍 Gelişmiş arama ve filtreleme
- 🌐 Multi-language desteği

---

## 🔧 Teknolojiler

- **.NET Core 8** - Ana framework
- **Entity Framework Core** - ORM 
- **Blazor** - UI framework
- **FluentValidation** - Doğrulama kütüphanesi
- **SQL Server** - Veritabanı
- **SignalR** - Gerçek zamanlı iletişim
- **Identity** - Kullanıcı yönetimi

---

## 🏗 Mimari

Bu proje Clean Architecture prensiplerine göre katmanlı bir yapıda tasarlanmıştır:
ECommerce_DotnetCore8
```
├── src
│   ├── Core
│   │   ├── Domain           # Varlıklar, değer nesneleri, enum'lar
│   │   └── Application      # İş mantığı, CQRS, arayüzler
│   │
│   ├── Infrastructure
│   │   ├── Persistence      # Veritabanı erişimi, repository
│   │   ├── Identity         # Kimlik doğrulama, yetkilendirme
│   │   └── Infrastructure   # Harici servis entegrasyonları
│   │
│   └── Presentation
│       ├── Web              # Blazor UI
│       └── Shared           # Paylaşılan UI bileşenleri
│
├── tests
│   ├── UnitTests
│   ├── IntegrationTests
│   └── FunctionalTests
```
---

## 🚀 Kurulum

### Gereksinimler:

- .NET 8 SDK
- SQL Server (veya başka desteklenen veritabanı)
- Visual Studio 2022, VS Code veya JetBrains Rider

---

## 📁 Proje Yapısı

### Domain Layer

- **Varlıklar**: Ürün, Kategori, Sepet, Kullanıcı, Sipariş
- **Değer Nesneleri**: Adres, Para, Renk, Boyut
- **Olaylar**: SiparişTamamlandı, StokAzaldı
- **Enum'lar**: SiparişDurumu, ÖdemeTürü

### Application Layer

- **CQRS**: Komutlar ve sorgular
- **Validasyon**: Veri doğrulama kuralları
- **Dto'lar**: Veri transfer nesneleri
- **Arayüzler**: Repository ve servis arayüzleri

### Infrastructure Layer

- **Veritabanı**: EF Core konfigürasyonları
- **Repository**: Veri erişim implementasyonları
- **Servisler**: E-posta, SMS, ödeme entegrasyonları

### Presentation Layer

- **Sayfalar**: Katalog, Ürün Detay, Sepet, Ödeme, Profil
- **Bileşenler**: Filtreleme, Pagination, Ürün Kartı
- **Layouts**: Ana Sayfa, Yönetim Paneli

---

## 💡 Kullanım

### Müşteri Deneyimi

- 🔍 Ürünleri arama ve filtreleme
- 🛒 Sepete ürün ekleme
- 💳 Ödeme işlemi
- 📦 Sipariş takibi
- 👤 Kullanıcı profil yönetimi

### Yönetici Paneli

- 📊 Satış istatistikleri
- 📝 Ürün ve kategori yönetimi
- 👥 Kullanıcı yönetimi
- 🚚 Sipariş yönetimi

---

## 👥 Katkıda Bulunma

1. Bu repoyu fork edin
2. Feature branch oluşturun (`git checkout -b feature/yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -m 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/yeni-ozellik`)
5. Pull Request açın

---

## 📄 Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.

---

## 📞 İletişim

Proje Sahibi: [alfacityx](https://github.com/alfacityx)

Proje Bağlantısı: [https://github.com/alfacityx/ECommerce_DotnetCore8](https://github.com/alfacityx/ECommerce_DotnetCore8)
