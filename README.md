# 🚀Tic Tac Toe - C# Console App
This is a Tic Tac Toe game developed in C# using .NET 8.0.
The project runs in the console and includes:

Game logic encapsulated in classes (GameBoard, Player, GameManager)

Integration with a simulated API to register the result

Local result saving in a file named placar.txt

# 📁 project structure
- JogoDaVelhaAPI/
- │
- ├── Program.cs                 → Entry point
- ├── Game/
- │   ├── GameManager.cs         → Main logic of the game
- │   ├── Board.cs               → Board logic
- │   └── Player.cs              → Represents the players
- ├── Services/
- │   └── ApiService.cs          → Communication with the API (HttpClient)

# 🎮 How to Play
Clone the project in Visual Studio

Run the project (JogoDaVelhaAPI) as a console application

Enter the names of both players when prompted

Play alternately by entering a number from 1 to 9 corresponding to the board position

The game ends with:

A victory message

Or a draw

Result sent to the simulated API and saved locally in placar.txt.
