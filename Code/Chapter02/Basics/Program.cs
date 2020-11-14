﻿using System;
using System.Linq;
using System.Reflection;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {//the start of a block
            // loop through the assemblies that this app references
            System.Data.DataSet ds;
            System.Net.Http.HttpClient client;
            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                var a=Assembly.Load(new AssemblyName(r.FullName));
                int methodCount=0;
                foreach (var t in a.DefinedTypes)
                {
                    methodCount+=t.GetMethods().Count();
                }
                Console.WriteLine("{0:NO} types with {1:NO} methods in {2} assembly.",arg0:a.DefinedTypes.Count(),arg1:methodCount,arg2:r.Name );
            }
        }//end of the block
    }
}
