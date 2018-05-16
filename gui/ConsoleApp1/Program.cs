using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

public class WebRequestPost
{

    [STAThread]
    static void Main()
    {
        RegisterRequest registerRequest = new RegisterRequest();
        registerRequest.email = "un@asnf.com";
        registerRequest.name = "Nuno Neto";
        registerRequest.department = "1";
        registerRequest.password = "12345678";
        registerRequest.confirmPassword = "12345678";

        makeRequest("/auth/register", registerRequest);
    }

    public static void makeRequest(string APIMethod, Object body)
    {
        //Criar o Web Request
        WebRequest webRequest = WebRequest.Create("http://localhost:3000" + APIMethod);
        webRequest.ContentType = "application/json";
        webRequest.Method = "POST";

        //Serializaçao de Objeto para JSON
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string request = serializer.Serialize(body);
        Console.WriteLine(request);

        //Conversao de conteudo para bytes
        byte[] requestData = Encoding.ASCII.GetBytes(request);
        webRequest.ContentLength = requestData.Length;

        //Escrever contéudo
        using (var stream = webRequest.GetRequestStream())
        {
            stream.Write(requestData, 0, requestData.Length);
        }

        //Enviar
        WebResponse webResponse = webRequest.GetResponse();

        //Receber e fechar
        string responseData;
        using (Stream stream = webResponse.GetResponseStream())
        {
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            responseData = reader.ReadToEnd();
            
        }
        webResponse.Close();

        //Deserializaçao
        Console.WriteLine(responseData);
        Response response = serializer.Deserialize<Response>(responseData);
        Console.WriteLine(response.error + " " + response.message);

        if(response.message == null)
            Console.WriteLine("null ó mano");
        else
            Console.WriteLine("not null ó mano");

        Console.ReadLine();
    }
}

//Response
public class Response
{
    public string error { get; set; }
    public string message { get; set; }
}
public class RegisterResponse : Response{}



//Request
public abstract class Request{}
public class RegisterRequest : Request
{
    public string department { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string confirmPassword { get; set; }

}


