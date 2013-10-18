using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability.ChainOfResponsability
{
    public interface IFileHandler
    {
        void NextHandler(IFileHandler handler);
        void HandleRequest(AddedFile file);
    }
}
