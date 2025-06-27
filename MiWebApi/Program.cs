// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Text.Json;
using EspacioFotos;

HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://dog.ceo/api/breeds/image/random/10");
response.EnsureSuccessStatusCode();
string json = await response.Content.ReadAsStringAsync();
var imagenes = JsonSerializer.Deserialize<FotosPerros>(json);

if (imagenes == null)
{
    Console.WriteLine("No se pudieron cargar los usuarios");
}

int i = 1;
Console.WriteLine($"La url de las fotos son:");

Console.WriteLine($"--------------------------------------------");


foreach (var url in imagenes.message)
{
    Console.WriteLine($"{i++}. {url}");
}
Console.WriteLine($"--------------------------------------------");

Console.WriteLine($"El estado de las fotos es: {imagenes.status}");

//serializar a json
var opcionesJson = new JsonSerializerOptions { WriteIndented = true };
string JsonCompleto = JsonSerializer.Serialize(imagenes, opcionesJson);

//guardarlo en un archivo

File.WriteAllText("imagenesRandomPerros.json", JsonCompleto);
Console.WriteLine("Las url fueron guradadas con exito en el archivo imagenesRandomPerros.json. ");
