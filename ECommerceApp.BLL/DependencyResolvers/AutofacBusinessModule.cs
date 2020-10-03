using Autofac;

namespace ECommerceApp.BLL.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .Where(type => type.Namespace.Contains("Concrete"))
                .AsImplementedInterfaces();
        }
    }
}
