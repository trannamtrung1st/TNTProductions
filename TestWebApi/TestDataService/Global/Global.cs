using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TestDataService.ViewModels;

namespace TestDataService.Global
{
    public partial class G
    {

        public static void Configure()
        {
            //MapperConfigs.Add(
            //    cfg =>
            //    {
            //        cfg.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            //        cfg.CreateMap<EmployeeSkill, EmployeeSkillViewModel>().ReverseMap();
            //        cfg.CreateMap<Skill, SkillViewModel>().ReverseMap();
            //    });
            DefaultConfigure();
        }

    }
}
