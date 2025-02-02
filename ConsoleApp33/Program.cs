﻿using ConsoleApp3.CQRS.Commands;
using ConsoleApp3.CQRS.Handlers;
using ConsoleApp3.CQRS.Queries;
using ConsoleApp3.DAL;

using var context = new AppDbContext();
var createUserHandler = new CreateUserCommandHandler(context);
createUserHandler.Handle(new CreateUserCommand { Name = "John Doe" });

var getUserHandler = new GetUserQueryHandler(context);
var user = getUserHandler.Handle(new GetUserQuery { UserId = 1 });
Console.WriteLine($"Retrieved User: {user.Name}");


//var items = context.Users.ToList();

//Console.WriteLine(items);

//// Настраиваем контейнер Autofac
//var builder = new ContainerBuilder();
//builder.RegisterType<EmailService>().As<IMessageService>();
//builder.RegisterType<NotificationManager>();

//// Разрешаем зависимости через контейнер
//using var container = builder.Build();
//using var scope = container.BeginLifetimeScope();
//var manager = scope.Resolve<NotificationManager>();
//manager.Notify("Hello with Autofac!");

//using var context = new AppDbContext();
//// Создание (Create)
//var newProduct = new Product { Name = "Laptop", Price = 1500.00M };
//context.Products.Add(newProduct);
//context.SaveChanges();
//Console.WriteLine("Product created!");

//// Чтение (Read)
//var product = context.Products.FirstOrDefault(p => p.Name == "Laptop");
//Console.WriteLine($"Product retrieved: {product.Name}, {product.Price}");

//// Обновление (Update)
//product.Price = 1400.00M;
//context.SaveChanges();
//Console.WriteLine("Product updated!");

//// Удаление (Delete)
//context.Products.Remove(product);
//context.SaveChanges();
//Console.WriteLine("Product deleted!");
