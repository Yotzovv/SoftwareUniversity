﻿using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

namespace LearningSystem.Services.Implementation
{
    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GeneratePdfFromHtml(string html)
        {
            var pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            var htmlParser = new HTMLWorker(pdfDoc);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                using (var stringReader = new StringReader(html))
                {
                    htmlParser.Parse(stringReader);
                }

                pdfDoc.Close();

                return memoryStream.ToArray();
            }
        }
    }
}