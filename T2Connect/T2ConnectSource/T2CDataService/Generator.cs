using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Auto;

namespace T2CDataService
{

    //class A
    //{
    //    public int test { get; set; }
    //    public int a { get; set; }
    //    public int b { get; set; }
    //    public int c { get; set; }
    //}

    //class B
    //{
    //    public int a { get; set; }
    //    public int b { get; set; }
    //    public int c { get; set; }
    //}

    //class C
    //{
    //    public int test { get; set; }
    //    public B obj { get; set; }
    //}

    class Generator
    {
        static void Main(string[] args)
        {
            var autoGen = new AutoDataServiceGen(
                @"T:\TNT\Workspace\TNTProductions\T2Connect\T2ConnectSource\T2CDataService",
                "T2CDataService",
                "bin/Debug/TNT.TemplateApi.dll",
                "bin/Debug/TNT.DataServiceTemplate.dll",
                "Models/T2CEntities.edmx");
            autoGen.AddVMExceptProps("Username", "Password");
            autoGen.AddVMIgnoreProps("Deactive");
            autoGen.Generate();

            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<A, C>()
            //        .ForMember(C => C.obj, opt => opt.MapFrom(A => new B()
            //        {
            //            a = A.a,
            //            b = A.b,
            //            c = A.c
            //        })).ReverseMap()
            //        .ForMember(A => A.a, opt => opt.MapFrom(C => C.obj.a))
            //        .ForMember(A => A.b, opt => opt.MapFrom(C => C.obj.b))
            //        .ForMember(A => A.c, opt => opt.MapFrom(C => C.obj.c));

            //});
            //var m = mapper.CreateMapper();
            //var a = new A()
            //{
            //    a = 1,
            //    b = 2,
            //    c = 3,
            //    test = 4
            //};
            //var c = new C()
            //{
            //    test = 4,
            //    obj = new B()
            //    {
            //        a = 1,
            //        b = 2,
            //        c = 3
            //    }
            //};
            //a = m.Map<A>(c);
        }

    }
}
