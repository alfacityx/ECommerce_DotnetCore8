# 🛒 E-Ticaret Uygulaması - .NET Core 8

![E-Commerce Platform](https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/dotnet/dotnet.png)

**Modern, Hızlı ve Kullanıcı Dostu E-Ticaret Çözümü**

[![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![EF Core](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

## ✨ Özellikler

### 📦 Ürün Yönetimi
* Kategoriler & Alt Kategoriler
* Ürün Varyantları
* Stok Yönetimi

### 👥 Kullanıcı Sistemi
* Müşteri Hesapları
* Rol Tabanlı Erişim
* Güvenli Kimlik Doğrulama

### 🛍️ Alışveriş Özellikleri
* Akıllı Sepet Sistemi
* Kolay Sipariş Süreci
* Ödeme Entegrasyonu

### 📊 Yönetici Paneli
* Görsel Raporlama
* Stok Kontrolü
* Kullanıcı Yönetimi

## 🏗️ Mimari Yapı

```mermaid
graph TD
    A[Web MVC Katmanı] --> B[Uygulama Katmanı]
    B --> C[Domain Katmanı]
    B --> D[Altyapı Katmanı]
    D --> E[(SQL Server)]
    style A fill:#4CAF50,stroke:#388E3C,color:white
    style B fill:#2196F3,stroke:#1976D2,color:white
    style C fill:#FFC107,stroke:#FFA000,color:black
    style D fill:#9C27B0,stroke:#7B1FA2,color:white
    style E fill:#F44336,stroke:#D32F2F,color:white
