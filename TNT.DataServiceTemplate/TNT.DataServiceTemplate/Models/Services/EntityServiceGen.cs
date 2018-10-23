using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Services
{
    public class EntityServiceGen : FileGen
    {

        private EntityInfo EInfo { get; set; }
        public EntityServiceGen(EntityInfo eInfo)
        {
            EInfo = eInfo;
            var dt = EInfo.Data;
            Directive.Add("System.Linq.Expressions",
                dt.ProjectName + ".Utilities",
                dt.ProjectName + ".Managers",
                dt.ProjectName + ".ViewModels", dt.ProjectName + ".Models.Repositories",
                dt.ProjectName + ".Global", "TNT.IoContainer.Wrapper");
            //ResolveMapping.Add("context", EInfo.Data.ContextName);
            ResolveMapping.Add("entity", EInfo.EntityName);
            ResolveMapping.Add("entityVM", EInfo.VMClass);
            ResolveMapping.Add("entityPK", EInfo.PKClass);

            //GENERATE
            GenerateNamespace();
            GenerateIEntityService();
            GenerateEntityService();
            GenerateEntityServiceBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Data.ProjectName + ".Models.Services";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IEntityService
        private ContainerGen IEntityService { get; set; }
        private BodyGen IEntityServiceBody { get; set; }
        public void GenerateIEntityService()
        {
            IEntityService = new ContainerGen();
            IEntityService.Signature = "public partial interface I`entity`Service : IBaseService<`entity`, `entity`ViewModel, `entityPK`>";
            IEntityServiceBody = IEntityService.Body;

            NamespaceBody.Add(IEntityService, new StatementGen(""));
        }

        //generate EntityService class
        private ContainerGen EntityService { get; set; }
        private BodyGen EntityServiceBody { get; set; }
        public void GenerateEntityService()
        {
            EntityService = new ContainerGen();
            EntityService.Signature =
                "public partial class `entity`Service : BaseService, I`entity`Service";
            EntityServiceBody = EntityService.Body;

            NamespaceBody.Add(EntityService);
        }

        public void GenerateEntityServiceBody()
        {
            var s1 = new StatementGen("private I`entity`Repository repository;");

            var c2 = new ContainerGen();
            c2.Signature = "public `entity`Service(IUnitOfWork uow)";
            c2.Body.Add(new StatementGen(
                "repository = uow.Scope.Resolve<I`entity`Repository>(uow);"));

            var m3 = new ContainerGen();
            m3.Signature = "public override bool AutoSave";
            m3.Body.Add(new StatementGen(
                "get",
                "{",
                "\treturn repository.AutoSave;",
                "}",
                "set",
                "{",
                "\trepository.AutoSave = value;",
                "}"));

            var m4 = new ContainerGen();
            m4.Signature = "public `entity` Add(`entity` entity)";
            m4.Body.Add(new StatementGen(
                "return repository.Add(entity);"));

            var m5 = new ContainerGen();
            m5.Signature = "public async Task<`entity`> AddAsync(`entity` entity)";
            m5.Body.Add(new StatementGen(
                "return await repository.AddAsync(entity);"));

            var m6 = new ContainerGen();
            m6.Signature = "public `entity` Update(`entity` entity)";
            m6.Body.Add(new StatementGen(
                "return repository.Update(entity);"));

            var m7 = new ContainerGen();
            m7.Signature = "public async Task<`entity`> UpdateAsync(`entity` entity)";
            m7.Body.Add(new StatementGen(
                "return await repository.UpdateAsync(entity);"));

            var m8 = new ContainerGen();
            m8.Signature = "public `entity` Delete(`entity` entity)";
            m8.Body.Add(new StatementGen(
                "return repository.Delete(entity);"));

            var m9 = new ContainerGen();
            m9.Signature = "public async Task<`entity`> DeleteAsync(`entity` entity)";
            m9.Body.Add(new StatementGen(
                "return await repository.DeleteAsync(entity);"));

            var m10 = new ContainerGen();
            m10.Signature = "public `entity` Delete(`entityPK` key)";
            m10.Body.Add(new StatementGen(
                "return repository.Delete(key);"));

            var m11 = new ContainerGen();
            m11.Signature = "public async Task<`entity`> DeleteAsync(`entityPK` key)";
            m11.Body.Add(new StatementGen(
                "return await repository.DeleteAsync(key);"));

            var m12 = new ContainerGen();
            m12.Signature = "public `entity` FindById(`entityPK` key)";
            m12.Body.Add(new StatementGen(
                "return repository.FindActiveById(key);"));

            var m13 = new ContainerGen();
            m13.Signature = "public async Task<`entity`> FindByIdAsync(`entityPK` key)";
            m13.Body.Add(new StatementGen("return await repository.FindActiveByIdAsync(key);"));

            var m141 = new ContainerGen();
            m141.Signature = "public `entity` Activate(`entity` entity)";
            m141.Body.Add(new StatementGen("return repository.Activate(entity);"));

            var m1411 = new ContainerGen();
            m1411.Signature = "public `entity` Activate(`entityPK` key)";
            m1411.Body.Add(new StatementGen("return repository.Activate(key);"));

            var m142 = new ContainerGen();
            m142.Signature = "public `entity` Deactivate(`entity` entity)";
            m142.Body.Add(new StatementGen("return repository.Deactivate(entity);"));

            var m1422 = new ContainerGen();
            m1422.Signature = "public `entity` Deactivate(`entityPK` key)";
            m1422.Body.Add(new StatementGen("return repository.Deactivate(key);"));

            var m14 = new ContainerGen();
            m14.Signature = "public IQueryable<`entity`> GetActive()";
            m14.Body.Add(new StatementGen("return repository.GetActive();"));

            var m15 = new ContainerGen();
            m15.Signature = "public IQueryable<`entity`> GetActive(Expression<Func<`entity`, bool>> expr)";
            m15.Body.Add(new StatementGen("return repository.GetActive(expr);"));

            var m16 = new ContainerGen();
            m16.Signature = "public `entity` FirstOrDefault()";
            m16.Body.Add(new StatementGen("return repository.FirstOrDefault();"));

            var m161 = new ContainerGen();
            m161.Signature = "public `entity` FirstOrDefault(Expression<Func<`entity`, bool>> expr)";
            m161.Body.Add(new StatementGen("return repository.FirstOrDefault(expr);"));

            var m17 = new ContainerGen();
            m17.Signature = "public async Task<`entity`> FirstOrDefaultAsync()";
            m17.Body.Add(new StatementGen("return await repository.FirstOrDefaultAsync();"));

            var m171 = new ContainerGen();
            m171.Signature = "public async Task<`entity`> FirstOrDefaultAsync(Expression<Func<`entity`, bool>> expr)";
            m171.Body.Add(new StatementGen("return await repository.FirstOrDefaultAsync(expr);"));

            var c18 = new ContainerGen();
            c18.Signature = "public `entity`Service()";
            c18.Body.Add(new StatementGen("repository = G.TContainer.Resolve<I`entity`Repository>();"));

            var cm19 = new CommentGen();
            cm19.Add("params order: 0/ uow");
            var m20 = new ContainerGen();
            m20.Signature = "public override void ReInit(params object[] initParams)";
            m20.Body.Add(new StatementGen(
                "base.ReInit(initParams);",
                "repository.ReInit(initParams);"));

            var d21 = new ContainerGen();
            d21.Signature = "~`entity`Service()";
            d21.Body.Add(new StatementGen("Dispose(false);"));

            EntityServiceBody.Add(
                s1, new StatementGen(""),
                c2, new StatementGen(""),
                m3, new StatementGen("", "#region CRUD Area"),
                m4, new StatementGen(""),
                m5, new StatementGen(""),
                m6, new StatementGen(""),
                m7, new StatementGen(""),
                m8, new StatementGen(""),
                m9, new StatementGen(""),
                m10, new StatementGen(""),
                m11, new StatementGen(""),
                m12, new StatementGen(""),
                m13, new StatementGen(""),
                m141, new StatementGen(""),
                m1411, new StatementGen(""),
                m142, new StatementGen(""),
                m1422, new StatementGen(""),
                m14, new StatementGen(""),
                m15, new StatementGen(""),
                m16, new StatementGen(""),
                m161, new StatementGen(""),
                m17, new StatementGen(""),
                m171, new StatementGen("#endregion"));
            if (EInfo.Data.ServicePool)
            {
                EntityServiceBody.Add(new StatementGen("", "#region Implement for Resource Pooling"),
                c18, new StatementGen(""),
                cm19, new StatementGen(""),
                m20, new StatementGen(""),
                d21, new StatementGen("#endregion"));
            }
        }

    }
}
