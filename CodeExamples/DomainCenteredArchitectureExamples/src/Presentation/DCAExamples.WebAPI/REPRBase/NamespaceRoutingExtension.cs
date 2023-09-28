using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DCAExamples.WebAPI.REPRBase;

public static class NamespaceRoutingExtension
{
    public static MvcOptions UseNamespaceRouteToken(this MvcOptions options)
    {
        options.Conventions.Add(new NamespaceRouteToken());

        return options;
    }
}

public class NamespaceRouteToken : IApplicationModelConvention
{
    private readonly string tokenRegex = $@"(\[autoroute])(?<!\[\1(?=]))";

    
    // this will replace api endpoint route templates of [autoroute] to {parentfolder/classname}
    // just to automatically create route template in a structured manner
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            // gets parent folder of Endpoint.
            string parentFolderName = controller.ControllerType.Namespace!.Split('.').Last();
            string actionName = controller.ControllerName;
            string finalRoute = $"{parentFolderName}/{actionName}";
            
            // extremely dirty hack
            // stolen from here https://github.com/ardalis/ApiEndpoints/blob/main/src/Ardalis.ApiEndpoints/Extensions/MvcOptionsExtensions.cs
            SelectorModel selectorModel = controller.Actions[0].Selectors[0];   // one action per controller
            string? template = selectorModel.AttributeRouteModel!.Template;     // current route template 
            selectorModel.AttributeRouteModel.Template = Regex.Replace(template, tokenRegex, finalRoute);
        }
    }
}