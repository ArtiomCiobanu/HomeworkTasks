using System;
using System.Collections.Generic;
using ConsoleApp1.Models;

namespace ConsoleApp1.API.Static_classes
{
    public static class UserManager
    {
        public static List<User> Users { get; private set; } = new List<User>();

        public static void PrintUsersToConsole()
        {
            for (int i = 0; i < Users.Count; i++)
            {
                Console.WriteLine($"{i} {Users[i].Name}");
            }
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}