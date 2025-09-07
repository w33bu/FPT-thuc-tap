using log4net;
using log4net.Config;
using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            log.Info("program Start");

            try
            {
                Console.Write("enter file path: ");
                string filePath = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    log.Info($"File name: {Path.GetFileName(filePath)}");

                    string[] lines = File.ReadAllLines(filePath);
                    log.Info($"number of row: {lines.Length}");

                    log.Info("content:");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    log.Error("File doesn't exist.");
                }
            }
            catch (Exception ex)
            {
                log.Error("error: " + ex.Message, ex);
            }

            log.Info("program close");
        }
    }
}
