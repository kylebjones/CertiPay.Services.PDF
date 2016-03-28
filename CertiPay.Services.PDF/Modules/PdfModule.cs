using CertiPay.Services.PDF.Interfaces;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Services.PDF.Modules
{
    public class PdfModule : NancyModule
    {
        public PdfModule(IPdfService pdfSvc)
        {
            Get["/Pdf/GenerateDocument", runAsync: true] = async (p, ctx) =>
            {
                return await pdfSvc.GenerateDocument(p.url);
            };
        }
    }
}
