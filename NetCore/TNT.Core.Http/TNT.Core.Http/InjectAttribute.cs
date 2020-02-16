using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Http
{

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        public InjectAttribute()
        {
        }
        
    }
}
