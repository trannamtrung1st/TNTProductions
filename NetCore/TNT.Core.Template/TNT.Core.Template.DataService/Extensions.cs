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
        public static DataServiceGen GetDataServiceGenerator(
            this DbContext dbContext,
            string projectPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle,
            bool activeCol = true,
            bool requestScope = false
            )
        {
            return new DataServiceGen(dbContext, projectPath, projectName,
                vmPropStyle, requestScope);
        }

        public static DataServiceGen GetDataServiceGenerator(
            this DbContext dbContext,
            string projectPath,
            string outputPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle,
            bool activeCol = true,
            bool requestScope = false
            )
        {
            return new DataServiceGen(dbContext, projectPath, outputPath, projectName,
                vmPropStyle, requestScope);
        }
    }
}
