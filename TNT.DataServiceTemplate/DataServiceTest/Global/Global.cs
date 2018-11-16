using DataServiceTest.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceTest.Global
{
    public partial class G
    {

        public static void Configure()
        {
            G.Builder.RegisterSingleton<IUnitOfWork>(new UnitOfWork());
            G.MapperConfigs.Add(cfg => { });
            G.DefaultConfigure();
        }

    }
}
