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
            var options = new BuilderOptions();
            options.InjectableConstructors = new Dictionary<int, Params[]>();
            options.InjectableConstructors[0] = new Params[] { Params.Injectable<IA>() };

            var container = new TContainerBuilder()
                .RegisterType<A>()
                .RegisterType<B>(options)
                .RegisterType<IA, A>().Build();

            var sw = Stopwatch.StartNew();
            var type = typeof(B);
            var cons = type.GetConstructor(new Type[] { typeof(int), typeof(A) });
            for (int i = 0; i < 1000; i++)
            {
                //var a = cons.Invoke(new object[] { 1, new A(1) });
                var a = container.Resolve<B>();
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}

