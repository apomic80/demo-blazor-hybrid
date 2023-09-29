namespace UILib.Store;

public class ToDoStore
{
    [FeatureState]
    public record State
    {
        public ImmutableList<string> Items { get; init; }
            = ImmutableList<string>.Empty;
    }

    public record AddItemToListAction(string Item);
    public record RemoveItemFromListAction(string Item);

    [ReducerMethod]
    public static State AddItemToListActionReducer(State state, AddItemToListAction action)
    {
        var item = action.Item?.Trim();
        if (string.IsNullOrEmpty(item)) return state;
        return state with { Items = state.Items.Add(item) };
    }
    
    [ReducerMethod]
    public static State RemoveItemFromListActionReducer(State state, RemoveItemFromListAction action)
    {
        var item = action.Item?.Trim();
        if (string.IsNullOrEmpty(item)) return state;
        return state with { Items = state.Items.Remove(item) };
    }
}