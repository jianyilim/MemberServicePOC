using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using Member.Interfaces;
using Member.Models;
using System.Text.RegularExpressions;
using Member.Factories;

namespace Member.Services
{

    public class MemberServiceBase
    {
        private protected IMemberRepository _memberRepository;
        private protected SelfExclusionServiceBase _selfExclusionService;
 
    
        public virtual bool RegisterNewMember(UserModel user, out string result)
        {
            result = "";
            if (this.ValidateNewUser(user, out result))
            {
                result = _memberRepository.InsertNewMember(user);
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
                result = _memberRepository.UpdateMember(user);
                return true;

            }

        }
        public virtual UserModel Login(UserModel user)
        {

            if (!_selfExclusionService.CheckHasSelfExclusion(user.Username))
                user = ValidateLoginCredential(user);
            else
                user = null;
          
           return user;
        }
        public virtual UserModel ValidateLoginCredential(UserModel user)
        {
            return _memberRepository.Login(user.Username, user.Password);
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
            if (_memberRepository.CheckMemberExists(user.Username))
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
