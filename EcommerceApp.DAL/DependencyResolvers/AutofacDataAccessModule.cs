using Autofac;
using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Repositories;

namespace EcommerceApp.DAL.DependencyResolvers
{
    public class AutofacDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
