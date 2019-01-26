using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TNT.Template.DataService.Helpers;

namespace TNT.Template.DataService.Data
{
    public class EdmxParser
    {

        private XElement Root { get; set; }
        public DataInfo Data { get; set; }
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
                { "Binary", "byte[]" },
                { "Guid", "System.Guid" },
                { "Time", "System.TimeSpan" }
            };

        public EdmxParser(string edmxFile, string projectName, bool activeCol = true)
        {
            Data = new DataInfo();
            Data.ActiveCol = activeCol;
            SetRoot(edmxFile);
            SetDBInfo();
            SetEntitiesInfo();
            Data.ProjectName = projectName;
        }

        private void SetRoot(string edmxFile)
        {
            var doc = XDocument.Load(edmxFile);
            Root = doc.Root;
        }

        private void SetDBInfo()
        {
            var conceptModel = Root.Descendants().SingleOrDefault(e => e.Name.LocalName.Equals("ConceptualModels"));
            var entityContainer = conceptModel.Descendants().SingleOrDefault(e => e.Name.LocalName.Equals("EntityContainer"));
            Data.ContextName = entityContainer.Attribute("Name").Value;

        }

        private void SetEntitiesInfo()
        {
            var conceptualModels = Root.Descendants().SingleOrDefault(e => e.Name.LocalName.Equals("ConceptualModels"));
            var entities = conceptualModels.Descendants().Where(e => e.Name.LocalName.Equals("EntityType"));
            foreach (var e in entities)
            {
                var eInfo = new EntityInfo(Data);
                eInfo.EntityName = GeneralHelper.SingularizeNoun(e.Attribute("Name").Value);
                eInfo.PluralEntityName = GeneralHelper.PluralizeNoun(eInfo.EntityName);
                eInfo.VMClass = eInfo.EntityName + "ViewModel";
                eInfo.Activable = IsActivable(e);
                SetPKInfo(eInfo, e);
                SetPropInfo(eInfo, e);
                SetNavPropInfo(eInfo, e, conceptualModels);
                Data.Entities.Add(eInfo);
            }
        }

        private void SetPropInfo(EntityInfo eInfo, XElement entity)
        {
            var propMapping = eInfo.PropMapping;
            var props = entity.Descendants().Where(e => e.Name.LocalName.Equals("Property"));
            foreach (var p in props)
            {
                var name = p.Attribute("Name").Value;
                var nullableAttr = p.Attribute("Nullable");
                var nullable = (nullableAttr == null ? true : nullableAttr.Value.Equals("true"));

                var type = p.Attribute("Type").Value;
                var extra = type.IndexOf("(");
                if (extra > -1)
                    type = type.Remove(extra);
                type = TypeMapping[type];

                if (nullable && !DefaultNullableType.Contains(type))
                    propMapping.Add(name, type + "?");
                else
                    propMapping.Add(name, type);
            }
        }

        private void SetNavPropInfo(EntityInfo eInfo, XElement entity, XElement concept)
        {
            var navProp = eInfo.NavPropMapping;
            var navColProp = eInfo.NavCollectionPropMapping;
            var props = entity.Descendants().Where(e => e.Name.LocalName.Equals("NavigationProperty"));
            foreach (var p in props)
            {
                var name = p.Attribute("Name").Value;
                var relationship = p.Attribute("Relationship").Value;
                relationship = relationship.Substring(relationship.IndexOf('.') + 1);
                var fk = concept.Descendants().Where(e =>
                    e.Name.LocalName.Equals("Association") && e.Attribute("Name").Value.Equals(relationship)).FirstOrDefault();
                if (fk != null)
                {
                    var roles = fk.Descendants().Where(e => e.Name.LocalName.Equals("End")).ToList();
                    var role1Name = roles[0].Attribute("Role").Value;
                    var role1Type = roles[0].Attribute("Type").Value;
                    role1Type = role1Type.Substring(role1Type.IndexOf('.') + 1);
                    var role1multiplicity = roles[0].Attribute("Multiplicity").Value;

                    var role2Name = roles[1].Attribute("Role").Value;
                    var role2Type = roles[1].Attribute("Type").Value;
                    role2Type = role2Type.Substring(role2Type.IndexOf('.') + 1);
                    var role2multiplicity = roles[1].Attribute("Multiplicity").Value;

                    var fromRole = p.Attribute("FromRole").Value;
                    var toRole = p.Attribute("ToRole").Value;
                    if (toRole.Equals(role1Name))
                    {
                        navProp.Add(name, role1Type + "ViewModel");
                    }
                    else
                    {
                        if (role2multiplicity.Equals("*"))
                        {
                            navColProp.Add(name, "IEnumerable<" + role2Type + "ViewModel>");
                        }
                        else
                        {
                            navProp.Add(name, role2Type + "ViewModel");
                        }
                    }
                }
            }
        }

        private void SetPKInfo(EntityInfo eInfo, XElement entity)
        {
            var pkProps = new List<string>();
            var props = entity.Descendants().Where(e => e.Name.LocalName.Equals("PropertyRef"));
            foreach (var p in props)
            {
                pkProps.Add(p.Attribute("Name").Value);
            }
            var propsEle = entity.Descendants().Where(e =>
                e.Name.LocalName.Equals("Property") &&
                pkProps.Contains(e.Attribute("Name").Value));

            string tempPKType = null;
            foreach (var p in propsEle)
            {
                var name = p.Attribute("Name").Value;

                var type = p.Attribute("Type").Value;
                var extra = type.IndexOf("(");
                if (extra > -1)
                    type = type.Remove(extra);
                type = TypeMapping[type];

                tempPKType = type;
                eInfo.PKPropMapping.Add(name, type);
            }

            if (propsEle.Count() > 1)
                eInfo.PKClass = eInfo.EntityName + "PK";
            else eInfo.PKClass = tempPKType;
        }

        private bool IsActivable(XElement entity)
        {
            var colName = (Data.ActiveCol ? "Active" : "Deactive");
            return entity.Descendants().Any(e =>
                e.Attribute("Name") != null
                && e.Attribute("Name").Value.Equals(colName)
                && e.Attribute("Type") != null
                && e.Attribute("Type").Value.Equals("Boolean")
                //&& e.Attribute("Nullable") != null
                /*&& e.Attribute("Nullable").Value.Equals("false")*/);
        }

    }
}
