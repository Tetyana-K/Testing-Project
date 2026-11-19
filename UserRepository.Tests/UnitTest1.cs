namespace UserRepository.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [Test]
        public void GetById_ReturnsAddedUser()
        {
            // Arrange
            var fakeRepository = new FakeUserRepository();

            fakeRepository.Add("Olena"); // id = 0
            fakeRepository.Add("Andrii"); // id = 1

            // Act
            var result = fakeRepository.GetById(1);

            // Assert
            Assert.That(result, Is.EqualTo("Andrii"));
        }
    }
}
/*
 * Як працює наш код
    - Fake зберігає дані у списку
    - Ми додаємо користувачів
    - Потім отримуємо користувача за індексом
    - Перевіряємо результат
Тобто Fake не просто повертає одну наперед задану відповідь. 
Він має власну робочу!! логіку.

** Головна ідея
 Fake імітує реальну функціональність компонента, але реалізує її простішим способом.

Приклади Fake у реальних проєктах:
- Замість SQL Server — репозиторій на основі колекції в пам'яті.
- Замість реального файлового сховища — зберігання файлів у пам'яті.
- Замість зовнішнього сервісу — спрощена реалізація його функцій.
 */
