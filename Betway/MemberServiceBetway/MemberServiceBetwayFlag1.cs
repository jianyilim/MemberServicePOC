using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Interfaces;
using Member.Models;
using Microsoft.AspNetCore.Mvc;

namespace Member.Services
{
    public class MemberServiceBetwayFlag1Dependency : MemberServiceDependency
    {
        public readonly IMemberRepositorySecondary MemberRepositorySecondary;
        public MemberServiceBetwayFlag1Dependency(IMemberRepository iMemberRepository, SelfExclusionServiceBase selfExclusionService, IMemberRepositorySecondary iMemberRepositorySecondary) : base(iMemberRepository,selfExclusionService)
        {
            MemberRepositorySecondary = iMemberRepositorySecondary;
        }
    }
    public class MemberServiceBetwayFlag1 :MemberServiceBase
    {
        public MemberServiceBetwayFlag1(MemberServiceDependency memberServiceDependency) : base(memberServiceDependency)
        {
        }
        public override bool RegisterNewMember(UserModel usermodel, out string result)
        {
            //Call base logic, which is register at Master repository
            var success = base.RegisterNewMember(usermodel, out result);

            if (success)
            {
                var memberServiceDependency = _memberServiceDependency as MemberServiceBetwayFlag1Dependency;

                //Register at Secondary repository which is Nettium internal DB
                result = result + "\n" + memberServiceDependency.MemberRepositorySecondary.InsertNewMember(usermodel);

            }
            return success;
        }

        public override bool UpdateMember(UserModel user, out string result)
        {
            var success = base.UpdateMember(user, out result);
            if (success)
            {
                var memberServiceDependency = _memberServiceDependency as MemberServiceBetwayFlag1Dependency;

                result = result + memberServiceDependency.MemberRepositorySecondary.UpdateMember(user);
            }

            return success;

        }
    }
}
