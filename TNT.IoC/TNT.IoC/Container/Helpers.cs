using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TNT.IoC.Container
{

    public static class Extension
    {
        public static bool IsSuitableForArgs(this ConstructorInfo ctor, object[] args)
        {
            var para = ctor.GetParameters();
            var len = para.Length;
            if (len == args.Length)
            {
                for (var i = 0; i < len; i++)
                    if (!para[i].ParameterType.IsAssignableFrom(args[i].GetType()))
                        return false;
            }
            else
                return false;
            return true;
        }
    }
}
