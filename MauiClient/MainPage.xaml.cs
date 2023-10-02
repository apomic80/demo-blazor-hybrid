using Microsoft.AspNetCore.Components;

namespace MauiClient;

public partial class MainPage : ContentPage
{
    
    public MainPage(IStore store)
    {
        store.InitializeAsync().Wait();

        InitializeComponent();
    }
}