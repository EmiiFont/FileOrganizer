using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponsability.Attribute;
using ChainOfResponsability.ChainOfResponsability;
using ChainOfResponsability.Helpers;

namespace ChainOfResponsability.FileHandlers
{
   public static class MoveFileHelper
    {
       public static void ProcessFile(AddedFile file)
       {
           var count = 1;
           var extension = (int) StringEnum.Parse(typeof (FileExtension),file.Extension, true);
           var directoryName = Path.Combine(file.ParentFolder, Enum.GetName(typeof(FileExtension), extension));
           var directoryInfo = new DirectoryInfo(directoryName);
           if (directoryInfo.Exists == false)
               Directory.CreateDirectory(directoryName);

           var fileInfo = new FileInfo(file.ParentFolder + "\\" + file.Name);
           var destinationPath = Path.Combine(directoryName, file.Name);
           var fileName = file.Name;

           while (File.Exists(destinationPath))
           {
               fileName = string.Format("{0}({1})", count++, file.Name);
               destinationPath = Path.Combine(directoryName, fileName);
           }
           fileInfo.MoveTo(directoryName + "\\" + fileName);

           new DirectoryInfo(file.ParentFolder).Refresh();
       }

    }
}
