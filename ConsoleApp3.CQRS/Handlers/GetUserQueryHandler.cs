using ConsoleApp3.CQRS.Queries;
using ConsoleApp3.DAL;

namespace ConsoleApp3.CQRS.Handlers
{
    public class GetUserQueryHandler
    {
        private readonly AppDbContext _context;

        public GetUserQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public Users Handle(GetUserQuery query)
        {
            return _context.Users.FirstOrDefault(u => u.Id == query.UserId);
        }
    }
}