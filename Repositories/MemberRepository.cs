using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Interfaces;
using Member.Models;
using Microsoft.AspNetCore.Mvc;

namespace Member.Repositories
{
    public abstract class MemberRepository : IMemberRepository, IMemberRepositoryBetwayFlag1Secondary, IMemberRepositoryBetwayFlag1, IMemberRepositoryBetwayFlag2, IMemberRepositoryBetwayFlag3
    {
        public abstract string InsertNewMember(UserModel userModel);
        public abstract UserModel Login(string userName, string password);

        public abstract bool CheckMemberExists(string username);

        public abstract string UpdateMember(UserModel userModel);
    }
    public class MemberRepositoryUnitTest : IMemberRepository, IMemberRepositoryBetwayFlag1Secondary, IMemberRepositoryBetwayFlag1, IMemberRepositoryBetwayFlag2, IMemberRepositoryBetwayFlag3
    {
        public bool CheckMemberExists(string username)
        {
            return false;
        }

        public string InsertNewMember(UserModel userModel)
        {
            return "Unit Test";
        }

        public UserModel Login(string userName, string password)
        {
            return null;
        }

        public string UpdateMember(UserModel userModel)
        {
            return "Unit Test";
        }
    }
    public class MemberRepositoryNettium : MemberRepository
    {
        private static Dictionary<string, UserModel> UserTable = new Dictionary<string, UserModel>();

        public override bool CheckMemberExists(string username)
        {
            return MemberRepositoryNettium.UserTable.ContainsKey(username.Trim().ToUpper());
        }

        public override string InsertNewMember(UserModel userModel)
        {
            MemberRepositoryNettium.UserTable.Add(userModel.Username.Trim().ToUpper(), userModel);
            return "Added user to Nettium. User name = " + userModel.Username;
        }
        public override UserModel Login(string userName, string password)
        {
            UserModel userModel;
            var result = MemberRepositoryNettium.UserTable.TryGetValue(userName.Trim().ToUpper(), out userModel);
            if (result && password != userModel.Password)
                userModel = null;
            return userModel;
        }

        public override string UpdateMember(UserModel userModel)
        {
            MemberRepositoryNettium.UserTable[userModel.Username.Trim().ToUpper()] =  userModel;
            return "Updated user in Nettium. User name = " + userModel.Username;
        }

    }
    public class MemberRepositoryFunpodium : MemberRepository
    {
        private static Dictionary<string, UserModel> UserTable = new Dictionary<string, UserModel>();
        public override bool CheckMemberExists(string username)
        {
            return MemberRepositoryFunpodium.UserTable.ContainsKey(username.Trim().ToUpper());
        }
        public override string InsertNewMember(UserModel userModel)
        {
            MemberRepositoryFunpodium.UserTable.Add(userModel.Username.Trim().ToUpper(), userModel);
            return "Added user to Funpodium. User name = " + userModel.Username;
        }
        public override UserModel Login(string userName, string password)
        {
            UserModel userModel;
            var result = MemberRepositoryFunpodium.UserTable.TryGetValue(userName.Trim().ToUpper(), out userModel);
            if (result && password != userModel.Password)
                userModel = null;
            Console.WriteLine("Funpodium Repository: User login : " + userName + ". Result:" + Convert.ToString(result));
            return userModel;
        }

        public override string UpdateMember(UserModel userModel)
        {
            MemberRepositoryFunpodium.UserTable[userModel.Username.Trim().ToUpper()] = userModel;
            return "Updated user in Funpodium. User name = " + userModel.Username;
        }
    }
}
