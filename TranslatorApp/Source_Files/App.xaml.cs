using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TranslatorApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade databaseFacade = new DatabaseFacade(new DataContext());
            databaseFacade.EnsureCreated();
        }
    }
}
