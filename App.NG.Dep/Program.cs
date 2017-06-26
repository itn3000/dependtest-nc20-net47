using System;

namespace propertychangedtest
{
    using System.Reflection;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            new Lib.Class1();
            foreach(var mod in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(var t in mod.GetTypes().Where(x => x.FullName.StartsWith("Lib")))
                {
                    if(t.Name=="Class1")
                    {
                        foreach(var prop in t.GetProperties())
                        {
                            Console.WriteLine($"prop={prop.Name}");
                        }
                    }
                }
            }
                
        }
    }
}
