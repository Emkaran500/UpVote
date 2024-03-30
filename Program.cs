using System.Net;
using System.Text.Json;

var httpListener = new HttpListener();

var prexif = "http://*:55555/";

httpListener.Prefixes.Add(prexif);

httpListener.Start();

Console.WriteLine($"Server started...");

while (true)
{
    var client = await httpListener.GetContextAsync();

    string? endpoint = client.Request.RawUrl;

    client.Response.Close();
}