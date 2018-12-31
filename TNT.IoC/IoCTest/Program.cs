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
            using (var db = new EmployeeManagerEntities())
            {
                Console.WriteLine(db.Employees.FirstOrDefault().EmpName);
            }
        }
    }
}

