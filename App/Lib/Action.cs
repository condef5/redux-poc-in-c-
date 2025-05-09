namespace ReduxToolkitExample.App.lib;

public interface IAction
{
    string Type { get; }
}

public static class ActionCreator
{
    public static T CreateAction<T>() where T : IAction, new() => new T();
}