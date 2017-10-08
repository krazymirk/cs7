// Copyright 2017 Krasimir Kostadinov. All rights reserved. Use of this source code is governed by the Apache License 2.0, as found on https://www.apache.org/licenses/LICENSE-2.0

using System;
using System.Threading.Tasks;

namespace WhatsNewInCS71
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int age = default;
            var name = "John Smith";
            var tuple = (name, age);
            Console.WriteLine($"{tuple.name} is {tuple.age} years old");
            Console.ReadKey();
        }
    }
}