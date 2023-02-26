using Chickeng.Domain.Services;
using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using Chickeng.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Chickeng.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(RegisterServices)
                .Build();
        }

        public void RegisterServices(HostBuilderContext context, IServiceCollection services)
        {
            IConfiguration configuaration = context.Configuration;

            var env = configuaration.GetValue<string>("LaunchOptions:Environment") 
                ?? throw new ArgumentNullException("Deployment environment not found");

            string? connectionString = null;
            if (env.Equals("DEV", StringComparison.OrdinalIgnoreCase))
            {
                connectionString = configuaration.GetConnectionString("Default");
            }
            else if (env.Equals("PROD", StringComparison.OrdinalIgnoreCase))
            {
                var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var propramPath = configuaration.GetValue<string>("LaunchOptions:ProgramPath") ?? string.Empty;
                var fileName = "chickeng-prod.db";
                var fullPath = Path.Combine(folder, propramPath, fileName);
                connectionString = $"Data Source={fullPath}";
            }
            else
            {
                throw new ArgumentNullException("Deployment environment not defined");
            }

            if (connectionString == null)
                throw new ArgumentNullException("Sqlite connection string was null");

            #region DI Func Create ViewModel
            services.AddDbContext<ChickengDbContext>(o => o.UseSqlite(connectionString), ServiceLifetime.Singleton);

            services.AddTransient<VocabularyService>();
            services.AddTransient<PhraseService>();

            services.AddTransient<HomeViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<VocabularyTableViewModel>();
            services.AddTransient<PhraseTableViewModel>();
            services.AddTransient<VocabularyEditViewModel>();
            services.AddTransient<PhraseEditViewModel>();

            services.AddSingleton<Func<HomeViewModel>>(s => () => s.GetRequiredService<HomeViewModel>());
            services.AddSingleton<Func<MainViewModel>>(s => () => s.GetRequiredService<MainViewModel>());
            services.AddSingleton<Func<VocabularyTableViewModel>>(s => () => s.GetRequiredService<VocabularyTableViewModel>());
            services.AddSingleton<Func<PhraseTableViewModel>>(s => () => s.GetRequiredService<PhraseTableViewModel>());
            services.AddSingleton<Func<VocabularyEditViewModel>>(s => () => s.GetRequiredService<VocabularyEditViewModel>());
            services.AddSingleton<Func<PhraseEditViewModel>>(s => () => s.GetRequiredService<PhraseEditViewModel>());
            #endregion

            #region DI Service
            services.AddSingleton<NavigationService<HomeViewModel>>();
            services.AddSingleton<NavigationService<VocabularyTableViewModel>>();
            services.AddSingleton<NavigationService<PhraseTableViewModel>>();
            services.AddSingleton<NavigationService<VocabularyEditViewModel>>();
            services.AddSingleton<NavigationService<PhraseEditViewModel>>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton(s => new MainWindow(s.GetRequiredService<NavigationService<HomeViewModel>>())
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            #endregion
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // call migrate() include (ensure create database & migrate schema)
            using var scope = _host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ChickengDbContext>();
            db.Database.Migrate();

            // starting as HOST
            _host.Start();

            var navigationService = _host.Services.GetRequiredService<NavigationService<HomeViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
