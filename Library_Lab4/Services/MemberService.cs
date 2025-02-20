using Library_Lab4.Data;
using Library_Lab4.Models;

namespace Library_Lab4.Services
{
    public class MemberService : IMemberService
    {
        private readonly LibraryContext _context;

        public MemberService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int id)
        {
            return _context.Members.Find(id);
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void UpdateMember(Member member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
        }

        public void DeleteMember(int id)
        {
            var member = _context.Members.Find(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
        }
        public IEnumerable<Member> SearchMembers(string keyword)
        {
            return _context.Members
                .Where(m => m.Name.Contains(keyword) || m.Email.Contains(keyword))
                .ToList();
        }
    }
}
