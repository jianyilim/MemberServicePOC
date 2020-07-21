using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Services;
using Microsoft.Extensions.DependencyInjection;
using Member.Factories;
using System.ComponentModel;
using Member.Controllers;

namespace Member.Factories
{
    class BUCode
    {
        public static readonly string Betway = "BETWAY";
        public static readonly string RB88 = "RB88";
    }
  
    public abstract class MemberFactory
    {
        private readonly ServiceProvider _serviceProvider;

        public abstract void ConfigureServices(IServiceCollection serviceCollection);

        public MemberFactory()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public static MemberFactory CreateMemberFactory()
        {
            var buCode = SettingsController.GlobalSettings.BUCode;
            MemberFactory memberFactory = null;
            if (buCode == BUCode.Betway)
            { 
                if(SettingsController.GlobalSettings.IsUnitTest)
                    memberFactory = new MemberFactoryBetwayUnitTest();
                else
                    memberFactory = new MemberFactoryBetway();
            }
                
            return memberFactory;
        }

        public static T GetRequiredService<T>()
        {
            var memberFactory = CreateMemberFactory();
            return memberFactory._serviceProvider.GetRequiredService<T>();
        }
    }
}
