using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Perfolizer.Mathematics.Common;

namespace ConsoleApp4
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LINQBenchmark
    {
        private readonly List<int> myTestList = Enumerable.Range(1, 1000).ToList();
        private List<Handle> myHandleList = new List<Handle>();

        [GlobalSetup]
        public void GlobalSetup()
        {
            myHandleList = myTestList.Select(x => new Handle(Convert.ToInt64(x))).ToList();
        }

        //[Benchmark]
        public int FirstWithLinq()
        {
            return myTestList.First();
        }

        //[Benchmark]
        public int FirstWithDefault()
        {
            return myTestList[0];
        }

        //[Benchmark]
        public int LastWithLinq()
        {
            return myTestList.Last();
        }

        //[Benchmark]
        public int LastWithDefault()
        {
            return myTestList[myTestList.Count - 1];
        }

        public List<int> ConvertListOfHandlesToListOfIntWithLinq()
        {
            return myHandleList.Select(x => Convert.ToInt32(x.Value)).ToList();
        }

        public List<int> ConvertListOfHandlesToListOfIntDefault()
        {
            var returnList = new List<int>();

            foreach (var handle in myHandleList)
            {
                returnList.Add(Convert.ToInt32(handle.Value));
            }

            return returnList;
        }

        public List<int> ConvertListOfHandlesToListOfIntDefaultWithParseFromString()
        {
            var returnList = new List<int>();

            foreach (var handle in myHandleList)
            {
                returnList.Add(int.Parse(handle.Value.ToString()));
            }

            return returnList;
        }

        public List<int> ConvertListOfHandlesToListOfIntDefaultWithCast()
        {
            var returnList = new List<int>();

            foreach (var handle in myHandleList)
            {
                returnList.Add((int)handle.Value);
            }

            return returnList;
        }

        public List<int> ConvertListOfHandlesToListOfIntDefaultWithConvert()
        {
            var returnList = new List<int>();

            foreach (var handle in myHandleList)
            {
                returnList.Add(Convert.ToInt32(handle.Value));
            }

            return returnList;
        }

        public int[] ListToArrayUsingLinq()
        {
            return myTestList.ToArray();
        }

        public int[] ListToArrayWithoutLinq()
        {
            int[] returnArray = new int[myTestList.Count];

            for (int i = 0; i < myTestList.Count; i++)
            {
                returnArray[i] = myTestList[i];
            }

            return returnArray;
        }

        public int[] ListToArrayWithoutLinqForeach()
        {
            int[] returnArray = new int[myTestList.Count];

            int count = 0;
            foreach (int value in myTestList)
            {
                returnArray[count] = value;

                count++;
            }

            return returnArray;
        }

        [Benchmark]
        public List<int> Add10ElementsToListUsingAdd()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);

            return list;
        }

        [Benchmark]
        public List<int> Add10ElementsToListUsingInitialization()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return list;
        }

        [Benchmark]
        public List<int> Add10ElementsToListUsingAddRange()
        {
            var list = new List<int>();

            list.AddRange(new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            return list;
        }

        private class Handle
        {
            public long Value { get; }

            public Handle(long value)
            {
                this.Value = value;
            }
        }
    }

}
