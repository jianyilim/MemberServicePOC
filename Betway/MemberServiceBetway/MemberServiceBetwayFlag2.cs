using Member.Factories;
using Member.Interfaces;

namespace Member.Services
{
    public class MemberServiceBetwayFlag2 : MemberServiceBetway
    {
        public MemberServiceBetwayFlag2() : base()
        {
            _memberRepository = MemberFactory.GetRequiredService<IMemberRepositoryBetwayFlag2>();
        }
    }
}
