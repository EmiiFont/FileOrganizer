using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability.ChainOfResponsability
{
   public class FileProcessor
   {
       private IFileHandler _firstHandler;
       private IFileHandler _succesorHandler;
       /// <summary>
       /// Mantein the reference to the previous handler so we can add a new one.
       /// </summary>
       /// <param name="handler"></param>
       public void AddHandler(IFileHandler handler)
       {
           if (_firstHandler == null)
           {
               _firstHandler = handler;
           }
           else
           {
               _succesorHandler.NextHandler(handler);
           }
           _succesorHandler = handler;

       }

       public void HandleFile(AddedFile file)
       {
           _firstHandler.HandleRequest(file);
       }

   }
}