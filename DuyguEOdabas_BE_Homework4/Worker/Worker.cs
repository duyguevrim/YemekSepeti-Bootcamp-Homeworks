using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string[] directories = Directory.GetDirectories(@"C:\Users\duyguevrim\Desktop\Kodluyoruz-Bootcamp");
                
                foreach (string name in directories)
                {
                    FileInfo fi = new FileInfo(@"C:\Users\duyguevrim\Desktop\Kodluyoruz-Bootcamp\DuyguEOdabas_BE_Homework4\Worker\worker.txt");
                    using (StreamWriter outputFile = new StreamWriter(fi.Open(FileMode.Truncate)))
                    {
                        outputFile.WriteLine(name + "\n");
                    }
                }
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
