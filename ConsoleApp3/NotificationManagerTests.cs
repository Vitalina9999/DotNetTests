using Moq;
using NUnit.Framework;
using System;


namespace ConsoleApp3;

// Объявление класса тестов для NotificationManager
public class NotificationManagerTests
{
    // Атрибут [Test] указывает, что этот метод является тестом
    [Test]
    public void Notify_CallsSendMessage_OnMessageService()
    {
        // Arrange: настройка теста
        // Создание mock-объекта для IMessageService с помощью Moq
        var mockMessageService = new Mock<IMessageService>();
        // Создание экземпляра NotificationManager с использованием mock-объекта IMessageService
        var notificationManager = new NotificationManager(mockMessageService.Object);
        // Определение тестового сообщения
        var testMessage = "Test Message";

        // Act: выполнение тестируемого метода
        // Вызов метода Notify у NotificationManager с тестовым сообщением
        notificationManager.Notify(testMessage);

        // Assert: проверка результатов
        // Проверка, что метод SendMessage у mock-объекта IMessageService был вызван один раз с тестовым сообщением
        mockMessageService.Verify(m => m.SendMessage(testMessage), Times.Once);
    }
}