using System;
using Microsoft.Practices.Unity;
using MundiPagg.Benfeitor.BenfeitorApi.Services;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data;
using MundiPagg.Benfeitor.Infrastructure.Data.Repositories;

namespace MundiPagg.Benfeitor.BenfeitorApi
{

    public static class IoCFactory
    {

        #region Properties

        static IUnityContainer _container;

        public static IUnityContainer Current
        {
            get
            {
                return _container;
            }
        }

        #endregion

        #region Constructor

        static IoCFactory()
        {
            ConfigureContainer();
        }

        #endregion

        #region Methods

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        static void ConfigureContainer()
        {

            _container = new UnityContainer();

            _container.RegisterType(typeof(UnitOfWork), new PerResolveLifetimeManager());
            

            // Repositories
            _container.RegisterType<IPersonRepository, PersonRepository>();
            _container.RegisterType<IAddressRepository, AddressRepository>();
            _container.RegisterType<ILoanRepository, LoanRepository>();

            // Application Services
            _container.RegisterType<IAuthenticationService, AuthenticationService>();
            _container.RegisterType<IPersonService, PersonService>();
            _container.RegisterType<ILoanService, LoanService>();
        }

        #endregion
    }
}
