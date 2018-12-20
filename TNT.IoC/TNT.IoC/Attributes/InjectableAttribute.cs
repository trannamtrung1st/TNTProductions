using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.IoC.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Parameter
        , AllowMultiple = false, Inherited = true)]
    public class InjectableAttribute : Attribute
    {
        internal int Id { get; set; }
        public InjectableAttribute(int id = 0)
        {
            Id = id;
        }
    }
}
