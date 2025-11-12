using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
class Program
{
    static async Task Main()
    {
        // Crear el cliente HTTP
        using (HttpClient client = new HttpClient())
        {
            // URL de ejemplo: una API pública gratuita
            string url = "https://jsonplaceholder.typicode.com/todos/1";

            try
            {
                // Enviar la petición GET
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                Todo todo = JsonSerializer.Deserialize<Todo>(content);
                Console.WriteLine($"Tarea #{todo.Id}: {todo.Title} (Completada:{todo.Completed})");

                Console.WriteLine("Respuesta recibida:");
                Console.WriteLine(content);
            }

            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error en la solicitud:{e.Message}");
            }
        }
    }
}

