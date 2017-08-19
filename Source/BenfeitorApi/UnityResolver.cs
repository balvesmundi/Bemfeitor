using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace MundiPagg.Benfeitor.BenfeitorApi
{

    public class UnityResolver : IDependencyResolver
    {

        protected IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {

            if (container == null) throw new ArgumentNullException("container");

            _container = container;
        }

        public IDependencyScope BeginScope()
        {

            var child = IoCFactory.Current.CreateChildContainer();

            return new UnityResolver(child);
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}