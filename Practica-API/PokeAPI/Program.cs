using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

class Program
{
    static HttpClient? client;

    static async Task Main(string[] args)
    {
        HttpClientHandler clientHandler = new HttpClientHandler(); 
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true; 
        client = new HttpClient(clientHandler);
        client.DefaultRequestHeaders.UserAgent.ParseAdd("CSharpApp/1.0");
        
        while (true)
        {
            await MainMenu();
        }
    }

    static async Task MainMenu()
    {
        Console.WriteLine("=========== MENÚ PRINCIPAL ===========");
        Console.WriteLine("1. Pokédex de Kanto");
        Console.WriteLine("2. Jardín de Bayas");
        Console.WriteLine("3. Salir");

        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await PokeMenu();
                break;

            case "2":
                await BerryMenu();
                break;

            case "3":
                Console.WriteLine("¡Muchas gracias por usar nuestro servicio!");
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Opción no válida.\n");
                break;
        }
    }

    static async Task PokeMenu()
    {
        Console.WriteLine("============== PokeMENÚ ==============");
        Console.WriteLine("¿Cómo quieres buscar?");
        Console.WriteLine("1. Por Nombre");
        Console.WriteLine("2. Por Pokédex ID");
        Console.WriteLine("3. Por Color");
        Console.WriteLine("4. Por Fase Evolutiva");
        Console.WriteLine("5. Por Tipo");
        Console.WriteLine("6. Salir");

        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
                Console.WriteLine("Funcionalidad no implementada aún.\n");
                break;

            case "6":
                Console.WriteLine("Saliendo...\n");
                break;

            default:
                Console.WriteLine("Opción no válida.\n");
                break;
        }
    }

    static async Task BerryMenu()
    {
        Console.WriteLine(">>> DEBUG: Entré a BerryMenu()");
        Console.WriteLine("============= Berry MENÚ =============");
        Console.WriteLine("1. Por ID");
        Console.WriteLine("2. Por Sabor");
        Console.WriteLine("3. Por Color");
        Console.WriteLine("4. Salir\n");

        string? option = Console.ReadLine();
        Console.WriteLine($"DEBUG opción recibida: '{option}'");

        switch (option)
        {
            case "1":
                Console.Write("ID de la Berry: ");
                string? berryID = Console.ReadLine();
                Console.WriteLine($"DEBUG berryID: '{berryID}'");

                if (!string.IsNullOrWhiteSpace(berryID))
                {
                    var berry = await GetBerryID(berryID);

                    if (berry != null)
                    {
                        Console.WriteLine("===========================");
                        Console.WriteLine($"Nombre: {berry.Name}");
                        Console.WriteLine($"Suavidad: {berry.Smoothness}");
                        Console.WriteLine($"Tiempo crecimiento: {berry.Growth_time}");
                        Console.WriteLine($"Sabor principal: {berry.Flavors[0].Flavor.Name}");
                        Console.WriteLine("===========================\n");
                    }
                }
                break;

            case "2":
            case "3":
                Console.WriteLine("Funcionalidad no implementada aún.\n");
                break;

            case "4":
                Console.WriteLine("Saliendo...\n");
                break;

            default:
                Console.WriteLine("Opción no válida.\n");
                break;
        }
    }

    static async Task<Berry?> GetBerryID(string id)
    {
        try
        {
            var response = await client.GetAsync($"https://pokeapi.co/api/v2/berry/{id}/");
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"No se encontró la berry '{id}'. Código HTTP: {response.StatusCode}\n");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                Berry? berry = JsonSerializer.Deserialize<Berry>(content);
                return berry;
            }
            catch (JsonException je)
            {
                Console.WriteLine($"Error al deserializar la respuesta de la API: {je.Message}\n");
                return null;
            }
        }
        catch (HttpRequestException hre)
        {
            Console.WriteLine($"Error de conexión con la API: {hre.Message}\n");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}\n");
            return null;
        }
    }
}

