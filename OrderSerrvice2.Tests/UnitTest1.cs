using OrderService_for_Spy;

namespace OrderSerrvice2.Tests
{
    public class Tests
    {
        [Test]
        public void CreateOrder_LogsMessageOnce()
        {
            // Arrange
            var spyLogger = new SpyLogger();
            var service = new OrderService(spyLogger);

            // Act
            service.CreateOrder(); // при створенні замовлення має спрацювати Log () від логера 

            // Assert
            Assert.That(spyLogger.CallCount, Is.EqualTo(1)); // перевірка, що логер працював один раз при створенні замовлення

            Assert.That(
                spyLogger.LastMessage,
                Is.EqualTo("Order created")
            );
            // Після виконання тесту ми можемо перевірити, чи було логування і яке саме повідомлення передавалося.

        }
    }
    // Головна ідея - Spy спостерігає за взаємодією між об'єктами та зберігає інформацію про виклики
}
