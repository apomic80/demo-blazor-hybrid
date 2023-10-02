var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddFluxor(
    options =>
    {
        options.ScanAssemblies(typeof(MainLayout).Assembly);
#if DEBUG
        options.UseReduxDevTools();
#endif
    });

await builder.Build().RunAsync();
