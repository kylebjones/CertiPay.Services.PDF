using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Services.PDF.Interfaces
{
    public interface IPdfService
    {
        byte[] GenerateDocument(string url);
    }
}
