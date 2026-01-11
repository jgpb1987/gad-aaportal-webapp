using gad.aainteroperador.soap.Client;
using gad.aainteroperador.soap.Configuration;
using gad.aaportal.commons.Dto;
using gad.interoperador;
using System.Net.Http.Json;

var options = new SoapClientOptions
{
    Endpoint = "http://127.0.0.1:8088/mockinteroperadorSoapBinding", //http
    //Endpoint = "http://interoperabilidad.dinardap.gob.ec/interoperador-v2", //QA

    Security = new SoapSecurityOptions
    {
        Type = SoapSecurityType.None
        //Type = SoapSecurityType.Basic, //QA
        //Username = "InAtRoGeMu", //QA
        //Password = "NKG3jt5%zFWeWZ" //QA
    }
};
Console.WriteLine("Ingrese identifiación:");
var identificacion = Console.ReadLine();

var service = new InteroperadorSoapService(options);

var parametros = new parametro[]
{
    new parametro { nombre = "codigoPaquete", valor = "6281" },
    new parametro { nombre = "identificacion", valor = identificacion }, //"1091730940001" sample
    new parametro { nombre = "fuenteDatos", valor = "T" },
};

var response = await service.ConsultarAsync(parametros);

var lista = MapearAForm101Lista(response);
foreach (var item in lista)
{
    using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
    var resp = await http.PostAsJsonAsync("api/Dinardap/UpdateForm101", item);
    resp.EnsureSuccessStatusCode(); 
    var result = await resp.Content.ReadFromJsonAsync<Form101SaveDtoResult>();
    Console.WriteLine($"Guardado: {result?.Result}");
}
Console.ReadLine();

#region Metodos publicos
static List<Form101DtoRequest> MapearAForm101Lista(consultarResponse response)
{
    var lista = new List<Form101DtoRequest>();
    foreach (var entidad in response.paquete.entidades)
    {
        foreach (var fila in entidad.filas)
        {
            var dto = new Form101DtoRequest();

            foreach (var col in fila.columnas)
            {
                switch (col.campo)
                {
                    case "anioFiscal":
                        dto.AnioFiscal = int.Parse(col.valor);
                        break;
                    case "numeroIdentificacion":
                        dto.NumeroIdentificacion = col.valor;
                        break;
                    case "razonSocial":
                        dto.RazonSocial = col.valor;
                        break;
                    case "perdidaEjercicio3430":
                        dto.PerdidaEjercicio3430 = TryDec(col.valor);
                        break;
                    case "totActivoNoCorriente1077":
                        dto.TotActivoNoCorriente1077 = TryDec(col.valor);
                        break;
                    case "totPasivosCorrientes1340":
                        dto.TotPasivosCorrientes1340 = TryDec(col.valor);
                        break;
                    case "totalActivo1080":
                        dto.TotalActivo1080 = TryDec(col.valor);
                        break;
                    case "totalActivoCorriente470":
                        dto.TotalActivoCorriente470 = TryDec(col.valor);
                        break;
                    case "totalIngresos1930":
                        dto.TotalIngresos1930 = TryDec(col.valor);
                        break;
                    case "totalPasivos1620":
                        dto.TotalPasivos1620 = TryDec(col.valor);
                        break;
                    case "totalPatrimonioNeto1780":
                        dto.TotalPatrimonioNeto1780 = TryDec(col.valor);
                        break;
                    case "totasCostosGastos3380":
                        dto.TotasCostosGastos3380 = TryDec(col.valor);
                        break;
                    case "utilidadEjercicio3420":
                        dto.UtilidadEjercicio3420 = TryDec(col.valor);
                        break;
                    case "totalPasivosLargoPlazo1590":
                        dto.TotalPasivosLargoPlazo1590 = TryDec(col.valor);
                        break;
                    case "proNoctePasCtgComNeg1577":
                        dto.ProNoctePasCtgComNeg1577 = TryDec(col.valor);
                        break;
                }
            }
            lista.Add(dto);
        }
    }
    return lista;
}

static decimal? TryDec(string valor)
{
    return decimal.TryParse(
        valor,
        System.Globalization.NumberStyles.Any,
        System.Globalization.CultureInfo.InvariantCulture,
        out var d
    ) ? d : null;
}
#endregion