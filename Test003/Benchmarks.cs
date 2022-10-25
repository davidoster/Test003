using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Test003
{
    [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    [MemoryDiagnoser]
    public class Benchmarks
    {
        public List<ReflectionClass<MyClass>> reflectors { get; set; }

        public Benchmarks()
        {

        }

        [Benchmark]
        public void CreateReflectors()
        {
            reflectors = new List<ReflectionClass<MyClass>>();

            for (int i = 0; i < 1000; i++)
            {
                MyClass myClass = new MyClass();
                ReflectionClass<MyClass> reflectionClass = new ReflectionClass<MyClass>(myClass);
                reflectors.Add(reflectionClass);
            }
        }

        [Benchmark]
        public void FillReflectors()
        {
            CreateReflectors();
            for (int i = 0; i < 1000; i++)
            {
                for (int k = 0; k < reflectors.Count; k++)
                {
                    int width = (int)reflectors[k].GetValue("width");
                    reflectors[k].SetValue("width", width + new Random().Next());

                    int height = (int)reflectors[k].GetValue("height");
                    reflectors[k].SetValue("height", height + new Random().Next());

                    Vector3 position = (Vector3)reflectors[k].GetValue("position");
                    reflectors[k].SetValue("position", position + new Vector3(10, 0, 0));

                    Quaternion quaternion = (Quaternion)reflectors[k].GetValue("rotation");
                    reflectors[k].SetValue("rotation", quaternion + new Quaternion(10, 0, 10, 0));
                }
            }
        }


    }
}
