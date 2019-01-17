using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.Helpers;

namespace TNT.Core.Template.Interfaces
{
    public interface IGenerator
    {
        string Generate();
        string T();//VisualHelper.PrintTabs()
        string E();//VisualHelper.Enter()

        // `key` => value
        IDictionary<string, string> ResolveMapping { get; set; }
        // auto call
        void Resolve();

    }

    public abstract class Generator : IGenerator
    {
        public string E()
        {
            return VisualHelper.Enter();
        }
        public abstract string Generate();
        public string T()
        {
            return VisualHelper.PrintTabs();
        }

        public IDictionary<string, string> ResolveMapping { get; set; } = new Dictionary<string, string>();
        public abstract void Resolve();

    }
}
