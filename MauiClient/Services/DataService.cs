namespace MauiClient.Services;

public class DataService(MainPage mainPage) : IDataService
{
    public async Task<string> RequestData()
    {
        return await mainPage.DisplayPromptAsync("To Do", "insert to do:");
    }
}