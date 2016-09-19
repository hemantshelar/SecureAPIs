using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecuredWebAPI
{
    public class TestClass :  IDisposable
    {
        public TestClass()
        {
            Console.WriteLine("Inside test class.");
        }

        public static TestClass Create()
        {
            return new TestClass();
        }

        public void Dispose()
        {
            Console.WriteLine("ok");
        }
    }
}