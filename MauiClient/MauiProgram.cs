namespace MauiClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<IDataService, DataService>();
        
        builder.Services.AddFluxor(
            options =>
            {
                options
                    .WithLifetime(StoreLifetime.Singleton)
                    .ScanAssemblies(typeof(MainLayout).Assembly);
            });

        return builder.Build();
    }
}