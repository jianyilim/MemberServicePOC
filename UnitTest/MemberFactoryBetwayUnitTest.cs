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
    public class MemberFactoryBetwayUnitTest : MemberFactoryBetway
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SelfExclusionServiceBetway>();
            services.AddScoped<ISelfExclusionRepository, SelfExclusionRepositoryUnitTest>();

            #region Flag1
            services.AddScoped<MemberServiceBetwayFlag1>();
            services.AddScoped<IMemberRepositoryBetwayFlag1, MemberRepositoryUnitTest>();
            services.AddScoped<IMemberRepositoryBetwayFlag1Secondary, MemberRepositoryUnitTest>();
            #endregion Flag1

            #region Flag2
            services.AddScoped<MemberServiceBetwayFlag2>();
            services.AddScoped<IMemberRepositoryBetwayFlag2, MemberRepositoryUnitTest>();
            #endregion Flag2

            #region Flag3
            services.AddScoped<MemberServiceBetwayFlag3>();
            services.AddScoped<IMemberRepositoryBetwayFlag3, MemberRepositoryUnitTest>();
            #endregion Flag3
        }

    }
}
