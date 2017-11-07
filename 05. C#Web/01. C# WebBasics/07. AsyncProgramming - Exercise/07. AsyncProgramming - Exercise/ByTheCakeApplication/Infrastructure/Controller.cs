using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Controller
{
    public const string DefaultPath = @"ByTheCakeApplication\Resources\{0}.html";
    public const string ContentPlaceHolder = "{{{content}}}";

    public Controller()
    {
        this.ViewData = new Dictionary<string, string>
        {
            ["authDisplay"] = "block",
            ["showError"] = "none"
        };
    }

    protected IDictionary<string, string> ViewData { get; private set; }


    public IHttpResponse FileViewResponse(string fileName)
    {
        var result = this.ProcessFileHtml(fileName);

        return new ViewResponse(HttpStatusCode.OK, new FileView(result));
    }
    
    protected IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
    {
        var result = this.ProcessFileHtml(fileName);

        if (this.ViewData.Any())
        {
            foreach (var value in this.ViewData)
            {
                result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
            }
        }

        return new ViewResponse(HttpStatusCode.OK, new FileView(result));
    }

    protected void AddError(string errorMessage)
    {
        this.ViewData["showError"] = "block";
        this.ViewData["error"] = errorMessage;
    }

    private string ProcessFileHtml(string fileName)
    {
        var layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));
        var fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));
        var result = layoutHtml.Replace(ContentPlaceHolder, fileHtml);

        return result;
    }
}
