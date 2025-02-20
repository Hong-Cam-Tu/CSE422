using Library_Lab4.Models;

namespace Library_Lab4.Services
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int id);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
        IEnumerable<Member> SearchMembers(string keyword);

    }
}
