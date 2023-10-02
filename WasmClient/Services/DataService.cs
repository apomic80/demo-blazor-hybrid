namespace WasmClient.Services;

public class DataService(IJSRuntime js) : IDataService
{
    public async Task<string> RequestData()
    {
        return await js.InvokeAsync<string>(
            "prompt", 
            "insert to do:");
    }
}