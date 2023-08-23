﻿using Autofac;
using SubBee.Services.Login;
using SubBee.Services.Register;
using SubBee.Services.Register.Dal;

namespace SubBee.Api.AutofacModules
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterDal>().As<IRegisterDal>().SingleInstance();

            builder.RegisterType<LoginService>().As<ILoginService>().SingleInstance();
            builder.RegisterType<RegisterService>().As<IRegisterService>().SingleInstance();
        }
    }
}
