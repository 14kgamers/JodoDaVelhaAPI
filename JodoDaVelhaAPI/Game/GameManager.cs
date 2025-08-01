using System.Reflection;
using JodoDaVelhaAPI.services;


namespace JodoDaVelhaAPI.Game
{
    public class GameManager
    {
        private readonly Board _board = new();
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly ApiService _api = new();

        public GameManager()
        {
            Console.WriteLine("Enter the player's name 1 (X): ");
            _player1 = new Player(Console.ReadLine() ?? "Player 1", 'X');

            Console.WriteLine("Enter the player's name 2 (O): ");
            _player2 = new Player(Console.ReadLine() ?? "Player 2", 'O');
        }

        public async Task StartGameAsync()
        {
            await _api.GetPreviousScoreAsync();

            int currentPlayer = 1;
            int result;

            do
            {
                Console.Clear();
                Console.WriteLine("Jogo da Velha");
                _board.Display();

                Player player = currentPlayer % 2 == 1 ? _player1 : _player2;
                Console.WriteLine($"\n{player.Name}, choose a position: ");
                if ( int.TryParse( Console.ReadLine(), out int pos ) && _board.MakeMove(pos, player.Mark))
                {
                    currentPlayer++;
                }
                else
                {
                    Console.WriteLine("Invalid move. Press Enter to try again.");
                    Console.ReadLine();
                }

                result = _board.CheckWinner();

            } while ( result == -1 );

            Console.Clear();
            _board.Display();

            if ( result == 1 )
            {
                Player winner = currentPlayer % 2== 0 ? _player1 : _player2;
                Console.WriteLine($"\nCongratulations, {winner.Name} Win!");

                await _api.SendResultAsync(winner.Name);
                SalvarResultadoLocal(winner.Name);
            }
            else
            {
                Console.WriteLine("\nDraw!");
                await _api.SendResultAsync("Draw");
                SalvarResultadoLocal("Draw");

            }
            Console.WriteLine("End Game.");
        }

        private void SalvarResultadoLocal(string vencedor)
        {
            string caminho = "placar.txt";
            string texto = $"Result: {vencedor} - {DateTime.Now}\n";

            try
            {
                File.AppendAllText(caminho, texto);
                Console.WriteLine("Result saved locally in 'placar.txt'. ");
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error saving locally " + ex.Message); ;
            }
        }
    }
}
