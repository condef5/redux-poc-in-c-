# Redux Toolkit Example in C# (.NET)

This project is a Proof of Concept (POC) demonstrating a Redux-like state management pattern in C# using .NET. It is inspired by the Redux Toolkit commonly used in JavaScript/TypeScript, but implemented with C# idioms such as records, immutability, and delegates.

## Features
- Immutable state management
- Actions and reducers
- Store with subscription support
- Example domain: Battle state with players and turn management

## Project Structure
```
/ReduxToolkitExample.sln          # Solution file
/App/
  App.csproj                     # Project file
  Program.cs                     # Main entry point and usage example
  BattleStore.cs                 # Battle state, actions, and reducer
  /Lib/
    Action.cs                    # Action interface
    Reducer.cs                   # Reducer builder/creator
    Store.cs                     # Store implementation
```

## How to Run

1. **Ensure you have [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or later installed.**

2. **Restore dependencies (if any):**
   ```sh
   dotnet restore App/App.csproj
   ```

3. **Build the project:**
   ```sh
   dotnet build App/App.csproj
   ```

4. **Run the example:**
   ```sh
   dotnet run --project App/App.csproj
   ```

You should see output in the console showing the state changes as actions are dispatched to the store.

## Example Output
```
Current state => Turns: 1, Players: []
Current state => Turns: 6, Players: []
Current state => Turns: 9, Players: []
Current state => Turns: 9, Players: [Alice]
Current state => Turns: 9, Players: [Alice, Bob]
Current state => Turns: 8, Players: [Alice, Bob]
Last state => Turns: 8, Players: [Alice, Bob]
```

## How It Works
- **Actions**: Represent state changes (e.g., `IncreaseTurnAction`, `AddPlayerAction`).
- **Reducer**: Pure functions that calculate the new state based on the current state and an action.
- **Store**: Holds the state, allows dispatching actions, and supports subscriptions to state changes.
- **BattleStore**: Example implementation for managing turns and players.

## Customization
You can add new actions, state fields, and reducer logic by following the patterns in `BattleStore.cs` and the `Lib` folder.

## License
This POC is for demonstration purposes only. Feel free to use or modify it as needed.
