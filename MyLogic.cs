using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.BLL;
using Users.Entities;

namespace Users.ConsolePL
{
    class MyLogic
    {
        private static IUserLogic userLogic = new UserLogic();
        private static AwardLogic awardLogic = new AwardLogic();
        public static void AddUser()
        {
            Console.WriteLine("Имя пользователя:");
            string name = Console.ReadLine();
            Console.WriteLine("Дата рождения:");
            try
            {
                if (DateTime.TryParse(Console.ReadLine(), out var dateOfBirth))
                {
                    Console.WriteLine("Возраст:");
                    if (int.TryParse(Console.ReadLine(), out var age))
                    {
                        var newUser = new User()
                        {

                            Name = name,
                            DateOfBirth = dateOfBirth,
                            Age = age
                        };
                        userLogic.AddUser(newUser);
                        Console.WriteLine("Пользователь добавлен!");
                    }
                    else
                    {
                        throw new Exception("No correctly format of User's age");
                    }
                } else
                {
                    throw new Exception("No correctly format of User's dateOfBirth");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Некорректные данные пользователя!");
            }
        }
        public static void GetUsers()
        {
            try
            {
                var result = userLogic.GetUsers();
                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.ToString());
                    }
                } else
                {
                    throw new Exception("Empty!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Нет пользователей!");
            }
        }
        public static void RemoveUser()
        {
            Console.WriteLine("Укажите ID пользователя:");
            try
            {
                if (int.TryParse(Console.ReadLine(), out var indexUser) && userLogic.GetNeedUsers(indexUser).Any())
                {
                    userLogic.RemoveUser(indexUser);
                    Console.WriteLine("Пользователь удален!");
                } else
                {
                    throw new Exception("No correctly operation");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Пользвателя с таким ID не существует!");
            }
        }
        public static void AddAward()
        {
            Console.WriteLine("ID пользователя:");
            try
            {
                if (int.TryParse(Console.ReadLine(), out var indexUser) && userLogic.GetNeedUsers(indexUser).Any())
                {
                    Console.WriteLine("Название награды:");
                    string Title = Console.ReadLine();
                    awardLogic.AddAward(indexUser, Title);
                    Console.WriteLine("Награда добавлена!");
                } else
                {
                    throw new Exception("No correctly operation!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Некорректный ID!");
            }
        }
        public static void GetAwardsByUser()
        {
            Console.WriteLine("ID пользователя:");
            try
            {

                if (int.TryParse(Console.ReadLine(), out var indexUser) && userLogic.GetNeedUsers(indexUser).Any())
                {
                    var result = awardLogic.GetAwardsByUser(indexUser);
                    if (result.Any())
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    } else
                    {
                        throw new Exception("No awards!");
                    }
                } else
                {
                    throw new Exception("No correctly operation!");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Некоректный ID/у пользователя нет наград");
            }
        }
        public static void RemoveAward()
        {
            Console.WriteLine("ID пользователя:");
            try
            {
                if (int.TryParse(Console.ReadLine(), out var indexUser) && userLogic.GetNeedUsers(indexUser).Any())
                {
                    Console.WriteLine("Название награды:");
                    string Title = Console.ReadLine();
                    if (awardLogic.GetNeedAwards(indexUser, Title).Any())
                    {
                        awardLogic.RemoveAward(indexUser, Title);
                    } else
                    {
                        throw new Exception("No correctly Title!");
                    }
                } else
                {
                    throw new Exception("No correctly IDUser!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Некорректные данные пользователя/награды!");
            }
        }
    }
}
