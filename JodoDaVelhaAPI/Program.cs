using JodoDaVelhaAPI.Game;

class Program
{
    static async Task Main(string[] args)
    {
        GameManager jogo = new();
        await jogo.StartGameAsync();
    }
}