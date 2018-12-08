using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Models.Repositories
{
    public class EntityRepositoryGen : FileGen
    {
        private EntityInfo EInfo { get; set; }
        public EntityRepositoryGen(EntityInfo eInfo)
        {
            EInfo = eInfo;
            Directive.Add(EInfo.Data.ProjectName + ".Models",
                EInfo.Data.ProjectName + ".Managers",
                "System.Linq.Expressions", "System.Data.Entity");
            ResolveMapping.Add("entity", EInfo.EntityName);
            ResolveMapping.Add("entities", EInfo.PluralEntityName);
            ResolveMapping.Add("entityPK", EInfo.PKClass);
            ResolveMapping.Add("context", EInfo.Data.ContextName);

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
            c1.Signature = "public `entity`Repository(DbContext context) : base(context)";
            var c2 = new ContainerGen();
            c2.Signature = "public `entity`Repository(IUnitOfWork uow) : base(uow)";

            var m9 = new ContainerGen();
            m9.Signature = "public override `entity` FindById(`entityPK` key)";
            m9.Body.Add(new StatementGen(
                "var entity = dbSet.FirstOrDefault(",
                GetKeyCompareExpr() + ");",
                "return entity;"));

            var m10 = new ContainerGen();
            m10.Signature = "public override async Task<`entity`> FindByIdAsync(`entityPK` key)";
            m10.Body.Add(
                new StatementGen(
                "var entity = await dbSet.FirstOrDefaultAsync(",
                GetKeyCompareExpr() + ");",
                "return entity;"));

            var m91 = new ContainerGen();
            m91.Signature = "public override `entity` FindActiveById(`entityPK` key)";
            m91.Body.Add(new StatementGen(
                "var entity = dbSet.FirstOrDefault(",
                GetKeyCompareExpr() +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? " && e.Active" : " && !e.Deactive") : "") + ");",
                "return entity;"));

            var m101 = new ContainerGen();
            m101.Signature = "public override async Task<`entity`> FindActiveByIdAsync(`entityPK` key)";
            m101.Body.Add(
                new StatementGen(
                "var entity = await dbSet.FirstOrDefaultAsync(",
                GetKeyCompareExpr() +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? " && e.Active" : " && !e.Deactive") : "") + ");",
                "return entity;"));

            //var m11 = new ContainerGen();
            //m11.Signature = "public override `entity` FindByIdInclude<TProperty>(`entityPK` key, params Expression<Func<`entity`, TProperty>>[] members)";
            //m11.Body.Add(new StatementGen(
            //    "IQueryable<`entity`> dbSet = this.dbSet;",
            //    "foreach (var m in members)",
            //    "{",
            //    "\tdbSet = dbSet.Include(m);",
            //    "}",
            //    "",
            //    "return dbSet.FirstOrDefault(",
            //    GetKeyCompareExpr() + ");"));

            //var m12 = new ContainerGen();
            //m12.Signature = "public override async Task<`entity`> FindByIdIncludeAsync<TProperty>(`entityPK` key, params Expression<Func<`entity`, TProperty>>[] members)";
            //m12.Body.Add(
            //    new StatementGen(
            //    "IQueryable<`entity`> dbSet = this.dbSet;",
            //    "foreach (var m in members)",
            //    "{",
            //    "\tdbSet = dbSet.Include(m);",
            //    "}",
            //    "",
            //    "return await dbSet.FirstOrDefaultAsync(",
            //    GetKeyCompareExpr() + ");"));

            var m131 = new ContainerGen();
            m131.Signature = "public override `entity` Activate(`entity` entity)";
            var activate =
                (EInfo.Activable ? (EInfo.Data.ActiveCol ?
                    "entity.Active = true; Update(entity); return entity;" :
                    "entity.Deactive = false; Update(entity); return entity;") : null);
            m131.Body.Add(new StatementGen(
                activate ?? "throw new Exception(\"Entity's not activable. Check if table has 'Active/Deactive' column\");"));

            var m1311 = new ContainerGen();
            m1311.Signature = "public override `entity` Activate(`entityPK` key)";
            if (EInfo.Activable)
            {
                m1311.Body.Add(new StatementGen(
                    "var entity = FindById(key);",
                    "if (entity!=null)",
                    "{",
                    (EInfo.Activable ? (EInfo.Data.ActiveCol ?
                    "\tentity.Active = true;" :
                    "\tentity.Deactive = false;") : null),
                    "\tUpdate(entity);",
                    "}",
                    "return entity;"));
            }
            else m1311.Body.Add(new StatementGen(
               "throw new Exception(\"Entity's not activable. Check if table has 'Active/Deactive' column\");"));

            var m132 = new ContainerGen();
            m132.Signature = "public override `entity` Deactivate(`entity` entity)";
            var deactivate =
                (EInfo.Activable ? (EInfo.Data.ActiveCol ?
                    "entity.Active = false; Update(entity); return entity;" :
                    "entity.Deactive = true; Update(entity); return entity;") : null);
            m132.Body.Add(new StatementGen(
                deactivate ?? "throw new Exception(\"Entity's not activable. Check if table has 'Active/Deactive' column\");"));

            var m1322 = new ContainerGen();
            m1322.Signature = "public override `entity` Deactivate(`entityPK` key)";
            if (EInfo.Activable)
            {
                m1322.Body.Add(new StatementGen(
                    "var entity = FindById(key);",
                    "if (entity!=null)",
                    "{",
                    (EInfo.Activable ? (EInfo.Data.ActiveCol ?
                    "\tentity.Active = false;" :
                    "\tentity.Deactive = true;") : null),
                    "\tUpdate(entity);",
                    "}",
                    "return entity;"));
            }
            else m1322.Body.Add(new StatementGen(
               "throw new Exception(\"Entity's not activable. Check if table has 'Active/Deactive' column\");"));

            var m13 = new ContainerGen();
            m13.Signature = "public override IQueryable<`entity`> GetActive()";
            var getActive = "return dbSet" +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? ".Where(e => e.Active);" : ".Where(e => !e.Deactive);") : ";");
            m13.Body.Add(new StatementGen(getActive));

            var m14 = new ContainerGen();
            m14.Signature = "public override IQueryable<`entity`> GetActive(Expression<Func<`entity`, bool>> expr)";
            m14.Body.Add(new StatementGen("return dbSet" +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? ".Where(e => e.Active)" : ".Where(e => !e.Deactive)") : "") + ".Where(expr);"));


            EntityRepositoryBody.Add(
                c1, new StatementGen(""),
                c2, new StatementGen("", "#region CRUD Area"),
                m9, new StatementGen(""),
                m91, new StatementGen(""),
                m10, new StatementGen(""),
                m101, new StatementGen(""),
                //m11, new StatementGen(""),
                //m12, new StatementGen(""),
                m131, new StatementGen(""),
                m1311, new StatementGen(""),
                m132, new StatementGen(""),
                m1322, new StatementGen(""),
                m13, new StatementGen(""),
                m14, new StatementGen("#endregion", ""));

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
