namespace EspacioUsuarios;

public class companiaDat
{
    public string name { get; set; }
    public string catchPhrase { get; set; }
    public string bs { get; set; }
}

public class geolocalizacionDat
{
    public string lat { get; set; }
    public string lng { get; set; }
}

public class datosPersonales
{
    public string street { get; set; }
    public string suite { get; set; }
    public string city { get; set; }
    public string zipcode { get; set; }

    public geolocalizacionDat geo { get; set; }
}

public class UsuariosDatos
{
    public int id { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public datosPersonales address { get; set; }
    public string phone { get; set; }
    public string website { get; set; }
    public companiaDat company { get; set; }
}