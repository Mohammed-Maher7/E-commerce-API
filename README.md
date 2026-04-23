# 🛒 E-Commerce API
Scalable E-Commerce REST API — ASP.NET Core, Onion Architecture, Stripe, Redis, EF Core, SQL Server

---

## 🏗️ Architecture

This project follows **Onion Architecture** pattern:

| Layer | Project | Responsibility |
|---|---|---|
| Presentation | E-commerce.API | Controllers, Middlewares |
| Business Logic | E-commerce.Service | Services, Validations |
| Domain | E-commerce.Core | Entities, Interfaces, DTOs |
| Data Access | E-commerce.Repository | DbContext, Repositories |

---

## 🛠️ Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Redis
- Stripe
- JWT Authentication

---

## 🚀 Getting Started

### 1. Clone the repo

git clone https://github.com/Mohammed-Maher7/E-commerce-API.git
cd E-commerce-API

### 2. Setup User Secrets

cd E-commerce.API
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_CONNECTION_STRING"
dotnet user-secrets set "JWT:SecretKey" "YOUR_SECRET_KEY"
dotnet user-secrets set "Stripe:SecretKey" "YOUR_STRIPE_KEY"
dotnet user-secrets set "Stripe:PublishableKey" "YOUR_STRIPE_KEY"

### 3. Run

dotnet run

---

## 👤 Author

**Mohammed Maher** - [@Mohammed-Maher7](https://github.com/Mohammed-Maher7)
