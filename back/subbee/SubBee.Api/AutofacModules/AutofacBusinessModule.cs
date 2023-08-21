using Autofac;
using SubBee.Services.Login;

namespace SubBee.Api.AutofacModules
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginService>().As<ILoginService>().SingleInstance();
        }
    }
}
