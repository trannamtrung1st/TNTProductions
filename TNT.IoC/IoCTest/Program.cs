using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TNT.IoC.Attributes;
using TNT.IoC.Container;
using TNT.IoC.Wrapper;

namespace IoCTest
{
    public interface IA
    {

    }

    public class A : IA
    {
        public int p1 { get; set; }

        public A(int iasd)
        {
            p1 = iasd;
        }

    }

    public class C : IA
    {

    }

    public class B
    {
        public IA GetA { get; set; }

        [Injectable]
        public B(int i, [Injectable] IA a)
        {
            GetA = a;
            Console.WriteLine(i + "" + GetA);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var container = new TContainerBuilder()
                .RegisterType<A>()
                .RegisterType<B>()
                .RegisterType<IA, A>().Build();
            var a = container.Resolve<A>(new object[] { 1123 });
            Console.WriteLine(a.p1);
        }
    }
}

