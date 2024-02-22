using BTGClient.Core.DbContext;
using BTGClient.Core.Repositories;
using BTGClient.Core.Repositories.Interfaces;
using BTGClient.Utils;
using BTGClient.Utils.Interfaces;
using BTGClient.ViewModels;
using BTGClient.Views;
using Microsoft.Maui.Controls.Hosting;

namespace BTGClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //builder.Services.AddSingleton<ClientListViewModel>();
            builder.Services.AddSingleton<ClientListPage>();
           // builder.Services.AddSingleton<ClientViewModel>();
            builder.Services.AddSingleton<ClientPage>();
            builder.Services.AddSingleton<DbContext>();
            builder.Services.AddSingleton<IClientRepository, ClientRespository>();
            builder.Services.AddSingleton<IAddresRepository, AddressRepository>();
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();

            builder.Services.AddViewModel<ClientListViewModel, ClientListPage>();
            builder.Services.AddViewModel<ClientViewModel, ClientPage>();

            return builder.Build();
        }

        private static void AddViewModel<TViewModel, TView>(this IServiceCollection services)
            where TView : ContentPage, new()
            where TViewModel : class
        {
            services.AddTransient<TViewModel>();
            services.AddTransient<TView>(s => new TView() { BindingContext = s.GetRequiredService<TViewModel>() });
        }
    }
}
