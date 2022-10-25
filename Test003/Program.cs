using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Test003
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoTheJob();
            var summary = BenchmarkRunner.Run<Benchmarks>();
            Console.ReadLine();
        }

        private static void DoTheJob()
        {
            List<ReflectionClass<MyClass>> reflectors = new List<ReflectionClass<MyClass>>();

            for (int i = 0; i < 1000; i++)
            {
                MyClass myClass = new MyClass();
                ReflectionClass<MyClass> reflectionClass = new ReflectionClass<MyClass>(myClass);
                reflectors.Add(reflectionClass);
            }

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
