using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Services;
using Member.Repositories;
using Member.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Member.Controllers;

namespace Member.Factories
{
    public class MemberFactoryBetway : MemberFactory
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SelfExclusionServiceBase, SelfExclusionServiceBetway>();
            services.AddScoped<ISelfExclusionRepository, SelfExclusionRepositoryNettium>();

            #region Flag1
            services.AddScoped<MemberServiceBetwayFlag1>();
            services.AddScoped<IMemberRepositoryBetwayFlag1, MemberRepositoryFunpodium>();
            services.AddScoped<IMemberRepositoryBetwayFlag1Secondary, MemberRepositoryNettium>();
            #endregion Flag1

            #region Flag2
            services.AddScoped<MemberServiceBetwayFlag2>();
            services.AddScoped<IMemberRepositoryBetwayFlag2, MemberRepositoryNettium>();
            #endregion Flag2

            #region Flag3
            services.AddScoped<MemberServiceBetwayFlag3>();
            services.AddScoped<IMemberRepositoryBetwayFlag3, MemberRepositoryFunpodium>();
            #endregion Flag3

        }

        public override MemberServiceBase CreateMemberService()
        {
            var flag = SettingsController.GlobalSettings.ProjectFlag;

            if (flag == 1)
                return MemberFactory.GetRequiredService<MemberServiceBetwayFlag1>();
            else if (flag == 2)
                return MemberFactory.GetRequiredService<MemberServiceBetwayFlag2>();
            else if (flag == 3)
                return MemberFactory.GetRequiredService<MemberServiceBetwayFlag3>();
            else
                throw new NotImplementedException();
        }
    }
}
