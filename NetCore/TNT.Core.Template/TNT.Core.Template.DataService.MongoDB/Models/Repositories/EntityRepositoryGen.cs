using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Models.Repositories
{
    public class EntityRepositoryGen : FileGen
    {
        private EntityInfo EInfo { get; set; }
        public EntityRepositoryGen(EntityInfo eInfo)
        {
            EInfo = eInfo;
            Directive.Add(EInfo.Info.ProjectName + ".Models.Configs",
                "MongoDB.Driver");

            ResolveMapping["entity"] = EInfo.EntityName;
            ResolveMapping["entityPK"] = EInfo.PKClass;
            ResolveMapping["entityVM"] = EInfo.VMClass;

            //GENERATE
            GenerateNamespace();
            GenerateIEntityRepository();
            GenerateEntityRepository();
            GenerateEntityRepositoryBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Info.ProjectName + ".Models.Repositories";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IEntityRepository : IBaseRepository<Entity, EntityPK>
        private ContainerGen IEntityRepository { get; set; }
        private BodyGen IEntityRepositoryBody { get; set; }
        public void GenerateIEntityRepository()
        {
            IEntityRepository = new ContainerGen();
            IEntityRepository.Signature = "public partial interface I`entity`Repository : IBaseRepository<`entity`, `entityPK`>";
            IEntityRepositoryBody = IEntityRepository.Body;
            NamespaceBody.Add(IEntityRepository, new StatementGen(""));
        }

        //generate EntityRepository class
        private ContainerGen EntityRepository { get; set; }
        private BodyGen EntityRepositoryBody { get; set; }
        public void GenerateEntityRepository()
        {
            EntityRepository = new ContainerGen();
            EntityRepository.Signature =
                "public partial class `entity`Repository : BaseRepository<`entity`, `entityPK`>, I`entity`Repository";
            EntityRepositoryBody = EntityRepository.Body;

            NamespaceBody.Add(EntityRepository);
        }

        public void GenerateEntityRepositoryBody()
        {
            var c0 = new ContainerGen();
            c0.Signature = "public `entity`Repository(IMongoDbSettings settings) : base(settings)";

            var s1 = new StatementGen("#region CRUD area");

            var m2 = new ContainerGen();
            m2.Signature = "public override `entity` FindById(`entityPK` id)";
            m2.Body.Add(new StatementGen(
                "var entity = _collection.Find(",
                $"{GetKeyCompareExpr()}).FirstOrDefault();",
                "return entity;"));

            var m3 = new ContainerGen();
            m3.Signature = "public override async Task<`entity`> FindByIdAsync(`entityPK` id)";
            m3.Body.Add(
                new StatementGen(
                "var entity = await (await _collection.FindAsync(",
                $"{GetKeyCompareExpr()})).FirstOrDefaultAsync();",
                "return entity;"));

            var m4 = new ContainerGen();
            m4.Signature = "public override DeleteResult Remove(`entityPK` id)";
            m4.Body.Add(
                new StatementGen(
                "return _collection.DeleteOne(",
                $"{GetKeyCompareExpr()});"));

            var m5 = new ContainerGen();
            m5.Signature = "public override DeleteResult Remove(IClientSessionHandle handle, `entityPK` id)";
            m5.Body.Add(
                new StatementGen(
                "return _collection.DeleteOne(handle,",
                $"{GetKeyCompareExpr()});"));

            var m6 = new ContainerGen();
            m6.Signature = "public override async Task<DeleteResult> RemoveAsync(`entityPK` id)";
            m6.Body.Add(
                new StatementGen(
                "return await _collection.DeleteOneAsync(",
                $"{GetKeyCompareExpr()});"));

            var m7 = new ContainerGen();
            m7.Signature = "public override async Task<DeleteResult> RemoveAsync(IClientSessionHandle handle, `entityPK` id)";
            m7.Body.Add(
                new StatementGen(
                "return await _collection.DeleteOneAsync(handle,",
                $"{GetKeyCompareExpr()});"));

            var m8 = new ContainerGen();
            m8.Signature = "public override ReplaceOneResult Replace(`entity` entity)";
            m8.Body.Add(
                new StatementGen(
                    $"var id = entity.{EInfo.PKProp};",
                "return _collection.ReplaceOne(",
                $"{GetKeyCompareExpr()}, entity);"));

            var m9 = new ContainerGen();
            m9.Signature = "public override async Task<ReplaceOneResult> ReplaceAsync(`entity` entity)";
            m9.Body.Add(
                new StatementGen(
                    $"var id = entity.{EInfo.PKProp};",
                "return await _collection.ReplaceOneAsync(",
                $"{GetKeyCompareExpr()}, entity);"));

            var m10 = new ContainerGen();
            m10.Signature = "public override ReplaceOneResult Replace(IClientSessionHandle handle, `entity` entity)";
            m10.Body.Add(
                new StatementGen(
                    $"var id = entity.{EInfo.PKProp};",
                "return _collection.ReplaceOne(handle,",
                $"{GetKeyCompareExpr()}, entity);"));

            var m11 = new ContainerGen();
            m11.Signature = "public override async Task<ReplaceOneResult> ReplaceAsync(IClientSessionHandle handle, `entity` entity)";
            m11.Body.Add(
                new StatementGen(
                    $"var id = entity.{EInfo.PKProp};",
                "return await _collection.ReplaceOneAsync(handle,",
                $"{GetKeyCompareExpr()}, entity);"));

            var s12 = new StatementGen("#endregion");

            EntityRepositoryBody.Add(
                c0, new StatementGen(""),
                s1, new StatementGen(""),
                m2, new StatementGen(""),
                m3, new StatementGen(""),
                m4, new StatementGen(""),
                m5, new StatementGen(""),
                m6, new StatementGen(""),
                m7, new StatementGen(""),
                m8, new StatementGen(""),
                m9, new StatementGen(""),
                m10, new StatementGen(""),
                m11, new StatementGen(""),
                s12, new StatementGen(""));
        }

        private string GetKeyCompareExpr()
        {
            var expr = "\te =>";
            var name = EInfo.PKProp;
            expr += " e." + name + " == id";
            return expr;
        }

    }
}
