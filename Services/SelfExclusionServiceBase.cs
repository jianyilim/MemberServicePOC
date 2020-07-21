using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Interfaces;

namespace Member.Services
{
    public class SelfExclusionServiceDependency
    {
        public readonly ISelfExclusionRepository SelfExclusionRepository;
        public SelfExclusionServiceDependency(ISelfExclusionRepository selfExclusionRepository)
        {
            SelfExclusionRepository = selfExclusionRepository;
        }
    }
    public class SelfExclusionServiceBase
    {
        protected readonly SelfExclusionServiceDependency _selfExclusionServiceDependency;
        public SelfExclusionServiceBase(SelfExclusionServiceDependency selfExclusionServiceDependency)
        {
            _selfExclusionServiceDependency = selfExclusionServiceDependency;
        }
        /// <summary>
        /// Check if the member has self-exclusion.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <returns></returns>
        public bool CheckHasSelfExclusion(string userName)
        {
            var result = _selfExclusionServiceDependency.SelfExclusionRepository.GetSelfExclusion(userName);
            return !string.IsNullOrEmpty(result);
        }

        /// <summary>
        /// Create Self-exclusion.
        /// </summary>
        /// <param name="userName">Username</param>
        public string CreateSelfExclusion(string userName)
        {
            if (this.CheckHasSelfExclusion(userName))
            {
                return "User already has self-exclusion.";
            }
           return _selfExclusionServiceDependency.SelfExclusionRepository.InsertSelfExclusion(userName);
        }
    }
}
