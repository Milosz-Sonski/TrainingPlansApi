using Microsoft.EntityFrameworkCore;
using TrainingPlansApi.Models;

namespace TrainingPlansApi.Data
{
    // Kontekst bazy danych w systemie
    public class TrainingPlansContext : DbContext
    {
        // Umożliwia przekazanie opcji konfiguracyjnych dla kontekstu bazy danych,
        public TrainingPlansContext(DbContextOptions<TrainingPlansContext> options) : base(options) { }
        // Pozwala na operowanie na danych związanych z planami treningowymi w bazie danych
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
    }
}

