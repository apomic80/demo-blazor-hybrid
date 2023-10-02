var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddFluxor(
    options =>
    {
        options.ScanAssemblies(typeof(MainLayout).Assembly);
#if DEBUG
        options.UseReduxDevTools();
#endif
    });

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
