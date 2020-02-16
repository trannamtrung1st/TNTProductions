using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Helpers.DI
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        public InjectAttribute()
        {
        }

    }
}
