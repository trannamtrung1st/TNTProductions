using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.Auto;
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
            bool activeCol = true,
            bool requestScope = false
            )
        {
            return new AutoDataServiceGen(dbContext, projectPath, projectName,
                vmPropStyle, activeCol, requestScope);
        }
    }
}
