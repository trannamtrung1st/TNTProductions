using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.Helpers;
using static TNT.Core.Template.DataService.Helpers.GeneralHelper;

namespace TNT.Core.Template.DataService
{
    public class CodeFirstGenerator
    {

        public CodeFirstGenerator()
        {
        }

        public void Generate(DbContext context,
            string projectPath, string projectName)
        {
            using (context)
            {
                FileHelper.DeleteDataServiceStructure(
                    projectPath);
                var gen = context.GetDataServiceGenerator(
                    "../../../", projectPath, projectName,
                    JsonPropertyFormatEnum.JsonStyle, true, true);
                gen.Generate();
            }
        }
    }
}
