using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public class WebRequestPost
{
    const string endpoint = "http://localhost:3000";
    const int timeout = 5000; //5 seconds timeout

    /**
     * This is only a test to show how it is done!
     * ALSO!!!!!!!!!!!! Feel free to test stuff here... You will need it
     */
    [STAThread]
    static void Main()
    {
        RequestRegister registerRequest = new RequestRegister();
        registerRequest.email = "sssun@asnf.com";
        registerRequest.name = "Nuno Neto";
        registerRequest.department = "1";
        registerRequest.password = "12345678";
        registerRequest.confirmPassword = "12345678";

        ResponseRegister response = (ResponseRegister)makeRequest<ResponseRegister>("/auth/register", registerRequest);

        Console.WriteLine(response.error + " " + response.message + " " + response.insertedId);
    }

    /**
     * Use this function to make a single request
     * APIMethod: api method to call, eg: /auth/register
     * body: Body of request, eg: {id:1234, email:344@g.com}
     */
    public static Object makeRequest<T>(string APIMethod, Object body)
    {
        //Criar o Web Request
        WebRequest webRequest = WebRequest.Create(endpoint + APIMethod);
        webRequest.ContentType = "application/json";
        webRequest.Method = "POST";
        webRequest.Timeout = timeout;

        //Serializaçao de Objeto para JSON
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string request = serializer.Serialize(body);

        //Conversao de conteudo para bytes
        byte[] requestData = Encoding.ASCII.GetBytes(request);
        webRequest.ContentLength = requestData.Length;

        //Enviar e receber
        try
        {
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
            return serializer.Deserialize<T>(responseData);
        }
        catch //Em caso do servidor nao ligado
        {

            //So isto tb funcionava ....
            //return serializer.Deserialize<T>({"'error':'1', 'message':'Connection to server failed!'"});

            //criar resposta e serializar para JSON
            Response responseException = new Response();
            responseException.error = "1";
            responseException.message = "Connection to server failed!";

            //Deserializaçao para a classe pretendida
            string responseExceptionData = serializer.Serialize(responseException);
            return serializer.Deserialize<T>(responseExceptionData);
        }
    }
}



/**
 * REQUEST CLASSES
 */
/*
 * Generic Request, not possible to use 
 */
public abstract class Request{}
public class RequestRegister : Request
{
    public string email { get; set; }
    public string name { get; set; }
    public string department { get; set; }
    public string password { get; set; }
    public string confirmPassword { get; set; }
}
public class RequestLogin : Request
{
    public string email { get; set; }
    public string password { get; set; }
}

public class RequestCreateTicket : Request
{
    public string email { get; set; }
    public string name { get; set; }
    public string title { get; set; }
    public string description { get; set; }
}


/**
 * RESPONSE CLASSES
 */
/*
 * Generic Response, at least these two paramethers will exist in every Response
 */
public class Response
{
    public string error { get; set; }
    public string message { get; set; }
}

public class ResponseRegister : Response
{
    public string insertedId { get; set; }
}

public class ResponseLogin : Response
{
    public string email { get; set; }
    public string name { get; set; }
    public string department { get; set; }
    public string id { get; set; }
    public List<TroubleTicket> solverTickets { get; set; }
    public List<TroubleTicket> unassignedTickets { get; set; }
    public List<TroubleTicket> userTickets { get; set; }
}

public class ResponseCreateTicket : Response
{
    public string insertedId { get; set; }
}


/**
 * Custom Classes 
 */

public class TroubleTicket
{
    public string email { get; set; }
    public string name { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string _id { get; set; }
    public string date { get; set; }
    public string state { get; set; }
    public string solverId { get; set; }
    public string solverName { get; set; }
    public string answer { get; set; }
}

public class SecondaryTroubleTicket
{
    public string title { get; set; }
    public string description { get; set; }
    public string _id { get; set; }
    public string troubleTicket_id { get; set; }
    public string state { get; set; }
    public string answer { get; set; }
}





