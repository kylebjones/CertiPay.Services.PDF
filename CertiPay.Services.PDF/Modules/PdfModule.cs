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
        public PdfModule()
        {
            Get["/Pdf/GenerateDocument", runAsync: true] = async (p, ctx) =>
            {
                return 1;
            };
        }
    }
}
