using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Factories;
using Member.Interfaces;

namespace Member.Services
{

    public class SelfExclusionServiceBase
    {
        private protected readonly ISelfExclusionRepository _selfExclusionRepository;
        public SelfExclusionServiceBase()
        {
            _selfExclusionRepository = MemberFactory.GetRequiredService<ISelfExclusionRepository>();
        }

        /// <summary>
        /// Check if the member has self-exclusion.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <returns></returns>
        public bool CheckHasSelfExclusion(string userName)
        {
            var result = _selfExclusionRepository.GetSelfExclusion(userName);
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
           return _selfExclusionRepository.InsertSelfExclusion(userName);
        }
    }
}
