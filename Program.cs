using RestSharp;
using System;
using System.Text.Json;

class Program
{
    public static void Main()
    {
        PokemonList();
    }

    private static void PokemonList()
    {
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/");
        RestRequest request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // Deserializando o conteúdo da resposta em um objeto JSON
            var options = new JsonSerializerOptions { WriteIndented = true }; // Opção para formatar o JSON com indentação
            var jsonFormatted = JsonSerializer.Serialize(
                JsonSerializer.Deserialize<object>(response.Content), options);

            // Imprimindo o JSON formatado
            Console.WriteLine(jsonFormatted);
        }
        else
        {
            Console.WriteLine($"Erro: {response.ErrorMessage}");
        }

        Console.ReadKey();
    }
}
