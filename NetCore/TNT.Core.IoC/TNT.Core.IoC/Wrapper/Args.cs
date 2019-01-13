using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.IoC.Wrapper
{
    public class Args
    {
        internal bool injectMode;
        internal object val;
        internal Type argsType;

        internal Args()
        {
        }

        internal Args(Type type)
        {
            injectMode = true;
            argsType = type;
        }

        internal Args(object val, Type type)
        {
            this.val = val;
            argsType = type;
            injectMode = false;
        }

        public static Args Value(object val)
        {
            return new Args(val, val.GetType());
        }
        public static Args Inject<Type>()
        {
            return new Args(typeof(Type));
        }
        public static Args Inject(Type type)
        {
            return new Args(type);
        }
        public static Args Null<Type>()
        {
            return new Args(null, typeof(Type));
        }
        public static Args Null(Type type)
        {
            return new Args(null, type);
        }

        public static Args[] Array(params Args[] args)
        {
            return args;
        }

        public static object[] Array(params object[] args)
        {
            return args;
        }

    }
}
