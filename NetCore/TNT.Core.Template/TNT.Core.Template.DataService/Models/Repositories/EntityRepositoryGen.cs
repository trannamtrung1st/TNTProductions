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
                "System.Linq.Expressions", "Microsoft.EntityFrameworkCore");

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
            var c1 = new ContainerGen();
            c1.Signature = "public `entity`Repository(IUnitOfWork uow) : base(uow)";
            EntityRepositoryBody.Add(c1, new StatementGen(""));

            if (EInfo.Data.DIContainer == DIContainer.TContainer)
            {
                var c2 = new ContainerGen();
                c2.Signature = "public `entity`Repository(DbContext context) : base(context)";
                EntityRepositoryBody.Add(c2, new StatementGen(""));

            }
            EntityRepositoryBody.Add(new StatementGen("#region CRUD area"));

            var m9 = new ContainerGen();
            m9.Signature = "public override `entity` FindById(`entityPK` key)";
            m9.Body.Add(new StatementGen(
                "var entity = dbSet.FirstOrDefault(",
                GetKeyCompareExpr() + ");",
                "return entity;"));

            EntityRepositoryBody.Add(m9, new StatementGen(""));

            var m10 = new ContainerGen();
            m10.Signature = "public override async Task<`entity`> FindByIdAsync(`entityPK` key)";
            m10.Body.Add(
                new StatementGen(
                "var entity = await dbSet.FirstOrDefaultAsync(",
                GetKeyCompareExpr() + ");",
                "return entity;"));
            EntityRepositoryBody.Add(m10, new StatementGen(""));

            if (EInfo.Activable)
            {
                var m91 = new ContainerGen();
                m91.Signature = "public `entity` FindActiveById(`entityPK` key)";
                m91.Body.Add(new StatementGen(
                    "var entity = dbSet.FirstOrDefault(",
                    GetKeyCompareExpr() +
                    (EInfo.Data.ActiveCol ? " && e.Active == true" : " && e.Deactive == false") + ");",
                    "return entity;"));
                EntityRepositoryBody.Add(m91, new StatementGen(""));

                var m101 = new ContainerGen();
                m101.Signature = "public async Task<`entity`> FindActiveByIdAsync(`entityPK` key)";
                m101.Body.Add(
                    new StatementGen(
                    "var entity = await dbSet.FirstOrDefaultAsync(",
                    GetKeyCompareExpr() +
                    (EInfo.Data.ActiveCol ? " && e.Active == true" : " && e.Deactive == false") + ");",
                    "return entity;"));
                EntityRepositoryBody.Add(m101, new StatementGen(""));

                var m13 = new ContainerGen();
                m13.Signature = "public IQueryable<`entity`> GetActive()";
                var getActive = "return dbSet" +
                    (EInfo.Data.ActiveCol ? ".Where(e => e.Active == true);" : ".Where(e => e.Deactive == false);");
                m13.Body.Add(new StatementGen(getActive));
                EntityRepositoryBody.Add(m13, new StatementGen(""));

                var m14 = new ContainerGen();
                m14.Signature = "public IQueryable<`entity`> GetActive(Expression<Func<`entity`, bool>> expr)";
                m14.Body.Add(new StatementGen("return dbSet" +
                    (EInfo.Data.ActiveCol ? ".Where(e => e.Active == true)" : ".Where(e => e.Deactive == false)") + ".Where(expr);"));
                EntityRepositoryBody.Add(m14, new StatementGen(""));
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

    }
}
