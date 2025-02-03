using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using ConsoleApp3.DAL;

namespace ConsoleApp3.Tests
{
    public class AppDbContextTests
    {
        [Test]
        public void CanAddAndRetrieveUser()
        {
            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("bbb", 20);
            ages.Add("aaa", 32);
            foreach (var item in ages)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            // Arrange
            var user = new Users { Name = "Iaiaia" };
            using (var context = new AppDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            // Act
            using (var context = new AppDbContext())
            {
                var retrievedUser = context.Users.FirstOrDefault(u => u.Id == user.Id);

                // Assert
                Assert.That(retrievedUser, Is.Not.Null);
                Assert.That(retrievedUser?.Name, Is.EqualTo(user.Name));
            }
        }

        [Test]
        public async Task GetDataAsync()
        {
            string data = await FetchDataAsync(1);
            Console.WriteLine(data);
        }

        async Task<string> FetchDataAsync(int userId)
        {
            await using var context = new AppDbContext();
            var retrievedUser = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return retrievedUser.Name;
        }
        
        [Test]
        public async Task RunWhenAnyTask()
        {
           await RunWhenAnyTaskCompletes();
        }
        
        async Task RunWhenAnyTaskCompletes()
        {
            Task.Delay(2000);
            var task1 = FetchDataAsync(1);
            Task.Delay(1000);
            var task2 = FetchDataAsync(2);
            Task.Delay(1000);
            var task3 = FetchDataAsync(3);
            List<Task> tasks = new List<Task>() { task1, task2, task3 };
            while (tasks.Count > 0)
            {
                Task completedTask = await Task.WhenAny(tasks);
                tasks = tasks.Where(t => t != completedTask).ToList();
                Console.WriteLine(await (Task<string>)completedTask);            }
        }
    }
}