using System;
using Microsoft.Practices.Unity;
using SportStoreDomainLibrary.Abstract;
using SportStoreDomainLibrary.Concrete;

namespace SportStoreValidationDIWpfApp
{
  class SportsStoreContainer
  {
    private static UnityContainer _unitContainer;

    static SportsStoreContainer()
    {
      _unitContainer = new UnityContainer();
      AddBindings();
    }

    public static UnityContainer Container { get { return _unitContainer; } }

    private static void AddBindings()
    {
      //ContainerControlledLifetimeManager this creates a Singleton object
      _unitContainer.RegisterType<iProductRepository, EFProductRepository>(new ContainerControlledLifetimeManager());
    }

  }
}
