namespace ConsoleApp3;

public class NotificationManager
{
    private readonly IMessageService _messageService;
    private readonly IOrderService _orderService;
      
    public NotificationManager(IMessageService messageService)
    {
        _messageService = messageService;
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.SendMessage(message);
    }
}