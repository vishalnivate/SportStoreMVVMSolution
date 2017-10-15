using System;
using Microsoft.Practices.Unity;
using SportStoreDomainLibrary.Abstract;
using SportStoreDomainLibrary.Concrete;

namespace SportStoreValidationDIWpfApp
{
    class SportStoreContainer
    {
        private static UnityContainer _unitycontainer;

        static SportStoreContainer()
        {
            _unitycontainer = new UnityContainer();
            AddBindings();
        }

        public static UnityContainer Container
        {
            get { return _unitycontainer; }
        }

        private static void AddBindings()
        {
            _unitycontainer.RegisterType<iProductRepository, EFProductRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
