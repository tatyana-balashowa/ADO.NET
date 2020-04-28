using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите одно из следующих действий:"
                                 + Environment.NewLine +
                                 "1 - Добавить пользователя"
                                 + Environment.NewLine +
                                 "2 - Просмотреть список пользователей"
                                 + Environment.NewLine +
                                  "3 - Удалить пользователя"
                                  + Environment.NewLine +
                                  "4 -Добавить награду"
                                  + Environment.NewLine +
                                  "5 - Просмотреть перечень наград пользователя"
                                  + Environment.NewLine +
                                  "6 - Удалить награду");
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        MyLogic.AddUser();
                        break;
                    case "2":
                        MyLogic.GetUsers();
                        break;
                    case "3":
                        MyLogic.RemoveUser();
                        break;
                    case "4":
                        MyLogic.AddAward();
                        break;
                    case "5":
                        MyLogic.GetAwardsByUser();
                        break;
                    case "6":
                        MyLogic.RemoveAward();
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
