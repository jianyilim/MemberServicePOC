using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member.Interfaces
{
    public interface ISelfExclusionRepository
    {
        /// <summary>
        /// Check if the member has Self-Exclusion from the table.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns></returns>
        string GetSelfExclusion(string username);
        /// <summary>
        /// Insert self-exclusion to the table.
        /// </summary>
        /// <param name="username">Username</param>
        string InsertSelfExclusion(string username);
    }
}
