using Microsoft.Extensions.Logging;
using TP4BlazorHybrid.Services;
using System.Net.Http;

namespace TP4BlazorHybrid
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddSingleton<ProductCache>();
#endif      
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                
                    BaseAddress = new Uri("https://fakestoreapi.com/")
                
                });

            builder.Services.AddScoped<ProductService>();

            return builder.Build();
        }
    }
}
