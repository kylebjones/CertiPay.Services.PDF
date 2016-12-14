using CertiPay.Common;
using CertiPay.PDF;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using System;
using System.Configuration;
using System.IO;
using System.Net.Mime;

namespace CertiPay.Services.PDF.Modules
{
    public class PdfModule : NancyModule
    {
        private static String AppName { get { return ConfigurationManager.AppSettings["ApplicationName"]; } }

        public PdfModule(IPDFService pdfSvc)
        {
            Get["/"] = _ =>
            {
                return Response.AsJson(new
                {
                    Application = AppName,
                    Version = Utilities.Version<PdfModule>(),
                    Environment = EnvUtil.Current.DisplayName(),
                    Server = Environment.MachineName
                });
            };

            Get["/Pdf/GenerateDocument"] = p =>
            {
                var useLandscape = (bool?)Request.Query["landscape"] ?? null;

                return GetPdf(pdfSvc, new PDFService.Settings
                {
                    UseLandscapeOrientation = useLandscape ?? false,
                    Uris = new String[] { Request.Query["url"] }
                });
            };

            Post["/Pdf/GenerateDocument"] = p =>
            {
                return GetPdf(pdfSvc, this.Bind<PDFService.Settings>());
            };
        }

        private StreamResponse GetPdf(IPDFService pdfSvc, PDFService.Settings request)
        {
            var stream = new MemoryStream(pdfSvc.CreatePdf(request));

            return new StreamResponse(() => stream, MediaTypeNames.Application.Pdf);
        }
    }
}