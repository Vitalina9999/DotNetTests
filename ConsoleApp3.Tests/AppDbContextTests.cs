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
                Assert.That(retrievedUser.Name, Is.EqualTo(user.Name));
            }
        }
    }
}
