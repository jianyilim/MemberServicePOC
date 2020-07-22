using Member.Factories;
using Member.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Services
{
    public class MemberServiceBetway : MemberServiceBase
    {
        public MemberServiceBetway()
        {
            _selfExclusionService = MemberFactory.GetRequiredService<SelfExclusionServiceBase>();
        }
    }
}
