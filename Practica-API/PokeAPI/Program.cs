
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Drawing;

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
        Console.WriteLine("1. Pokédex de Universal");
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
        Console.WriteLine("3. Por Tipo");
        Console.WriteLine("4. Salir");

        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Write("Nombre del Pokemon: ");
                string pokeName = Console.ReadLine();
                Console.WriteLine($"DEBUG pokeName: '{pokeName}'");

                if (!string.IsNullOrEmpty(pokeName))
                {
                    var pokemon = await GetPokemonByName(pokeName);

                    if(pokemon != null)
                    {
                        Console.WriteLine("\n===========================");
                        Console.WriteLine($"Nombre: {pokemon.Name}");
                        Console.WriteLine($"Número Pokédex: {pokemon.DexNumber}");
                        Console.WriteLine($"Color: {pokemon.Color}");
                        Console.WriteLine($"Tipos: {string.Join(", ", pokemon.Types)}");
                        Console.WriteLine($"Fase evolutiva: {pokemon.EvolutionStage}");
                        Console.WriteLine("===========================\n");
                    } else
                    {
                        Console.WriteLine($"No se encontro a {pokeName} en la API");
                    }
                }
                break;

            case "2":
                Console.Write("Numero de la Pokedex: ");
                int pokeID = Int32.Parse(Console.ReadLine());

                if (pokeID > 0)
                {
                    var pokemon = await GetPokemonByID(pokeID);
                    if(pokemon != null)
                    {
                        Console.WriteLine("\n===========================");
                        Console.WriteLine($"Nombre: {pokemon.Name}");
                        Console.WriteLine($"Número Pokédex: {pokemon.DexNumber}");
                        Console.WriteLine($"Color: {pokemon.Color}");
                        Console.WriteLine($"Tipos: {string.Join(", ", pokemon.Types)}");
                        Console.WriteLine($"Fase evolutiva: {pokemon.EvolutionStage}");
                        Console.WriteLine("===========================\n");
                    } else
                    {
                        Console.WriteLine($"No se encontro al Pokemon {pokeID} en la API");
                    }
                }
                break;

            case "3":
                Console.Write("Tipo primario del Pokemon: ");
                string? pokeType = Console.ReadLine()?.Trim().ToLower();

                if (!string.IsNullOrEmpty(pokeType))
                {
                    var pokemons = await GetPokemonByType(pokeType);

                    if (pokemons.Count > 0)
                    {
                        foreach (var pokemon in pokemons)
                        {
                            Console.WriteLine("\n===========================");
                            Console.WriteLine($"Nombre: {pokemon.Name}");
                            Console.WriteLine($"Número Pokédex: {pokemon.DexNumber}");
                            Console.WriteLine($"Color: {pokemon.Color}");
                            Console.WriteLine($"Tipos: {string.Join(", ", pokemon.Types)}");
                            Console.WriteLine($"Fase evolutiva: {pokemon.EvolutionStage}");
                            Console.WriteLine("===========================\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ningún Pokémon con tipo '{pokeType}'.\n");
                    }
                }
                break;

            case "4":
                Console.WriteLine("Saliendo...\n");
                break;

            default:
                Console.WriteLine("Opción no válida.\n");
                break;
        }
    }

    static async Task BerryMenu()
    {
        Console.WriteLine("\n============= Berry MENÚ =============");
        Console.WriteLine("1. Por ID");
        Console.WriteLine("2. Por Sabor");
        Console.WriteLine("3. Por Tipo");
        Console.WriteLine("4. Salir\n");

        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Write("ID de la Berry: ");
                string? berryID = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(berryID))
                {
                    var berry = await GetBerryByID(berryID);

                    if (berry != null)
                    {
                        Console.WriteLine("\n===========================");
                        Console.WriteLine($"Nombre: {berry.Name}");
                        Console.WriteLine($"Suavidad: {berry.Smoothness}");
                        Console.WriteLine($"Tiempo crecimiento: {berry.GrowthTime}");
                        Console.WriteLine($"Sabor principal: {berry.Flavors[0].Flavor.Name}");
                        Console.WriteLine("===========================\n");
                    }
                }
                break;

            case "2":
                Console.Write("Sabor de la Berry: ");
                string? berryFlavor = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(berryFlavor))
                {
                    var berries = await GetBerryByFlavor(berryFlavor);

                    foreach(var berry in berries)
                    {
                        if (berry != null)
                        {
                            Console.WriteLine("\n===========================");
                            Console.WriteLine($"Nombre: {berry.Name}");
                            Console.WriteLine($"Suavidad: {berry.Smoothness}");
                            Console.WriteLine($"Tiempo crecimiento: {berry.GrowthTime}");
                            Console.WriteLine($"Tamaño estándar: {berry.Size}");
                            Console.WriteLine("===========================\n");
                        }
                    }
                }
                break;

            case "3":
                Console.Write("Tipo de la Berry: ");
                string? berryType = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(berryType))
                {
                    var berries = await GetBerriesByNaturalGiftType(berryType);

                    foreach(var berry in berries)
                    {
                        if (berry != null)
                        {
                            Console.WriteLine("\n===========================");
                            Console.WriteLine($"Nombre: {berry.Name}");
                            Console.WriteLine($"Suavidad: {berry.Smoothness}");
                            Console.WriteLine($"Tiempo crecimiento: {berry.GrowthTime}");
                            Console.WriteLine($"Tipo Natural de la baya: {berry.NaturalGiftType.Name}");
                            Console.WriteLine("===========================\n");
                        }
                    }
                }
                break;

            case "4":
                Console.WriteLine("Saliendo...\n");
                break;

            default:
                Console.WriteLine("Opción no válida.\n");
                break;
        }
    }

