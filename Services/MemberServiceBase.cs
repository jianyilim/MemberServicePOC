using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using Member.Interfaces;
using Member.Models;
using System.Text.RegularExpressions;

namespace Member.Services
{
    public class MemberServiceDependency
    {
        public readonly IMemberRepository MemberRepository;
        public readonly SelfExclusionServiceBase SelfExclusionService;
        public MemberServiceDependency(IMemberRepository iMemberRepository, SelfExclusionServiceBase selfExclusionService)
        {
            MemberRepository = iMemberRepository;
            SelfExclusionService = selfExclusionService;
        }
    }

    public class MemberServiceBase
    {
        protected readonly MemberServiceDependency _memberServiceDependency;
        public MemberServiceBase(MemberServiceDependency memberServiceDependency)
        {
            _memberServiceDependency = memberServiceDependency;
        }
    
        public virtual bool RegisterNewMember(UserModel user, out string result)
        {
            result = "";
            if (this.ValidateNewUser(user, out result))
            {
                result = _memberServiceDependency.MemberRepository.InsertNewMember(user);
                return true;
            }
            else
                return false;
        }
        public virtual bool UpdateMember(UserModel user, out string result)
        {

            if (this.Login(user) is null)
            {
                result = "Invalid login";
                return false;
            }
            else
            {
                result = _memberServiceDependency.MemberRepository.UpdateMember(user);
                return true;

            }

        }
        public virtual UserModel Login(UserModel user)
        {

            if (!_memberServiceDependency.SelfExclusionService.CheckHasSelfExclusion(user.Username))
                user = ValidateLoginCredential(user);
            else
                user = null;
          
           return user;
        }
        public virtual UserModel ValidateLoginCredential(UserModel user)
        {
            return _memberServiceDependency.MemberRepository.Login(user.Username, user.Password);
        }
        public bool VerifyPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && Regex.Match(password, this.GetPasswordRegex()).Success;
        }

        public string GetPasswordRegex()
        {
            return "^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$";
        }

        public bool ValidateNewUser(UserModel user, out string resultstring)
        {
            resultstring = string.Empty;
            if (_memberServiceDependency.MemberRepository.CheckMemberExists(user.Username))
            {
                resultstring = "Member exists";
                return false;
            }
            else if (!VerifyPassword(user.Password))
            {
                resultstring = "Weak password.";
                return false;
            }
            return true;
        }
    }
}
