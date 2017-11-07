using SimpleMvc.Framework.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

namespace SimpleMvc.Framework.View
{
    public class View : IRenderable
    {
        public const string BaseLayoutFileName = "Layout";

        public const string ContentPlaceholder = "{{{conent}}}";

        public const string HtmlExtension = ".html";

        public const string LocalErrorPath = "\\SimpleMvc.Framework\\Errors\\Error.html";


        private readonly string templateFullQualifiedName;

        private readonly IDictionary<string, string> viewData;

        public View(string templateFullQualifiedName, IDictionary<string, string> viewData)
        {
            this.templateFullQualifiedName = templateFullQualifiedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            string fullHtml = this.ReadFile();

            if(this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value);
                }
            }

            return fullHtml;
        }

        private string ReadFile()
        {
            string layoutHtml = this.RenderLayoutHtml();

            string templateFullQualifiedNameWithExtension = this.templateFullQualifiedName + HtmlExtension;

            if(!File.Exists(templateFullQualifiedName))
            {
                string errorPath = this.GetErrorPath();
                string errorHtml = File.ReadAllText(errorPath);

                this.viewData.Add("error", "Requested view does not exist!");

                return errorHtml;
            }

            var file = File.ReadAllText(templateFullQualifiedName + HtmlExtension);

            return file;
        }

        private string GetErrorPath()
        {
            string appDirectoryPath = Directory.GetCurrentDirectory();
            DirectoryInfo parrentDir = Directory.GetParent(appDirectoryPath);
            string parrentDirPath = parrentDir.FullName;

            string errorPagePath = parrentDirPath + LocalErrorPath;

            return errorPagePath;
        }

        private string RenderLayoutHtml()
        {
            string layoutHtmlQualifiedName = string.Format("{0}\\{1}{2}",
                                                           MvcContext.Get.ViewsFolder,
                                                           BaseLayoutFileName,
                                                           HtmlExtension
                                                           );

            if(!File.Exists(layoutHtmlQualifiedName))
            {
                string errorPath = this.GetErrorPath();
                string errorHtml = File.ReadAllText(errorPath);

                this.viewData.Add("error", "Layout view does not exist!");

                return errorHtml;
            }

            string layoutHtmlFileContent = File.ReadAllText(layoutHtmlQualifiedName);

            return layoutHtmlFileContent;
        }
    }
}
