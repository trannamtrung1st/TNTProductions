using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataMapper;
using TNT.IoContainer.Container;
using TNT.IoContainer.Wrapper;

namespace MyBenchmark
{
    public interface IMyRepository : IResource
    {
        void Test();
    }

    public class MyRepository : IMyRepository
    {
        public ResourceWrapper Wrapper { get; set; }

        public MyRepository() { }
        public MyRepository(int test)
        {
        }

        public void ReInit(params object[] initParams)
        {
            disposedValue = false;
        }

        public void Test()
        {
            Console.WriteLine("OK");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                if (Wrapper != null)
                    Wrapper.IsFree = true;
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~MyRepository()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class Program
    {

        public static Stopwatch sw;

        public static void Main(string[] args)
        {
            sw = Stopwatch.StartNew();

            IoContainerTest(); //TContainer won
            Console.WriteLine("--------------------");
            MapperTest(); //AutoMapper won

            sw.Stop();
        }

        public static void IoContainerTest()
        {
            //Autofac init
            var builder = new ContainerBuilder();
            builder.RegisterType<MyRepository>().As<IMyRepository>();
            IContainer autofac = builder.Build();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            //-------------------

            //TNT init
            ITContainer tnt = new TContainer();
            tnt.RegisterType<IMyRepository, MyRepository>();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            //-------------------

            //Autofac Resolution
            for (var i = 0; i < 100000; i++)
            {
                autofac.Resolve<IMyRepository>(new NamedParameter("test", 1));
                autofac.Resolve<IMyRepository>();
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            //------------------

            //TNT Resolution
            for (var i = 0; i < 100000; i++)
            {
                tnt.Resolve<IMyRepository>(Params.Constructor(1));
                tnt.Resolve<IMyRepository>();
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            //------------------

        }

        public static void MapperTest()
        {
            //AutoMapper config
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<People, Student>();
                cfg.CreateMap<Student, Student>();
                cfg.CreateMap<Student, People>()
                    .ForMember(pp => pp.DontKnow, opts => opts.MapFrom(source => source.Known))
                    .ForMember(pp => pp.TestTing, opts => opts.MapFrom(source => source.Test));
            });
            var autoMapper = config.CreateMapper();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();

            //DataMapper config
            IMapper mapper = new Mapper();
            mapper.CreateMap<People, Student>();
            mapper.CreateMap<Student, Student>();
            mapper.CreateMap<Student, People>(cfg =>
            {
                cfg.Member(pp => pp.DontKnow).MapWith(st => st.Known);
                cfg.Member(pp => pp.TestTing).MapWith(st => st.Test);
            });
            Console.WriteLine(sw.ElapsedMilliseconds);
            //--------------------


            sw.Restart();
            //AutoMapper
            for (var i = 0; i < 100000; i++)
            {
                var s = new Student()
                {
                    Id = i,
                    Test = new Impl(),
                    Known = "ASDAS",
                    Name = "TNT"
                };
                var p = autoMapper.Map<People>(s);
                var st = autoMapper.Map<Student>(p);
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();

            //Data Mapper
            for (var i = 0; i < 100000; i++)
            {
                var s = new Student()
                {
                    Id = i,
                    Test = new Impl(),
                    Known = "ASDAS",
                    Name = "TNT"
                };
                var p = mapper.Map<People>(s);
                var st = mapper.Map<Student>(p);
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
        }

    }

    //for mapper test
    class Base
    {

    }
    class Impl : Base
    {
        public People p { get; set; }
    }
    class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DontKnow { get; set; }
        public Base TestTing { get; set; }
    }
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Known { get; set; }
        public Impl Test { get; set; }
    }

}
