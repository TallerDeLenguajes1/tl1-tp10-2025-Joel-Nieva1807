// See https://aka.ms/new-console-template for more information
using System.Security.Claims;
using System.Text.Json;
using EspacioApi;

HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
string responseBody = await response.Content.ReadAsStringAsync();
List<ApiC> listaApi = JsonSerializer.Deserialize<List<ApiC>>(responseBody);
List<ApiC> TareasPendientes = new List<ApiC>();
List<ApiC> TareasRealizadas = new List<ApiC>();
//mostrar informacion


for (int i = 0; i < listaApi.Count; i++)
{
  if (listaApi[i].completed == true)
  {
    TareasRealizadas.Add(listaApi[i]);

  }
  else
  {
    TareasPendientes.Add(listaApi[i]);
  }

}

foreach (var usuarioNoCompletado in TareasPendientes)
{
  Console.WriteLine($"Titulo: '{usuarioNoCompletado.title}' / Estado completado: '{usuarioNoCompletado.completed}'");
}

foreach (var usuarioCompletado in TareasRealizadas)
{
  Console.WriteLine($"Titulo: '{usuarioCompletado.title}' / Estado completado: '{usuarioCompletado.completed}'");
}

// Serializar la lista completa a JSON
var opcionesJson = new JsonSerializerOptions { WriteIndented = true }; //para que este identado, use multiples lineas y sea mas legible
string jsonCompleto = JsonSerializer.Serialize(TareasRealizadas, opcionesJson);

// Guardarlo en un archivo
File.WriteAllText("tareas.json", jsonCompleto);

Console.WriteLine("\nLas tareas fueron guardadas en el archivo tareas.json");