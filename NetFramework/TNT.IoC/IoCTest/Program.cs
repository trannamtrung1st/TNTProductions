using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TNT.IoC.Container;

namespace IoCTest
{
    public interface IA
    {

    }

    public class A : IA
    {
        public int p1 { get; set; }

        public A()
        {
        }

    }

    public class C : IA
    {

    }

    public class B
    {
        public IA GetA { get; set; }

        public B()
        {
        }

        public B(IA a)
        {
            GetA = a;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var ioc = new TContainerBuilder();
            ioc.RegisterSingleton<IA, A>(null);
            var cont = ioc.Build();
            Console.WriteLine(cont.Resolve<IA>());
        }
    }
}

