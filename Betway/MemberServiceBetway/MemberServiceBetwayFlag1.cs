using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Factories;
using Member.Interfaces;
using Member.Models;
using Microsoft.AspNetCore.Mvc;

namespace Member.Services
{
    public class MemberServiceBetwayFlag1 : MemberServiceBetway
    {
        private readonly IMemberRepository _memberRepositorySecondary;
        public MemberServiceBetwayFlag1() : base()
        {
            _memberRepository = MemberFactory.GetRequiredService<IMemberRepositoryBetwayFlag1>();
            _memberRepositorySecondary = MemberFactory.GetRequiredService<IMemberRepositoryBetwayFlag1Secondary>();
        }
        public override bool RegisterNewMember(UserModel usermodel, out string result)
        {
            //Call base logic, which is register at Master repository
            var success = base.RegisterNewMember(usermodel, out result);

            if (success)
            {
                //Register at Secondary repository which is Nettium internal DB
                result = result + "\n" + _memberRepositorySecondary.InsertNewMember(usermodel);

            }
            return success;
        }

        public override bool UpdateMember(UserModel user, out string result)
        {
            var success = base.UpdateMember(user, out result);
            if (success)
                result = result + _memberRepositorySecondary.UpdateMember(user);
            
            return success;

        }
    }
}
