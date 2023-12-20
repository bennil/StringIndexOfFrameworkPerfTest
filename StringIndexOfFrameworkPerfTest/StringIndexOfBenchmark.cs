using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringIndexOfFrameworkPerfTest
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net50)]
    //[SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net80)]
    public class StringIndexOfBenchmark
    {
        string largeString;

        [GlobalSetup]
        public void Setup()
        {
            CultureInfo ci = new CultureInfo("de-DE");              // slow
            //CultureInfo ci = new CultureInfo("fr-FR");            // slow
            //CultureInfo ci = CultureInfo.InvariantCulture;        // fast
            //CultureInfo ci = new CultureInfo("en-US");            // fast
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            //largeString = new string('a', 1_000_000);
            largeString = new string('a', 500_000);
            //largeString = new string('a', 10_000);
        }

        
        [Benchmark]
        public void IndexOfOfNotContainingStringInLargeString()
        {
            largeString.IndexOf("NotInStringPattern");
        }
    }
}
