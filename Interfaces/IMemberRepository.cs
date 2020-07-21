using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member.Models;

namespace Member.Interfaces
{ 
    public interface IMemberRepository
    {
        /// <summary>
        /// Insert new member to the table.
        /// </summary>
        /// <param name="userModel">User model.</param>
        string InsertNewMember(UserModel userModel);

        /// <summary>
        /// Validate login credential.
        /// </summary>
        /// <param name="userModel">User model.</param>
        /// <returns>Validation result. True = Successful.</returns>
        UserModel Login(string userName, string password);

        /// <summary>
        /// Check if member exists.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns></returns>
        bool CheckMemberExists(string username);

        /// <summary>
        /// Insert new member to the table.
        /// </summary>
        /// <param name="userModel">User model.</param>
        string UpdateMember(UserModel userModel);
    }
    public interface IMemberRepositorySecondary : IMemberRepository
    { 
    
    }
}
