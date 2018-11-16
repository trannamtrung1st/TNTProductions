using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.IoContainer.Attributes
{
    /*
     * PROPERTY ATTRIBUTE:
     * - Inject obj after init base obj
     * */
    [AttributeUsage(AttributeTargets.Property)]
    public class Injectable : Attribute
    {
        public Injectable() { }
    }

    /*
     * Injectable params must stick with an Id for container to know which to resolve
     * + Must be put above public constructor
     * */
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method)]
    public class InjectableParams : Attribute
    {
        internal int Id { get; set; }
        public InjectableParams(int id)
        {
            Id = id;
        }
    }

    /*
     * Injectable attribute props will be created after init obj
     * so if you want to use Injectable automatically along with constructor:
     * - Create a method (same params as your constructor) and put PostConstruct attribute above it
     * - Private is allowed, return type will be discarded on PostConstruct method
     * */
    [AttributeUsage(AttributeTargets.Method)]
    public class PostConstruct : Attribute
    {
        public PostConstruct() { }
    }

}
