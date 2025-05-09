
using ReduxToolkitExample.App.lib;

namespace ReduxToolkitExample.App;

public abstract class Program
{
    static void Main()
    {
        var store = new Store<BattleState>(BattleStore.InitialState, BattleStore.Reducer);

        store.Subscribe(state =>
        {
            var playerNames = string.Join(", ", state.Players.Select(p => p.Username));
            Console.WriteLine($"Current state => Turns: {state.Turns}, Players: [{playerNames}]");
        });
        
        store.Dispatch(new IncreaseTurnAction());
        store.Dispatch(new IncreaseTurnAction(TurnsToAdd: 5));
        store.Dispatch(new IncreaseTurnAction(TurnsToAdd: 3));
        store.Dispatch(new AddPlayerAction(new PlayerDto("1", "Alice")));
        store.Dispatch(new AddPlayerAction(new PlayerDto("2", "Bob")));
        store.Dispatch(new DecreaseTurnAction());
        
        var lastState = store.GetState();
        Console.WriteLine($"Last state => Turns: {lastState.Turns}, Players: [{string.Join(", ", lastState.Players.Select(p => p.Username))}]");
    }
}