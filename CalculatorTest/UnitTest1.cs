using CalculatorNS;
using System.Diagnostics;
namespace CalculatorTest
{
    [TestFixture]
    public class CalculatorTests
    {

        private Calculator calc; // поле з посиланням на об'єкт класу Калькулятор
        
        [SetUp]
        public void Setup()
        {
            calc = new Calculator(); //  на початку тесту буде створено об'єкт Калькулятора
        }

        [Test]
        public void Add_TwoNumbers_ReturnCorrectSum()
        {
            //calc = new Calculator();

            // pattern AAA =  Arrange Action Assert 
            //  Arrange - готуємо дані для тесту
            int first = 2;
            int second = 3;

            // Action - дія, виклик функціональності, яку тестуємо
            int result = calc.Add(first, second); // фактичний результат
            int expectedResult = first + second;

            // Assert - перевірка
            Assert.That(result, Is.EqualTo(expectedResult)); //  перевірка чи фактичний результат співпадає з очікуваним
            
            //Assert.Pass();
        }

        [Test]
        public void SubTwoNumbers_ReturnCorrectSubtraction()
        {
            Assert.That(calc.Sub(5, 2), Is.EqualTo(3));
        }

        // один тестовий метод може виконуватися з різними наборами вхідних даних
        //  дозволяє перевіряти
        //  - позитивні значення;- негативні значення;- нуль;- граничні значення
        [TestCase(2, 3, 6)]
        [TestCase(10, 5, 50)]
        [TestCase(-2, 1, -2)]
        [TestCase(0, 3, 3)] // невірний набір даних
        public void MultTest(int a, int b, int expected)
        {
            // Arrange + Action
            int result = calc.Mult(a, b);
            
            // Assert
            Assert.That(result, Is.EqualTo(expected), $"Error : Multiply  {a} * {b}");
        }

        // тестові дані для перевірки додавання винесені у окреме джерело
        // приватний метод нижче у класі
       
        [TestCaseSource(nameof(TestData))] // вказуємо джерело для тестових даних
        public void AddTestWithSource(int a, int b, int expected)
        {
            //var calculator = new Calculator();

            //Assert.That(
            //    calculator.Add(a, b),
            //    Is.EqualTo(expected));

            Assert.That(calc.Add(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            //var calculator = new Calculator();

            //Assert.Throws<DivideByZeroException>(
            //    () => calculator.Div(10, 0));

            Assert.Throws<DivideByZeroException>(
                () => calc.Div(10, 0), "Error: expected exception DivideByZeroException");
        }


        [Test]
        //[Ignore("Тимчасово не використовуємо")]
        [Category("Smoke")]
        public void SomeFeatureTest()
        {
            int value = 2;
            Assert.That(value, Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            calc = null!;
        }

        private static IEnumerable<TestCaseData> TestData()
        {
            yield return new TestCaseData(2, 3, 5);
            yield return new TestCaseData(5, 5, 10);
            yield return new TestCaseData(-2, 2, 0);
        }

    }
}
/*
 Основні атрибути NUnit

[Test]	Позначає тестовий метод
[TestFixture]	Позначає тестовий клас
[SetUp]	Виконується перед кожним тестом
[TearDown]	Виконується після кожного тесту
[OneTimeSetUp]	Виконується один раз перед тестами
[OneTimeTearDown]	Виконується один раз після тестів
[TestCase]	Дозволяє передавати різні набори даних
[Ignore]	Пропускає тест
[Category]	Групує тести
 */

/*
 * Assertions використовуються для порівняння фактичного результату з очікуваним.
Assert.That(10, Is.EqualTo(10));

Assert.That(10, Is.Not.EqualTo(5));

Assert.That(10 > 5, Is.True);

Assert.That(10 < 5, Is.False);

Assert.That("Anna", Is.Not.Null);

Assert.That("Anna", Does.Contain("Ann"));

Assert.That(10, Is.GreaterThan(5));

Assert.That(10, Is.LessThan(20));
*/