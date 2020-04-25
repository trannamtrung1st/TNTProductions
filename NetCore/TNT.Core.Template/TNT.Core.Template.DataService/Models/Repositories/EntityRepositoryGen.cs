using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.Models.Repositories
{
    public class EntityRepositoryGen : FileGen
    {
        private EntityInfo EInfo { get; set; }
        public EntityRepositoryGen(EntityInfo eInfo)
        {
            EInfo = eInfo;
            Directive.Add(EInfo.Data.ContextNamespace,
                "System.Linq.Expressions", "Microsoft.EntityFrameworkCore",
                "Microsoft.EntityFrameworkCore.ChangeTracking");

            ResolveMapping["entity"] = EInfo.EntityName;
            ResolveMapping["entityPK"] = EInfo.PKClass;
            ResolveMapping["entityVM"] = EInfo.VMClass;
            ResolveMapping["context"] = EInfo.Data.ContextName;

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
            Namespace.Signature = "namespace " + EInfo.Data.ProjectName + ".Models.Repositories";
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
            if (EInfo.Activable)
            {
                IEntityRepositoryBody.Add(
                    new StatementGen("`entity` FindActiveById(`entityPK` key);"),
                    new StatementGen("Task<`entity`> FindActiveByIdAsync(`entityPK` key);"),
                    new StatementGen("IQueryable<`entity`> GetActive();"),
                    new StatementGen("IQueryable<`entity`> GetActive(Expression<Func<`entity`, bool>> expr);")
                    );
            }

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
            //var c1 = new ContainerGen();
            //c1.Signature = "public `entity`Repository(IUnitOfWork uow) : base(uow)";
            //EntityRepositoryBody.Add(c1, new StatementGen(""));
            var c1 = new ContainerGen();
            c1.Signature = "public `entity`Repository(DbContext context) : base(context)";
            EntityRepositoryBody.Add(c1, new StatementGen(""));
            EntityRepositoryBody.Add(new StatementGen("#region CRUD area"));

            var keyCompare = GetKeyCompareExpr();
            var keyAssignArgs = GetKeyAssignmentExpr(true);
            var keyAssign = GetKeyAssignmentExpr(false);

            var m9 = new ContainerGen();
            m9.Signature = "public override `entity` FindById(`entityPK` key)";
            m9.Body.Add(new StatementGen(
                "var entity = QuerySet.FirstOrDefault(",
                keyCompare + ");",
                "return entity;"));

            EntityRepositoryBody.Add(m9, new StatementGen(""));

            var m10 = new ContainerGen();
            m10.Signature = "public override async Task<`entity`> FindByIdAsync(`entityPK` key)";
            m10.Body.Add(
                new StatementGen(
                "var entity = await QuerySet.FirstOrDefaultAsync(",
                keyCompare + ");",
                "return entity;"));
            EntityRepositoryBody.Add(m10, new StatementGen(""));

            var m11 = new ContainerGen();
            m11.Signature = "public override EntityEntry<`entity`> Remove(`entityPK` key)";
            m11.Body.Add(
                new StatementGen(
                $"var entity = new `entity` {{ {keyAssign} }};",
                "return dbSet.Remove(entity);"));
            EntityRepositoryBody.Add(m11, new StatementGen(""));

            var m12 = new ContainerGen();
            m12.Signature = "public override IEnumerable<`entity`> RemoveIf(Expression<Func<`entity`, bool>> expr)";
            m12.Body.Add(
                new StatementGen(
                $"var list = dbSet.Where(expr)" +
                    $".Select(o => new `entity` {{ {keyAssignArgs} }}).ToList();",
                "dbSet.RemoveRange(list);",
                "return list;"));
            EntityRepositoryBody.Add(m12, new StatementGen(""));

            var m14 = new ContainerGen();
            m14.Signature = "public override async Task<int> SqlRemoveAllAsync()";
            m14.Body.Add(
                new StatementGen(
                $"var result = await context.Database.ExecuteSqlRawAsync(\"DELETE FROM `entity`\");",
                "return result;"));
            EntityRepositoryBody.Add(new StatementGen("//Default DELETE command, override if there's any exception"),
                m14, new StatementGen(""));

            if (EInfo.Activable)
            {
                var m91 = new ContainerGen();
                m91.Signature = "public `entity` FindActiveById(`entityPK` key)";
                m91.Body.Add(new StatementGen(
                    "var entity = QuerySet.FirstOrDefault(",
                    keyCompare +
                    (EInfo.Data.ActiveCol ? " && e.Active == true" : " && e.Deactive == false") + ");",
                    "return entity;"));
                EntityRepositoryBody.Add(m91, new StatementGen(""));

                var m101 = new ContainerGen();
                m101.Signature = "public async Task<`entity`> FindActiveByIdAsync(`entityPK` key)";
                m101.Body.Add(
                    new StatementGen(
                    "var entity = await QuerySet.FirstOrDefaultAsync(",
                    keyCompare +
                    (EInfo.Data.ActiveCol ? " && e.Active == true" : " && e.Deactive == false") + ");",
                    "return entity;"));
                EntityRepositoryBody.Add(m101, new StatementGen(""));

                var m15 = new ContainerGen();
                m15.Signature = "public IQueryable<`entity`> GetActive()";
                var getActive = "return QuerySet" +
                    (EInfo.Data.ActiveCol ? ".Where(e => e.Active == true);" : ".Where(e => e.Deactive == false);");
                m15.Body.Add(new StatementGen(getActive));
                EntityRepositoryBody.Add(m15, new StatementGen(""));

                var m16 = new ContainerGen();
                m16.Signature = "public IQueryable<`entity`> GetActive(Expression<Func<`entity`, bool>> expr)";
                m16.Body.Add(new StatementGen("return QuerySet" +
                    (EInfo.Data.ActiveCol ? ".Where(e => e.Active == true)" : ".Where(e => e.Deactive == false)") + ".Where(expr);"));
                EntityRepositoryBody.Add(m16, new StatementGen(""));
            }
            EntityRepositoryBody.Add(new StatementGen("#endregion"));

        }

        private string GetKeyCompareExpr()
        {
            var expr = "\te =>";
            if (EInfo.PKPropMapping.Count == 1)
            {
                var name = EInfo.PKPropMapping.Keys.ToList()[0];
                expr += " e." + name + " == key";
            }
            else
            {
                foreach (var prop in EInfo.PKPropMapping)
                {
                    var name = prop.Key;
                    var type = prop.Value;
                    expr += " e." + name + " == key." + name + " &&";
                }
                expr = expr.Remove(expr.Length - 3);
            }
            return expr;
        }

        private string GetKeyAssignmentExpr(bool hasArgs)
        {
            var expr = "";
            if (EInfo.PKPropMapping.Count == 1)
            {
                var name = EInfo.PKPropMapping.Keys.ToList()[0];
                expr += $"{name} = {(hasArgs ? $"o.{name}" : "key")}";
            }
            else
            {
                var parts = EInfo.PKPropMapping.Select(prop =>
                {
                    var name = prop.Key;
                    var type = prop.Value;
                    return $"{name} = {(hasArgs ? $"o.{name}" : $"key.{name}")}";
                });
                expr = string.Join(',', parts);
            }
            return expr;
        }

    }
}
