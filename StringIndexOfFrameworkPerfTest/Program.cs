using System;
using BenchmarkDotNet.Running;

namespace StringIndexOfFrameworkPerfTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start string.IndexOf Framework Performance Test...");

            var summary = BenchmarkRunner.Run<StringIndexOfBenchmark>();
        }
    }
}
