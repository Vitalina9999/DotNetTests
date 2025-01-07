namespace ConsoleApp3.CQRS.Events

{
    public class UserCreatedEventHandler
    {
        public void Handle(UserCreatedEvent @event)
        {
            // Handle the event (e.g., log, update read models, etc.)
            Console.WriteLine($"User created: {@event.UserId}, {@event.Name}");
        }
    }
}