﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Services;
using Member.Repositories;
using Member.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Member.Factories
{
    public class MemberFactoryBetwayUnitTest : MemberFactory
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var flag = Member.Controllers.SettingsController.GlobalSettings.ProjectFlag;

            services.AddScoped<SelfExclusionServiceBase, SelfExclusionServiceBetway>();
            services.AddScoped<ISelfExclusionRepository, SelfExclusionRepositoryUnitTest>();
            services.AddScoped<SelfExclusionServiceDependency, SelfExclusionServiceDependency>();
            services.AddScoped<IMemberRepository, MemberRepositoryUnitTest>();
            if (flag == 1)
            {
                services.AddScoped<MemberServiceBase, MemberServiceBetwayFlag1>();
                services.AddScoped<MemberServiceDependency, MemberServiceBetwayFlag1Dependency>();
                services.AddScoped<IMemberRepositorySecondary, MemberRepositoryUnitTest>();
            }
            else if (flag == 2)
            {
                services.AddScoped<MemberServiceBase, MemberServiceBetwayFlag2>();
                services.AddScoped<MemberServiceDependency, MemberServiceDependency>();
            }
            else if (flag == 3)
            {
                services.AddScoped<MemberServiceBase, MemberServiceBetwayFlag3>();
                services.AddScoped<MemberServiceDependency, MemberServiceDependency>();
            }
        }
    }
}
