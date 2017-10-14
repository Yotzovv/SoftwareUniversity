using System;
using System.IO;

public class IndexController : Controller
{
    public IHttpResponse Index() => this.FileViewResponse(@"home\index");

    public IHttpResponse About() => this.FileViewResponse(@"home\about");
}