using NUnit.Framework;
using Moq;
using Discount_Service;
namespace DiscountService.Tests
{
    [TestFixture]
    public class DiscountServiceTests
    {

        [Test]
        public void CalculateDiscount_PremiumUser_Returns20()
        {
            // Arrange
            // Створюємо тестовий об'єкт, який реалізує інтерфейс IUserRepository
            var mockRepository = new Mock<IUserRepository>();

            //mockRepository.Object.IsPremiumUser()
            // Setup() - налаштування поведінки моку
            mockRepository
                .Setup(r => r.IsPremiumUser(1)) // налаштовуємо поведінку функції IsPremiumUser для корситувача з id =  1
                .Returns(true); // якщо буде викликано IsPremiumUser(1), поверни true

            //// якщо налаштувати так, то  незалежно від переданого ID метод IsPremiumUser() повертатиме true
            //mockRepository
            //    .Setup(r => r.IsPremiumUser(It.IsAny<int>()))
            //    .Returns(true);


            //mockRepository //  якщо хочемо налаштувати, що метод кидає помилку
            //    .Setup(r => r.IsPremiumUser(1))
            //    .Throws(new Exception("Database error"));

            // mockRepository.Object - отримання об'єкта для тестування
            // створюємо об'єкт сервісу і передаємо у конструктор наш мок
            var service = new Discount_Service.DiscountService( // конструктор сервісу очікує об'єкт репозиторія, а ми передаємо мок
                mockRepository.Object);

            // Act
            var result = service.CalculateDiscount(1); // викликаємо функцію CalculateDiscount(), яка має розрахувати знижку для клієнта
                                                       // попередньо нашатували, що для користувача з Ід = 1 IsPremiumUser() буде повертати true, то очікуємо знижку 20
                                                       // Assert

            Assert.That(result, Is.EqualTo(20));
            mockRepository.Verify(r => r.IsPremiumUser(1), Times.Once);// перевіряємо, чи був метод IsPremiumUser(1) викликаний рівно один раз 
        }


        [Test]
        public void CalculateDiscount_RegularUser_Returns5()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();

            mockRepository
                .Setup(r => r.IsPremiumUser(1)) // налаштовуємо поведінку функції IsPremiumUser для корситувача з id =  1
                .Returns(false); // якщо буде викликано IsPremiumUser(1), поверни true

            // створюємо об'єкт сервісу і передаємо у конструктор наш мок
            var service = new Discount_Service.DiscountService( 
                mockRepository.Object);

            // Act
            var result = service.CalculateDiscount(1); // викликаємо функцію CalculateDiscount(), яка має розрахувати знижку для клієнта
                                                       // попередньо нашатували, що для користувача з Ід = 1 IsPremiumUser() буде повертати true, то очікуємо знижку 20
                                                       // Assert

            Assert.That(result, Is.EqualTo(5));
            mockRepository.Verify(r => r.IsPremiumUser(1), Times.Once);// перевіряємо, чи був метод IsPremiumUser(1) викликаний рівно один раз 
        }

        [Test]
        public void CalculateDiscount__RepositoryThrowsException_PropagatesException()
        {
            // Arrange
            // Створюємо тестовий об'єкт, який реалізує інтерфейс IUserRepository
            var mockRepository = new Mock<IUserRepository>();

            mockRepository //  якщо хочемо налаштувати, що метод кидає помилку
                .Setup(r => r.IsPremiumUser(1))
                .Throws(new Exception("Some error"));

            // mockRepository.Object - отримання об'єкта для тестування
            // створюємо об'єкт сервісу і передаємо у конструктор наш мок
            var service = new Discount_Service.DiscountService( // конструктор сервісу очікує об'єкт репозиторя, а ми передаємо мок
                mockRepository.Object);

            // Act
            var ex = Assert.Throws<Exception> (() => service.CalculateDiscount(1)); // перевіряємо чи генерувався виняток типу Exception
            Assert.That(ex.Message, Does.Contain("Some err")); // перевірка, що повідомлення винятку містить текст 'Some err'

            mockRepository.Verify(r => r.IsPremiumUser(1), Times.Once);// перевіряємо, чи був метод IsPremiumUser(1) викликаний рівно один раз 

        }
    }
}
/*
Інші можливості Moq

Setup()	Налаштувати поведінку методу
Returns()	Визначити результат
Throws()	Імітувати виняток
Verify()	Перевірити виклик методу
Times.Once	Перевірити один виклик
It.IsAny<int>()	Прийняти будь-яке значення int
  */
