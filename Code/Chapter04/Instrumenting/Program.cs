using System;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;


namespace Instrumenting
{
    class Program
    {
        static void Main(string[] args)
        {
            // write to a text file in the project folder
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));
            // text writer is buffered, so this option calls
            // Flush() on all listeners after writing
            Trace.AutoFlush = true;
            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var ts = new TraceSwitch(displayName: "PackSwitch", description: "This switch is set via JSON.config.");
            configuration.GetSection("PackSwitch").Bind(ts);
            Trace.WriteIf(ts.TraceError, "Trace error");
            Trace.WriteIf(ts.TraceWarning, "Trace warning");
            Trace.WriteIf(ts.TraceInfo, "Trace information");
            Trace.WriteIf(ts.TraceVerbose, "Trace verbose");

        }
    }
}
