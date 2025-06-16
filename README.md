# 🏋️‍♂️ TrainingPlansApi – ASP.NET Core MVC + REST API

Aplikacja webowa do zarządzania planami treningowymi stworzona w technologii ASP.NET Core. Obsługuje dodawanie, edycję, przeglądanie i usuwanie planów – przez REST API oraz klasyczne Razor Views.

---

## 📌 Opis projektu
Ten projekt łączy **MVC (Razor)** i **REST API** z dostępem do **SQL Servera** przy użyciu **Entity Framework Core**.
Funkcjonalności:
- ✅ Interfejs użytkownika (Views): Community, Create, Edit
- ✅ REST API: GET / POST / PUT / DELETE planów
- ✅ Model z walidacją `[Required]`
- ✅ Obsługa błędów (`ErrorViewModel`)
- ✅ SQL Server z konfigurowalnym connection stringiem

---

## 📂 Struktura katalogów
<code>
TrainingPlansApi/
│
├── Controllers/ # Kontrolery MVC i API
│ ├── HomeController.cs
│ ├── PlansController.cs
│ └── TrainingPlansController.cs
│
├── Data/
│ └── TrainingPlansContext.cs
│
├── Migrations/ # EF Core – snapshot i migracje
│
├── Models/
│ ├── ErrorViewModel.cs
│ └── TrainingPlan.cs
│
├── Views/ # Razor views
│ ├── Home/
│ ├── Plans/
│ └── Shared/
│
├── wwwroot/ # CSS, JS, favicon
├── appsettings.json # Connection string
├── Program.cs # Bootstrap aplikacji
└── SQL.sql # (opcjonalny) skrypt tworzący bazę
</code>

---

## 📦 Modele danych
## TrainingPlan.cs
<code>
public class TrainingPlan
{
    public int Id { get; set; }

    [Required] public string? Name { get; set; }
    [Required] public string? TrainingDays { get; set; }
    [Required] public string Exercises { get; set; }
    [Required] public string CreatedBy { get; set; }
    [Required] public string Description { get; set; }
    [Required] public DateTime CreatedAt { get; set; }
}
</code>

## 🧭 Routing i kontrolery
## 🔧 TrainingPlansController (REST API)
| Metoda | Trasa                     | Opis                          |
| ------ | ------------------------- | ----------------------------- |
| GET    | `/api/TrainingPlans`      | Pobiera wszystkie plany       |
| GET    | `/api/TrainingPlans/{id}` | Pobiera plan po ID            |
| POST   | `/api/TrainingPlans/post` | Dodaje plan                   |
| POST   | `/api/TrainingPlans/add`  | Alternatywny POST (formularz) |
| PUT    | `/api/TrainingPlans/{id}` | Aktualizuje plan              |
| DELETE | `/api/TrainingPlans/{id}` | Usuwa plan                    |

## 🎨 PlansController (Views)
- /Plans/Community – Lista planów
- /Plans/Create – Formularz tworzenia
- /Plans/Edit/{id} – Formularz edycji
- POST Plans/UpdatePlan – Zapis zmian

## 🏠 HomeController
- / – Strona główna (Index)
- /Home/Error – Obsługa błędów (ErrorViewModel)

## 🛠️ Konfiguracja bazy danych
- Plik: appsettings.json
<code>
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=TrainingPlansDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
}
</code>

- Klasa: TrainingPlansContext.cs
<code>
public class TrainingPlansContext : DbContext
{
    public DbSet<TrainingPlan> TrainingPlans { get; set; }
    public TrainingPlansContext(DbContextOptions<TrainingPlansContext> options) : base(options) { }

}
</code>

## 📌 Uwagi końcowe
- Projekt oparty na ASP.NET Core MVC + Web API
- Nie wymaga zewnętrznej bazy danych do testów (można użyć InMemory EF Core)
- Gotowy do integracji z frontendem lub aplikacją mobilną
