using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.IoContainer.Wrapper
{
    internal interface IImplementType
    {
        object[] DefaultInitParams { get; set; }
        Type WrappedType { get; set; }
    }

    internal class ImplementType : IImplementType
    {

        public object[] DefaultInitParams { get; set; }
        public Type WrappedType { get; set; }

    }
}