// BERRIES
    static async Task<Berry?> GetBerryByID(string id)
    {
        try
        {
            // Accedemos a la API y en caso de no encontrar el objeto saltaría un error, 
            // asi como si ni siquiera llegase a entrar en la API 
            var response = await client.GetAsync($"https://pokeapi.co/api/v2/berry/{id}/");
 
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"No se encontró la berry '{id}'. Código HTTP: {response.StatusCode}\n");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();

            // Creamos una berry segun los parametros especificados en el mapeo de la API en Todo.cs
            try
            {
                var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
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

    static async Task<List<Berry?>> GetBerryByFlavor(string flavor)
    {
        try
    {
        var response = await client.GetAsync($"https://pokeapi.co/api/v2/berry-flavor/{flavor}/");

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"No se encontró el sabor '{flavor}'. Código HTTP: {response.StatusCode}\n");
            return new List<Berry>();
        }

        var content = await response.Content.ReadAsStringAsync();

        // Deserializamos usando la clase auxiliar
        var flavorData = JsonSerializer.Deserialize<BerryFlavorResponse>(content,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var berries = new List<Berry>();

        if (flavorData?.Berries != null)
        {
            foreach (var berryRef in flavorData.Berries)
            {
                // Obtenemos cada Berry completo usando tu clase Berry existente
                var berryResponse = await client.GetAsync(berryRef.Berry.Url);
                if (berryResponse.IsSuccessStatusCode)
                {
                    var berryContent = await berryResponse.Content.ReadAsStringAsync();
                    var berry = JsonSerializer.Deserialize<Berry>(berryContent,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (berry != null)
                        berries.Add(berry);
                }
            }
        }

        return berries;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
        return new List<Berry>();
    }
    }

    static async Task<List<Berry>> GetBerriesByNaturalGiftType(string type)
    {
        // Lista donde esta´ran todas las Berries que queramos mostrar.
        var berries = new List<Berry>();

        try
        {
            var listResponse = await client.GetAsync("https://pokeapi.co/api/v2/berry?limit=64");
            if (!listResponse.IsSuccessStatusCode)
                return berries;

            var listContent = await listResponse.Content.ReadAsStringAsync();
            var listData = JsonSerializer.Deserialize<BerryListResponse>(listContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (listData?.Results == null)
                return berries;

            // Metemos cada berry en la lista segun cumpla nuestros requisitos.
            foreach (var item in listData.Results)
            {
                var berryResponse = await client.GetAsync(item.Url);
                if (!berryResponse.IsSuccessStatusCode)
                    continue;

                var berryContent = await berryResponse.Content.ReadAsStringAsync();
                var berry = JsonSerializer.Deserialize<Berry>(berryContent,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (berry != null && berry.NaturalGiftType.Name.Equals(type, StringComparison.OrdinalIgnoreCase))
                    berries.Add(berry);
            }
        }
        catch
        {
            return berries;
        }

        return berries;
    }

// POKEMON

    static async Task<PokemonInfo?> GetPokemonByName(string name)
    {
        try
        {
            // 1. Obtener datos principales del Pokémon --> (Num.Pokedex, Name)
            var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Pokémon no encontrado.");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var pokemon = JsonSerializer.Deserialize<JsonElement>(content);

            int pokedexID = pokemon.GetProperty("id").GetInt32();
            string pokemonName = pokemon.GetProperty("name").GetString() ?? "";

            // Obtener informacion de los tipos --> (Type, Name)
            var tipos = new List<string>();
            foreach (var tipo in pokemon.GetProperty("types").EnumerateArray())
            {
                tipos.Add(tipo.GetProperty("type").GetProperty("name").GetString() ?? "");
            }

            // 2. Obtener datos de Species (color, evolution_chain)
            var speciesUrl = pokemon.GetProperty("species").GetProperty("url").GetString();
            var speciesResponse = await client.GetAsync(speciesUrl);

            var speciesContent = await speciesResponse.Content.ReadAsStringAsync();
            var species = JsonSerializer.Deserialize<JsonElement>(speciesContent);

            string color = species.GetProperty("color").GetProperty("name").GetString() ?? "";

            var evoChainUrl = species.GetProperty("evolution_chain").GetProperty("url").GetString();
        
            // 3. Obtener evolución y determinar la fase evolutiva
            var evoResponse = await client.GetAsync(evoChainUrl);
            var evoContent = await evoResponse.Content.ReadAsStringAsync();
            var evoChain = JsonSerializer.Deserialize<JsonElement>(evoContent);

            string stage = GetEvolutionStage(evoChain.GetProperty("chain"), pokemonName);


            // devolver resultado unificado
            return new PokemonInfo
            {
                DexNumber = pokedexID,
                Name = pokemonName,
                Color = color,
                Types = tipos,
                EvolutionStage = stage
            };
        } catch (Exception ex)
        {
            Console.WriteLine($"Ocurrrió un error: {ex.Message}");
            return null;
        }
    }

    static async Task<PokemonInfo?> GetPokemonByID(int id)
    {
        try
        {
            //  Obtenemos datos principales del Pokémon --> (Num.Pokedex, Name)
            var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Pokémon no encontrado.");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var pokemon = JsonSerializer.Deserialize<JsonElement>(content);

            int pokedexID = pokemon.GetProperty("id").GetInt32();
            string pokemonName = pokemon.GetProperty("name").GetString() ?? "";

            // Obtenemos informacion de los tipos --> (Type, Name)
            var tipos = new List<string>();
            foreach (var tipo in pokemon.GetProperty("types").EnumerateArray())
            {
                tipos.Add(tipo.GetProperty("type").GetProperty("name").GetString() ?? "");
            }

            // Obtenemos datos de Species (color, evolution_chain)
            var speciesUrl = pokemon.GetProperty("species").GetProperty("url").GetString();
            var speciesResponse = await client.GetAsync(speciesUrl);

            var speciesContent = await speciesResponse.Content.ReadAsStringAsync();
            var species = JsonSerializer.Deserialize<JsonElement>(speciesContent);

            string color = species.GetProperty("color").GetProperty("name").GetString() ?? "";

            var evoChainUrl = species.GetProperty("evolution_chain").GetProperty("url").GetString();
        
            // Obtenemos evolución y determinar la fase evolutiva
            var evoResponse = await client.GetAsync(evoChainUrl);
            var evoContent = await evoResponse.Content.ReadAsStringAsync();
            var evoChain = JsonSerializer.Deserialize<JsonElement>(evoContent);

            string stage = GetEvolutionStage(evoChain.GetProperty("chain"), pokemonName);

            return new PokemonInfo
            {
                DexNumber = pokedexID,
                Name = pokemonName,
                Color = color,
                Types = tipos,
                EvolutionStage = stage
            };
        } catch (Exception ex)
        {
            Console.WriteLine($"Ocurrrió un error: {ex.Message}");
            return null;
        }
    }

    static async Task<List<PokemonInfo>> GetPokemonByType(string type)
    {
        var result = new List<PokemonInfo>();

        try
        {
            var response = await client!.GetAsync($"https://pokeapi.co/api/v2/type/{type}/");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"No se encontró el tipo '{type}'.");
                return result;
            }

            var content = await response.Content.ReadAsStringAsync();
            var typeData = JsonSerializer.Deserialize<JsonElement>(content);

            // Recorremos la lista de Pokémon del tipo
            foreach (var pokeEntry in typeData.GetProperty("pokemon").EnumerateArray())
            {
                var pokeObj = pokeEntry.GetProperty("pokemon");
                string pokeName = pokeObj.GetProperty("name").GetString() ?? "";
                
                // Verificamos que sea **tipo primario** (slot == 1)
                int slot = pokeEntry.GetProperty("slot").GetInt32();
                if (slot != 1) continue;

                // Obtenemos info completa
                var pokemonInfo = await GetPokemonByName(pokeName);
                if (pokemonInfo != null)
                    result.Add(pokemonInfo);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }

        return result;
    }
    // Metodo auxiliar para recorrer el array de Evolution_Chain y determinar la misma en cada caso
    static string GetEvolutionStage(JsonElement chain, string name)
    {
        string speciesName = chain.GetProperty("species").GetProperty("name").GetString() ?? "";

        if (speciesName == name)
            return "Base";

        foreach (var evo in chain.GetProperty("evolves_to").EnumerateArray())
        {
            string evoName = evo.GetProperty("species").GetProperty("name").GetString() ?? "";
            if (evoName == name)
                return "Media";

            // sub-evoluciones
            foreach (var sub in evo.GetProperty("evolves_to").EnumerateArray())
            {
                string subName = sub.GetProperty("species").GetProperty("name").GetString() ?? "";
                if (subName == name)
                    return "Final";
            }
        }

        return "Desconocida";
    }
}


