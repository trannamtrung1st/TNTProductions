using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.IoContainer.Container
{
    public partial class TContainer
    {
        /*
         * SCOPE AREA
         * */
        public ITContainer CreateScope()
        {
            var parent = this;
            var scope = new TContainer()
            {
                typeMapping = parent.typeMapping,
                poolMapping = parent.poolMapping,
                singletonResources = parent.singletonResources
            };
            return scope;
        }

        /*
         * DISPOSABLE AREA
         * */
        //auto dispose
        public void ClearManagedResources()
        {
            foreach (var r in resolvedResources)
                try
                {
                    r.Dispose();
                }
                catch (Exception) { }
            resolvedResources.Clear();
        }
        //specify if necessary
        public void ClearManagedResources(bool autoDispose)
        {
            if (autoDispose)
                foreach (var r in resolvedResources)
                    try
                    {
                        r.Dispose();
                    }
                    catch (Exception) { }
            resolvedResources.Clear();
        }

        //Check if a resolved obj is a disposable resource and whether it needs to be controlled
        internal void CheckResource(object resource)
        {
            if (!ResourcesControlModeOn)
                return;
            IDisposable disposable = resource as IDisposable;
            if (disposable != null)
                resolvedResources.Add(disposable);
        }

        public void ManageResources(params IDisposable[] resources)
        {
            foreach (var r in resources)
                resolvedResources.Add(r);
        }
        /*
         * DISPOSE AREA
         * */
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                //clear resources
                ClearManagedResources();

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~TContainer()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
