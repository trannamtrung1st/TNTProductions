using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNT.Core.Template.DataService.MongoDB.Data
{
    public class InfoParser
    {
        public Info Info { get; set; }

        public InfoParser(IEnumerable<Type> entities, string projectName)
        {
            Info = new Info();
            Info.ProjectName = projectName;
            SetEntitiesInfo(entities);
        }

        private void SetEntitiesInfo(IEnumerable<Type> entities)
        {
            var eTypes = entities;
            foreach (var eT in eTypes)
            {
                var eInfo = new EntityInfo(Info);
                eInfo.SourceType = eT;
                eInfo.EntityName = eT.Name.Substring(eT.Name.LastIndexOf('.') + 1);
                eInfo.VMClass = eInfo.EntityName + "ViewModel";
                SetPKInfo(eInfo, eT);
                Info.Entities.Add(eInfo);
            }
        }

        private void SetPKInfo(EntityInfo eInfo, Type eType)
        {
            var property = eType.GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(BsonIdAttribute), true).Any());
            eInfo.PKClass = property.PropertyType.Name;
            eInfo.PKProp = property.Name;
        }

    }
}
