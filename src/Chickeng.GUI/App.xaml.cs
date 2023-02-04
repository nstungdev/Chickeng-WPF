using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

            // Write code below
            string? connectionString = configuaration.GetConnectionString("Default");

            if (connectionString == null)
                throw new ArgumentNullException("Sqlite connection string was null");

            #region DI Func Create ViewModel
            services.AddTransient<HomeViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<VocabularyTableViewModel>();
            services.AddTransient<PhraseTableViewModel>();
            services.AddTransient<VocabularyEditViewModel>();

            services.AddSingleton<Func<HomeViewModel>>(s => () => s.GetRequiredService<HomeViewModel>());
            services.AddSingleton<Func<VocabularyTableViewModel>>(s => () => s.GetRequiredService<VocabularyTableViewModel>());
            services.AddSingleton<Func<PhraseTableViewModel>>(s => () => s.GetRequiredService<PhraseTableViewModel>());
            services.AddSingleton<Func<VocabularyEditViewModel>>(s => () => s.GetRequiredService<VocabularyEditViewModel>());
            #endregion

            #region DI Service
            services.AddSingleton<NavigationService<HomeViewModel>>();
            services.AddSingleton<NavigationService<VocabularyTableViewModel>>();
            services.AddSingleton<NavigationService<PhraseTableViewModel>>();
            services.AddSingleton<NavigationService<VocabularyEditViewModel>>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            #endregion
        }

        protected override void OnStartup(StartupEventArgs e)
        {
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
