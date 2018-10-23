using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.IoContainer.Wrapper
{
    /*
     * ALL INJECTABLE PARAMS MUST STICK WITH AN ID (ID 0 IS THE DEFAULT CONSTRUCTOR FOR AUTO INJECTION)
     * */

    public enum ParamsPolicy
    {
        Constructor = 1, //all params used as raw value params
        AllInjectables = 2, //all params are injectable params
        InjectableParams = 3, //combination of raw and injectable
    }
    public enum ParamsType
    {
        Injectable = 1 //Specify that this param will be resolved
    }

    public class Params
    {
        internal object[] Parameters { get; set; }
        internal ParamsPolicy Policy { get; set; }

        //an injectable params constructor must stick with an ID
        //when resolve and register
        internal int Id { get; set; }

        private Params() { }

        public static Params Constructor(params object[] parameters)
        {
            var constructorParams = new Params() { Parameters = parameters };
            constructorParams.Policy = ParamsPolicy.Constructor;

            return constructorParams;
        }

        public static Params InjectAll(int id)
        {
            var injectAllParams = new Params() { };
            injectAllParams.Id = id;
            injectAllParams.Policy = ParamsPolicy.AllInjectables;

            return injectAllParams;
        }

        public static Params FromParams(int id, params object[] parameters)
        {
            var injectableParams = new Params() { };
            injectableParams.Parameters = parameters;
            injectableParams.Policy = ParamsPolicy.InjectableParams;
            injectableParams.Id = id;

            return injectableParams;
        }

    }
}
