//Stub — заглушка
//Stub — це тестовий об'єкт, який повертає заздалегідь визначені результати у відповідь на виклики методів.

//Його основне завдання — надати тестованому класу потрібні дані, щоб ми могли перевірити його логіку.
using Discount_Service;

namespace DicountService.Stub.Tests
{ 
    [TestFixture]
    public class DicountServiceStubTests
    {
        [Test]
        public void CalculateDiscount_PremiumUser_Returns20()
        {
            // Arrange
            var stub = new StubUserRepository();// створюємо об'єкт Stub
            var service = new DiscountService(stub); // створюємо об'єкт сервісу, який використовує заглушку

            // Act
            var result = service.CalculateDiscount(1);

            // Assert
            Assert.That(result, Is.EqualTo(20));
        }
    }

    // Stub class для UserRepository
    internal class StubUserRepository : IUserRepository // Irepository у папці Mock з проектами (Discount Service проект)
    {
        public bool IsPremiumUser(int userId)
        {
            return true; // stub завжди повертає true
        }
    }
}
/*
 * Ми не звертаємося до реальної бази даних. 
 * Stub завжди повертає true, тобто повідомляє, що користувач має преміум-статус.

Завдяки цьому ми можемо перевірити, чи правильно DiscountService обчислює знижку.
Якщо потрібно перевірити звичайного користувача, можна створити іншу заглушку:
public class StubRegularUserRepository : IUserRepository
{
    public bool IsPremiumUser(int userId)
    {
        return false;
    }
}

Тоді сервіс поверне знижку 5%.
Головна ідея - 
 Stub контролює дані, які отримує тестований клас.
 */