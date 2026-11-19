using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    // Реальний репозиторій може використовувати SQL Server  чи інш.

    // А для тестування створимо Fake, який зберігає дані у звичайному списку (List)
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<string> _users = new();

        public void Add(string name)
        {
            _users.Add(name);
        }

        public string GetById(int id)
        {
            if (id < 0 || id >= _users.Count)
                return null;

            return _users[id];
        }
    }
}
