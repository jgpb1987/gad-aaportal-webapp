using gad.aainteroperador.soap.Client;
using gad.aainteroperador.soap.Configuration;
using gad.interoperador;
using System.Xml.Serialization;

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

var service = new InteroperadorSoapService(options);

var parametros = new parametro[]
{
    new parametro { nombre = "codigoPaquete", valor = "6281" },
    new parametro { nombre = "identificacion", valor = "1091730940001" },
    new parametro { nombre = "fuenteDatos", valor = "T" },
};

var response = await service.ConsultarAsync(parametros);
PrintAsXml(response);
//Console.WriteLine(response?.paquete?.numeroPaquete);
Console.ReadLine();

#region Metodos publicos
static void PrintAsXml<T>(T obj)
{
    if (obj == null)
    {
        Console.WriteLine("Respuesta nula");
        return;
    }

    var serializer = new XmlSerializer(typeof(T));
    using var writer = new StringWriter();
    serializer.Serialize(writer, obj);
    Console.WriteLine(writer.ToString());
}
#endregion