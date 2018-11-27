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
            c1.Signature = "public `entity`Repository(`context` context) : base(context)";
            var c2 = new ContainerGen();
            c2.Signature = "public `entity`Repository(IUnitOfWork uow) : base(uow)";

            var m3 = new ContainerGen();
            m3.Signature = "public override `entity` Add(`entity` entity)";
            m3.Body.Add(new StatementGen(
                EInfo.Activable ? (EInfo.Data.ActiveCol ? "entity.Active = true;" : "entity.Deactive = false;") : "",
                "entity = context.`entities`.Add(entity);",
                //"if (AutoSave)",
                //"\tcontext.SaveChanges();",
                "return entity;"));

            //var m4 = new ContainerGen();
            //m4.Signature = "public override async Task<`entity`> AddAsync(`entity` entity)";
            //m4.Body.Add(new StatementGen(
            //    EInfo.Activable ? (EInfo.Data.ActiveCol ? "entity.Active = true;" : "entity.Deactive = false;") : "",
            //    "entity = context.`entities`.Add(entity);",
            //    //"if (AutoSave)",
            //    //"\tawait context.SaveChangesAsync();",
            //    "return entity;"));

            var m5 = new ContainerGen();
            m5.Signature = "public override `entity` Remove(`entity` entity)";
            m5.Body.Add(new StatementGen(
                "context.`entities`.Attach(entity);",
                "entity = context.`entities`.Remove(entity);",
                //"if (AutoSave)",
                //"\tcontext.SaveChanges();",
                "return entity;"));

            //var m6 = new ContainerGen();
            //m6.Signature = "public override async Task<`entity`> RemoveAsync(`entity` entity)";
            //m6.Body.Add(new StatementGen(
            //    "context.`entities`.Attach(entity);",
            //    "entity = context.`entities`.Remove(entity);",
            //    //"if (AutoSave)",
            //    //"\tawait context.SaveChangesAsync();",
            //    "return entity;"));

            var m7 = new ContainerGen();
            m7.Signature = "public override `entity` Remove(`entityPK` key)";
            m7.Body.Add(new StatementGen(
                "var entity = FindById(key);",
                "if (entity!=null)",
                "\tentity = context.`entities`.Remove(entity);",
                //"if (AutoSave)",
                //"\tcontext.SaveChanges();",
                "return entity;"));

            var m8 = new ContainerGen();
            m8.Signature = "public override IEnumerable<`entity`> RemoveIf(Expression<Func<`entity`, bool>> expr)";
            m8.Body.Add(new StatementGen(
                "return context.`entities`.RemoveRange(GetActive(expr).ToList());"));

            var m81 = new ContainerGen();
            m81.Signature = "public override IEnumerable<`entity`> RemoveRange(IEnumerable<`entity`> list)";
            m81.Body.Add(new StatementGen(
                "return context.`entities`.RemoveRange(list);"));

            //var m8 = new ContainerGen();
            //m8.Signature = "public override async Task<`entity`> RemoveAsync(`entityPK` key)";
            //m8.Body.Add(new StatementGen(
            //    "var entity = FindById(key);",
            //    "if (entity!=null)",
            //    "\tentity = context.`entities`.Remove(entity);",
            //    //"if (AutoSave)",
            //    //"\tawait context.SaveChangesAsync();",
            //    "return entity;"));

            var m9 = new ContainerGen();
            m9.Signature = "public override `entity` FindById(`entityPK` key)";
            m9.Body.Add(new StatementGen(
                "var entity = context.`entities`.FirstOrDefault(",
                GetKeyCompareExpr() + ");",
                "return entity;"));

            var m10 = new ContainerGen();
            m10.Signature = "public override async Task<`entity`> FindByIdAsync(`entityPK` key)";
            m10.Body.Add(
                new StatementGen(
                "var entity = await context.`entities`.FirstOrDefaultAsync(",
                GetKeyCompareExpr() + ");",
                "return entity;"));

            var m91 = new ContainerGen();
            m91.Signature = "public override `entity` FindActiveById(`entityPK` key)";
            m91.Body.Add(new StatementGen(
                "var entity = context.`entities`.FirstOrDefault(",
                GetKeyCompareExpr() +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? " && e.Active" : " && !e.Deactive") : "") + ");",
                "return entity;"));

            var m101 = new ContainerGen();
            m101.Signature = "public override async Task<`entity`> FindActiveByIdAsync(`entityPK` key)";
            m101.Body.Add(
                new StatementGen(
                "var entity = await context.`entities`.FirstOrDefaultAsync(",
                GetKeyCompareExpr() +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? " && e.Active" : " && !e.Deactive") : "") + ");",
                "return entity;"));

            var m11 = new ContainerGen();
            m11.Signature = "public override `entity` FindByIdInclude<TProperty>(`entityPK` key, params Expression<Func<`entity`, TProperty>>[] members)";
            m11.Body.Add(new StatementGen(
                "IQueryable<`entity`> dbSet = context.`entities`;",
                "foreach (var m in members)",
                "{",
                "\tdbSet = dbSet.Include(m);",
                "}",
                "",
                "return dbSet.FirstOrDefault(",
                GetKeyCompareExpr() + ");"));

            var m12 = new ContainerGen();
            m12.Signature = "public override async Task<`entity`> FindByIdIncludeAsync<TProperty>(`entityPK` key, params Expression<Func<`entity`, TProperty>>[] members)";
            m12.Body.Add(
                new StatementGen(
                "IQueryable<`entity`> dbSet = context.`entities`;",
                "foreach (var m in members)",
                "{",
                "\tdbSet = dbSet.Include(m);",
                "}",
                "",
                "return await dbSet.FirstOrDefaultAsync(",
                GetKeyCompareExpr() + ");"));

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
            var getActive = "return context.`entities`" +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? ".Where(e => e.Active);" : ".Where(e => !e.Deactive);") : ";");
            m13.Body.Add(new StatementGen(getActive));

            var m14 = new ContainerGen();
            m14.Signature = "public override IQueryable<`entity`> GetActive(Expression<Func<`entity`, bool>> expr)";
            m14.Body.Add(new StatementGen("return context.`entities`" +
                (EInfo.Activable ? (EInfo.Data.ActiveCol ? ".Where(e => e.Active)" : ".Where(e => !e.Deactive)") : "") + ".Where(expr);"));

            var m15 = new ContainerGen();
            m15.Signature = "public override `entity` FirstOrDefault()";
            m15.Body.Add(new StatementGen("return GetActive().FirstOrDefault();"));

            var m151 = new ContainerGen();
            m151.Signature = "public override `entity` FirstOrDefault(Expression<Func<`entity`, bool>> expr)";
            m151.Body.Add(new StatementGen("return GetActive().FirstOrDefault(expr);"));

            var m16 = new ContainerGen();
            m16.Signature = "public override async Task<`entity`> FirstOrDefaultAsync()";
            m16.Body.Add(new StatementGen("return await GetActive().FirstOrDefaultAsync();"));

            var m161 = new ContainerGen();
            m161.Signature = "public override async Task<`entity`> FirstOrDefaultAsync(Expression<Func<`entity`, bool>> expr)";
            m161.Body.Add(new StatementGen("return await GetActive().FirstOrDefaultAsync(expr);"));

            var m17 = new ContainerGen();
            m17.Signature = "public override `entity` SingleOrDefault(Expression<Func<`entity`, bool>> expr)";
            m17.Body.Add(new StatementGen("return GetActive().SingleOrDefault(expr);"));

            var m18 = new ContainerGen();
            m18.Signature = "public override async Task<`entity`> SingleOrDefaultAsync(Expression<Func<`entity`, bool>> expr)";
            m18.Body.Add(new StatementGen("return await GetActive().SingleOrDefaultAsync(expr);"));

            var m19 = new ContainerGen();
            m19.Signature = "public override `entity` Update(`entity` entity)";
            m19.Body.Add(new StatementGen(
                "entity = context.`entities`.Attach(entity);",
                "context.Entry(entity).State = EntityState.Modified;",
                //"if (AutoSave)",
                //"\tcontext.SaveChanges();",
                "return entity;"));

            //var m20 = new ContainerGen();
            //m20.Signature = "public override async Task<`entity`> UpdateAsync(`entity` entity)";
            //m20.Body.Add(new StatementGen(
            //    "entity = context.`entities`.Attach(entity);",
            //    "context.Entry(entity).State = EntityState.Modified;",
            //    //"if (AutoSave)",
            //    //"\tawait context.SaveChangesAsync();",
            //    "return entity;"));

            EntityRepositoryBody.Add(
                c1, new StatementGen(""),
                c2, new StatementGen("", "#region CRUD Area"),
                m3, new StatementGen(""),
                //m4, new StatementGen(""),
                m5, new StatementGen(""),
                //m6, new StatementGen(""),
                m7, new StatementGen(""),
                m8, new StatementGen(""),
                m81, new StatementGen(""),
                m9, new StatementGen(""),
                m91, new StatementGen(""),
                m10, new StatementGen(""),
                m101, new StatementGen(""),
                m11, new StatementGen(""),
                m12, new StatementGen(""),
                m131, new StatementGen(""),
                m1311, new StatementGen(""),
                m132, new StatementGen(""),
                m1322, new StatementGen(""),
                m13, new StatementGen(""),
                m14, new StatementGen(""),
                m15, new StatementGen(""),
                m151, new StatementGen(""),
                m16, new StatementGen(""),
                m161, new StatementGen(""),
                m17, new StatementGen(""),
                m18, new StatementGen(""),
                m19, new StatementGen("#endregion", ""));
            //m20, new StatementGen("#endregion", ""));

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
