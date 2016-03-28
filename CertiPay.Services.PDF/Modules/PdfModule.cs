using CertiPay.PDF;
using Nancy;
using System.Collections.Generic;

namespace CertiPay.Services.PDF.Modules
{
    public class PdfModule : NancyModule
    {
        public PdfModule(IPDFService pdfSvc)
        {
            Get["/Pdf/GenerateDocument"] = p =>
            {
                var settings = new PDFService.Settings()
                {
                    Uris = new List<string>()
                    {
                        p.url
                    }
                };

                return pdfSvc.CreatePdf(settings);
            };
        }
    }
}
