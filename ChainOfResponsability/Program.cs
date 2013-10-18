using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponsability.ChainOfResponsability;
using ChainOfResponsability.FileHandlers;

namespace ChainOfResponsability
{
    class Program
    {
        private static void Main(string[] args)
        {
        // If a directory is not specified, exit program. 
            // Display the proper way to call the program.
            Console.WriteLine("Specify Directory to Organize");
            var path = Console.ReadLine();

            while(path != null && !Directory.Exists(path))
            {
             Console.WriteLine("Directory not exist check path");
             path = Console.ReadLine();
            }

            //Add handlers to the file manipulation
            var fileProcessor = new FileProcessor();
            fileProcessor.AddHandler(new TextFileHandler());
            fileProcessor.AddHandler(new Mp3FileHandler());
            fileProcessor.AddHandler(new PngFileHandler());
            fileProcessor.AddHandler(new ZipFileHandler());

            foreach (var file in Directory.GetFiles(path))
            {
                var addedFile = new AddedFile
                {
                    Extension = Path.GetExtension(file),
                    Name = Path.GetFileName(file),
                    ParentFolder = Path.GetDirectoryName(file)
                };
                fileProcessor.HandleFile(addedFile);
            }
            Console.WriteLine("Working Current Files");

        // Create a new FileSystemWatcher and set its properties.
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = path;
        /* Watch for changes in LastAccess and LastWrite times, and
          the renaming of files or directories. */
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                               | NotifyFilters.FileName;
            
        // Add event handlers.
        watcher.Created += (s,e) => OnCreated(s,e, fileProcessor);
        watcher.Changed += OnMoved;
        // Begin watching.
        watcher.EnableRaisingEvents = true;

        // Wait for the user to quit the program.
        Console.WriteLine("Listening for incoming files...");
        Console.WriteLine("Press \'q\' to quit the sample.");
        while(Console.Read()!='q');
    

        }
        // Define the event handlers. 
        private static void OnCreated(object source, FileSystemEventArgs e, FileProcessor fileProcessor)
        {
            var extension = Path.GetExtension(e.FullPath);
            var addedFile = new AddedFile
                            {
                                Extension = Path.GetExtension(e.FullPath),
                                Name = Path.GetFileName(e.FullPath),
                                ParentFolder = Path.GetDirectoryName(e.FullPath)
                            };
           fileProcessor.HandleFile(addedFile);
        }
        private static void OnMoved(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath +  " movido");
        }
    }
}
