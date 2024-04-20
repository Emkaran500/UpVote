using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Text.Json;
using Dapper;
using UpVote.Controllers;
using UpVote.Controllers.Base;
using UpVote.HttpAttributes.Base;

async Task<bool> CallMethodAsync(BaseController controllerBase, string methodName, string httpMethod)
{
    var method = controllerBase.GetType().GetMethods()
        .FirstOrDefault(method =>
        {
            foreach (var customAttribute in method.CustomAttributes)
            {
                var attributeType = customAttribute.AttributeType;
                if (attributeType.BaseType == typeof(BaseAttribute))
                {
                    var actionNameArgument = customAttribute.NamedArguments.FirstOrDefault(arg => arg.MemberName == "ActionName");
                    var actionName = actionNameArgument.TypedValue.Value?.ToString() ?? method.Name;

                    var obj = Activator.CreateInstance(attributeType);
                    var httpAttribute = (Activator.CreateInstance(attributeType) as BaseAttribute)!;

                    if (httpAttribute.MethodType.ToUpper() == httpMethod.ToUpper()
                    && actionName?.ToUpper() == methodName.ToUpper())
                    {
                        return true;
                    }
                }
            }

            return false;
        });

    if (method is null)
    {
        return false;
    }

    var result = method.Invoke(controllerBase, null);

    if (result != null && result is Task taskResult)
    {
        await taskResult;
    }

    return true;
}

string[] GetEndpointItems(string endpoint) {
    if(endpoint == "/") {
        return new string[] { "Home" };
    }

    else if(endpoint.Contains('?')) {
        var queryParametersStartIndex = endpoint.LastIndexOf('?');

        return endpoint[..queryParametersStartIndex]
            .Split("/", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    else {
        return endpoint
            .Split("/", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
}

var httpListener = new HttpListener();

var prefix = "http://localhost:55555/";

httpListener.Prefixes.Add(prefix);

httpListener.Start();

Console.WriteLine($"Server started... address {prefix}");

while (true)
{
    var context = await httpListener.GetContextAsync();

    string? endpoint = context.Request.RawUrl;

    if (string.IsNullOrWhiteSpace(endpoint))
    {
        continue;
    }

    var enpointItems = GetEndpointItems(endpoint);

    var controllerNormalizedName = enpointItems.First().ToLower();

    var controllerType = Assembly.GetExecutingAssembly().GetTypes()
        .FirstOrDefault(type => type.Name.ToLower() == $"{controllerNormalizedName}controller");

    if (controllerType is null)
    {
        continue;
    }

    var controllerObj = Activator.CreateInstance(controllerType);

    
    if (controllerObj is not BaseController)
    {
        continue;
    }
    var controller = (controllerObj as BaseController)!;
    controller.Response = context.Response;
    controller.Request = context.Request;

    if (enpointItems.Length == 1)
    {
        await CallMethodAsync(controller, "index", context.Request.HttpMethod);
    }
    else
    {
        var methodNameToCall = enpointItems[1].ToLower();
        await CallMethodAsync(controller, methodNameToCall, context.Request.HttpMethod);
    }

    context.Response.Close();
}