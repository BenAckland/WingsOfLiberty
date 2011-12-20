using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

namespace WingsOfLiberty.Tests
{
    public class TestBase
    {
        public void Describes(string description)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(description);
            Console.WriteLine("--------------------------------------");
        }

        public void IsPending()
        {
            Console.WriteLine(" -- PENDING -- ");
            Assert.Inconclusive();
        }

        public string GetCaller()
        {
            StackTrace stack = new StackTrace();
            return stack.GetFrame(2).GetMethod().Name.Replace("_", " ");
        }
    }
}
