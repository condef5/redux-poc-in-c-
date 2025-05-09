namespace ReduxToolkitExample.App.lib;

public static class ReducerCreator
{
    public static Func<TState, object, TState> CreateReducer<TState>(
        Action<ReducerBuilder<TState>> builderAction)
    {
        var builder = new ReducerBuilder<TState>();
        builderAction(builder);
        return builder.Build();
    }
}

public class ReducerBuilder<TState>
{
    private readonly List<(Type ActionType, Func<TState, object, TState> Handler)> _handlers = new();

    public ReducerBuilder<TState> AddCase<TAction>(
        Func<TState, TAction, TState> handler) where TAction : class, IAction
    {
        _handlers.Add((typeof(TAction), (state, action) => handler(state, (TAction)action)));
        return this;
    }

    public Func<TState, object, TState> Build()
    {
        return (state, action) =>
        {
            foreach (var (actionType, handler) in _handlers)
            {
                if (action.GetType() == actionType)
                {
                    return handler(state, action);
                }
            }
            return state;
        };
    }
}