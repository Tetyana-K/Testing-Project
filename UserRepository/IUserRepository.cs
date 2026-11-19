using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    // Припустимо, у нашому застосунку є репозиторій користувачів, який у реальному проєкті працює з базою даних
    public interface IUserRepository
    {
        void Add(string name); // функція додавання користувача
        string GetById(int id); // функція отримання даних  (у вигляді рядка) за Id користувача
    }
}
