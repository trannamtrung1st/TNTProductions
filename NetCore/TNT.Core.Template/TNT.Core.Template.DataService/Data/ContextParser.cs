using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using TNT.Core.Template.DataService.Helpers;

namespace TNT.Core.Template.DataService.Data
{
    public class ContextParser
    {
        public ContextInfo Data { get; set; }
        protected DbContext context;
        private HashSet<string> DefaultNullableType
            = new HashSet<string>()
            {
                "string",
                "byte[]"
            };
        private IDictionary<string, string> TypeMapping { get; set; }
            = new Dictionary<string, string>()
            {
                { "Byte", "byte"},
                { "SByte", "sbyte"},
                { "Int32", "int"},
                { "UInt32", "uint"},
                { "Int16", "short"},
                { "UInt16", "ushort"},
                { "Int64", "long"},
                { "UInt64", "ulong"},
                { "Single", "float"},
                { "Double", "double"},
                { "Char", "char"},
                { "Boolean", "bool"},
                { "Object", "object"},
                { "String", "string" },
                { "Decimal", "decimal" },
                { "DateTime", "DateTime" },
                { "TimeSpan", "System.TimeSpan" },
                { "DateTimeOffset", "DateTimeOffset" },
                { "Binary", "byte[]" },
                { "Byte[]", "byte[]" },
                { "Guid", "System.Guid" },
                { "Time", "System.TimeSpan" }
            };

        public ContextParser(DbContext context, string projectName, bool activeCol = true)
        {
            Data = new ContextInfo();
            Data.ProjectName = projectName;
            Data.ActiveCol = activeCol;
            this.context = context;
            SetDBInfo();
            SetEntitiesInfo();
        }

        private void SetDBInfo()
        {
            Data.ContextName = context.GetType().Name;
            Data.ContextNamespace = context.GetType().Namespace;
            Data.ContextNamespace = Data.ProjectName + Data.ContextNamespace.Remove(0, Data.ContextNamespace.IndexOf(".Models"));
        }

        private void SetEntitiesInfo()
        {
            var eTypes = context.Model.GetEntityTypes();
            foreach (var eT in eTypes)
            {
                var eInfo = new EntityInfo(Data);
                eInfo.EntityName = eT.Name.Substring(eT.Name.LastIndexOf('.') + 1);
                eInfo.VMClass = eInfo.EntityName + "ViewModel";
                eInfo.Activable = IsActivable(eT);
                SetPKInfo(eInfo, eT);
                SetPropInfo(eInfo, eT);
                SetNavPropInfo(eInfo, eT);
                Data.Entities.Add(eInfo);
            }
        }

        private void SetPropInfo(EntityInfo eInfo, IEntityType eType)
        {
            var propMapping = eInfo.PropMapping;
            var props = eType.GetProperties();
            foreach (var p in props)
            {
                var name = p.Name;

                var type = p.ClrType.Name;
                var nullable = type.Contains("Nullable");
                if (nullable)
                    type = TypeMapping[p.ClrType.GetGenericArguments().FirstOrDefault().Name];
                else type = TypeMapping[type];

                if (nullable && !DefaultNullableType.Contains(type))
                    propMapping.Add(name, type + "?");
                else
                    propMapping.Add(name, type);
            }
        }

        private void SetNavPropInfo(EntityInfo eInfo, IEntityType eType)
        {
            var navProp = eInfo.NavPropMapping;
            var navColProp = eInfo.NavCollectionPropMapping;
            var props = eType.GetNavigations();
            foreach (var p in props)
            {
                var name = p.Name;
                var type = p.ClrType.Name;
                if (p.IsCollection())
                {
                    navColProp.Add(name, "IEnumerable<" + p.ClrType.GetGenericArguments().FirstOrDefault().Name + "ViewModel>");
                }
                else
                {
                    navProp.Add(name, type + "ViewModel");
                }
            }
        }

        private void SetPKInfo(EntityInfo eInfo, IEntityType eType)
        {
            var pkProps = new List<string>();
            var props = eType.FindPrimaryKey().Properties;
            string tempPKClass = null;
            foreach (var p in props)
            {
                pkProps.Add(p.Name);
                tempPKClass = TypeMapping[p.ClrType.Name];
                eInfo.PKPropMapping[p.Name] = tempPKClass;
            }
            if (pkProps.Count() > 1)
                eInfo.PKClass = eInfo.EntityName + "PK";
            else eInfo.PKClass = tempPKClass;
        }

        private bool IsActivable(IEntityType eType)
        {
            var colName = (Data.ActiveCol ? "Active" : "Deactive");
            var prop = eType.FindProperty(colName);
            return (prop != null && (prop.ClrType.Equals(typeof(bool)) || prop.ClrType.Equals(typeof(bool?))));
        }

    }
}
