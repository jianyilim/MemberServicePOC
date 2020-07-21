using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Interfaces;

namespace Member.Repositories
{

    public abstract class SelfExclusionRepository : ISelfExclusionRepository
    {
        public abstract string GetSelfExclusion(string username);
        public abstract string InsertSelfExclusion(string username);

    }
    public class SelfExclusionRepositoryUnitTest : ISelfExclusionRepository
    {
        public string GetSelfExclusion(string username)
        {
            return "Unit Test";
        }

        public string InsertSelfExclusion(string username)
        {
            return "Unit Test";
        }
    }
    public class SelfExclusionRepositoryNettium : SelfExclusionRepository
    {
        public static Dictionary<string, string> _SelfExclusionTable = new Dictionary<string, string>();
        public override string GetSelfExclusion(string username)
        {
            var result = "";
            SelfExclusionRepositoryNettium._SelfExclusionTable.TryGetValue(username.Trim().ToUpper(), out result);
            Console.WriteLine("Nettium repository: Check self-exclusion : " + username + ". Result:" + Convert.ToString(result));
            return result;
        }
        public override string InsertSelfExclusion(string username)
        {
            SelfExclusionRepositoryNettium._SelfExclusionTable.Add(username.Trim().ToUpper(), username.Trim().ToUpper());
            return "Added user to Nettium Self-exclusion table. User name = " + username;
        }
    }
}
