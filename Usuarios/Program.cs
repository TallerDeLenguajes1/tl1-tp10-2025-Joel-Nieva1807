// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Text.Json;
using EspacioUsuarios;

HttpClient client = new HttpClient();


HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
response.EnsureSuccessStatusCode(); // lanza excepcion si falla
string json = await response.Content.ReadAsStringAsync();

var usuarios = JsonSerializer.Deserialize<List<UsuariosDatos>>(json); // uso var?

if (usuarios == null)
{
    Console.WriteLine("No se pudieron cargar los usuarios");
}

// mostrar los primeros 5 usuarios

Console.WriteLine("Los primeros 5 usuarios son");

foreach (var nodo in usuarios.Take(5))
{
    Console.WriteLine("-----------------------------");
    Console.WriteLine($"Nombre: {nodo.name}");
    Console.WriteLine($"Email: {nodo.email}");
    Console.WriteLine($"Domicilio: {nodo.address}");

    Console.WriteLine("-----------------------------");

}

//serializar la lista a json
var opcionesJson = new JsonSerializerOptions { WriteIndented = true };
string JsonCompleto = JsonSerializer.Serialize(usuarios.Take(5), opcionesJson);

// Guardarlo en un archivo
File.WriteAllText("usuarios.json", JsonCompleto);
Console.WriteLine("Las tareas fueron guardadas en el archivo usuarios.json");



