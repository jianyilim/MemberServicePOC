using Member.Factories;
using Member.Interfaces;

namespace Member.Services
{
    public class MemberServiceBetwayFlag3 : MemberServiceBetway
    {
        public MemberServiceBetwayFlag3() : base()
        {
            _memberRepository = MemberFactory.GetRequiredService<IMemberRepositoryBetwayFlag3>();
        }
    }
}
