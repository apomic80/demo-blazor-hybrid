using Microsoft.AspNetCore.Components;

namespace MauiClient;

public partial class MainPage : ContentPage
{
    private readonly List<string> _items = new();

    public void RemoveItemFromList(string item)
    {
        _items.Remove(item);
    }

    private void AddItemToList(string item)
    {
        _items.Add(item);
    }
    
    public MainPage()
    {
        InitializeComponent();
        
        rootComponent.Parameters = 
            new Dictionary<string, object>
            {
                { "Items", _items },
                { "OnAddItemRequested", new EventCallbackFactory().Create<string>(this, AddItemToList) }, 
                { "OnDeleteItemRequested", new EventCallbackFactory().Create<string>(this, RemoveItemFromList)  }
            };
        
    }
}