using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<LINQBenchmark>();
        }
    }
}
