using Microsoft.EntityFrameworkCore;
using TranslatorApp.Pages;

namespace TranslatorApp
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = VocabularyDatabase.db");
        }

        public DbSet<Word> Words { get; set; }
    }
}
