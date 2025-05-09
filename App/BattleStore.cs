using ReduxToolkitExample.App.lib;

namespace ReduxToolkitExample.App;

public record PlayerDto(string Id, string Username);

public record BattleState(int Turns, List<PlayerDto> Players);

public record IncreaseTurnAction(int TurnsToAdd = 1) : IAction
{
    public string Type => "INCREASE_TURN";
}

public record DecreaseTurnAction : IAction
{
    public string Type => "DECREASE_TURN";
}

public record AddPlayerAction(PlayerDto Player) : IAction
{
    public string Type => "ADD_PLAYER";
}

public static class BattleStore
{
    public static readonly Func<BattleState, object, BattleState> Reducer = ReducerCreator.CreateReducer<BattleState>(builder =>
    {
        builder.AddCase<IncreaseTurnAction>((state, action) => state with { Turns = state.Turns + 1 });

        builder.AddCase<DecreaseTurnAction>((state, action) => state with { Turns = state.Turns - 1 });
        
        builder.AddCase<AddPlayerAction>((state, action) =>
        {
            // Create a new list to maintain immutability
            var newPlayers = new List<PlayerDto>(state.Players) { action.Player };
            return state with { Players = newPlayers };
        });
    });
    
    public static readonly BattleState InitialState = new BattleState(Turns: 0, Players: new List<PlayerDto>());
}