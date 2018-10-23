using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Managers
{
    public class ContextManagerGen : FileGen
    {
        private DataInfo Data { get; set; }
        public ContextManagerGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add("TNT.IoContainer.Container",
                Data.ProjectName + ".Global", Data.ProjectName + ".Models");
            ResolveMapping.Add("context", Data.ContextName);

            //GENERATE
            //GENERATE
            GenerateNamespace();
            GenerateContextManager();
            GenerateOpenMethod();
            GenerateOpenMethod(true);
            GenerateOpenGetMethod();
            GenerateOpenGetMethod(true);
            GenerateOpenAsyncMethod();
            GenerateOpenAsyncMethod(true);
            GenerateOpenGetAsyncMethod();
            GenerateOpenGetAsyncMethod(true);

        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".Managers";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate ContextManager
        private ContainerGen ContextManager { get; set; }
        private BodyGen ContextManagerBody { get; set; }
        public void GenerateContextManager()
        {
            ContextManager = new ContainerGen();
            ContextManager.Signature = "public partial class ContextManager";
            ContextManagerBody = ContextManager.Body;

            NamespaceBody.Add(ContextManager);
        }

        public void GenerateOpenMethod(bool transaction = false)
        {
            var method = new ContainerGen();
            var methodName = transaction ? "OpenTransaction" : "Open";
            method.Signature = "public static void " + methodName + "(Action<UnitOfWork> action)";

            method.Body.Add(new StatementGen(
                "using (var scope = G.TContainer.CreateScope())"));

            var usingBody = new BodyGen();
            usingBody.Add(new StatementGen("var context = new `context`();"));
            if (transaction)
                usingBody.Add(new StatementGen("var transaction = context.Database.BeginTransaction();"));

            usingBody.Add(new StatementGen(
                "scope.ManageResources(context" + (transaction ? ", transaction" : "") + ");",
                "action.Invoke(new UnitOfWork(scope, context" + (transaction ? ", transaction" : "") + "));"));

            method.Body.Add(usingBody);

            ContextManagerBody.Add(method, new StatementGen(""));
        }

        public void GenerateOpenAsyncMethod(bool transaction = false)
        {
            var method = new ContainerGen();
            var methodName = transaction ? "OpenTransactionAsync" : "OpenAsync";
            method.Signature = "public static async void " + methodName + "(Action<UnitOfWork> action)";

            method.Body.Add(new StatementGen(
                "await Task.Run(() =>",
                "{"),
                new StatementGen(
                    "using (var scope = G.TContainer.CreateScope())"));

            var usingBody = new BodyGen();
            usingBody.Add(new StatementGen("var context = new `context`();"));
            if (transaction)
                usingBody.Add(new StatementGen("var transaction = context.Database.BeginTransaction();"));

            usingBody.Add(new StatementGen(
                "scope.ManageResources(context" + (transaction ? ", transaction" : "") + ");",
                "action.Invoke(new UnitOfWork(scope, context" + (transaction ? ", transaction" : "") + "));"));

            method.Body.Add(usingBody);
            method.Body.Add(new StatementGen(
                "});"));

            ContextManagerBody.Add(method, new StatementGen(""));
        }

        public void GenerateOpenGetMethod(bool transaction = false)
        {
            var method = new ContainerGen();
            var methodName = transaction ? "OpenTransactionGet" : "OpenGet";
            method.Signature = "public static T " + methodName + "<T>(Func<UnitOfWork, T> func)";

            method.Body.Add(new StatementGen(
                "using (var scope = G.TContainer.CreateScope())"));

            var usingBody = new BodyGen();
            usingBody.Add(new StatementGen("var context = new `context`();"));
            if (transaction)
                usingBody.Add(new StatementGen("var transaction = context.Database.BeginTransaction();"));

            usingBody.Add(new StatementGen(
                "scope.ManageResources(context" + (transaction ? ", transaction" : "") + ");",
                "var res = func.Invoke(new UnitOfWork(scope, context" + (transaction ? ", transaction" : "") + "));"));

            usingBody.Add(new StatementGen(
                "return res;"));
            method.Body.Add(usingBody);

            ContextManagerBody.Add(method, new StatementGen(""));
        }

        public void GenerateOpenGetAsyncMethod(bool transaction = false)
        {
            var method = new ContainerGen();
            var methodName = transaction ? "OpenTransactionGetAsync" : "OpenGetAsync";
            method.Signature = "public static async Task<T> " + methodName + "<T>(Func<UnitOfWork, T> func)";

            method.Body.Add(new StatementGen(
                "return await Task.Run(() =>",
                "{"),
                new StatementGen(
                    "using (var scope = G.TContainer.CreateScope())"));

            var usingBody = new BodyGen();
            usingBody.Add(new StatementGen("var context = new `context`();"));
            if (transaction)
                usingBody.Add(new StatementGen("var transaction = context.Database.BeginTransaction();"));

            usingBody.Add(new StatementGen(
                "scope.ManageResources(context" + (transaction ? ", transaction" : "") + ");",
                "var res = func.Invoke(new UnitOfWork(scope, context" + (transaction ? ", transaction" : "") + "));"));

            usingBody.Add(new StatementGen(
                "return res;"));
            method.Body.Add(usingBody);
            method.Body.Add(new StatementGen(
                "});"));

            ContextManagerBody.Add(method, new StatementGen(""));
        }
    }
}
