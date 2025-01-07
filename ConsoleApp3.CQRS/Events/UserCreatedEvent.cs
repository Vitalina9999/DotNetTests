namespace ConsoleApp3.CQRS.Events

{
    public class UserCreatedEvent
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}