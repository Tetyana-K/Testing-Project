using Order_Service;

//Dummy потрібен для заповнення обов'язкового параметра, але не бере участі в логіці тесту.

namespace OrderService.Tests
{
    [TestFixture]
    public class OrderServiceTests // клас із тестами
    {

        [Test]
        public void CalculateTotal_ReturnsCorrectValue()
        {
            // Arrange
            var dummyLogger = new DummyLogger();
            var service = new Order_Service.OrderService(dummyLogger); // Конструктор отримує DummyLogger

            // Act
            var result = service.CalculateTotal(100, 3); // Метод CalculateTotal() не використовує логер

            // Assert
            Assert.That(result, Is.EqualTo(300)); // Ми перевіряємо лише правильність обчислення
        }
    }
    
    // Ми хочемо протестувати метод CalculateTotal().
    // Логування нам не потрібне, але конструктор вимагає об'єкт ILogger

    //Створюємо Dummy клас:
    public class DummyLogger : ILogger // клас, який реалізує інтерфейс ILogger
    {
        public void Log(string message)
        {
            // нічого не робимо
        }
    }

}
