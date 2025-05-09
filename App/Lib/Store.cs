namespace ReduxToolkitExample.App.lib;

public class Store<TState>
{
    private TState _state;
    private readonly Func<TState, object, TState> _reducer;
    private event Action<TState> StateChanged;

    public Store(TState initialState, Func<TState, object, TState> reducer)
    {
        _state = initialState;
        _reducer = reducer;
    }

    public TState GetState() => _state;

    public void Dispatch(object action)
    {
        _state = _reducer(_state, action);
        StateChanged?.Invoke(_state);
    }

    public void Subscribe(Action<TState> handler)
    {
        StateChanged += handler;
    }
}
