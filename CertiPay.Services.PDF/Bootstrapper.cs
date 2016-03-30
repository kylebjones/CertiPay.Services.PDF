using CertiPay.PDF;
using Nancy;
using Nancy.TinyIoc;
using System;
using System.Configuration;

namespace CertiPay.Services.PDF
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private static String ABCPdfLicense
        {
            get { return ConfigurationManager.AppSettings["ABCPDF-License"]; }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IPDFService>(new PDFService(ABCPdfLicense));
        }
    }
}