using log4net;
using log4net.Config;
using System;

namespace ConsoleApp
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            log.Info("program start");

            try
            {
                Console.Write("1st number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("2nd number: ");
                int num2 = int.Parse(Console.ReadLine());

                int sum = num1 + num2;
                log.Info($"Sum {num1} + {num2} : {sum}");
            }
            catch (Exception ex)
            {
                log.Error("error: " + ex.Message, ex);
            }

            log.Info("program closed");
        }
    }
}
