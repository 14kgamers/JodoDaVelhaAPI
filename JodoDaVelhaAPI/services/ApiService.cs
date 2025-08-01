using System.Net.Http;
using System.Text;
using System.Text.Json;




namespace JodoDaVelhaAPI.services
{
    public class ApiService
    {
        private readonly HttpClient _client = new();

        public async Task GetPreviousScoreAsync()
        {
            try
            {
                var response = await _client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Previous score:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving score: " + ex.Message);
            }
        }


        public async Task SendResultAsync(string winner)
        {
            var data = new {vencedor = winner, data = DateTime.Now };
            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "aplication/json");

            try
            {
                var response = await _client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Result sent : ");
                Console.WriteLine(result);
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Erro ao enviar resultado: " + ex.Message);
            }

        }
    }

}
