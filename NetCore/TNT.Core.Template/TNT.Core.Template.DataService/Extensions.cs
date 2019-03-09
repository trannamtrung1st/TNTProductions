using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.Auto;
using TNT.Core.Template.DataService.Data;
using static TNT.Core.Template.DataService.Helpers.GeneralHelper;

namespace TNT.Core.Template.DataService
{
    public static class Extensions
    {
        public static AutoDataServiceGen GetDataServiceGenerator(
            this DbContext dbContext,
            string projectPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle,
            DIContainer dIContainer,
            bool activeCol = true,
            bool requestScope = false
            )
        {
            return new AutoDataServiceGen(dbContext, projectPath, projectName,
                vmPropStyle, dIContainer, requestScope);
        }

        public static AutoDataServiceGen GetDataServiceGenerator(
            this DbContext dbContext,
            string projectPath,
            string outputPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle,
            DIContainer dIContainer,
            bool activeCol = true,
            bool requestScope = false
            )
        {
            return new AutoDataServiceGen(dbContext, projectPath, outputPath, projectName,
                vmPropStyle, dIContainer, requestScope);
        }
    }
}
