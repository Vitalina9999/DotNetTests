using ConsoleApp3.CQRS.Commands;
using ConsoleApp3.CQRS.Events;
using ConsoleApp3.DAL;

namespace ConsoleApp3.CQRS.Handlers
{
    public class CreateUserCommandHandler
    {
        private readonly AppDbContext _context;

        public CreateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public void Handle(CreateUserCommand command)
        {
            var user = new Users { Name = command.Name };
            _context.Users.Add(user);
            _context.SaveChanges();

            // Raise event
            var userCreatedEvent = new UserCreatedEvent { UserId = user.Id, Name = user.Name };
            new UserCreatedEventHandler().Handle(userCreatedEvent);
        }
    }
}