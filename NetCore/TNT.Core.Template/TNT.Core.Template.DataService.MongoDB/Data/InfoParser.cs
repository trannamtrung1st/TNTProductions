﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Helpers;

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
                if (SetPKInfo(eInfo, eT))
                    Info.Entities.Add(eInfo);
            }
        }

        private bool SetPKInfo(EntityInfo eInfo, Type eType)
        {
            var property = eType.GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(BsonIdAttribute), true).Any());
            if (property == null)
                return false;
            eInfo.PKClass = property.PropertyType.SyntaxName();
            eInfo.PKProp = property.Name;
            return true;
        }

    }
}