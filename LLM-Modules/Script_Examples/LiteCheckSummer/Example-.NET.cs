using System;
using System.Diagnostics;

namespace LLM.Examples.LiteCheckSummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            return;
            var process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("LiteCheckSummer/LLMCheckSummer.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfoRedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            
            process.StartInfo = startInfo;
            process.Start();
            
            process.StandardOutput.ReadToEnd().Dump();
        }
    }
}